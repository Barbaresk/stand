----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date:    15:21:00 03/21/2017 
-- Design Name: 
-- Module Name:    add10 - Behavioral 
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

entity add10 is
    Port ( a : in  STD_LOGIC_VECTOR (3 downto 0);
           b : in  STD_LOGIC_VECTOR (3 downto 0);
           p1 : out  STD_LOGIC_VECTOR (3 downto 0);
           p2 : out  STD_LOGIC_VECTOR (3 downto 0));
end add10;

architecture Behavioral of add10 is

begin
	process (a, b) begin
		if a + b > x"A" then
			p1 <= x"1";
			p2 <= a + b - 10;
		else
			p1 <= x"0";
			p2 <= a + b;
		end if;
	end process;

end Behavioral;

