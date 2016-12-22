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

entity CS is
    Port ( CLK : in STD_LOGIC;
	        CLR : in STD_LOGIC;
           DATA_IN_I   : in  STD_LOGIC_VECTOR (67 downto 0);
           CHECK_IN_I  : in  STD_LOGIC_VECTOR (1 downto 0);
           DATA_OUT_I  : in  STD_LOGIC_VECTOR (67 downto 0);
           CHECK_OUT_I : in  STD_LOGIC_VECTOR (1 downto 0);
			  
           DATA_IN_O   : out STD_LOGIC_VECTOR (67 downto 0);
	        CHECK_IN_O  : out STD_LOGIC_VECTOR (1 downto 0);
			  DATA_OUT_O  : out STD_LOGIC_VECTOR (67 downto 0);
           CHECK_OUT_O : out STD_LOGIC_VECTOR (1 downto 0));
end CS;

architecture Behavioral of CS is
	type data_buf  is array (3 downto 0) of std_logic_vector(67 downto 0); --буфер для эмуляции задержек
	type check_buf is array (3 downto 0) of std_logic_vector(1  downto 0);
	signal data_in   : data_buf;
	signal data_out  : data_buf;
	signal check_in  : check_buf;
	signal check_out : check_buf;
begin
	data_in_o   <= data_in(3);
	data_out_o  <= data_out(3);
	check_in_o  <= check_in(3);
	check_out_o <= check_out(3);

	process (CLK) 
		variable i : integer := 0;
	begin
		if CLK'event and CLK = '1' then
			if CLR = '1' then
				for i in 0 to 3 loop
					data_in(i)   <= (others => '0');
					data_out(i)  <= (others => '0');
					check_in(i)  <= (others => '0');
					check_out(i) <= (others => '0');
				end loop;
			else
				for i in 0 to 2 loop
					data_in(i + 1)   <= data_in(i);
					data_out(i + 1)  <= data_out(i);
					check_in(i + 1)  <= check_in(i);
					check_out(i + 1) <= check_out(i);
				end loop;
				data_in(0)   <= data_in_i;
				data_out(0)  <= data_out_i;
				check_in(0)  <= check_in_i;
				check_out(0) <= check_out_i;
			end if;
		end if;
	end process;
end Behavioral;

