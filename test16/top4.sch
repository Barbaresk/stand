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
        <signal name="XLXN_4(67:0)" />
        <signal name="FROM_TCL(67:0)" />
        <signal name="DATA_IN(3:2)" />
        <signal name="DATA_IN(67:4)" />
        <signal name="DATA_IN(1:0)" />
        <signal name="DATA_OUT(67:0)" />
        <signal name="DATA_OUT(67:4)" />
        <signal name="DATA_OUT(1:0)" />
        <signal name="DATA_OUT(3:2)" />
        <signal name="XLXN_26(63:0)" />
        <signal name="XLXN_28(63:0)" />
        <signal name="XLXN_14(63:0)" />
        <signal name="C" />
        <signal name="CLR" />
        <signal name="XLXN_17" />
        <signal name="XLXN_18" />
        <signal name="XLXN_38" />
        <signal name="XLXN_39(63:0)" />
        <signal name="Q(3:0)" />
        <signal name="Q(3:2)" />
        <signal name="Q(1:0)" />
        <signal name="XLXN_45(3:0)" />
        <signal name="XLXN_46(3:0)" />
        <signal name="XLXN_47(3:0)" />
        <port polarity="Output" name="TO_TCL(67:0)" />
        <port polarity="Input" name="FROM_TCL(67:0)" />
        <port polarity="Input" name="C" />
        <port polarity="Input" name="CLR" />
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
        <blockdef name="tester">
            <timestamp>2017-2-20T11:21:40</timestamp>
            <rect width="368" x="64" y="-448" height="448" />
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
            <line x2="496" y1="-416" y2="-416" x1="432" />
            <rect width="64" x="432" y="-300" height="24" />
            <line x2="496" y1="-288" y2="-288" x1="432" />
            <rect width="64" x="432" y="-172" height="24" />
            <line x2="496" y1="-160" y2="-160" x1="432" />
            <rect width="64" x="432" y="-44" height="24" />
            <line x2="496" y1="-32" y2="-32" x1="432" />
        </blockdef>
        <block symbolname="CS_Entity" name="XLXI_10">
            <blockpin signalname="C" name="CLK" />
            <blockpin signalname="CLR" name="CLR_IN" />
            <blockpin signalname="FROM_TCL(67:0)" name="FROM_TCL_IN(67:0)" />
            <blockpin signalname="DATA_OUT(67:0)" name="FROM_VHD_IN(67:0)" />
            <blockpin signalname="XLXN_38" name="CLR_OUT" />
            <blockpin signalname="DATA_IN(67:0)" name="FROM_TCL_OUT(67:0)" />
            <blockpin signalname="TO_TCL(67:0)" name="FROM_VHD_OUT(67:0)" />
        </block>
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
        <block symbolname="tester" name="XLXI_19">
            <blockpin signalname="C" name="CLK" />
            <blockpin signalname="XLXN_38" name="CLR" />
            <blockpin signalname="Q(3:0)" name="q1(3:0)" />
            <blockpin signalname="Q(3:0)" name="q2(3:0)" />
            <blockpin signalname="Q(3:0)" name="number2_q1(3:0)" />
            <blockpin signalname="Q(3:0)" name="number2_q2(3:0)" />
            <blockpin signalname="XLXN_26(63:0)" name="DATA_IN(63:0)" />
            <blockpin name="CLR_O" />
            <blockpin signalname="Q(1:0)" name="dd(1:0)" />
            <blockpin signalname="Q(3:2)" name="number2_dd(1:0)" />
            <blockpin signalname="XLXN_28(63:0)" name="DATA_OUT(63:0)" />
        </block>
    </netlist>
    <sheet sheetnum="1" width="5440" height="3520">
        <instance x="1248" y="1808" name="XLXI_10" orien="R0">
        </instance>
        <branch name="DATA_IN(67:0)">
            <attrtext style="alignment:SOFT-LEFT;fontsize:28;fontname:Arial" attrname="Name" x="2160" y="1584" type="branch" />
            <wire x2="2160" y1="1584" y2="1584" x1="1888" />
        </branch>
        <branch name="TO_TCL(67:0)">
            <wire x2="880" y1="1904" y2="1904" x1="864" />
            <wire x2="864" y1="1904" y2="2000" x1="864" />
            <wire x2="1904" y1="2000" y2="2000" x1="864" />
            <wire x2="1904" y1="1776" y2="1776" x1="1888" />
            <wire x2="1904" y1="1776" y2="2000" x1="1904" />
        </branch>
        <branch name="FROM_TCL(67:0)">
            <wire x2="1248" y1="1712" y2="1712" x1="1136" />
        </branch>
        <bustap x2="1936" y1="1584" y2="1488" x1="1936" />
        <bustap x2="2016" y1="1584" y2="1488" x1="2016" />
        <branch name="DATA_IN(3:2)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="2096" y="1440" type="branch" />
            <wire x2="2016" y1="1440" y2="1488" x1="2016" />
            <wire x2="2096" y1="1440" y2="1440" x1="2016" />
            <wire x2="2208" y1="1440" y2="1440" x1="2096" />
        </branch>
        <branch name="DATA_IN(67:4)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="2048" y="1376" type="branch" />
            <wire x2="1936" y1="1376" y2="1488" x1="1936" />
            <wire x2="2048" y1="1376" y2="1376" x1="1936" />
            <wire x2="2208" y1="1376" y2="1376" x1="2048" />
        </branch>
        <branch name="DATA_IN(1:0)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="2080" y="2000" type="branch" />
            <wire x2="1984" y1="1680" y2="2000" x1="1984" />
            <wire x2="2080" y1="2000" y2="2000" x1="1984" />
            <wire x2="2176" y1="2000" y2="2000" x1="2080" />
        </branch>
        <branch name="DATA_OUT(67:0)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="2560" y="2256" type="branch" />
            <wire x2="1248" y1="1776" y2="1776" x1="1200" />
            <wire x2="1200" y1="1776" y2="2256" x1="1200" />
            <wire x2="2560" y1="2256" y2="2256" x1="1200" />
            <wire x2="2896" y1="2256" y2="2256" x1="2560" />
        </branch>
        <branch name="DATA_OUT(67:4)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="2784" y="2064" type="branch" />
            <wire x2="2784" y1="2064" y2="2064" x1="2656" />
            <wire x2="2784" y1="2064" y2="2160" x1="2784" />
        </branch>
        <branch name="DATA_OUT(1:0)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="2752" y="1872" type="branch" />
            <wire x2="2752" y1="1872" y2="1872" x1="2656" />
            <wire x2="2816" y1="1872" y2="1872" x1="2752" />
            <wire x2="2816" y1="1872" y2="2160" x1="2816" />
        </branch>
        <branch name="DATA_OUT(3:2)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="2800" y="1312" type="branch" />
            <wire x2="2800" y1="1312" y2="1312" x1="2688" />
            <wire x2="2848" y1="1312" y2="1312" x1="2800" />
            <wire x2="2848" y1="1312" y2="2160" x1="2848" />
        </branch>
        <branch name="XLXN_26(63:0)">
            <wire x2="3200" y1="1376" y2="1376" x1="2688" />
            <wire x2="3200" y1="1376" y2="1440" x1="3200" />
            <wire x2="3328" y1="1440" y2="1440" x1="3200" />
        </branch>
        <branch name="XLXN_28(63:0)">
            <wire x2="2176" y1="2064" y2="2064" x1="2160" />
            <wire x2="2160" y1="2064" y2="2112" x1="2160" />
            <wire x2="4320" y1="2112" y2="2112" x1="2160" />
            <wire x2="4320" y1="1440" y2="1440" x1="3824" />
            <wire x2="4320" y1="1440" y2="2112" x1="4320" />
        </branch>
        <rect width="300" x="852" y="1552" height="404" />
        <text style="fontsize:40;fontname:Arial" x="948" y="1580">SCRIPT</text>
        <branch name="C">
            <wire x2="1200" y1="1056" y2="1056" x1="1152" />
            <wire x2="1200" y1="1056" y2="1584" x1="1200" />
            <wire x2="1248" y1="1584" y2="1584" x1="1200" />
            <wire x2="2144" y1="1056" y2="1056" x1="1200" />
            <wire x2="2144" y1="1056" y2="1248" x1="2144" />
            <wire x2="2208" y1="1248" y2="1248" x1="2144" />
            <wire x2="2144" y1="1248" y2="1872" x1="2144" />
            <wire x2="2176" y1="1872" y2="1872" x1="2144" />
            <wire x2="3328" y1="1056" y2="1056" x1="2144" />
        </branch>
        <instance x="2208" y="1408" name="XLXI_13" orien="R0">
        </instance>
        <bustap x2="1984" y1="1584" y2="1680" x1="1984" />
        <instance x="2176" y="2096" name="XLXI_14" orien="R0">
        </instance>
        <bustap x2="2784" y1="2256" y2="2160" x1="2784" />
        <bustap x2="2816" y1="2256" y2="2160" x1="2816" />
        <bustap x2="2848" y1="2256" y2="2160" x1="2848" />
        <rect width="1760" x="1176" y="1068" height="1344" />
        <text style="fontsize:40;fontname:Arial" x="2012" y="1116">BLACK BOX</text>
        <branch name="CLR">
            <wire x2="1248" y1="1840" y2="1840" x1="1136" />
        </branch>
        <branch name="XLXN_38">
            <wire x2="2112" y1="1840" y2="1840" x1="1888" />
            <wire x2="2112" y1="1840" y2="1936" x1="2112" />
            <wire x2="2176" y1="1936" y2="1936" x1="2112" />
            <wire x2="2112" y1="1120" y2="1312" x1="2112" />
            <wire x2="2208" y1="1312" y2="1312" x1="2112" />
            <wire x2="2112" y1="1312" y2="1840" x1="2112" />
            <wire x2="3328" y1="1120" y2="1120" x1="2112" />
        </branch>
        <rect width="1348" x="2984" y="992" height="1420" />
        <text style="fontsize:40;fontname:Arial" x="3596" y="2360">USER</text>
        <iomarker fontsize="28" x="880" y="1904" name="TO_TCL(67:0)" orien="R0" />
        <iomarker fontsize="28" x="1136" y="1712" name="FROM_TCL(67:0)" orien="R180" />
        <iomarker fontsize="28" x="1136" y="1840" name="CLR" orien="R180" />
        <iomarker fontsize="28" x="1152" y="1056" name="C" orien="R180" />
        <instance x="3328" y="1472" name="XLXI_19" orien="R0">
        </instance>
        <branch name="Q(3:0)">
            <attrtext style="alignment:SOFT-VRIGHT;fontsize:28;fontname:Arial" attrname="Name" x="3264" y="1616" type="branch" />
            <wire x2="3328" y1="1184" y2="1184" x1="3264" />
            <wire x2="3264" y1="1184" y2="1248" x1="3264" />
            <wire x2="3328" y1="1248" y2="1248" x1="3264" />
            <wire x2="3264" y1="1248" y2="1312" x1="3264" />
            <wire x2="3328" y1="1312" y2="1312" x1="3264" />
            <wire x2="3264" y1="1312" y2="1376" x1="3264" />
            <wire x2="3328" y1="1376" y2="1376" x1="3264" />
            <wire x2="3264" y1="1376" y2="1536" x1="3264" />
            <wire x2="3264" y1="1536" y2="1584" x1="3264" />
            <wire x2="3264" y1="1584" y2="1616" x1="3264" />
        </branch>
        <bustap x2="3360" y1="1584" y2="1584" x1="3264" />
        <bustap x2="3360" y1="1536" y2="1536" x1="3264" />
        <branch name="Q(3:2)">
            <wire x2="3904" y1="1536" y2="1536" x1="3360" />
            <wire x2="3904" y1="1312" y2="1312" x1="3824" />
            <wire x2="3904" y1="1312" y2="1536" x1="3904" />
        </branch>
        <branch name="Q(1:0)">
            <wire x2="3888" y1="1584" y2="1584" x1="3360" />
            <wire x2="3888" y1="1184" y2="1184" x1="3824" />
            <wire x2="3888" y1="1184" y2="1584" x1="3888" />
        </branch>
    </sheet>
</drawing>