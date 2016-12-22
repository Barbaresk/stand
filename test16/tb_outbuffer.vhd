--------------------------------------------------------------------------------
-- Company: 
-- Engineer:
--
-- Create Date:   02:37:19 12/22/2016
-- Design Name:   
-- Module Name:   C:/Users/Barbaresk/Documents/xilinx/test16/tb_outbuffer.vhd
-- Project Name:  test16
-- Target Device:  
-- Tool versions:  
-- Description:   
-- 
-- VHDL Test Bench Created by ISE for module: OutBuffer
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
 
ENTITY tb_outbuffer IS
END tb_outbuffer;
 
ARCHITECTURE behavior OF tb_outbuffer IS 
 
    -- Component Declaration for the Unit Under Test (UUT)
 
    COMPONENT OutBuffer
    PORT(
         CLK : IN  std_logic;
         CLR : IN  std_logic;
         STATE_IN : IN  std_logic_vector(1 downto 0);
         DATA_OUT : OUT  std_logic_vector(67 downto 0);
         DATA_IN : IN  std_logic_vector(63 downto 0)
        );
    END COMPONENT;
    

   --Inputs
   signal CLK : std_logic := '0';
   signal CLR : std_logic := '0';
   signal STATE_IN : std_logic_vector(1 downto 0) := (others => '0');
   signal DATA_IN : std_logic_vector(63 downto 0) := (others => '0');

 	--Outputs
   signal DATA_OUT : std_logic_vector(67 downto 0);

   -- Clock period definitions
   constant CLK_T : time := 10 ns;
 
BEGIN
 
	-- Instantiate the Unit Under Test (UUT)
   uut: OutBuffer PORT MAP (
          CLK => CLK,
          CLR => CLR,
          STATE_IN => STATE_IN,
          DATA_OUT => DATA_OUT,
          DATA_IN => DATA_IN
        );

   -- Clock process definitions
	CLK <= not CLK after CLK_T / 2;

	process begin
		clr <= '1';
		wait for clk_t;
		clr <= '0';
		wait for clk_t;
		data_in <= (others => '0');
		data_in(1 downto 0) <= "11"; --инициализация в 128 бит
		data_in(47 downto 32) <= "0000000010000000"; 
		wait for clk_t;
		data_in <= x"FFEEDDCCBBAA0011";
		wait for clk_t;
		data_in <= x"1010101010101010";
		wait for clk_t;
		data_in <= x"1AAAAAAAAAAAAAA1";
		wait for clk_t;
		data_in <= (others => '0');
		wait for 10 * clk_t;
		
		data_in(47 downto 32) <= "0000000011000000"; --просто инфа
		data_in(1 downto 0) <= "10";
		wait for clk_t;
		data_in <= x"0123456789abcdef";
		wait for clk_t;
		data_in <= x"0000111223ffffff";
		wait for clk_t;
		data_in <= x"1111000011100000";
		wait for clk_t;
		data_in <= (others => '0');
		wait for 10 * clk_t;
		
		--ещё инфа, должна перетереть предыдущую          --параллельно с этим начинаем общение со вторым процессом
		data_in(47 downto 32) <= "0000000011000000"; 
		data_in(1 downto 0) <= "10";                         state_in <= "10";
		wait for clk_t;----------------------------------------------------------------------
		data_in <= x"1010101010101010";
		wait for clk_t;----------------------------------------------------------------------
		data_in <= x"AAAAAAAABBBBBBBB";                      state_in <= "01";
		wait for clk_t;----------------------------------------------------------------------
		data_in <= x"00000000000BBBBB";                      state_in <= "10";
		wait for clk_t;----------------------------------------------------------------------
		data_in <= (others => '0');                          state_in <= "01";
		wait for clk_t;----------------------------------------------------------------------
		                                                     state_in <= "00";
		wait for 5 * clk_t;------------------------------------------------------------------
		
		                                                   --просто считываем инфу с помощью cs
																			  state_in <= "01";
		                                                     wait for 3 * clk_t;
																			  state_in <= "10";
																			  wait for 3 * clk_t;
																			  state_in <= "01";
																			  wait for 3 * clk_t;
																			  state_in <= "00";
																			  
		
		
				
		
		wait for clk_t * 100;
	end process;

END;
