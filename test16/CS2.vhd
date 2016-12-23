----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date:    04:08:44 12/17/2016 
-- Design Name: 
-- Module Name:    CS - Behavioral 
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

entity CS_Entity is
    Port ( CLK : in STD_LOGIC;
	        CLR_IN  : in  STD_LOGIC;
			  CLR_OUT : out STD_LOGIC;
           FROM_TCL_IN  : in  STD_LOGIC_VECTOR (67 downto 0);
           FROM_VHD_IN  : in  STD_LOGIC_VECTOR (67 downto 0);
           FROM_TCL_OUT : out STD_LOGIC_VECTOR (67 downto 0);
           FROM_VHD_OUT : out STD_LOGIC_VECTOR (67 downto 0));
end CS_Entity;

architecture Behavioral of CS_Entity is
	type data_buf  is array (3 downto 0) of std_logic_vector(67 downto 0); --буфер для эмуляции задержек
	
	signal data_in   : data_buf;
	signal data_out  : data_buf;
begin
	from_tcl_out <= data_in(3);
	from_vhd_out <= data_out(3);
	clr_out <= clr_in;
	
	process (CLK) 
		variable i : integer := 0;
	begin
		if CLK'event and CLK = '1' then
			if CLR_IN = '1' then
				data_in  <= (others => (others => '0'));
				data_out <= (others => (others => '0'));
			else
				for i in 0 to 2 loop
					data_in(i + 1)   <= data_in(i);
					data_out(i + 1)  <= data_out(i);
				end loop;
				data_in(0)   <= from_tcl_in;
				data_out(0)  <= from_vhd_in;
			end if;
		end if;
	end process;
end Behavioral;

