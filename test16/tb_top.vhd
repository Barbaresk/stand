-- Vhdl test bench created from schematic C:\Users\Barbaresk\Documents\xilinx\test16\top.sch - Sat Dec 17 13:28:41 2016
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
ENTITY top_top_sch_tb IS
END top_top_sch_tb;
ARCHITECTURE behavioral OF top_top_sch_tb IS 

   COMPONENT top
   PORT( 
		BUF_IN_CHECK : OUT STD_LOGIC_VECTOR (1 DOWNTO 0); 
		DATA_IN      : IN  STD_LOGIC_VECTOR (67 DOWNTO 0); 
		CHECK_IN     : OUT STD_LOGIC_VECTOR (1 DOWNTO 0); 
      CLK          : IN  STD_LOGIC; 
      CLR          : IN  STD_LOGIC; 
      BUF_IN_DATA  : OUT STD_LOGIC_VECTOR (63 DOWNTO 0); 
      ENABLE       : OUT STD_LOGIC);
   END COMPONENT;

   SIGNAL DATA_IN_Info : STD_LOGIC_VECTOR (67 DOWNTO 4) := (others => '0'); --сигнал, который будет задан в c#
	SIGNAL DATA_IN_Bit  : STD_LOGIC_VECTOR (1 DOWNTO 0):="00";               --01 | 10 | 00
   SIGNAL BUF_IN_CHECK : STD_LOGIC_VECTOR (1 DOWNTO 0);                     --01 | 10 | 11 | 00 c моего буфера, но ещё до cs
   SIGNAL CHECK_IN     : STD_LOGIC_VECTOR (1 DOWNTO 0);                     --тоде самое, после задержек, связанных с cs
   SIGNAL CLK          : STD_LOGIC := '0';
   SIGNAL CLR          : STD_LOGIC := '1';
   SIGNAL BUF_IN_DATA  : STD_LOGIC_VECTOR (63 DOWNTO 0);                    --выходы моего буфера, можно проверить, что всё ок
   SIGNAL ENABLE       : STD_LOGIC;
	constant CLK_T : time := 10 ns;
BEGIN

   UUT: top PORT MAP(
		BUF_IN_CHECK => BUF_IN_CHECK, 
		DATA_IN      => DATA_IN_Info & "00" & DATA_IN_bit, 
		CHECK_IN     => CHECK_IN, 
		CLK          => CLK, 
		CLR          => CLR, 
		BUF_IN_DATA  => BUF_IN_DATA, 
		ENABLE       => ENABLE
   );
	
	CLK <= not CLK after CLK_T / 2;
	--в данном процессе описывается та логика, которая будет в C# или tcl (т.е. выдача информации и проверка 01/10)
	process begin
		clr <= '1';
		wait for clk_t;
		clr <= '0';
		wait for 8 * clk_t;
		
		--выдали из С# на входы cs информацию
		DATA_IN_INFO(67 downto 8) <= (others => '0');
		DATA_IN_INFO(8 downto 4) <= (others => '1');
		--и биты 01 для загрузки
		DATA_IN_Bit <= "01";
		--теперь ожидаем ответ, который будет равен 01
		while CHECK_IN /= "01" loop
			wait for CLK_T;
		end loop;
		--выдали из С# на входы cs новую порцию информации
		DATA_IN_INFO(67 downto 6) <= (others => '0');
		DATA_IN_INFO(6 downto 4) <= (others => '1');
		DATA_IN_Bit <= "10";
		--ожидаем ответ
		while CHECK_IN /= "10" loop
			wait for CLK_T;
		end loop;
		--выдали опять информацию
		DATA_IN_INFO(67 downto 10) <= (others => '0');
		DATA_IN_INFO(10 downto 4) <= (others => '1');
		DATA_IN_Bit <= "01";
		--ожидаем ответ
		while CHECK_IN /= "01" loop
			wait for CLK_T;
		end loop;		
		--посылаем сигнал о завершение
		DATA_IN_Bit <= "00";
		--ожидаем, когда всё завершится
		while CHECK_IN /= "00" loop
			wait for CLK_T;
		end loop;	


		--выдали из С# на входы cs информацию
		DATA_IN_INFO(67 downto 7) <= (others => '0');
		DATA_IN_INFO(7 downto 7) <= (others => '1');
		--и биты 01 для загрузки
		DATA_IN_Bit <= "01";
		--теперь ожидаем ответ, который будет равен 01
		while CHECK_IN /= "01" loop
			wait for CLK_T;
		end loop;
		--выдали из С# на входы cs новую порцию информации
		DATA_IN_INFO(67 downto 8) <= (others => '0');
		DATA_IN_INFO(8 downto 4) <= (others => '1');
		DATA_IN_Bit <= "10";
		--ожидаем ответ
		while CHECK_IN /= "10" loop
			wait for CLK_T;
		end loop;
		--выдали опять информацию
		DATA_IN_INFO(67 downto 9) <= (others => '0');
		DATA_IN_INFO(9 downto 4) <= (others => '1');
		DATA_IN_Bit <= "01";
		--ожидаем ответ
		while CHECK_IN /= "01" loop
			wait for CLK_T;
		end loop;		
		--посылаем сигнал о завершение
		DATA_IN_Bit <= "00";
		
		
		wait for 100 * CLK_T;
	
	end process;
END;
