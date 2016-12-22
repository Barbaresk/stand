--------------------------------------------------------------------------------
-- Company: 
-- Engineer:
--
-- Create Date:   17:58:50 12/20/2016
-- Design Name:   
-- Module Name:   C:/Users/Barbaresk/Documents/xilinx/test16/tb_item3.vhd
-- Project Name:  test16
-- Target Device:  
-- Tool versions:  
-- Description:   
-- 
-- VHDL Test Bench Created by ISE for module: item3
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
 
ENTITY tb_item3 IS
END tb_item3;
 
ARCHITECTURE behavior OF tb_item3 IS 
 
    -- Component Declaration for the Unit Under Test (UUT)
 
    COMPONENT item3
    PORT(
         CLK : IN  std_logic;
         CLR : IN  std_logic;
         D : IN  std_logic_vector(3 downto 0);
         L : IN  std_logic;
         E : IN  std_logic;
         Q : OUT  std_logic_vector(7 downto 0);
         U : OUT  std_logic_vector(5 downto 0);
         DATA_IN : IN  std_logic_vector(63 downto 0);
         DATA_OUT : OUT  std_logic_vector(63 downto 0)
        );
    END COMPONENT;
    

   --Inputs
   signal CLK : std_logic := '0';
   signal CLR : std_logic := '0';
   signal D : std_logic_vector(3 downto 0) := "1100";
   signal L : std_logic := '0';
   signal E : std_logic := '1';
   signal DATA_IN : std_logic_vector(63 downto 0) := (others => '0');

 	--Outputs
   signal Q : std_logic_vector(7 downto 0);
   signal U : std_logic_vector(5 downto 0);
   signal DATA_OUT : std_logic_vector(63 downto 0);

   -- Clock period definitions
   constant clk_t : time := 10 ns;
 
BEGIN
 
	-- Instantiate the Unit Under Test (UUT)
   uut: item3 PORT MAP (
          CLK => CLK,
          CLR => CLR,
          D => D,
          L => L,
          E => E,
          Q => Q,
          U => U,
          DATA_IN  => DATA_IN,
          DATA_OUT => DATA_OUT
        );

   -- Clock process definitions
   CLK <= not CLK after clk_t / 2;
	
	process begin
		clr <= '1';
		wait for clk_t;
		clr <= '0';
		wait for clk_t;
		data_in(1 downto 0) <= "11";
		wait for 10 * clk_t;
		data_in <= x"0000001400000001";
		wait for clk_t;
		data_in <= (others => '0');
		data_in(19 downto 0) <= "11001100110011000000";
		wait for clk_t;
		data_in <= (others => '0');
		wait;
	
	end process;

END;
