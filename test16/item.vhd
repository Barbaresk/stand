----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date:    16:51:18 12/18/2016 
-- Design Name: 
-- Module Name:    item - Behavioral 
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

entity item is
    Port ( CLK : in  STD_LOGIC;
           CLR : in  STD_LOGIC;
           DATA_IN : in  STD_LOGIC_VECTOR (63 downto 0);
           DATA_OUT : out  STD_LOGIC_VECTOR (63 downto 0));
end item;

architecture Behavioral of item is
	type state_type is (
		idle,     --до инициализации
		init,     --инициализации 11
		writing,  --загрузка 01
		reading,  --загрузка 10
		waiting   --ожидание
	);
	constant len  : integer := 74;
	constant name : integer := 5 * 16;
	
	signal cop   : std_logic_vector(1 downto 0);
	signal arg   : std_logic_vector(15 downto 0);
	signal value : std_logic_vector(len - 1 downto 0);
	signal info  : std_logic_vector(name - 1 downto 0) := x"FFAABB1100FF1122" & "1100110011001100";
begin

	cop <= data_in(1 downto 0);
	arg <= data_in(31 downto 16);

	process (CLK)
		variable state  : state_type;
		variable offset : integer;
		variable endstr : integer;
		variable pos    : integer;
		variable i      : integer;
	begin
		if clk = '1' and clk'event then
			if clr = '1' then
				value    <= (others => '0');
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
					when writing => null;
					when reading => null;
					when waiting => null;
				end case;
			end if;
		end if;
	
	
	end process;
end Behavioral;

