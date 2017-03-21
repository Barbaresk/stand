----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date:    16:22:18 11/16/2016 
-- Design Name: 
-- Module Name:    top - Behavioral 
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
use IEEE.STD_LOGIC_unsigned.ALL;

-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values
--use IEEE.NUMERIC_STD.ALL;

-- Uncomment the following library declaration if instantiating
-- any Xilinx primitives in this code.
library UNISIM;
use UNISIM.VComponents.all;

entity cs_vio is
	port(
		clk_p 	: 	in		std_logic;
						 data_in	: 				out					std_logic_vector(67 downto 4);
						  outbuffer_in:			out						std_logic_vector(1 downto 0);
							inbuffer_in:			out						std_logic_vector(3 downto 2);
                    clr_out  :          out                 std_logic;
						  data_out	: 				in						std_logic_vector(67 downto 4);
						  outbuffer_out:			in						std_logic_vector(1 downto 0);
							inbuffer_out:			in						std_logic_vector(3 downto 2);
							clk_out:					out					std_logic
						
                    
	);
end cs_vio;

architecture cs_vio_arch of cs_vio is
-------------------------------------------------------------------------------
-- Компоненты - объявление

	-- блок управления
	component cs_con
		port (
			CONTROL0 	: inout 	std_logic_vector(35 downto 0));
	end component;
	
	-- блок виртуального ввода - вывода
	component vio
		PORT (
			CONTROL 		: inout 	std_logic_vector(35 downto 0);
			CLK 			: in 		std_logic;
			ASYNC_IN 	: in 		std_logic_vector(71 downto 0);-----------------------------
			ASYNC_OUT 	: out 	std_logic_vector(71 downto 0);
			SYNC_OUT	:	out	std_logic_vector(0 downto 0)
		);
	end component;
	
	component clk_gen
		port(-- Clock in ports
			CLK_IN1        : in     std_logic;
			-- Clock out ports
			CLK_OUT1          : out    std_logic;
			CLK_OUT2          : out    std_logic;
			CLK_OUT2_CE          : in    std_logic);
	end component;
	
	
-------------------------------------------------------------------------------
-- Сигналы

	-- подключение CS
	signal vio_con				:	std_logic_vector(35 downto 0);
	signal ce				: std_logic;
	signal clk				:	std_logic;
	signal vio_async_out		:	std_logic_vector(71 downto 0);----------------------------------
	signal vio_sync_out		:	std_logic_vector(0 downto 0);
	
	--signal buf_reg				:	std_logic_vector(71 downto 0):= (others => '0');---------------------------------
	
-------------------------------------------------------------------------------
begin

	--buf_reg_p : process(clk_alu)
	--begin
	--	if clk_alu'event and clk_alu = '1' then
	--			buf_reg <= vio_async_out;
	--	end if;
	--end process buf_reg_p;
	
	

			outbuffer_in<=vio_async_out(1 downto 0); 
			inbuffer_in<=vio_async_out(3 downto 2); 
         data_in<=vio_async_out(67 downto 4);
			clr_out<=vio_async_out(71) or vio_async_out(70) or vio_async_out(69) or vio_async_out(68);
	ce<='1';
		--vio_async_out(72) or vio_async_out(73);
		
		
		
-------------------------------------------------------------------------------
-- Компоненты - подключение
	cs_con_inst : cs_con port map(vio_con);
	cs_vio_inst : vio
	port map (
		CONTROL 		=> vio_con,
		CLK			=> clk,
		ASYNC_IN 	=> "0000" & data_out & inbuffer_out & outbuffer_out,
		ASYNC_OUT 	=> vio_async_out,
		SYNC_OUT => open
		);
		
	clk_gen_inst : clk_gen 
	port map(
	clk_in1 =>clk_p,

	clk_out1 =>clk,
	clk_out2=>clk_out,
	clk_out2_ce=>ce
	);
	
-------------------------------------------------------------------------------

end cs_vio_arch;

