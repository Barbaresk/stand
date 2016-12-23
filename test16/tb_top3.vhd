-- Vhdl test bench created from schematic C:\Users\Barbaresk\Documents\xilinx\test16\top3.sch - Fri Dec 23 03:24:53 2016
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
ENTITY top3_top3_sch_tb IS
END top3_top3_sch_tb;
ARCHITECTURE behavioral OF top3_top3_sch_tb IS 

   COMPONENT top3
   PORT( TO_TCL	 	:	OUT	STD_LOGIC_VECTOR (67 DOWNTO 0); 
          FROM_TCL	:	IN		STD_LOGIC_VECTOR (67 DOWNTO 0); 
          C		:	IN		STD_LOGIC; 
          CLR	:	IN		STD_LOGIC; 
          T3_L	:	IN		STD_LOGIC; 
          T3_E	:	IN		STD_LOGIC; 
          T3_D	:	IN		STD_LOGIC_VECTOR (3 DOWNTO 0); 
          T3_Q	:	OUT	STD_LOGIC_VECTOR (7 DOWNTO 0); 
          T3_U	:	OUT	STD_LOGIC_VECTOR (5 DOWNTO 0); 
          T4_D	:	IN		STD_LOGIC_VECTOR (20 DOWNTO 0); 
          T4_Q	:	OUT	STD_LOGIC_VECTOR (11 DOWNTO 0); 
          T4_U	:	OUT	STD_LOGIC_VECTOR (52 DOWNTO 0));
   END COMPONENT;

   SIGNAL TO_TCL		:	STD_LOGIC_VECTOR (67 DOWNTO 0);
   SIGNAL FROM_TCL	:	STD_LOGIC_VECTOR (67 DOWNTO 0) := (others => '0');
   SIGNAL C				:	STD_LOGIC := '0';
   SIGNAL CLR			:	STD_LOGIC;
	
	--интерфейс пользователя
   SIGNAL T3_L	:	STD_LOGIC := '0';
   SIGNAL T3_E	:	STD_LOGIC := '1';
   SIGNAL T3_D	:	STD_LOGIC_VECTOR (3 DOWNTO 0)  := "1101";
   SIGNAL T3_Q	:	STD_LOGIC_VECTOR (7 DOWNTO 0);
   SIGNAL T3_U	:	STD_LOGIC_VECTOR (5 DOWNTO 0);
   SIGNAL T4_D	:	STD_LOGIC_VECTOR (20 DOWNTO 0) := '0' & x"ABCDE";
   SIGNAL T4_Q	:	STD_LOGIC_VECTOR (11 DOWNTO 0);
   SIGNAL T4_U	:	STD_LOGIC_VECTOR (52 DOWNTO 0);

	CONSTANT c_t : TIME := 10 ns;
BEGIN

   UUT: top3 PORT MAP(
		TO_TCL => TO_TCL, 
		FROM_TCL => FROM_TCL, 
		C => C, 
		CLR => CLR, 
		T3_L => T3_L, 
		T3_E => T3_E, 
		T3_D => T3_D, 
		T3_Q => T3_Q, 
		T3_U => T3_U, 
		T4_D => T4_D, 
		T4_Q => T4_Q, 
		T4_U => T4_U
   );
	
	c <= not c after c_t / 2;

	process begin
		--сброс
		clr <= '1';
		wait for c_t * 5;
		clr <= '0';
		wait for c_t * 10;
		
		--инициализация старт
		from_tcl(5 downto 4) <= "11"; --Информация - init
		from_tcl(3 downto 2) <= "10"; --начало записи с tcl в схему
		while to_tcl(3 downto 2) /= "10" loop
			wait for c_t;
		end loop;
		from_tcl <= (others => '0');
		wait for c_t;
		
		--инициализаци - ожидаем готовность
		while to_tcl(1 downto 0) = "11" loop
			wait for c_t;
		end loop;
		
		--инициализация -- начинаем чтение имён
		
		
	
	end process;

	
END;
