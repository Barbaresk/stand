<?xml version="1.0" encoding="UTF-8"?>
<drawing version="7">
    <attr value="spartan6" name="DeviceFamilyName">
        <trait delete="all:0" />
        <trait editname="all:0" />
        <trait edittrait="all:0" />
    </attr>
    <netlist>
        <signal name="DATA_IN(67:0)" />
        <signal name="TO_TCL(67:0)" />
        <signal name="FROM_TCL(67:0)" />
        <signal name="DATA_IN(3:2)" />
        <signal name="DATA_IN(67:4)" />
        <signal name="DATA_IN(1:0)" />
        <signal name="DATA_OUT(67:0)" />
        <signal name="DATA_OUT(67:4)" />
        <signal name="DATA_OUT(1:0)" />
        <signal name="DATA_OUT(3:2)" />
        <signal name="XLXN_26(63:0)" />
        <signal name="XLXN_27(63:0)" />
        <signal name="XLXN_28(63:0)" />
        <signal name="XLXN_29" />
        <signal name="XLXN_30" />
        <signal name="C" />
        <signal name="XLXN_34(63:0)" />
        <signal name="XLXN_35" />
        <signal name="CLR" />
        <signal name="XLXN_37" />
        <signal name="XLXN_38" />
        <signal name="T3_L" />
        <signal name="T3_E" />
        <signal name="T3_D(3:0)" />
        <signal name="T3_Q(7:0)" />
        <signal name="T3_U(5:0)" />
        <signal name="T4_D(20:0)" />
        <signal name="XLXN_47(20:0)" />
        <signal name="XLXN_48(63:0)" />
        <signal name="XLXN_49" />
        <signal name="XLXN_50(20:0)" />
        <signal name="XLXN_51(63:0)" />
        <signal name="XLXN_52" />
        <signal name="XLXN_53(63:0)" />
        <signal name="T4_Q(11:0)" />
        <signal name="T4_U(52:0)" />
        <signal name="XLXN_56" />
        <signal name="XLXN_57" />
        <port polarity="Output" name="TO_TCL(67:0)" />
        <port polarity="Input" name="FROM_TCL(67:0)" />
        <port polarity="Input" name="C" />
        <port polarity="Input" name="CLR" />
        <port polarity="Input" name="T3_L" />
        <port polarity="Input" name="T3_E" />
        <port polarity="Input" name="T3_D(3:0)" />
        <port polarity="Output" name="T3_Q(7:0)" />
        <port polarity="Output" name="T3_U(5:0)" />
        <port polarity="Input" name="T4_D(20:0)" />
        <port polarity="Output" name="T4_Q(11:0)" />
        <port polarity="Output" name="T4_U(52:0)" />
        <blockdef name="CS_Entity">
            <timestamp>2016-12-23T0:14:35</timestamp>
            <line x2="0" y1="32" y2="32" x1="64" />
            <line x2="640" y1="32" y2="32" x1="576" />
            <line x2="0" y1="-224" y2="-224" x1="64" />
            <rect width="64" x="0" y="-108" height="24" />
            <line x2="0" y1="-96" y2="-96" x1="64" />
            <rect width="64" x="0" y="-44" height="24" />
            <line x2="0" y1="-32" y2="-32" x1="64" />
            <rect width="64" x="576" y="-236" height="24" />
            <line x2="640" y1="-224" y2="-224" x1="576" />
            <rect width="64" x="576" y="-44" height="24" />
            <line x2="640" y1="-32" y2="-32" x1="576" />
            <rect width="512" x="64" y="-256" height="320" />
        </blockdef>
        <blockdef name="InBuffer_Entity">
            <timestamp>2016-12-23T0:3:39</timestamp>
            <rect width="64" x="0" y="20" height="24" />
            <line x2="0" y1="32" y2="32" x1="64" />
            <line x2="0" y1="-160" y2="-160" x1="64" />
            <line x2="0" y1="-96" y2="-96" x1="64" />
            <rect width="64" x="0" y="-44" height="24" />
            <line x2="0" y1="-32" y2="-32" x1="64" />
            <rect width="64" x="416" y="-108" height="24" />
            <line x2="480" y1="-96" y2="-96" x1="416" />
            <rect width="64" x="416" y="-44" height="24" />
            <line x2="480" y1="-32" y2="-32" x1="416" />
            <rect width="352" x="64" y="-192" height="256" />
        </blockdef>
        <blockdef name="OutBuffer_Entity">
            <timestamp>2016-12-22T23:45:32</timestamp>
            <rect width="352" x="64" y="-256" height="256" />
            <line x2="0" y1="-224" y2="-224" x1="64" />
            <line x2="0" y1="-160" y2="-160" x1="64" />
            <rect width="64" x="0" y="-108" height="24" />
            <line x2="0" y1="-96" y2="-96" x1="64" />
            <rect width="64" x="0" y="-44" height="24" />
            <line x2="0" y1="-32" y2="-32" x1="64" />
            <rect width="64" x="416" y="-236" height="24" />
            <line x2="480" y1="-224" y2="-224" x1="416" />
            <rect width="64" x="416" y="-44" height="24" />
            <line x2="480" y1="-32" y2="-32" x1="416" />
        </blockdef>
        <blockdef name="item3">
            <timestamp>2016-12-22T22:43:27</timestamp>
            <rect width="352" x="64" y="-384" height="384" />
            <line x2="0" y1="-352" y2="-352" x1="64" />
            <line x2="0" y1="-288" y2="-288" x1="64" />
            <line x2="0" y1="-224" y2="-224" x1="64" />
            <line x2="0" y1="-160" y2="-160" x1="64" />
            <rect width="64" x="0" y="-108" height="24" />
            <line x2="0" y1="-96" y2="-96" x1="64" />
            <rect width="64" x="0" y="-44" height="24" />
            <line x2="0" y1="-32" y2="-32" x1="64" />
            <rect width="64" x="416" y="-364" height="24" />
            <line x2="480" y1="-352" y2="-352" x1="416" />
            <rect width="64" x="416" y="-204" height="24" />
            <line x2="480" y1="-192" y2="-192" x1="416" />
            <rect width="64" x="416" y="-44" height="24" />
            <line x2="480" y1="-32" y2="-32" x1="416" />
        </blockdef>
        <blockdef name="item4">
            <timestamp>2016-12-22T22:42:23</timestamp>
            <rect width="352" x="64" y="-256" height="256" />
            <line x2="0" y1="-224" y2="-224" x1="64" />
            <line x2="0" y1="-160" y2="-160" x1="64" />
            <rect width="64" x="0" y="-108" height="24" />
            <line x2="0" y1="-96" y2="-96" x1="64" />
            <rect width="64" x="0" y="-44" height="24" />
            <line x2="0" y1="-32" y2="-32" x1="64" />
            <rect width="64" x="416" y="-236" height="24" />
            <line x2="480" y1="-224" y2="-224" x1="416" />
            <rect width="64" x="416" y="-140" height="24" />
            <line x2="480" y1="-128" y2="-128" x1="416" />
            <rect width="64" x="416" y="-44" height="24" />
            <line x2="480" y1="-32" y2="-32" x1="416" />
        </blockdef>
        <block symbolname="InBuffer_Entity" name="XLXI_13">
            <blockpin signalname="C" name="CLK" />
            <blockpin signalname="XLXN_38" name="CLR" />
            <blockpin signalname="DATA_IN(3:2)" name="STATE_IN(1:0)" />
            <blockpin signalname="DATA_IN(67:4)" name="DATA_IN(63:0)" />
            <blockpin signalname="DATA_OUT(3:2)" name="STATE_OUT(1:0)" />
            <blockpin signalname="XLXN_26(63:0)" name="DATA_OUT(63:0)" />
        </block>
        <block symbolname="OutBuffer_Entity" name="XLXI_14">
            <blockpin signalname="C" name="CLK" />
            <blockpin signalname="XLXN_38" name="CLR" />
            <blockpin signalname="DATA_IN(1:0)" name="STATE_IN(1:0)" />
            <blockpin signalname="XLXN_28(63:0)" name="DATA_IN(63:0)" />
            <blockpin signalname="DATA_OUT(1:0)" name="STATE_OUT(1:0)" />
            <blockpin signalname="DATA_OUT(67:4)" name="DATA_OUT(63:0)" />
        </block>
        <block symbolname="CS_Entity" name="XLXI_10">
            <blockpin signalname="C" name="CLK" />
            <blockpin signalname="CLR" name="CLR_IN" />
            <blockpin signalname="FROM_TCL(67:0)" name="FROM_TCL_IN(67:0)" />
            <blockpin signalname="DATA_OUT(67:0)" name="FROM_VHD_IN(67:0)" />
            <blockpin signalname="XLXN_38" name="CLR_OUT" />
            <blockpin signalname="DATA_IN(67:0)" name="FROM_TCL_OUT(67:0)" />
            <blockpin signalname="TO_TCL(67:0)" name="FROM_VHD_OUT(67:0)" />
        </block>
        <block symbolname="item3" name="XLXI_17">
            <blockpin signalname="C" name="CLK" />
            <blockpin signalname="XLXN_38" name="CLR" />
            <blockpin signalname="T3_L" name="L" />
            <blockpin signalname="T3_E" name="E" />
            <blockpin signalname="T3_D(3:0)" name="D(3:0)" />
            <blockpin signalname="XLXN_26(63:0)" name="DATA_IN(63:0)" />
            <blockpin signalname="T3_Q(7:0)" name="Q(7:0)" />
            <blockpin signalname="T3_U(5:0)" name="U(5:0)" />
            <blockpin signalname="XLXN_27(63:0)" name="DATA_OUT(63:0)" />
        </block>
        <block symbolname="item4" name="XLXI_18">
            <blockpin signalname="C" name="CLK" />
            <blockpin signalname="XLXN_38" name="CLR" />
            <blockpin signalname="T4_D(20:0)" name="D(20:0)" />
            <blockpin signalname="XLXN_27(63:0)" name="DATA_IN(63:0)" />
            <blockpin signalname="T4_Q(11:0)" name="Q(11:0)" />
            <blockpin signalname="T4_U(52:0)" name="U(52:0)" />
            <blockpin signalname="XLXN_28(63:0)" name="DATA_OUT(63:0)" />
        </block>
    </netlist>
    <sheet sheetnum="1" width="3520" height="2720">
        <instance x="400" y="832" name="XLXI_10" orien="R0">
        </instance>
        <branch name="DATA_IN(67:0)">
            <attrtext style="alignment:SOFT-LEFT;fontsize:28;fontname:Arial" attrname="Name" x="1312" y="608" type="branch" />
            <wire x2="1088" y1="608" y2="608" x1="1040" />
            <wire x2="1136" y1="608" y2="608" x1="1088" />
            <wire x2="1168" y1="608" y2="608" x1="1136" />
            <wire x2="1312" y1="608" y2="608" x1="1168" />
        </branch>
        <branch name="TO_TCL(67:0)">
            <wire x2="32" y1="928" y2="928" x1="16" />
            <wire x2="16" y1="928" y2="1024" x1="16" />
            <wire x2="1056" y1="1024" y2="1024" x1="16" />
            <wire x2="1056" y1="800" y2="800" x1="1040" />
            <wire x2="1056" y1="800" y2="1024" x1="1056" />
        </branch>
        <branch name="FROM_TCL(67:0)">
            <wire x2="400" y1="736" y2="736" x1="288" />
        </branch>
        <bustap x2="1088" y1="608" y2="512" x1="1088" />
        <bustap x2="1168" y1="608" y2="512" x1="1168" />
        <branch name="DATA_IN(3:2)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="1248" y="464" type="branch" />
            <wire x2="1168" y1="464" y2="512" x1="1168" />
            <wire x2="1248" y1="464" y2="464" x1="1168" />
            <wire x2="1360" y1="464" y2="464" x1="1248" />
        </branch>
        <branch name="DATA_IN(67:4)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="1200" y="400" type="branch" />
            <wire x2="1088" y1="400" y2="512" x1="1088" />
            <wire x2="1200" y1="400" y2="400" x1="1088" />
            <wire x2="1360" y1="400" y2="400" x1="1200" />
        </branch>
        <branch name="DATA_IN(1:0)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="1232" y="1024" type="branch" />
            <wire x2="1136" y1="704" y2="1024" x1="1136" />
            <wire x2="1232" y1="1024" y2="1024" x1="1136" />
            <wire x2="1328" y1="1024" y2="1024" x1="1232" />
        </branch>
        <branch name="DATA_OUT(67:0)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="1712" y="1280" type="branch" />
            <wire x2="400" y1="800" y2="800" x1="352" />
            <wire x2="352" y1="800" y2="1280" x1="352" />
            <wire x2="1712" y1="1280" y2="1280" x1="352" />
            <wire x2="1936" y1="1280" y2="1280" x1="1712" />
            <wire x2="1968" y1="1280" y2="1280" x1="1936" />
            <wire x2="2000" y1="1280" y2="1280" x1="1968" />
            <wire x2="2048" y1="1280" y2="1280" x1="2000" />
        </branch>
        <branch name="DATA_OUT(67:4)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="1920" y="1088" type="branch" />
            <wire x2="1920" y1="1088" y2="1088" x1="1808" />
            <wire x2="1936" y1="1088" y2="1088" x1="1920" />
            <wire x2="1936" y1="1088" y2="1184" x1="1936" />
        </branch>
        <branch name="DATA_OUT(1:0)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="1904" y="896" type="branch" />
            <wire x2="1904" y1="896" y2="896" x1="1808" />
            <wire x2="1968" y1="896" y2="896" x1="1904" />
            <wire x2="1968" y1="896" y2="1184" x1="1968" />
        </branch>
        <branch name="DATA_OUT(3:2)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="1952" y="336" type="branch" />
            <wire x2="1952" y1="336" y2="336" x1="1840" />
            <wire x2="2000" y1="336" y2="336" x1="1952" />
            <wire x2="2000" y1="336" y2="1184" x1="2000" />
        </branch>
        <branch name="XLXN_26(63:0)">
            <wire x2="2352" y1="400" y2="400" x1="1840" />
        </branch>
        <branch name="XLXN_27(63:0)">
            <wire x2="2880" y1="400" y2="400" x1="2832" />
            <wire x2="2880" y1="400" y2="848" x1="2880" />
            <wire x2="2928" y1="848" y2="848" x1="2880" />
        </branch>
        <branch name="XLXN_28(63:0)">
            <wire x2="1328" y1="1088" y2="1088" x1="1312" />
            <wire x2="1312" y1="1088" y2="1136" x1="1312" />
            <wire x2="3472" y1="1136" y2="1136" x1="1312" />
            <wire x2="3472" y1="848" y2="848" x1="3408" />
            <wire x2="3472" y1="848" y2="1136" x1="3472" />
        </branch>
        <iomarker fontsize="28" x="32" y="928" name="TO_TCL(67:0)" orien="R0" />
        <rect width="300" x="4" y="576" height="404" />
        <text style="fontsize:40;fontname:Arial" x="100" y="604">SCRIPT</text>
        <branch name="C">
            <wire x2="352" y1="80" y2="80" x1="304" />
            <wire x2="352" y1="80" y2="608" x1="352" />
            <wire x2="400" y1="608" y2="608" x1="352" />
            <wire x2="1296" y1="80" y2="80" x1="352" />
            <wire x2="2224" y1="80" y2="80" x1="1296" />
            <wire x2="2352" y1="80" y2="80" x1="2224" />
            <wire x2="2224" y1="80" y2="656" x1="2224" />
            <wire x2="2928" y1="656" y2="656" x1="2224" />
            <wire x2="1296" y1="80" y2="272" x1="1296" />
            <wire x2="1360" y1="272" y2="272" x1="1296" />
            <wire x2="1296" y1="272" y2="896" x1="1296" />
            <wire x2="1328" y1="896" y2="896" x1="1296" />
        </branch>
        <iomarker fontsize="28" x="288" y="736" name="FROM_TCL(67:0)" orien="R180" />
        <instance x="1360" y="432" name="XLXI_13" orien="R0">
        </instance>
        <bustap x2="1136" y1="608" y2="704" x1="1136" />
        <instance x="1328" y="1120" name="XLXI_14" orien="R0">
        </instance>
        <bustap x2="1936" y1="1280" y2="1184" x1="1936" />
        <bustap x2="1968" y1="1280" y2="1184" x1="1968" />
        <bustap x2="2000" y1="1280" y2="1184" x1="2000" />
        <rect width="1760" x="328" y="92" height="1344" />
        <text style="fontsize:40;fontname:Arial" x="1164" y="140">BLACK BOX</text>
        <branch name="CLR">
            <wire x2="400" y1="864" y2="864" x1="288" />
        </branch>
        <iomarker fontsize="28" x="288" y="864" name="CLR" orien="R180" />
        <iomarker fontsize="28" x="304" y="80" name="C" orien="R180" />
        <instance x="2352" y="432" name="XLXI_17" orien="R0">
        </instance>
        <branch name="XLXN_38">
            <wire x2="1184" y1="864" y2="864" x1="1040" />
            <wire x2="1184" y1="864" y2="960" x1="1184" />
            <wire x2="1328" y1="960" y2="960" x1="1184" />
            <wire x2="1264" y1="864" y2="864" x1="1184" />
            <wire x2="1360" y1="336" y2="336" x1="1264" />
            <wire x2="1264" y1="336" y2="720" x1="1264" />
            <wire x2="1264" y1="720" y2="864" x1="1264" />
            <wire x2="2160" y1="720" y2="720" x1="1264" />
            <wire x2="2928" y1="720" y2="720" x1="2160" />
            <wire x2="2352" y1="144" y2="144" x1="2160" />
            <wire x2="2160" y1="144" y2="720" x1="2160" />
        </branch>
        <branch name="T3_L">
            <wire x2="2352" y1="208" y2="208" x1="2336" />
        </branch>
        <branch name="T3_E">
            <wire x2="2352" y1="272" y2="272" x1="2336" />
        </branch>
        <branch name="T3_D(3:0)">
            <wire x2="2352" y1="336" y2="336" x1="2336" />
        </branch>
        <branch name="T3_Q(7:0)">
            <wire x2="2848" y1="80" y2="80" x1="2832" />
        </branch>
        <branch name="T3_U(5:0)">
            <wire x2="2848" y1="240" y2="240" x1="2832" />
        </branch>
        <branch name="T4_D(20:0)">
            <wire x2="2928" y1="784" y2="784" x1="2752" />
        </branch>
        <instance x="2928" y="880" name="XLXI_18" orien="R0">
        </instance>
        <branch name="T4_Q(11:0)">
            <wire x2="3440" y1="656" y2="656" x1="3408" />
        </branch>
        <branch name="T4_U(52:0)">
            <wire x2="3440" y1="752" y2="752" x1="3408" />
        </branch>
        <iomarker fontsize="28" x="2336" y="208" name="T3_L" orien="R180" />
        <iomarker fontsize="28" x="2336" y="272" name="T3_E" orien="R180" />
        <iomarker fontsize="28" x="2336" y="336" name="T3_D(3:0)" orien="R180" />
        <iomarker fontsize="28" x="2752" y="784" name="T4_D(20:0)" orien="R180" />
        <iomarker fontsize="28" x="2848" y="80" name="T3_Q(7:0)" orien="R0" />
        <iomarker fontsize="28" x="2848" y="240" name="T3_U(5:0)" orien="R0" />
        <iomarker fontsize="28" x="3440" y="656" name="T4_Q(11:0)" orien="R0" />
        <iomarker fontsize="28" x="3440" y="752" name="T4_U(52:0)" orien="R0" />
        <rect width="1348" x="2136" y="16" height="1420" />
        <text style="fontsize:40;fontname:Arial" x="2748" y="1384">USER</text>
    </sheet>
</drawing>