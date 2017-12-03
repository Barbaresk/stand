<?xml version="1.0" encoding="UTF-8"?>
<drawing version="7">
    <attr value="spartan6" name="DeviceFamilyName">
        <trait delete="all:0" />
        <trait editname="all:0" />
        <trait edittrait="all:0" />
    </attr>
    <netlist>
        <signal name="XLXN_3(63:0)" />
        <signal name="XLXN_40" />
        <signal name="clk_p" />
        <signal name="XLXN_11" />
        <signal name="XLXN_13" />
        <signal name="XLXN_18(3:2)" />
        <signal name="XLXN_19(67:4)" />
        <signal name="XLXN_20(1:0)" />
        <signal name="XLXN_21(3:2)" />
        <signal name="XLXN_1(3:0)" />
        <signal name="XLXN_2(3:0)" />
        <signal name="XLXN_27(3:0)" />
        <signal name="XLXN_28(3:0)" />
        <signal name="XLXN_39(67:4)" />
        <signal name="XLXN_40(1:0)" />
        <signal name="XLXN_17(1:0)" />
        <signal name="XLXN_16(67:4)" />
        <signal name="XLXN_43(67:4)" />
        <signal name="XLXN_45(3:2)" />
        <signal name="XLXN_46(67:4)" />
        <signal name="XLXN_47(1:0)" />
        <signal name="XLXN_48(3:2)" />
        <port polarity="Input" name="clk_p" />
        <blockdef name="buffers">
            <timestamp>2017-3-14T15:20:36</timestamp>
            <rect width="400" x="64" y="-384" height="384" />
            <line x2="0" y1="-352" y2="-352" x1="64" />
            <line x2="0" y1="-288" y2="-288" x1="64" />
            <rect width="64" x="0" y="-236" height="24" />
            <line x2="0" y1="-224" y2="-224" x1="64" />
            <rect width="64" x="0" y="-172" height="24" />
            <line x2="0" y1="-160" y2="-160" x1="64" />
            <rect width="64" x="0" y="-108" height="24" />
            <line x2="0" y1="-96" y2="-96" x1="64" />
            <rect width="64" x="0" y="-44" height="24" />
            <line x2="0" y1="-32" y2="-32" x1="64" />
            <rect width="64" x="464" y="-364" height="24" />
            <line x2="528" y1="-352" y2="-352" x1="464" />
            <rect width="64" x="464" y="-268" height="24" />
            <line x2="528" y1="-256" y2="-256" x1="464" />
            <rect width="64" x="464" y="-172" height="24" />
            <line x2="528" y1="-160" y2="-160" x1="464" />
            <rect width="64" x="464" y="-76" height="24" />
            <line x2="528" y1="-64" y2="-64" x1="464" />
        </blockdef>
        <blockdef name="summator">
            <timestamp>2017-3-21T12:1:29</timestamp>
            <rect width="352" x="64" y="-448" height="448" />
            <line x2="0" y1="-416" y2="-416" x1="64" />
            <line x2="0" y1="-352" y2="-352" x1="64" />
            <rect width="64" x="0" y="-300" height="24" />
            <line x2="0" y1="-288" y2="-288" x1="64" />
            <rect width="64" x="0" y="-236" height="24" />
            <line x2="0" y1="-224" y2="-224" x1="64" />
            <rect width="64" x="0" y="-172" height="24" />
            <line x2="0" y1="-160" y2="-160" x1="64" />
            <rect width="64" x="0" y="-108" height="24" />
            <line x2="0" y1="-96" y2="-96" x1="64" />
            <rect width="64" x="0" y="-44" height="24" />
            <line x2="0" y1="-32" y2="-32" x1="64" />
            <line x2="480" y1="-416" y2="-416" x1="416" />
            <rect width="64" x="416" y="-300" height="24" />
            <line x2="480" y1="-288" y2="-288" x1="416" />
            <rect width="64" x="416" y="-172" height="24" />
            <line x2="480" y1="-160" y2="-160" x1="416" />
            <rect width="64" x="416" y="-44" height="24" />
            <line x2="480" y1="-32" y2="-32" x1="416" />
        </blockdef>
        <blockdef name="add10">
            <timestamp>2017-3-21T12:31:59</timestamp>
            <rect width="256" x="64" y="-128" height="128" />
            <rect width="64" x="0" y="-108" height="24" />
            <line x2="0" y1="-96" y2="-96" x1="64" />
            <rect width="64" x="0" y="-44" height="24" />
            <line x2="0" y1="-32" y2="-32" x1="64" />
            <rect width="64" x="320" y="-108" height="24" />
            <line x2="384" y1="-96" y2="-96" x1="320" />
            <rect width="64" x="320" y="-44" height="24" />
            <line x2="384" y1="-32" y2="-32" x1="320" />
        </blockdef>
        <blockdef name="cs_vio">
            <timestamp>2017-3-7T13:44:51</timestamp>
            <line x2="496" y1="32" y2="32" x1="432" />
            <line x2="0" y1="-224" y2="-224" x1="64" />
            <rect width="64" x="0" y="-172" height="24" />
            <line x2="0" y1="-160" y2="-160" x1="64" />
            <rect width="64" x="0" y="-108" height="24" />
            <line x2="0" y1="-96" y2="-96" x1="64" />
            <rect width="64" x="0" y="-44" height="24" />
            <line x2="0" y1="-32" y2="-32" x1="64" />
            <line x2="496" y1="-224" y2="-224" x1="432" />
            <rect width="64" x="432" y="-172" height="24" />
            <line x2="496" y1="-160" y2="-160" x1="432" />
            <rect width="64" x="432" y="-108" height="24" />
            <line x2="496" y1="-96" y2="-96" x1="432" />
            <rect width="64" x="432" y="-44" height="24" />
            <line x2="496" y1="-32" y2="-32" x1="432" />
            <rect width="368" x="64" y="-256" height="704" />
        </blockdef>
        <block symbolname="buffers" name="XLXI_1">
            <blockpin signalname="XLXN_11" name="clk" />
            <blockpin signalname="XLXN_13" name="clr" />
            <blockpin signalname="XLXN_40" name="data_in(63:0)" />
            <blockpin name="from_tcl(63:0)" />
            <blockpin name="out_buffer_in(1:0)" />
            <blockpin signalname="XLXN_18(3:2)" name="in_buffer_in(1:0)" />
            <blockpin signalname="XLXN_3(63:0)" name="data_out(63:0)" />
            <blockpin signalname="XLXN_19(67:4)" name="to_tcl(63:0)" />
            <blockpin signalname="XLXN_20(1:0)" name="out_buffer_out(1:0)" />
            <blockpin signalname="XLXN_21(3:2)" name="in_buffer_out(1:0)" />
        </block>
        <block symbolname="summator" name="XLXI_2">
            <blockpin signalname="XLXN_11" name="CLK" />
            <blockpin signalname="XLXN_13" name="CLR" />
            <blockpin signalname="XLXN_1(3:0)" name="a(3:0)" />
            <blockpin signalname="XLXN_2(3:0)" name="b(3:0)" />
            <blockpin signalname="XLXN_27(3:0)" name="p1(3:0)" />
            <blockpin signalname="XLXN_28(3:0)" name="p2(3:0)" />
            <blockpin signalname="XLXN_3(63:0)" name="DATA_IN(63:0)" />
            <blockpin name="CLR_O" />
            <blockpin signalname="XLXN_1(3:0)" name="aout(3:0)" />
            <blockpin signalname="XLXN_2(3:0)" name="bout(3:0)" />
            <blockpin signalname="XLXN_40" name="DATA_OUT(63:0)" />
        </block>
        <block symbolname="add10" name="XLXI_6">
            <blockpin signalname="XLXN_1(3:0)" name="a(3:0)" />
            <blockpin signalname="XLXN_2(3:0)" name="b(3:0)" />
            <blockpin signalname="XLXN_27(3:0)" name="p1(3:0)" />
            <blockpin signalname="XLXN_28(3:0)" name="p2(3:0)" />
        </block>
        <block symbolname="cs_vio" name="XLXI_7">
            <blockpin signalname="clk_p" name="clk_p" />
            <blockpin signalname="XLXN_19(67:4)" name="data_out(67:4)" />
            <blockpin signalname="XLXN_20(1:0)" name="outbuffer_out(1:0)" />
            <blockpin signalname="XLXN_21(3:2)" name="inbuffer_out(3:2)" />
            <blockpin signalname="XLXN_13" name="clr_out" />
            <blockpin signalname="XLXN_11" name="clk_out" />
            <blockpin signalname="XLXN_16(67:4)" name="data_in(67:4)" />
            <blockpin signalname="XLXN_17(1:0)" name="outbuffer_in(1:0)" />
            <blockpin signalname="XLXN_18(3:2)" name="inbuffer_in(3:2)" />
        </block>
    </netlist>
    <sheet sheetnum="1" width="3520" height="2720">
        <branch name="XLXN_3(63:0)">
            <wire x2="2384" y1="1424" y2="1424" x1="1712" />
        </branch>
        <instance x="1184" y="1776" name="XLXI_1" orien="R0">
        </instance>
        <branch name="XLXN_16(67:4)">
            <wire x2="880" y1="1168" y2="1168" x1="816" />
            <wire x2="880" y1="1088" y2="1168" x1="880" />
            <wire x2="1168" y1="1088" y2="1088" x1="880" />
            <wire x2="1168" y1="1088" y2="1616" x1="1168" />
            <wire x2="1184" y1="1616" y2="1616" x1="1168" />
        </branch>
        <branch name="XLXN_17(1:0)">
            <wire x2="976" y1="1232" y2="1232" x1="816" />
            <wire x2="976" y1="1232" y2="1680" x1="976" />
            <wire x2="1184" y1="1680" y2="1680" x1="976" />
        </branch>
        <branch name="XLXN_18(3:2)">
            <wire x2="960" y1="1296" y2="1296" x1="816" />
            <wire x2="960" y1="1296" y2="1744" x1="960" />
            <wire x2="1184" y1="1744" y2="1744" x1="960" />
        </branch>
        <instance x="2384" y="1456" name="XLXI_2" orien="R0">
        </instance>
        <branch name="XLXN_1(3:0)">
            <wire x2="1904" y1="1168" y2="1296" x1="1904" />
            <wire x2="1936" y1="1296" y2="1296" x1="1904" />
            <wire x2="2320" y1="1168" y2="1168" x1="1904" />
            <wire x2="2384" y1="1168" y2="1168" x1="2320" />
            <wire x2="2944" y1="736" y2="736" x1="2320" />
            <wire x2="2944" y1="736" y2="1168" x1="2944" />
            <wire x2="2320" y1="736" y2="1168" x1="2320" />
            <wire x2="2944" y1="1168" y2="1168" x1="2864" />
        </branch>
        <branch name="XLXN_2(3:0)">
            <wire x2="1920" y1="1232" y2="1360" x1="1920" />
            <wire x2="1936" y1="1360" y2="1360" x1="1920" />
            <wire x2="2336" y1="1232" y2="1232" x1="1920" />
            <wire x2="2384" y1="1232" y2="1232" x1="2336" />
            <wire x2="2928" y1="768" y2="768" x1="2336" />
            <wire x2="2928" y1="768" y2="1296" x1="2928" />
            <wire x2="2336" y1="768" y2="1232" x1="2336" />
            <wire x2="2928" y1="1296" y2="1296" x1="2864" />
        </branch>
        <instance x="1936" y="1392" name="XLXI_6" orien="R0">
        </instance>
        <branch name="XLXN_27(3:0)">
            <wire x2="2384" y1="1296" y2="1296" x1="2320" />
        </branch>
        <branch name="XLXN_28(3:0)">
            <wire x2="2384" y1="1360" y2="1360" x1="2320" />
        </branch>
        <iomarker fontsize="28" x="80" y="1104" name="clk_p" orien="R180" />
        <branch name="XLXN_13">
            <wire x2="1072" y1="1104" y2="1104" x1="816" />
            <wire x2="1072" y1="1104" y2="1488" x1="1072" />
            <wire x2="1184" y1="1488" y2="1488" x1="1072" />
            <wire x2="2384" y1="1104" y2="1104" x1="1072" />
        </branch>
        <branch name="XLXN_21(3:2)">
            <wire x2="320" y1="1296" y2="1296" x1="256" />
            <wire x2="256" y1="1296" y2="1856" x1="256" />
            <wire x2="1728" y1="1856" y2="1856" x1="256" />
            <wire x2="1728" y1="1712" y2="1712" x1="1712" />
            <wire x2="1728" y1="1712" y2="1856" x1="1728" />
        </branch>
        <branch name="XLXN_19(67:4)">
            <wire x2="256" y1="976" y2="1168" x1="256" />
            <wire x2="320" y1="1168" y2="1168" x1="256" />
            <wire x2="1728" y1="976" y2="976" x1="256" />
            <wire x2="1728" y1="976" y2="1520" x1="1728" />
            <wire x2="1728" y1="1520" y2="1520" x1="1712" />
        </branch>
        <branch name="clk_p">
            <wire x2="320" y1="1104" y2="1104" x1="80" />
        </branch>
        <instance x="320" y="1328" name="XLXI_7" orien="R0">
        </instance>
        <branch name="XLXN_20(1:0)">
            <wire x2="304" y1="1008" y2="1232" x1="304" />
            <wire x2="320" y1="1232" y2="1232" x1="304" />
            <wire x2="1824" y1="1008" y2="1008" x1="304" />
            <wire x2="1824" y1="1008" y2="1616" x1="1824" />
            <wire x2="1824" y1="1616" y2="1616" x1="1712" />
        </branch>
        <branch name="XLXN_11">
            <wire x2="896" y1="1360" y2="1360" x1="816" />
            <wire x2="896" y1="1168" y2="1360" x1="896" />
            <wire x2="992" y1="1168" y2="1168" x1="896" />
            <wire x2="992" y1="1168" y2="1424" x1="992" />
            <wire x2="1184" y1="1424" y2="1424" x1="992" />
            <wire x2="2384" y1="1040" y2="1040" x1="992" />
            <wire x2="992" y1="1040" y2="1168" x1="992" />
        </branch>
    </sheet>
</drawing>