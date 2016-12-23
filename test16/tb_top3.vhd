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
	
	--интерфейс пользовател€
   SIGNAL T3_L	:	STD_LOGIC := '0';
   SIGNAL T3_E	:	STD_LOGIC := '1';
   SIGNAL T3_D	:	STD_LOGIC_VECTOR (3 DOWNTO 0)  := "1101";
   SIGNAL T3_Q	:	STD_LOGIC_VECTOR (7 DOWNTO 0);
   SIGNAL T3_U	:	STD_LOGIC_VECTOR (5 DOWNTO 0);
   SIGNAL T4_D	:	STD_LOGIC_VECTOR (20 DOWNTO 0) := '0' & x"ABCDE";
   SIGNAL T4_Q	:	STD_LOGIC_VECTOR (11 DOWNTO 0);
   SIGNAL T4_U	:	STD_LOGIC_VECTOR (52 DOWNTO 0);

	constant buf_sz : integer := 5;
	type matrix is array (buf_sz downto 0) of std_logic_vector(63 downto 0); --пам€ть дл€ запоминани€ того, что пришло
	signal tcl_buf  : matrix;
	signal i : integer;

	signal len : std_logic_vector(47 downto 32);

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
		i <= 0;
		tcl_buf <= (others => (others => '0'));
		clr <= '1';
		wait for c_t * 5;
		clr <= '0';
		wait for c_t * 10;
		
		--инициализаци€ старт
		from_tcl(5 downto 4) <= "11"; --»нформаци€ - init
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
		
		--инициализаци€ -- начинаем чтение имЄн
		i <= 0;
		from_tcl(1 downto 0) <= "10";
		while to_tcl(1 downto 0) /= "10" loop
			wait for c_t;
		end loop;
		
		tcl_buf(i) <= to_tcl(67 downto 4);
		i <= i + 1;
		len <= to_tcl(47 downto 32); --запомили число разр€дов
		
		while to_tcl(1 downto 0) /= "00" loop
			
			from_tcl(1 downto 0) <= "01";
			while to_tcl(1 downto 0) /= "01" and to_tcl(1 downto 0) /= "00" loop --ждЄм 01
				wait for c_t;
			end loop;
			
			exit when to_tcl(1 downto 0) = "00";
			
			tcl_buf(i) <= to_tcl(67 downto 4);
			i <= i + 1;
			
			from_tcl(1 downto 0) <= "10";
			while to_tcl(1 downto 0) /= "10" and to_tcl(1 downto 0) /= "00" loop --ждЄм 10
				wait for c_t;
			end loop;
			
			exit when to_tcl(1 downto 0) = "00"; --закончили цикл, если встретили 00
			
			tcl_buf(i) <= to_tcl(67 downto 4);
			i <= i + 1;
			
		end loop;
			
		from_tcl(1 downto 0) <= "00";
		while to_tcl(1 downto 0) /= "00" loop
			wait for c_t;
		end loop;
		--конец чтени€ имЄн
		

		--запускаем операцию записи (перва€ операци€, котора€ об€зательно должна быть после инициализации)
		from_tcl <= (others => '0');
		from_tcl(47 downto 32) <= len;
		from_tcl(5 downto 4) <= "01";  --сигнал об операции чтени€ (задаЄтс€ мной из программы)
		from_tcl(3 downto 2) <= "01";
		
		while to_tcl(3 downto 2) /= "01" loop
			wait for c_t;
		end loop;
		
		from_tcl <= (others => '0');
		from_tcl(3 downto 2) <= "10";
		from_tcl(9 downto 4) <= (others => '0');    --эти будут заполн€тьс€ из item3  : E & L & D
		from_tcl(17 downto 10) <= (others => '1');  --эти будут устанавливать в item3 : Q
		from_tcl(23 downto 18) <= "101010";         --эти будут устанавливать в item3 : U
		from_tcl(44 downto 24) <= (others => '0');  --эти будут заполн€тьс€ из item4  : D
		from_tcl(56 downto 45) <= "110011001100";   --эти будут устанавливать в item4 : Q
		from_tcl(67 downto 57) <= (others => '1');  --эти будут устанавливать в item4 : U (младшие)
		
		while to_tcl(3 downto 2) /= "10" loop
			wait for c_t;
		end loop;
		
		from_tcl <= (others => '0');
		from_tcl(3 downto 2) <= "01";
		from_tcl(44 downto 4) <= (others => '1');   --эти будут устанавливать в item4 : U (старшие, кроме самого старшего, который останетс€ в 0)
		
		while to_tcl(3 downto 2) /= "01" loop
			wait for c_t;
		end loop;
		
		from_tcl <= (others => '0'); 
		
		while to_tcl(3 downto 2) /= "00" loop
			wait for c_t;
		end loop;
		
		--закончили запись
		
		wait for 5 * c_t;
		
		--читаем информацию
		tcl_buf <= (others => (others => '0'));
		i <= 0;
		from_tcl(1 downto 0) <= "10";
		while to_tcl(1 downto 0) /= "10" loop
			wait for c_t;
		end loop;
		
		tcl_buf(i) <= to_tcl(67 downto 4);
		i <= i + 1;
		
		while to_tcl(1 downto 0) /= "00" loop
			
			from_tcl(1 downto 0) <= "01";
			while to_tcl(1 downto 0) /= "01" and to_tcl(1 downto 0) /= "00" loop --ждЄм 01
				wait for c_t;
			end loop;
			
			exit when to_tcl(1 downto 0) = "00";
			
			tcl_buf(i) <= to_tcl(67 downto 4);
			i <= i + 1;
			
			from_tcl(1 downto 0) <= "10";
			while to_tcl(1 downto 0) /= "10" and to_tcl(1 downto 0) /= "00" loop --ждЄм 10
				wait for c_t;
			end loop;
			
			exit when to_tcl(1 downto 0) = "00"; --закончили цикл, если встретили 00
			
			tcl_buf(i) <= to_tcl(67 downto 4);
			i <= i + 1;
			
		end loop;
			
		from_tcl(1 downto 0) <= "00";
		while to_tcl(1 downto 0) /= "00" loop
			wait for c_t;
		end loop;
		
		
		
	
				
	
	end process;

	
END;
