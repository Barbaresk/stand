----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date:    15:10:23 03/21/2017 
-- Design Name: 
-- Module Name:    CS3 - Behavioral 
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

-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values
--use IEEE.NUMERIC_STD.ALL;

-- Uncomment the following library declaration if instantiating
-- any Xilinx primitives in this code.
--library UNISIM;
--use UNISIM.VComponents.all;

entity CS3 is
    Port ( clk_p : in  STD_LOGIC;
           data_out : in  STD_LOGIC_VECTOR (67 downto 4);
           outbuffer_out : in  STD_LOGIC_VECTOR (1 downto 0);
           inbuffer_out : in  STD_LOGIC_VECTOR (3 downto 2);
           from_tcl : in  STD_LOGIC_VECTOR (71 downto 0);
           clr_out : out  STD_LOGIC;
           data_in : out  STD_LOGIC_VECTOR (67 downto 4);
           outbuffer_in : out  STD_LOGIC_VECTOR (1 downto 0);
           inbuffer_in : out  STD_LOGIC_VECTOR (3 downto 2);
           clk_out : out  STD_LOGIC;
           to_tcl : out  STD_LOGIC_VECTOR (71 downto 0));
end CS3;

architecture Behavioral of CS3 is

begin
	clk_out <= clk_p;
	clr_out <= from_tcl(71) or from_tcl(70) or from_tcl(69) or from_tcl(68);
	data_in <= from_tcl(67 downto 4);
	inbuffer_in <= from_tcl(3 downto 2);
	outbuffer_in <= from_tcl(1 downto 0);
	to_tcl <= "0000" & data_out & inbuffer_out & outbuffer_out;
end Behavioral;

