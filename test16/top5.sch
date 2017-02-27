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
        <signal name="XLXN_3(67:0)" />
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
        <signal name="XLXN_12(63:0)" />
        <signal name="C" />
        <signal name="CLR" />
        <signal name="XLXN_15" />
        <signal name="XLXN_38" />
        <signal name="XLXN_18(1:0)" />
        <signal name="XLXN_19(1:0)" />
        <signal name="XLXN_39(3:0)" />
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
        <blockdef name="inc">
            <timestamp>2017-2-21T23:41:18</timestamp>
            <rect width="352" x="64" y="-256" height="256" />
            <line x2="0" y1="-224" y2="-224" x1="64" />
            <line x2="0" y1="-160" y2="-160" x1="64" />
            <rect width="64" x="0" y="-108" height="24" />
            <line x2="0" y1="-96" y2="-96" x1="64" />
            <rect width="64" x="0" y="-44" height="24" />
            <line x2="0" y1="-32" y2="-32" x1="64" />
            <line x2="480" y1="-224" y2="-224" x1="416" />
            <rect width="64" x="416" y="-140" height="24" />
            <line x2="480" y1="-128" y2="-128" x1="416" />
            <rect width="64" x="416" y="-44" height="24" />
            <line x2="480" y1="-32" y2="-32" x1="416" />
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
        <block symbolname="inc" name="XLXI_20">
            <blockpin signalname="C" name="CLK" />
            <blockpin signalname="XLXN_38" name="CLR" />
            <blockpin signalname="XLXN_39(3:0)" name="d(3:0)" />
            <blockpin signalname="XLXN_26(63:0)" name="DATA_IN(63:0)" />
            <blockpin name="CLR_O" />
            <blockpin signalname="XLXN_39(3:0)" name="q(3:0)" />
            <blockpin signalname="XLXN_28(63:0)" name="DATA_OUT(63:0)" />
        </block>
    </netlist>
    <sheet sheetnum="1" width="5440" height="3520">
        <instance x="1344" y="1776" name="XLXI_10" orien="R0">
        </instance>
        <branch name="DATA_IN(67:0)">
            <attrtext style="alignment:SOFT-LEFT;fontsize:28;fontname:Arial" attrname="Name" x="2256" y="1552" type="branch" />
            <wire x2="2256" y1="1552" y2="1552" x1="1984" />
        </branch>
        <branch name="TO_TCL(67:0)">
            <wire x2="976" y1="1872" y2="1872" x1="960" />
            <wire x2="960" y1="1872" y2="1968" x1="960" />
            <wire x2="2000" y1="1968" y2="1968" x1="960" />
            <wire x2="2000" y1="1744" y2="1744" x1="1984" />
            <wire x2="2000" y1="1744" y2="1968" x1="2000" />
        </branch>
        <branch name="FROM_TCL(67:0)">
            <wire x2="1344" y1="1680" y2="1680" x1="1232" />
        </branch>
        <bustap x2="2032" y1="1552" y2="1456" x1="2032" />
        <bustap x2="2112" y1="1552" y2="1456" x1="2112" />
        <branch name="DATA_IN(3:2)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="2192" y="1408" type="branch" />
            <wire x2="2112" y1="1408" y2="1456" x1="2112" />
            <wire x2="2192" y1="1408" y2="1408" x1="2112" />
            <wire x2="2304" y1="1408" y2="1408" x1="2192" />
        </branch>
        <branch name="DATA_IN(67:4)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="2144" y="1344" type="branch" />
            <wire x2="2032" y1="1344" y2="1456" x1="2032" />
            <wire x2="2144" y1="1344" y2="1344" x1="2032" />
            <wire x2="2304" y1="1344" y2="1344" x1="2144" />
        </branch>
        <branch name="DATA_IN(1:0)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="2176" y="1968" type="branch" />
            <wire x2="2080" y1="1648" y2="1968" x1="2080" />
            <wire x2="2176" y1="1968" y2="1968" x1="2080" />
            <wire x2="2272" y1="1968" y2="1968" x1="2176" />
        </branch>
        <branch name="DATA_OUT(67:0)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="2656" y="2224" type="branch" />
            <wire x2="1344" y1="1744" y2="1744" x1="1296" />
            <wire x2="1296" y1="1744" y2="2224" x1="1296" />
            <wire x2="2656" y1="2224" y2="2224" x1="1296" />
            <wire x2="2992" y1="2224" y2="2224" x1="2656" />
        </branch>
        <branch name="DATA_OUT(67:4)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="2880" y="2032" type="branch" />
            <wire x2="2880" y1="2032" y2="2032" x1="2752" />
            <wire x2="2880" y1="2032" y2="2128" x1="2880" />
        </branch>
        <branch name="DATA_OUT(1:0)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="2848" y="1840" type="branch" />
            <wire x2="2848" y1="1840" y2="1840" x1="2752" />
            <wire x2="2912" y1="1840" y2="1840" x1="2848" />
            <wire x2="2912" y1="1840" y2="2128" x1="2912" />
        </branch>
        <branch name="DATA_OUT(3:2)">
            <attrtext style="alignment:SOFT-BCENTER;fontsize:28;fontname:Arial" attrname="Name" x="2896" y="1280" type="branch" />
            <wire x2="2896" y1="1280" y2="1280" x1="2784" />
            <wire x2="2944" y1="1280" y2="1280" x1="2896" />
            <wire x2="2944" y1="1280" y2="2128" x1="2944" />
        </branch>
        <branch name="XLXN_26(63:0)">
            <wire x2="3296" y1="1344" y2="1344" x1="2784" />
            <wire x2="3424" y1="1216" y2="1216" x1="3296" />
            <wire x2="3296" y1="1216" y2="1344" x1="3296" />
        </branch>
        <branch name="XLXN_28(63:0)">
            <wire x2="2272" y1="2032" y2="2032" x1="2256" />
            <wire x2="2256" y1="2032" y2="2080" x1="2256" />
            <wire x2="4416" y1="2080" y2="2080" x1="2256" />
            <wire x2="4416" y1="1216" y2="1216" x1="3904" />
            <wire x2="4416" y1="1216" y2="2080" x1="4416" />
        </branch>
        <rect width="300" x="948" y="1520" height="404" />
        <text style="fontsize:40;fontname:Arial" x="1044" y="1548">SCRIPT</text>
        <branch name="C">
            <wire x2="1296" y1="1024" y2="1024" x1="1248" />
            <wire x2="1296" y1="1024" y2="1552" x1="1296" />
            <wire x2="1344" y1="1552" y2="1552" x1="1296" />
            <wire x2="2240" y1="1024" y2="1024" x1="1296" />
            <wire x2="2240" y1="1024" y2="1216" x1="2240" />
            <wire x2="2304" y1="1216" y2="1216" x1="2240" />
            <wire x2="2240" y1="1216" y2="1840" x1="2240" />
            <wire x2="2272" y1="1840" y2="1840" x1="2240" />
            <wire x2="3424" y1="1024" y2="1024" x1="2240" />
        </branch>
        <instance x="2304" y="1376" name="XLXI_13" orien="R0">
        </instance>
        <bustap x2="2080" y1="1552" y2="1648" x1="2080" />
        <instance x="2272" y="2064" name="XLXI_14" orien="R0">
        </instance>
        <bustap x2="2880" y1="2224" y2="2128" x1="2880" />
        <bustap x2="2912" y1="2224" y2="2128" x1="2912" />
        <bustap x2="2944" y1="2224" y2="2128" x1="2944" />
        <rect width="1744" x="1272" y="1036" height="1344" />
        <text style="fontsize:40;fontname:Arial" x="2108" y="1084">BLACK BOX</text>
        <branch name="CLR">
            <wire x2="1344" y1="1808" y2="1808" x1="1232" />
        </branch>
        <branch name="XLXN_38">
            <wire x2="2208" y1="1808" y2="1808" x1="1984" />
            <wire x2="2208" y1="1808" y2="1904" x1="2208" />
            <wire x2="2272" y1="1904" y2="1904" x1="2208" />
            <wire x2="2208" y1="1088" y2="1280" x1="2208" />
            <wire x2="2304" y1="1280" y2="1280" x1="2208" />
            <wire x2="2208" y1="1280" y2="1808" x1="2208" />
            <wire x2="3424" y1="1088" y2="1088" x1="2208" />
        </branch>
        <rect width="1200" x="3228" y="960" height="1420" />
        <text style="fontsize:40;fontname:Arial" x="3692" y="2328">USER</text>
        <iomarker fontsize="28" x="976" y="1872" name="TO_TCL(67:0)" orien="R0" />
        <iomarker fontsize="28" x="1232" y="1680" name="FROM_TCL(67:0)" orien="R180" />
        <iomarker fontsize="28" x="1232" y="1808" name="CLR" orien="R180" />
        <iomarker fontsize="28" x="1248" y="1024" name="C" orien="R180" />
        <instance x="3424" y="1248" name="XLXI_20" orien="R0">
        </instance>
        <branch name="XLXN_39(3:0)">
            <wire x2="3424" y1="1152" y2="1152" x1="3344" />
            <wire x2="3344" y1="1152" y2="1312" x1="3344" />
            <wire x2="3984" y1="1312" y2="1312" x1="3344" />
            <wire x2="3984" y1="1120" y2="1120" x1="3904" />
            <wire x2="3984" y1="1120" y2="1312" x1="3984" />
        </branch>
        <rect style="linewidth:W;linecolor:rgb(0,128,0);linestyle:Dot;fillcolor:rgb(192,220,192)" width="60" x="3044" y="996" height="1108" />
        <text style="alignment:VLEFT;fontsize:64;fontname:Arial" x="3072" y="1828">Interface</text>
    </sheet>
</drawing>