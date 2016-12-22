-- Vhdl test bench created from schematic C:\Users\Barbaresk\Documents\xilinx\test16\top2.sch - Tue Dec 20 01:22:39 2016
--
-- Notes: 
-- 1) This testbench template has been automatically generated using types
-- std_logic and std_logic_vector for the ports of the unit under test.
-- Xilinx recommends that these types always be used for the top-level
-- I/O of a design in order to guarantee that the testbench will bind
-- correctly to the timing (post-route) simulation model.
-- 2) To use this template as your testbench, change the filename to any
-- name of your choice with the extension .vhd, and use the "Source->Add"
-- menu in Project Navigator to import the testbench. Then
-- edit the user defined section below, adding code to generate the 
-- stimulus for your design.
--
LIBRARY ieee;
USE ieee.std_logic_1164.ALL;
USE ieee.numeric_std.ALL;
LIBRARY UNISIM;
USE UNISIM.Vcomponents.ALL;
ENTITY top2_top2_sch_tb IS
END top2_top2_sch_tb;
ARCHITECTURE behavioral OF top2_top2_sch_tb IS 

   COMPONENT top2
   PORT( BUF_IN_CHECK : OUT STD_LOGIC_VECTOR (1 DOWNTO 0); 
          DATA_IN     : IN  STD_LOGIC_VECTOR (67 DOWNTO 0); 
          CHECK_IN    : OUT STD_LOGIC_VECTOR (1 DOWNTO 0); 
          CLK         : IN  STD_LOGIC; 
          CLR         : IN  STD_LOGIC; 
          BUF_IN_DATA : OUT STD_LOGIC_VECTOR (63 DOWNTO 0); 
			 DO1         : OUT STD_LOGIC_VECTOR (63 DOWNTO 0);
			 DO2         : OUT STD_LOGIC_VECTOR (63 DOWNTO 0);
          ENABLE      : OUT STD_LOGIC);
   END COMPONENT;

   SIGNAL BUF_IN_CHECK : STD_LOGIC_VECTOR (1 DOWNTO 0);
   SIGNAL DATA_IN      : STD_LOGIC_VECTOR (67 DOWNTO 0) := (others => '0');
   SIGNAL CHECK_IN     : STD_LOGIC_VECTOR (1 DOWNTO 0);
   SIGNAL CLK          : STD_LOGIC := '0';
   SIGNAL CLR          : STD_LOGIC;
   SIGNAL BUF_IN_DATA  : STD_LOGIC_VECTOR (63 DOWNTO 0);
   SIGNAL ENABLE       : STD_LOGIC;
	SIGNAL DO1          : STD_LOGIC_VECTOR (63 DOWNTO 0);
	SIGNAL DO2          : STD_LOGIC_VECTOR (63 DOWNTO 0);
	CONSTANT CLK_T : TIME := 10 ns;
BEGIN

   UUT: top2 PORT MAP(
		BUF_IN_CHECK => BUF_IN_CHECK, 
		DATA_IN => DATA_IN, 
		CHECK_IN => CHECK_IN, 
		CLK => CLK, 
		CLR => CLR, 
		BUF_IN_DATA => BUF_IN_DATA, 
		ENABLE => ENABLE,
		DO1 => DO1,
		DO2 => DO2
   );
	
	CLK <= not CLK after CLK_T / 2;
	
	process begin
		clr <= '1';
		wait for clk_t;
		clr <= '0';
		wait for clk_t;
		data_in(5 downto 0) <= "110010";
		data_in(67 downto 6) <= (others => '0');
		while check_in /= "10" loop
			wait for clk_t;
		end loop;
		data_in <= (others => '0');
		wait for 20 * clk_t;
	end process;
	
END;
