--------------------------------------------------------------------------------
-- Company: 
-- Engineer:
--
-- Create Date:   18:25:19 12/15/2016
-- Design Name:   
-- Module Name:   C:/Users/Barbaresk/Documents/xilinx/test16/tb_inbuffer.vhd
-- Project Name:  test16
-- Target Device:  
-- Tool versions:  
-- Description:   
-- 
-- VHDL Test Bench Created by ISE for module: InBuffer
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
 
ENTITY tb_inbuffer IS
END tb_inbuffer;
 
ARCHITECTURE behavior OF tb_inbuffer IS 
 
    -- Component Declaration for the Unit Under Test (UUT)
 
    COMPONENT InBuffer
    PORT(
         CLK       : in  std_logic;
			CLR       : in  std_logic;
			ENABLE    : out std_logic;
         DATA_IN   : in  std_logic_vector(67 downto 0);
         STATE_OUT : out std_logic_vector(1  downto 0);
         DATA_OUT  : out std_logic_vector(63 downto 0)
        );
    END COMPONENT;
    

   --Inputs
   signal CLK       : std_logic := '0';
	signal CLR       : std_logic := '1';
   signal DATA_IN   : std_logic_vector(67 downto 4) := (others => '0');
	signal STATE_IN  : std_logic_vector(1 downto 0)  := "00";
   signal STATE_OUT : std_logic_vector(1 downto 0)  := (others => '0');
   signal DATA_OUT  : std_logic_vector(63 downto 0) := (others => '0');
	signal ENABLE    : std_logic;

   -- Clock period definitions
   constant CLK_T : time := 100 ns;
 
BEGIN
 
	-- Instantiate the Unit Under Test (UUT)
   uut: InBuffer PORT MAP (
          CLK                  => CLK,
			 CLR                  => CLR,
			 ENABLE               => ENABLE,
          DATA_IN(67 downto 4) => DATA_IN,
			 DATA_IN(3  downto 2) => "00",
          DATA_IN(1  downto 0) => STATE_IN,
			 STATE_OUT            => STATE_OUT,
          DATA_OUT             => DATA_OUT
        );

   -- Clock process definitions
	CLK <= not CLK after CLK_T / 2;
	
	process begin
		CLR <= '1';
		wait for CLK_T;
		CLR <= '0';
		
		DATA_IN(67 downto 59) <= "000011101";
		DATA_IN(58 downto 4)  <= (others => '0');
		STATE_IN              <= "01";
		wait for 2 * CLK_T;
		DATA_IN(67 downto 30) <= (others => '0');
		DATA_IN(29 downto 4)  <= (others => '1');
		STATE_IN              <= "10";
		wait for 2 * CLK_T;
		DATA_IN(67 downto 62) <= (others => '0'); 
		DATA_IN(61 downto 12) <= (others => '1');
		DATA_IN(11 downto 4)  <= (others => '0');
		STATE_IN              <= "01";
		wait for 2 * CLK_T;
		STATE_IN              <= (others => '0');
		wait for 20 * CLK_T;
		
		DATA_IN(67 downto 59) <= "010110001";
		DATA_IN(58 downto 4)  <= (others => '0');
		STATE_IN              <= "01";
		wait for 2 * CLK_T;
		DATA_IN(67 downto 20) <= (others => '0');
		DATA_IN(19 downto 4)  <= (others => '1');
		STATE_IN              <= "10";
		wait for 2 * CLK_T;
		DATA_IN(67 downto 62) <= "001111"; 
		DATA_IN(61 downto 12) <= (others => '1');
		DATA_IN(11 downto 4)  <= (others => '0');
		STATE_IN              <= "01";
		wait for 2 * CLK_T;
		STATE_IN              <= (others => '0');
		wait for 20 * CLK_T;
	end process;
END;
