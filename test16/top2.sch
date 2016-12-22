<?xml version="1.0" encoding="UTF-8"?>
<drawing version="7">
    <attr value="spartan6" name="DeviceFamilyName">
        <trait delete="all:0" />
        <trait editname="all:0" />
        <trait edittrait="all:0" />
    </attr>
    <netlist>
        <signal name="XLXN_18" />
        <signal name="BUF_IN_CHECK(1:0)" />
        <signal name="DATA_IN(67:0)" />
        <signal name="CHECK_IN(1:0)" />
        <signal name="CLK" />
        <signal name="CLR" />
        <signal name="BUF_IN_DATA(63:0)" />
        <signal name="XLXN_27" />
        <signal name="ENABLE" />
        <signal name="XLXN_9(67:0)" />
        <signal name="DO1(63:0)" />
        <signal name="DO2(63:0)" />
        <signal name="XLXN_32" />
        <port polarity="Output" name="BUF_IN_CHECK(1:0)" />
        <port polarity="Input" name="DATA_IN(67:0)" />
        <port polarity="Output" name="CHECK_IN(1:0)" />
        <port polarity="Input" name="CLK" />
        <port polarity="Input" name="CLR" />
        <port polarity="Output" name="BUF_IN_DATA(63:0)" />
        <port polarity="Output" name="ENABLE" />
        <port polarity="Output" name="DO1(63:0)" />
        <port polarity="Output" name="DO2(63:0)" />
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
        <blockdef name="item">
            <timestamp>2016-12-19T22:17:58</timestamp>
            <rect width="352" x="64" y="-192" height="192" />
            <line x2="0" y1="-160" y2="-160" x1="64" />
            <line x2="0" y1="-96" y2="-96" x1="64" />
            <rect width="64" x="0" y="-44" height="24" />
            <line x2="0" y1="-32" y2="-32" x1="64" />
            <rect width="64" x="416" y="-172" height="24" />
            <line x2="480" y1="-160" y2="-160" x1="416" />
        </blockdef>
        <blockdef name="item2">
            <timestamp>2016-12-19T22:17:31</timestamp>
            <rect width="352" x="64" y="-192" height="192" />
            <line x2="0" y1="-160" y2="-160" x1="64" />
            <line x2="0" y1="-96" y2="-96" x1="64" />
            <rect width="64" x="0" y="-44" height="24" />
            <line x2="0" y1="-32" y2="-32" x1="64" />
            <rect width="64" x="416" y="-172" height="24" />
            <line x2="480" y1="-160" y2="-160" x1="416" />
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
        <block symbolname="item" name="XLXI_5">
            <blockpin signalname="CLK" name="CLK" />
            <blockpin signalname="CLR" name="CLR" />
            <blockpin signalname="BUF_IN_DATA(63:0)" name="DATA_IN(63:0)" />
            <blockpin signalname="DO1(63:0)" name="DATA_OUT(63:0)" />
        </block>
        <block symbolname="item2" name="XLXI_6">
            <blockpin signalname="CLK" name="CLK" />
            <blockpin signalname="CLR" name="CLR" />
            <blockpin signalname="DO1(63:0)" name="DATA_IN(63:0)" />
            <blockpin signalname="DO2(63:0)" name="DATA_OUT(63:0)" />
        </block>
    </netlist>
    <sheet sheetnum="1" width="3520" height="2720">
        <instance x="1216" y="1136" name="XLXI_1" orien="R0">
        </instance>
        <instance x="464" y="1456" name="XLXI_2" orien="R0">
        </instance>
        <branch name="BUF_IN_CHECK(1:0)">
            <wire x2="400" y1="768" y2="1296" x1="400" />
            <wire x2="464" y1="1296" y2="1296" x1="400" />
            <wire x2="1792" y1="768" y2="768" x1="400" />
            <wire x2="1856" y1="768" y2="768" x1="1792" />
            <wire x2="1792" y1="768" y2="1040" x1="1792" />
            <wire x2="1792" y1="1040" y2="1040" x1="1696" />
        </branch>
        <branch name="DATA_IN(67:0)">
            <wire x2="464" y1="1232" y2="1232" x1="336" />
        </branch>
        <branch name="CHECK_IN(1:0)">
            <wire x2="1072" y1="1200" y2="1200" x1="1024" />
        </branch>
        <branch name="CLK">
            <wire x2="352" y1="976" y2="976" x1="144" />
            <wire x2="352" y1="976" y2="1104" x1="352" />
            <wire x2="464" y1="1104" y2="1104" x1="352" />
            <wire x2="1072" y1="976" y2="976" x1="352" />
            <wire x2="1216" y1="976" y2="976" x1="1072" />
            <wire x2="1072" y1="848" y2="976" x1="1072" />
            <wire x2="1968" y1="848" y2="848" x1="1072" />
            <wire x2="2576" y1="848" y2="848" x1="1968" />
            <wire x2="2576" y1="848" y2="960" x1="2576" />
            <wire x2="2608" y1="960" y2="960" x1="2576" />
            <wire x2="1968" y1="848" y2="976" x1="1968" />
            <wire x2="2000" y1="976" y2="976" x1="1968" />
        </branch>
        <branch name="CLR">
            <wire x2="288" y1="1040" y2="1040" x1="144" />
            <wire x2="288" y1="1040" y2="1168" x1="288" />
            <wire x2="464" y1="1168" y2="1168" x1="288" />
            <wire x2="1168" y1="1040" y2="1040" x1="288" />
            <wire x2="1216" y1="1040" y2="1040" x1="1168" />
            <wire x2="1168" y1="896" y2="1040" x1="1168" />
            <wire x2="1872" y1="896" y2="896" x1="1168" />
            <wire x2="1872" y1="896" y2="1040" x1="1872" />
            <wire x2="2000" y1="1040" y2="1040" x1="1872" />
            <wire x2="2544" y1="896" y2="896" x1="1872" />
            <wire x2="2544" y1="896" y2="1024" x1="2544" />
            <wire x2="2608" y1="1024" y2="1024" x1="2544" />
        </branch>
        <branch name="BUF_IN_DATA(63:0)">
            <wire x2="1824" y1="1104" y2="1104" x1="1696" />
            <wire x2="2000" y1="1104" y2="1104" x1="1824" />
            <wire x2="1824" y1="1104" y2="1216" x1="1824" />
            <wire x2="1840" y1="1216" y2="1216" x1="1824" />
        </branch>
        <branch name="ENABLE">
            <wire x2="1712" y1="976" y2="976" x1="1696" />
            <wire x2="1952" y1="608" y2="608" x1="1712" />
            <wire x2="1712" y1="608" y2="976" x1="1712" />
        </branch>
        <branch name="XLXN_9(67:0)">
            <wire x2="1216" y1="1104" y2="1104" x1="1024" />
        </branch>
        <instance x="2000" y="1136" name="XLXI_5" orien="R0">
        </instance>
        <instance x="2608" y="1120" name="XLXI_6" orien="R0">
        </instance>
        <branch name="DO1(63:0)">
            <wire x2="2512" y1="976" y2="976" x1="2480" />
            <wire x2="2512" y1="976" y2="1088" x1="2512" />
            <wire x2="2608" y1="1088" y2="1088" x1="2512" />
            <wire x2="2512" y1="1088" y2="1136" x1="2512" />
        </branch>
        <branch name="DO2(63:0)">
            <wire x2="3136" y1="960" y2="960" x1="3088" />
            <wire x2="3136" y1="960" y2="1120" x1="3136" />
        </branch>
        <iomarker fontsize="28" x="1072" y="1200" name="CHECK_IN(1:0)" orien="R0" />
        <iomarker fontsize="28" x="144" y="976" name="CLK" orien="R180" />
        <iomarker fontsize="28" x="144" y="1040" name="CLR" orien="R180" />
        <iomarker fontsize="28" x="336" y="1232" name="DATA_IN(67:0)" orien="R180" />
        <iomarker fontsize="28" x="1952" y="608" name="ENABLE" orien="R0" />
        <iomarker fontsize="28" x="2512" y="1136" name="DO1(63:0)" orien="R90" />
        <iomarker fontsize="28" x="3136" y="1120" name="DO2(63:0)" orien="R90" />
        <iomarker fontsize="28" x="1840" y="1216" name="BUF_IN_DATA(63:0)" orien="R0" />
        <iomarker fontsize="28" x="1856" y="768" name="BUF_IN_CHECK(1:0)" orien="R0" />
    </sheet>
</drawing>