----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date:    15:01:05 12/15/2016 
-- Design Name: 
-- Module Name:    InBuffer - Behavioral 
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

entity InBuffer is
    Port ( CLK       : in  STD_LOGIC;
	        CLR       : in  STD_LOGIC;
			  ENABLE    : out STD_LOGIC;
           DATA_IN   : in  STD_LOGIC_VECTOR (67 downto 0);
           STATE_OUT : out STD_LOGIC_VECTOR (1 downto 0);
           DATA_OUT  : out STD_LOGIC_VECTOR (63 downto 0));
end InBuffer;

architecture Behavioral of InBuffer is
--��������� ������
	type state_type is (
		free,   --��������
		load1,  --�������� 01
		load2,  --�������� 10
		unload  --�������� � ����
	);	
	type matrix is array (10 downto 0) of std_logic_vector(63 downto 0); --������ ��� ����������� ����, ��� ������
	signal reg : matrix;
	signal state_in : std_logic_vector (1 downto 0);                  --��� �������������� ����
begin
	state_in <= data_in(1 downto 0);
	
	process (CLK) 
		variable state : state_type := free;
		variable depth : integer := 0;
		variable i     : integer := 0;
		variable j     : integer := 0;
	begin
		
		if CLK = '1' and CLK'event then
			if CLR = '1' then
				state := free;
				depth := 0;
				i := 0;
				state_out <= "00";
				data_out <= (others => '0');
				enable <= '0';
				for j in 0 to 10 loop
					reg(j) <= (others => '0');
				end loop;
			else
				case state is
					when free => 
						case state_in is
							when "01" =>
								state := load1;
								reg(depth) <= data_in(67 downto 4);
								depth := depth + 1;
							when "10" =>
								state := load2;
								reg(depth) <= data_in(67 downto 4);
								depth := depth + 1;
							when others => null;	
						end case;
					when load1 =>
						case state_in is
							when "00" =>
								state := unload;
								data_out <= (others => '0');
							when "10" =>
								state := load2;
								reg(depth) <= data_in(67 downto 4);
								depth := depth + 1;
							when others => null;
						end case;				
					when load2 =>
						case state_in is
							when "00" =>
								state := unload;
								data_out <= (others => '0');
							when "01" =>
								state := load1;
								reg(depth) <= data_in(67 downto 4);
								depth := depth + 1;
							when others => null;
						end case;				
					when unload =>
						if i /= depth then
							data_out <= reg(i);
							reg(i) <= (others => '0');
							i := i + 1;
							enable <= '1';
						else
							state := free;
							i := 0;
							depth := 0;
							data_out <= (others => '0');
							enable <= '0';
						end if;
				end case;
			
				case state is
					when free => state_out <= "00";
					when load1 => state_out <= "01";
					when load2 => state_out <= "10";
					when unload => state_out <= "11";
				end case;
			end if;
		end if;
	end process;


end Behavioral;

