-- Vhdl test bench created from schematic C:\Users\Barbaresk\Documents\Visual Studio 2015\Projects\Stand\test16\top5.sch - Mon Feb 27 11:49:10 2017
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
ENTITY top5_top5_sch_tb IS
END top5_top5_sch_tb;
ARCHITECTURE behavioral OF top5_top5_sch_tb IS 

   COMPONENT top5
   PORT( TO_TCL	:	OUT	STD_LOGIC_VECTOR (67 DOWNTO 0); 
          FROM_TCL	:	IN	STD_LOGIC_VECTOR (67 DOWNTO 0);
			state_buffer_in : out std_logic_vector (2 downto 0);
			state_buffer_out : out std_logic_vector (2 downto 0);
          MEAN : out std_logic_vector (3 downto 0);
			 C	:	IN	STD_LOGIC; 
          CLR	:	IN	STD_LOGIC);
   END COMPONENT;

   SIGNAL TO_TCL	:	STD_LOGIC_VECTOR (67 DOWNTO 0);
   SIGNAL FROM_TCL	:	STD_LOGIC_VECTOR (67 DOWNTO 0) := (others => '0');
   SIGNAL C	:	STD_LOGIC := '0';
   SIGNAL CLR	:	STD_LOGIC := '0';
	signal state_buffer_in : std_logic_vector (2 downto 0);
	signal state_buffer_out : std_logic_vector (2 downto 0);
	signal mean : std_logic_vector (3 downto 0);

	CONSTANT c_t : TIME := 10 ns;
	
		constant buf_sz : integer := 5;
	type matrix is array (buf_sz downto 0) of std_logic_vector(63 downto 0); --память для запоминания того, что пришло
	signal tcl_buf  : matrix;
	signal i : integer;

	signal len : std_logic_vector(47 downto 32);

BEGIN

   UUT: top5 PORT MAP(
		TO_TCL => TO_TCL, 
		FROM_TCL => FROM_TCL, 
		C => C, 
		CLR => CLR,
		state_buffer_out => state_buffer_out,
		state_buffer_in => state_buffer_in,
		mean => mean
   );

	c <= not c after c_t / 2;

	process begin
		--сброс
		i <= 0;
		tcl_buf <= (others => (others => '0'));
		clr <= '1';
		wait for c_t;
		clr <= '0';
		wait for 10 * c_t;
		
		--инициализация старт
		from_tcl(5 downto 4) <= "11"; --Информация - init
		from_tcl(3 downto 2) <= "01"; --начало записи с tcl в схему
		while to_tcl(3 downto 2) /= "01" loop
			wait for c_t;
		end loop;
		wait for 5 * c_t;
		from_tcl <= (others => '0');
		wait for c_t;
	
		--инициализаци - ожидаем готовность
		while to_tcl(1 downto 0) = "11" loop
			wait for c_t;
		end loop;
		
		--инициализация -- начинаем чтение имён
		i <= 0;
		from_tcl(1 downto 0) <= "10";
		while to_tcl(1 downto 0) /= "10" loop
			wait for c_t;
		end loop;
		
		tcl_buf(i) <= to_tcl(67 downto 4);
		i <= i + 1;
		len <= to_tcl(35 downto 20); --запомили число разрядов
		
		while to_tcl(1 downto 0) /= "00" loop
			
			from_tcl(1 downto 0) <= "01";
			while to_tcl(1 downto 0) /= "01" and to_tcl(1 downto 0) /= "00" loop --ждём 01
				wait for c_t;
			end loop;
			
			exit when to_tcl(1 downto 0) = "00";
			
			tcl_buf(i) <= to_tcl(67 downto 4);
			i <= i + 1;
			
			from_tcl(1 downto 0) <= "10";
			while to_tcl(1 downto 0) /= "10" and to_tcl(1 downto 0) /= "00" loop --ждём 10
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
		--конец чтения имён
		
		--запускаем операцию записи (первая операция, которая обязательно должна быть после инициализации)
		from_tcl <= (others => '0');
		from_tcl(35 downto 20) <= len;
		from_tcl(5 downto 4) <= "01";  --сигнал об операции чтения (задаётся мной из программы)
		from_tcl(3 downto 2) <= "01";
		
		while to_tcl(3 downto 2) /= "01" loop
			wait for c_t;
		end loop;
		
		from_tcl <= (others => '0');
		from_tcl(3 downto 2) <= "10";
		from_tcl(7 downto 4) <= (others => '0');    --эти будут заполняться из inc : D
		from_tcl(11 downto 8) <= "1011";  --эти будут устанавливать в inc : Q
		
		while to_tcl(3 downto 2) /= "10" loop
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
			while to_tcl(1 downto 0) /= "01" and to_tcl(1 downto 0) /= "00" loop --ждём 01
				wait for c_t;
			end loop;
			
			exit when to_tcl(1 downto 0) = "00";
			
			tcl_buf(i) <= to_tcl(67 downto 4);
			i <= i + 1;
			
			from_tcl(1 downto 0) <= "10";
			while to_tcl(1 downto 0) /= "10" and to_tcl(1 downto 0) /= "00" loop --ждём 10
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
		--закончили чтение
		
		--запускаем операцию записи (первая операция, которая обязательно должна быть после инициализации)
		from_tcl <= (others => '0');
		from_tcl(35 downto 20) <= len;
		from_tcl(5 downto 4) <= "01";  --сигнал об операции чтения (задаётся мной из программы)
		from_tcl(3 downto 2) <= "01";
		
		while to_tcl(3 downto 2) /= "01" loop
			wait for c_t;
		end loop;
		
		from_tcl <= (others => '0');
		from_tcl(3 downto 2) <= "10";
		from_tcl(7 downto 4) <= (others => '0');    --эти будут заполняться из inc : D
		from_tcl(11 downto 8) <= "1011";  --эти будут устанавливать в inc : Q
		
		while to_tcl(3 downto 2) /= "10" loop
			wait for c_t;
		end loop;
		
		from_tcl <= (others => '0'); 
		
		while to_tcl(3 downto 2) /= "00" loop
			wait for c_t;
		end loop;
		from_tcl <= (others=> '0');
		wait for c_t;
		--закончили запись
		
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
			while to_tcl(1 downto 0) /= "01" and to_tcl(1 downto 0) /= "00" loop --ждём 01
				wait for c_t;
			end loop;
			
			exit when to_tcl(1 downto 0) = "00";
			
			tcl_buf(i) <= to_tcl(67 downto 4);
			i <= i + 1;
			
			from_tcl(1 downto 0) <= "10";
			while to_tcl(1 downto 0) /= "10" and to_tcl(1 downto 0) /= "00" loop --ждём 10
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
		from_tcl <= (others=> '0');
		wait for c_t;		
		--закончили чтение
		
		
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
			while to_tcl(1 downto 0) /= "01" and to_tcl(1 downto 0) /= "00" loop --ждём 01
				wait for c_t;
			end loop;
			
			exit when to_tcl(1 downto 0) = "00";
			
			tcl_buf(i) <= to_tcl(67 downto 4);
			i <= i + 1;
			
			from_tcl(1 downto 0) <= "10";
			while to_tcl(1 downto 0) /= "10" and to_tcl(1 downto 0) /= "00" loop --ждём 10
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
				from_tcl <= (others=> '0');
		wait for c_t;
		--закончили чтение
				
	end process;

END;
