<?xml version="1.0" encoding="UTF-8"?>
<drawing version="7">
    <attr value="spartan6" name="DeviceFamilyName">
        <trait delete="all:0" />
        <trait editname="all:0" />
        <trait edittrait="all:0" />
    </attr>
    <netlist>
        <signal name="XLXN_3(63:0)" />
        <signal name="XLXN_6(63:0)" />
        <signal name="XLXN_7" />
        <signal name="CLK" />
        <signal name="XLXN_10" />
        <signal name="XLXN_11" />
        <signal name="XLXN_12" />
        <signal name="XLXN_13" />
        <signal name="XLXN_14" />
        <signal name="XLXN_16(67:4)" />
        <signal name="XLXN_17(1:0)" />
        <signal name="XLXN_18(3:2)" />
        <signal name="XLXN_19(67:4)" />
        <signal name="XLXN_20(1:0)" />
        <signal name="XLXN_21(3:2)" />
        <signal name="FROM_TCL(71:0)" />
        <signal name="TO_TCL(71:0)" />
        <signal name="XLXN_1(3:0)" />
        <signal name="XLXN_2(3:0)" />
        <signal name="XLXN_27(3:0)" />
        <signal name="XLXN_28(3:0)" />
        <signal name="XLXN_29(3:0)" />
        <signal name="XLXN_30(3:0)" />
        <port polarity="Input" name="CLK" />
        <port polarity="Input" name="FROM_TCL(71:0)" />
        <port polarity="Output" name="TO_TCL(71:0)" />
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
        <blockdef name="CS3">
            <timestamp>2017-3-21T12:14:19</timestamp>
            <rect width="368" x="64" y="-384" height="384" />
            <line x2="0" y1="-352" y2="-352" x1="64" />
            <rect width="64" x="0" y="-284" height="24" />
            <line x2="0" y1="-272" y2="-272" x1="64" />
            <rect width="64" x="0" y="-204" height="24" />
            <line x2="0" y1="-192" y2="-192" x1="64" />
            <rect width="64" x="0" y="-124" height="24" />
            <line x2="0" y1="-112" y2="-112" x1="64" />
            <rect width="64" x="0" y="-44" height="24" />
            <line x2="0" y1="-32" y2="-32" x1="64" />
            <line x2="496" y1="-352" y2="-352" x1="432" />
            <line x2="496" y1="-288" y2="-288" x1="432" />
            <rect width="64" x="432" y="-236" height="24" />
            <line x2="496" y1="-224" y2="-224" x1="432" />
            <rect width="64" x="432" y="-172" height="24" />
            <line x2="496" y1="-160" y2="-160" x1="432" />
            <rect width="64" x="432" y="-108" height="24" />
            <line x2="496" y1="-96" y2="-96" x1="432" />
            <rect width="64" x="432" y="-44" height="24" />
            <line x2="496" y1="-32" y2="-32" x1="432" />
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
        <block symbolname="buffers" name="XLXI_1">
            <blockpin signalname="XLXN_11" name="clk" />
            <blockpin signalname="XLXN_13" name="clr" />
            <blockpin signalname="XLXN_6(63:0)" name="data_in(63:0)" />
            <blockpin signalname="XLXN_16(67:4)" name="from_tcl(63:0)" />
            <blockpin signalname="XLXN_17(1:0)" name="out_buffer_in(1:0)" />
            <blockpin signalname="XLXN_18(3:2)" name="in_buffer_in(1:0)" />
            <blockpin signalname="XLXN_3(63:0)" name="data_out(63:0)" />
            <blockpin signalname="XLXN_19(67:4)" name="to_tcl(63:0)" />
            <blockpin signalname="XLXN_20(1:0)" name="out_buffer_out(1:0)" />
            <blockpin signalname="XLXN_21(3:2)" name="in_buffer_out(1:0)" />
        </block>
        <block symbolname="CS3" name="XLXI_4">
            <blockpin signalname="CLK" name="clk_p" />
            <blockpin signalname="XLXN_19(67:4)" name="data_out(67:4)" />
            <blockpin signalname="XLXN_20(1:0)" name="outbuffer_out(1:0)" />
            <blockpin signalname="XLXN_21(3:2)" name="inbuffer_out(3:2)" />
            <blockpin signalname="FROM_TCL(71:0)" name="from_tcl(71:0)" />
            <blockpin signalname="XLXN_13" name="clr_out" />
            <blockpin signalname="XLXN_11" name="clk_out" />
            <blockpin signalname="XLXN_16(67:4)" name="data_in(67:4)" />
            <blockpin signalname="XLXN_17(1:0)" name="outbuffer_in(1:0)" />
            <blockpin signalname="XLXN_18(3:2)" name="inbuffer_in(3:2)" />
            <blockpin signalname="TO_TCL(71:0)" name="to_tcl(71:0)" />
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
            <blockpin signalname="XLXN_6(63:0)" name="DATA_OUT(63:0)" />
        </block>
        <block symbolname="add10" name="XLXI_6">
            <blockpin signalname="XLXN_1(3:0)" name="a(3:0)" />
            <blockpin signalname="XLXN_2(3:0)" name="b(3:0)" />
            <blockpin signalname="XLXN_27(3:0)" name="p1(3:0)" />
            <blockpin signalname="XLXN_28(3:0)" name="p2(3:0)" />
        </block>
    </netlist>
    <sheet sheetnum="1" width="3520" height="2720">
        <branch name="XLXN_3(63:0)">
            <wire x2="1728" y1="1424" y2="1424" x1="1712" />
            <wire x2="2384" y1="1424" y2="1424" x1="1728" />
        </branch>
        <instance x="1184" y="1776" name="XLXI_1" orien="R0">
        </instance>
        <branch name="XLXN_6(63:0)">
            <wire x2="1184" y1="1552" y2="1552" x1="1168" />
            <wire x2="1168" y1="1552" y2="1888" x1="1168" />
            <wire x2="2944" y1="1888" y2="1888" x1="1168" />
            <wire x2="2944" y1="1424" y2="1424" x1="2864" />
            <wire x2="2944" y1="1424" y2="1888" x1="2944" />
        </branch>
        <branch name="CLK">
            <wire x2="320" y1="1104" y2="1104" x1="256" />
        </branch>
        <branch name="XLXN_13">
            <wire x2="1072" y1="1104" y2="1104" x1="816" />
            <wire x2="1072" y1="1104" y2="1488" x1="1072" />
            <wire x2="1184" y1="1488" y2="1488" x1="1072" />
            <wire x2="2384" y1="1104" y2="1104" x1="1072" />
        </branch>
        <instance x="320" y="1456" name="XLXI_4" orien="R0">
        </instance>
        <iomarker fontsize="28" x="256" y="1104" name="CLK" orien="R180" />
        <branch name="XLXN_16(67:4)">
            <wire x2="976" y1="1232" y2="1232" x1="816" />
            <wire x2="976" y1="1232" y2="1616" x1="976" />
            <wire x2="1184" y1="1616" y2="1616" x1="976" />
        </branch>
        <branch name="XLXN_17(1:0)">
            <wire x2="960" y1="1296" y2="1296" x1="816" />
            <wire x2="960" y1="1296" y2="1680" x1="960" />
            <wire x2="1184" y1="1680" y2="1680" x1="960" />
        </branch>
        <branch name="XLXN_18(3:2)">
            <wire x2="944" y1="1360" y2="1360" x1="816" />
            <wire x2="944" y1="1360" y2="1744" x1="944" />
            <wire x2="1184" y1="1744" y2="1744" x1="944" />
        </branch>
        <branch name="XLXN_19(67:4)">
            <wire x2="320" y1="1184" y2="1184" x1="240" />
            <wire x2="240" y1="1184" y2="1840" x1="240" />
            <wire x2="1792" y1="1840" y2="1840" x1="240" />
            <wire x2="1792" y1="1520" y2="1520" x1="1712" />
            <wire x2="1792" y1="1520" y2="1840" x1="1792" />
        </branch>
        <branch name="XLXN_20(1:0)">
            <wire x2="320" y1="1264" y2="1264" x1="256" />
            <wire x2="256" y1="1264" y2="1824" x1="256" />
            <wire x2="1776" y1="1824" y2="1824" x1="256" />
            <wire x2="1776" y1="1616" y2="1616" x1="1712" />
            <wire x2="1776" y1="1616" y2="1824" x1="1776" />
        </branch>
        <branch name="XLXN_21(3:2)">
            <wire x2="320" y1="1344" y2="1344" x1="272" />
            <wire x2="272" y1="1344" y2="1808" x1="272" />
            <wire x2="1760" y1="1808" y2="1808" x1="272" />
            <wire x2="1760" y1="1712" y2="1712" x1="1712" />
            <wire x2="1760" y1="1712" y2="1808" x1="1760" />
        </branch>
        <branch name="FROM_TCL(71:0)">
            <wire x2="320" y1="1424" y2="1424" x1="176" />
        </branch>
        <branch name="TO_TCL(71:0)">
            <wire x2="848" y1="1424" y2="1424" x1="816" />
        </branch>
        <iomarker fontsize="28" x="176" y="1424" name="FROM_TCL(71:0)" orien="R180" />
        <iomarker fontsize="28" x="848" y="1424" name="TO_TCL(71:0)" orien="R0" />
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
        <branch name="XLXN_11">
            <wire x2="992" y1="1168" y2="1168" x1="816" />
            <wire x2="992" y1="1168" y2="1424" x1="992" />
            <wire x2="1184" y1="1424" y2="1424" x1="992" />
            <wire x2="2384" y1="1040" y2="1040" x1="992" />
            <wire x2="992" y1="1040" y2="1168" x1="992" />
        </branch>
        <instance x="1936" y="1392" name="XLXI_6" orien="R0">
        </instance>
        <branch name="XLXN_27(3:0)">
            <wire x2="2384" y1="1296" y2="1296" x1="2320" />
        </branch>
        <branch name="XLXN_28(3:0)">
            <wire x2="2384" y1="1360" y2="1360" x1="2320" />
        </branch>
    </sheet>
</drawing>