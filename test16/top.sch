<?xml version="1.0" encoding="UTF-8"?>
<drawing version="7">
    <attr value="spartan6" name="DeviceFamilyName">
        <trait delete="all:0" />
        <trait editname="all:0" />
        <trait edittrait="all:0" />
    </attr>
    <netlist>
        <signal name="BUF_IN_CHECK(1:0)" />
        <signal name="DATA_IN(67:0)" />
        <signal name="CHECK_IN(1:0)" />
        <signal name="CLK" />
        <signal name="CLR" />
        <signal name="BUF_IN_DATA(63:0)" />
        <signal name="ENABLE" />
        <signal name="XLXN_9(67:0)" />
        <port polarity="Output" name="BUF_IN_CHECK(1:0)" />
        <port polarity="Input" name="DATA_IN(67:0)" />
        <port polarity="Output" name="CHECK_IN(1:0)" />
        <port polarity="Input" name="CLK" />
        <port polarity="Input" name="CLR" />
        <port polarity="Output" name="BUF_IN_DATA(63:0)" />
        <port polarity="Output" name="ENABLE" />
        <blockdef name="InBuffer">
            <timestamp>2016-12-18T12:2:41</timestamp>
            <rect width="352" x="64" y="-192" height="192" />
            <line x2="0" y1="-160" y2="-160" x1="64" />
            <line x2="0" y1="-96" y2="-96" x1="64" />
            <rect width="64" x="0" y="-44" height="24" />
            <line x2="0" y1="-32" y2="-32" x1="64" />
            <line x2="480" y1="-160" y2="-160" x1="416" />
            <rect width="64" x="416" y="-108" height="24" />
            <line x2="480" y1="-96" y2="-96" x1="416" />
            <rect width="64" x="416" y="-44" height="24" />
            <line x2="480" y1="-32" y2="-32" x1="416" />
        </blockdef>
        <blockdef name="CS">
            <timestamp>2016-12-18T12:5:43</timestamp>
            <rect width="432" x="64" y="-384" height="384" />
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
            <rect width="64" x="496" y="-364" height="24" />
            <line x2="560" y1="-352" y2="-352" x1="496" />
            <rect width="64" x="496" y="-268" height="24" />
            <line x2="560" y1="-256" y2="-256" x1="496" />
            <rect width="64" x="496" y="-172" height="24" />
            <line x2="560" y1="-160" y2="-160" x1="496" />
            <rect width="64" x="496" y="-76" height="24" />
            <line x2="560" y1="-64" y2="-64" x1="496" />
        </blockdef>
        <block symbolname="InBuffer" name="XLXI_1">
            <blockpin signalname="CLK" name="CLK" />
            <blockpin signalname="CLR" name="CLR" />
            <blockpin signalname="XLXN_9(67:0)" name="DATA_IN(67:0)" />
            <blockpin signalname="ENABLE" name="ENABLE" />
            <blockpin signalname="BUF_IN_CHECK(1:0)" name="STATE_OUT(1:0)" />
            <blockpin signalname="BUF_IN_DATA(63:0)" name="DATA_OUT(63:0)" />
        </block>
        <block symbolname="CS" name="XLXI_2">
            <blockpin signalname="CLK" name="CLK" />
            <blockpin signalname="CLR" name="CLR" />
            <blockpin signalname="DATA_IN(67:0)" name="DATA_IN_I(67:0)" />
            <blockpin signalname="BUF_IN_CHECK(1:0)" name="CHECK_IN_I(1:0)" />
            <blockpin name="DATA_OUT_I(67:0)" />
            <blockpin name="CHECK_OUT_I(1:0)" />
            <blockpin signalname="XLXN_9(67:0)" name="DATA_IN_O(67:0)" />
            <blockpin signalname="CHECK_IN(1:0)" name="CHECK_IN_O(1:0)" />
            <blockpin name="DATA_OUT_O(67:0)" />
            <blockpin name="CHECK_OUT_O(1:0)" />
        </block>
    </netlist>
    <sheet sheetnum="1" width="3520" height="2720">
        <instance x="2000" y="1232" name="XLXI_1" orien="R0">
        </instance>
        <instance x="1248" y="1552" name="XLXI_2" orien="R0">
        </instance>
        <branch name="BUF_IN_CHECK(1:0)">
            <wire x2="1184" y1="960" y2="1392" x1="1184" />
            <wire x2="1248" y1="1392" y2="1392" x1="1184" />
            <wire x2="2560" y1="960" y2="960" x1="1184" />
            <wire x2="2560" y1="960" y2="1136" x1="2560" />
            <wire x2="2688" y1="1136" y2="1136" x1="2560" />
            <wire x2="2560" y1="1136" y2="1136" x1="2480" />
        </branch>
        <branch name="DATA_IN(67:0)">
            <wire x2="1248" y1="1328" y2="1328" x1="1120" />
        </branch>
        <branch name="CHECK_IN(1:0)">
            <wire x2="1856" y1="1296" y2="1296" x1="1808" />
        </branch>
        <iomarker fontsize="28" x="1856" y="1296" name="CHECK_IN(1:0)" orien="R0" />
        <branch name="CLK">
            <wire x2="1136" y1="1072" y2="1072" x1="928" />
            <wire x2="2000" y1="1072" y2="1072" x1="1136" />
            <wire x2="1136" y1="1072" y2="1200" x1="1136" />
            <wire x2="1248" y1="1200" y2="1200" x1="1136" />
        </branch>
        <iomarker fontsize="28" x="928" y="1072" name="CLK" orien="R180" />
        <branch name="CLR">
            <wire x2="1072" y1="1136" y2="1136" x1="928" />
            <wire x2="2000" y1="1136" y2="1136" x1="1072" />
            <wire x2="1072" y1="1136" y2="1264" x1="1072" />
            <wire x2="1248" y1="1264" y2="1264" x1="1072" />
        </branch>
        <iomarker fontsize="28" x="928" y="1136" name="CLR" orien="R180" />
        <branch name="BUF_IN_DATA(63:0)">
            <wire x2="2688" y1="1200" y2="1200" x1="2480" />
        </branch>
        <iomarker fontsize="28" x="2688" y="1200" name="BUF_IN_DATA(63:0)" orien="R0" />
        <branch name="ENABLE">
            <wire x2="2688" y1="1072" y2="1072" x1="2480" />
        </branch>
        <iomarker fontsize="28" x="2688" y="1072" name="ENABLE" orien="R0" />
        <iomarker fontsize="28" x="2688" y="1136" name="BUF_IN_CHECK(1:0)" orien="R0" />
        <iomarker fontsize="28" x="1120" y="1328" name="DATA_IN(67:0)" orien="R180" />
        <branch name="XLXN_9(67:0)">
            <wire x2="2000" y1="1200" y2="1200" x1="1808" />
        </branch>
    </sheet>
</drawing>