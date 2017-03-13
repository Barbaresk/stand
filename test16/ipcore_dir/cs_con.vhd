-------------------------------------------------------------------------------
-- Copyright (c) 2017 Xilinx, Inc.
-- All Rights Reserved
-------------------------------------------------------------------------------
--   ____  ____
--  /   /\/   /
-- /___/  \  /    Vendor     : Xilinx
-- \   \   \/     Version    : 14.7
--  \   \         Application: XILINX CORE Generator
--  /   /         Filename   : cs_con.vhd
-- /___/   /\     Timestamp  : Mon Feb 27 12:44:54 RTZ 2 (зима) 2017
-- \   \  /  \
--  \___\/\___\
--
-- Design Name: VHDL Synthesis Wrapper
-------------------------------------------------------------------------------
-- This wrapper is used to integrate with Project Navigator and PlanAhead

LIBRARY ieee;
USE ieee.std_logic_1164.ALL;
ENTITY cs_con IS
  port (
    CONTROL0: inout std_logic_vector(35 downto 0));
END cs_con;

ARCHITECTURE cs_con_a OF cs_con IS
BEGIN

END cs_con_a;
