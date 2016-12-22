----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date:    08:29:14 12/20/2016 
-- Design Name: 
-- Module Name:    item3 - Behavioral 
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

entity item3 is
    Port ( CLK : in  STD_LOGIC;
           CLR : in  STD_LOGIC;
------------------------------------------------------------------
-- Генерируемая часть                                           --
------------------------------------------------------------------
			  D : in  std_logic_vector(3 downto 0);
			  L : in  std_logic;
			  E : in  std_logic;
			  Q : out std_logic_vector(7 downto 0);
			  U : out std_logic_vector(5 downto 0);
------------------------------------------------------------------			  
           DATA_IN  : in   STD_LOGIC_VECTOR (63 downto 0);
           DATA_OUT : out  STD_LOGIC_VECTOR (63 downto 0));
end item3;

architecture Behavioral of item3 is

------------------------------------------------------------------
--Генерируемая часть                                            --
------------------------------------------------------------------
	constant len  : integer := 20;     --суммарная разрядность сигнала
	constant rwc  : integer := 6;      --из них на чтение
	constant name : integer := 8 * 16; --длина имени
	signal   info : std_logic_vector(name - 1 downto 0) := x"ABBAABBACEEEEEECFFFFFFFF22222222"; --имя 16-битные символы UTF
------------------------------------------------------------------
	constant rd   : integer := len - rwc;
	signal value  : std_logic_vector(len - 1 downto 0); --массив для сопоставления
	signal rvalue : std_logic_vector(len - rwc - 1 downto 0);
	type state_type is (
		idle,     --до инициализации 00
		init,     --инициализации    11
		rw,       --чтение/запись    01
		waiting   --ожидание         00
	);

	
	signal cop   : std_logic_vector(1 downto 0);
	signal arg   : std_logic_vector(15 downto 0);
begin
------------------------------------------------------------------
--Генерируемая часть                                            --
------------------------------------------------------------------
	Q <= value(13 downto 6);
	U <= value(19 downto 14);
------------------------------------------------------------------
	
	value(rwc - 1 downto 0) <= E & L & D;
	value(len - 1 downto rwc) <= rvalue;
	cop <= data_in(1 downto 0);
	arg <= data_in(31 downto 16);

	process (CLK)
		variable state  : state_type; --состояния элемента
		variable offset : integer;   
		variable endstr : integer;
		variable offr   : integer;
		variable pos    : integer;
		variable i      : integer;
	begin
		if clk = '1' and clk'event then
			if clr = '1' then
				rvalue <= (others => '0');
				data_out <= (others => '0');

				state  := idle;
				offset := 0;
				endstr := 0;
				pos    := 0;
				i      := 0;
			else
				case state is
					when idle => 
						if cop = "11" then
							offset := conv_integer(unsigned(arg));
							offr   := offset + rwc;
							state  := init;
							endstr := conv_integer(unsigned(data_in(47 downto 32)));
							pos    := 0;
							i      := 0;
							data_out(1 downto 0)   <= "11";
							data_out(31 downto 16) <= arg + len;
							data_out(47 downto 32) <= data_in(47 downto 32) + name;
						end if;
						
					when init =>
						
						data_out <= data_in;
						if pos >= endstr + name then
							state    := waiting;
							data_out <= (others => '0');
						else
							if pos < endstr then
								if pos + 64 > endstr then
									if pos + 64 <= endstr + name then -- pos < endsrt < pos + 64 <= endstr + name
										i := pos + 64 - endstr;
										data_out(63 downto endstr - pos) <= info(i - 1 downto 0);
									else                              -- pos < endstr < endstr + name < pos + 64
										data_out(endstr + name - 1 - pos downto endstr - pos) <= info(name - 1 downto 0);
									end if;
								end if;
							else
								if pos < endstr + name then
									if pos + 64 <= endstr + name then -- endstr <= pos < pos + 64 <= endstr + name
										i := i + 64;
										data_out <= info(i - 1 downto i - 64);
									else                              -- endstr <= pos < endstr + name < pos + 64
										data_out(endstr + name - pos - 1 downto 0) <= info(name - 1 downto i);
									end if;
								end if;
							end if;
							pos := pos + 64;
						end if;
						
					when rw =>
						
						data_out <= data_in;
						if pos >= offset + len then
							state    := waiting;
							data_out <= (others => '0');
						else
							--пишем из схемы в cs
							if pos < offset then
								if pos + 64 > offset then
									if pos + 64 <= offset + rwc then -- pos < offset < pos + 64 <= offset + rw
										i := pos + 64 - offset;
										data_out(63 downto offset - pos) <= value(i - 1 downto 0);
									else                            -- pos < offset < offset + rw < pos + 64
										i := rwc;
										data_out(offset + rwc - 1 - pos downto offset - pos) <= value(rwc - 1 downto 0);
									end if;
								end if;
							else
								if pos < offset + rwc then
									if pos + 64 <= offset + rwc then -- offset <= pos < pos + 64 <= offset + rw
										i := i + 64;
										data_out <= value(i - 1 downto i - 64);
									else                            -- offset <= pos < offset + rw < pos + 64
										data_out(offset + rwc - pos - 1 downto 0) <= value(rwc - 1 downto i);
										i := rwc;
									end if;
								end if;
							end if;
							
							--пишем из cs в схему
							if pos < offr then
								if pos + 64 > offr then
									if pos + 64 <= offr + rd then -- pos < offr < pos + 64 <= offr + rd
										i := pos + 64 - offr;
										rvalue(i - 1 downto 0) <= data_in(63 downto offr - pos);
									else                            -- pos < offr < offr + rd < pos + 64
										rvalue(rd - 1 downto 0) <= data_in(offr + rd - 1 - pos downto offr - pos);
									end if;
								end if;
							else
								if pos < offr + rd then
									if pos + 64 <= offr + rd then -- offr <= pos < pos + 64 <= offr + rd
										i := i + 64;
										rvalue(i - 1 downto i - 64) <= data_in;
									else                            -- offr <= pos < offr + rd < pos + 64
										rvalue(rd - 1 downto i) <= data_in(offr + rd - pos - 1 downto 0);
									end if;
								end if;
							end if;
							
							pos := pos + 64;
						end if;
						
					when waiting =>
						if cop = "01" or cop = "10" then
							state    := rw;
							endstr   := conv_integer(unsigned(data_in(47 downto 32)));
							pos      := 0;
							i        := 0;
							data_out <= data_in;
						end if;
				end case;
			end if;
		end if;
	
	
	end process;

end Behavioral;

