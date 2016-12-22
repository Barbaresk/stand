--------------------------------------------------------------------------------
-- Company: 
-- Engineer:
--
-- Create Date:   22:47:37 12/19/2016
-- Design Name:   
-- Module Name:   C:/Users/Barbaresk/Documents/xilinx/test16/tb_item.vhd
-- Project Name:  test16
-- Target Device:  
-- Tool versions:  
-- Description:   
-- 
-- VHDL Test Bench Created by ISE for module: item
-- 
-- Dependencies:
-- 
-- Revision:
-- Revision 0.01 - File Created
-- Additional Comments:
--
-- Notes: 
-- This testbench has been automatically generated using types std_logic and
-- std_logic_vector for the ports of the unit under test.  Xilinx recommends
-- that these types always be used for the top-level I/O of a design in order
-- to guarantee that the testbench will bind correctly to the post-implementation 
-- simulation model.
--------------------------------------------------------------------------------
LIBRARY ieee;
USE ieee.std_logic_1164.ALL;
 
-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values
--USE ieee.numeric_std.ALL;
 
ENTITY tb_item IS
END tb_item;
 
ARCHITECTURE behavior OF tb_item IS 
 
    -- Component Declaration for the Unit Under Test (UUT)
 
    COMPONENT item
    PORT(
         CLK : IN  std_logic;
         CLR : IN  std_logic;
         DATA_IN : IN  std_logic_vector(63 downto 0);
         DATA_OUT : OUT  std_logic_vector(63 downto 0)
        );
    END COMPONENT;
    

   --Inputs
   signal CLK : std_logic := '0';
   signal CLR : std_logic := '0';
   signal DATA_IN : std_logic_vector(63 downto 0) := (others => '0');

 	--Outputs
   signal DATA_OUT : std_logic_vector(63 downto 0);

   -- Clock period definitions
   constant CLK_period : time := 10 ns;
 
BEGIN
 
	-- Instantiate the Unit Under Test (UUT)
   uut: item PORT MAP (
          CLK => CLK,
          CLR => CLR,
          DATA_IN => DATA_IN,
          DATA_OUT => DATA_OUT
        );

   -- Clock process definitions
   clk <= not clk after clk_period;
	
	process begin
		clr <= '1';
		wait for clk_period;
		clr <= '0';
		wait for clk_period;
		data_in(63 downto 2) <= (others => '0');
		data_in(1 downto 0) <= "11";
		wait for 10 * clk_period;
	end process;

END;
