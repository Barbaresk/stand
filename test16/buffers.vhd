----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date:    17:13:05 03/14/2017 
-- Design Name: 
-- Module Name:    buffers - Behavioral 
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

entity buffers is
    Port ( data_in : in  STD_LOGIC_VECTOR (63 downto 0);
           data_out : out  STD_LOGIC_VECTOR (63 downto 0);
           from_tcl : in  STD_LOGIC_VECTOR (63 downto 0);
           to_tcl : out  STD_LOGIC_VECTOR (63 downto 0);
           out_buffer_in : in  STD_LOGIC_VECTOR (1 downto 0);
           out_buffer_out : out  STD_LOGIC_VECTOR (1 downto 0);
           in_buffer_in : in  STD_LOGIC_VECTOR (1 downto 0);
           in_buffer_out : out  STD_LOGIC_VECTOR (1 downto 0);
           clk : in  STD_LOGIC;
           clr : in  STD_LOGIC);
end buffers;

architecture Behavioral of buffers is
	component InBuffer_Entity
		port(
			clk       : in  std_logic;
			clr       : in  std_logic;
			state_in  : in  std_logic_vector (1  downto 0);
			data_in   : in  std_logic_vector (63 downto 0);
			state_out : out std_logic_vector (1  downto 0);
			data_out  : out std_logic_vector (63 downto 0)
		);
	end component;
	
	component OutBuffer_Entity
		port(
			clk       : in  std_logic;
			clr       : in  std_logic;
			state_out : out std_logic_vector(1  downto 0);
			data_out  : out std_logic_vector(63 downto 0);
			state_in  : in  std_logic_vector(1  downto 0);
			data_in   : in  std_logic_vector(63 downto 0)
		);
	end component;
begin
	inb : InBuffer_Entity port map(
		clk => clk,
		clr => clr,
		state_in => in_buffer_in,
		data_in => from_tcl,
		state_out => in_buffer_out,
		data_out => data_out
	);
	
	onb : OutBuffer_Entity port map(
		clk => clk,
		clr => clr,
		state_out => out_buffer_out,
		data_out => to_tcl,
		state_in => out_buffer_in,
		data_in => data_in
	);
		

end Behavioral;

