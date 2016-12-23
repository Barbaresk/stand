----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date:    14:19:47 12/18/2016 
-- Design Name: 
-- Module Name:    OutBuffer - Behavioral 
-- Project Name: 
-- Target Devices: 
-- Tool versions: 
-- Description: 
--
-- Dependencies: 
--
-- Revision: 
-- Revision 0.01 - File Created
-- Additional Comments: 
--
----------------------------------------------------------------------------------
library IEEE;
use IEEE.STD_LOGIC_1164.ALL;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;

-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values
--use IEEE.NUMERIC_STD.ALL;

-- Uncomment the following library declaration if instantiating
-- any Xilinx primitives in this code.
--library UNISIM;
--use UNISIM.VComponents.all;

entity OutBuffer_Entity is
    Port ( CLK       : in  STD_LOGIC;
           CLR       : in  STD_LOGIC;
			  STATE_OUT : out STD_LOGIC_VECTOR (1 downto 0);
           DATA_OUT  : out STD_LOGIC_VECTOR (63 downto 0);
			  STATE_IN  : in  STD_LOGIC_VECTOR (1 downto 0);
           DATA_IN   : in  STD_LOGIC_VECTOR (63 downto 0));
end OutBuffer_Entity;

architecture Behavioral of OutBuffer_Entity is
	constant buf_sz : integer := 5;
	type matrix is array (buf_sz downto 0) of std_logic_vector(63 downto 0); --память для запоминания того, что пришло
	signal bufin  : matrix;
	
	signal bufout : matrix;

	type state_type is (
		idle,     --до инициализации 00
		init,     --инициализации    11
		rw,       --чтение/запись    01
		waiting  --ожидание         00
	);

	
	signal len_bits : std_logic_vector(47 downto 32);
	signal cop      : std_logic_vector(1 downto 0);
	signal getting  : boolean;
	signal bufdepth : integer;
begin

	len_bits <= data_in(47 downto 32);
	cop <= data_in(1 downto 0);
	
	--процесс чтения из схемы
	process (CLK)
		variable state_i: state_type;
		variable len   : integer;
		variable i     : integer;
		variable depth : integer;
	begin
		if clk = '1' then
			if clr = '1' then
				state_i := idle;
				depth := 0;
				i     := 0;
				len   := 0;
				bufdepth <= 0;
				bufin <= (others => (others => '0'));
			else
				case state_i is
					when idle =>         --самое стартовое состояние
						if cop = "11" then
							len := conv_integer(unsigned(len_bits));
							state_i := init;
							i := 0;
							depth := 0;
							bufdepth <= 0;
						end if;
							
					when init =>         --инициализация
						if i < len then   --ещё идёт
							bufin(depth) <= data_in;
							i := i + 64;
							depth := depth + 1;
						else
							bufdepth <= depth;
						end if;
						
						if getting then   --если получено, то переходим в состояние ожидания
							state_i := waiting;
							depth := 0;
							bufdepth <= 0;
						end if;
						
					when rw =>            --состояние записи в буфер
						if i < len then
							bufin(depth) <= data_in;
							i := i + 64;
							depth := depth + 1;
						else
							bufdepth <= depth;
							depth := 0;
							state_i := waiting;
						end if;
					
					when waiting =>      
						if cop = "01" or cop = "10" then
							bufin <= (others => (others => '0'));
							len := conv_integer(unsigned(len_bits));
							i := 0;
							state_i := rw;
						end if;						
				end case;
			end if;
		end if;
	end process;
	
	--процесс записи на cs --то, что будет общаться со скриптом Влада!
	process (CLK)
		type state_type_out is (
			idle,    --старт
			init,    --ожидание полной инициализации
			waiting, --свободно, ожидает нового сеанса записи
			waitoff, --все значения были переданы на cs, но до сих пор не был получен сигнал 00 - о том, что cs понял, что запись закончилась
			load1,   --загрузка 01
			load2    --загрузка 10
		);
		variable state_o : state_type_out;
		variable i : integer;
		variable depth : integer;
	begin
		if CLK = '1' then
			if clr = '1' then
				getting <= false;
				data_out <= (others => '0');
				state_o := idle;
				state_out <= "11";
				i := 0;
				bufout <= (others => (others => '0'));
			else
				case state_o is
					when idle =>  --самый старт, ожидаем, когда проинициализируется буфер
						state_out <= "11";
						if bufdepth /= 0 then
							for i in 0 to bufdepth loop
								bufout(i) <= bufin(i);
							end loop;
							depth := bufdepth;
							state_o := init;
							state_out <= "00";
							getting <= true;
						end if;
						
					when init =>  --инициализация, лжидаем, когда начнётся чтение
						i := 0;
						case state_in is
							when "01" =>
								state_o := load1;
								state_out <= "01";
								data_out <= bufout(i);
								i := i + 1;
							when "10" =>
								state_o := load2;
								state_out <= "10";
								data_out <= bufout(i);
								i := i + 1;
							when others => null;	
						end case;
					
					when load1 =>  --выгрузка 01
						if state_in = "10" then
							if i >= depth then
								state_o := waitoff;
								state_out <= "00";
								data_out <= (others => '0');
								i := 0;
							else
								state_o := load2;
								state_out <= "10";
								data_out <= bufout(i);
								i := i + 1;
							end if;
						end if;
						
					when load2 =>  --выгрузка 10
						if state_in = "01" then
							if i >= depth then
								state_o := waitoff;
								state_out <= "00";
								data_out <= (others => '0');
								i := 0;
							else
								state_o := load1;
								state_out <= "01";
								data_out <= bufout(i);
								i := i + 1;
							end if;
						end if;
						
					when waitoff =>  --ожидание 00 от cs
						bufout <= bufin;
						if state_in = "00" then
							state_o := waiting;
						end if;
					
					when waiting =>  --ожидание начала выгрузки
						bufout <= bufin;
						i := 0;
						case state_in is
							when "01" => 
								state_o := load1;
								state_out <= "01";
								data_out <= bufout(i);
								i := i + 1;
							when "10" =>
								state_o := load2;
								state_out <= "10";
								data_out <= bufout(i);
								i := i + 1;
							when others => null;
						end case;
				end case;
			end if;
		end if;
	end process;
	
end Behavioral;

