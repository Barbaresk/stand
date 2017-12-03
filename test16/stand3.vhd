library IEEE;
use IEEE.STD_LOGIC_1164.ALL;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;
entity stand3 is

    Port ( CLK   : in  STD_LOGIC;
           CLR   : in  STD_LOGIC;
           CLR_O : out STD_LOGIC;
		q : in  std_logic_vector(3 downto 0);
		digit2_q : in  std_logic_vector(3 downto 0);
		digit3_q : in  std_logic_vector(3 downto 0);
		digit4_q : in  std_logic_vector(3 downto 0);
		diod_q : in  std_logic;
		diod2_q : in  std_logic;
		diod3_q : in  std_logic;
		panel4_q : in  std_logic_vector(3 downto 0);
		panel42_q : in  std_logic_vector(3 downto 0);
		d : out std_logic_vector(3 downto 0);
		tumler42_d : out std_logic_vector(3 downto 0);
		tumler43_d : out std_logic_vector(3 downto 0);
		tumler44_d : out std_logic_vector(3 downto 0);
		redButton_d : out std_logic;
		redButton2_d : out std_logic;
DATA_IN  : in   STD_LOGIC_VECTOR (63 downto 0);
           DATA_OUT : out  STD_LOGIC_VECTOR (63 downto 0));
end stand3;
architecture Behavioral of stand3 is
	 constant len  : integer := 45 ;
	 constant rwc  : integer := 27 ;
	 constant name : integer := 7 * 16;
	 signal   info : std_logic_vector(name - 1 downto 0) := x"0000CC002600760086002E00CE00";
constant rd   : integer := len - rwc;
	signal value  : std_logic_vector(len - 1 downto 0); --массив для сопоставления
	signal rvalue : std_logic_vector(len - rwc - 1 downto 0);
	type state_type is (
		idle,     --до инициализации 00
		init,     --инициализации    11
		rw,       --чтение/запись    01
		waiting   --ожидание         00
	);

	
	signal cop   : std_logic_vector(1 downto 0);
	signal arg   : std_logic_vector(15 downto 0);
begin
	value(rwc - 1 downto 0) <= panel42_q & panel4_q & diod3_q & diod2_q & diod_q & digit4_q & digit3_q & digit2_q & q;
d <= value(30 downto 27);
tumler42_d <= value(34 downto 31);
tumler43_d <= value(38 downto 35);
tumler44_d <= value(42 downto 39);
redButton_d <= value(43);
redButton2_d <= value(44);
clr_o <= clr;
	value(len - 1 downto rwc) <= rvalue;
	cop <= data_in(1 downto 0);
	arg <= data_in(31 downto 16);

	process (CLK)
		variable state  : state_type; --состояния элемента
		variable offset : integer;   
		variable endstr : integer;
		variable offr   : integer;
		variable pos    : integer;
		variable i      : integer;
	begin
		if clk = '1' and clk'event then
			if clr = '1' then
				rvalue <= (others => '0');
				data_out <= (others => '0');

				state  := idle;
				offset := 0;
				endstr := 0;
				pos    := 0;
				i      := 0;
			else
				case state is
					when idle => 
						if cop = "11" then
							offset := conv_integer(unsigned(arg));
							offr   := offset + rwc;
							state  := init;
							endstr := conv_integer(unsigned(data_in(47 downto 32)));
							pos    := 0;
							i      := 0;
							data_out(1 downto 0)   <= "11";
							data_out(31 downto 16) <= arg + len;
							data_out(47 downto 32) <= data_in(47 downto 32) + name;
						end if;
						
					when init =>
						
						data_out <= data_in;
						if pos >= endstr + name then
							state    := waiting;
							data_out <= (others => '0');
						else
							if pos < endstr then
								if pos + 64 > endstr then
									if pos + 64 <= endstr + name then -- pos < endsrt < pos + 64 <= endstr + name
										i := pos + 64 - endstr;
										data_out(63 downto endstr - pos) <= info(i - 1 downto 0);
									else                              -- pos < endstr < endstr + name < pos + 64
										data_out(endstr + name - 1 - pos downto endstr - pos) <= info(name - 1 downto 0);
									end if;
								end if;
							else
								if pos < endstr + name then
									if pos + 64 <= endstr + name then -- endstr <= pos < pos + 64 <= endstr + name
										i := i + 64;
										data_out <= info(i - 1 downto i - 64);
									else                              -- endstr <= pos < endstr + name < pos + 64
										data_out(endstr + name - pos - 1 downto 0) <= info(name - 1 downto i);
									end if;
								end if;
							end if;
							pos := pos + 64;
						end if;
						
					when rw =>
						
						data_out <= data_in;
						if pos >= endstr then
							state    := waiting;
							data_out <= (others => '0');
						else
							--пишем из схемы в cs
							if pos < offset then
								if pos + 64 > offset then
									if pos + 64 <= offset + rwc then -- pos < offset < pos + 64 <= offset + rw
										i := pos + 64 - offset;
										data_out(63 downto offset - pos) <= value(i - 1 downto 0);
									else                            -- pos < offset < offset + rw < pos + 64
										i := rwc;
										data_out(offset + rwc - 1 - pos downto offset - pos) <= value(rwc - 1 downto 0);
									end if;
								end if;
							else
								if pos < offset + rwc then
									if pos + 64 <= offset + rwc then -- offset <= pos < pos + 64 <= offset + rw
										i := i + 64;
										data_out <= value(i - 1 downto i - 64);
									else                            -- offset <= pos < offset + rw < pos + 64
										data_out(offset + rwc - pos - 1 downto 0) <= value(rwc - 1 downto i);
										i := rwc;
									end if;
								end if;
							end if;
							
							--пишем из cs в схему
							if pos < offr then
								if pos + 64 > offr then
									if pos + 64 <= offr + rd then -- pos < offr < pos + 64 <= offr + rd
										i := pos + 64 - offr;
										rvalue(i - 1 downto 0) <= data_in(63 downto offr - pos);
									else                            -- pos < offr < offr + rd < pos + 64
										rvalue(rd - 1 downto 0) <= data_in(offr + rd - 1 - pos downto offr - pos);
									end if;
								end if;
							else
								if pos < offr + rd then
									if pos + 64 <= offr + rd then -- offr <= pos < pos + 64 <= offr + rd
										i := i + 64;
										rvalue(i - 1 downto i - 64) <= data_in;
									else                            -- offr <= pos < offr + rd < pos + 64
										rvalue(rd - 1 downto i) <= data_in(offr + rd - pos - 1 downto 0);
									end if;
								end if;
							end if;
							
							if pos > offr + rd then
								data_out <= data_in;
							else
								if pos + 64 > offr + rd then
									data_out(63 downto offr + rd - pos) <= data_in(63 downto offr + rd - pos);
								end if;
							end if;
							
							pos := pos + 64;
						end if;
						
					when waiting =>
						if cop = "01" or cop = "10" then
							state    := rw;
							endstr   := conv_integer(unsigned(data_in(31 downto 16)));
							pos      := 0;
							i        := 0;
							data_out <= data_in;
						end if;
				end case;
			end if;
		end if;
	
	
	end process;

end Behavioral;
