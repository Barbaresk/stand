<?xml version="1.0" encoding="UTF-8"?>
<drawing version="7">
    <attr value="spartan6" name="DeviceFamilyName">
        <trait delete="all:0" />
        <trait editname="all:0" />
        <trait edittrait="all:0" />
    </attr>
    <netlist>
        <signal name="XLXN_44(67:4)" />
        <signal name="XLXN_45(3:2)" />
        <signal name="XLXN_46(1:0)" />
        <signal name="XLXN_47(67:4)" />
        <signal name="XLXN_48(3:2)" />
        <signal name="XLXN_49(1:0)" />
        <signal name="clk_p" />
        <signal name="XLXN_70(63:0)" />
        <signal name="XLXN_71(63:0)" />
        <signal name="XLXN_72(3:0)" />
        <signal name="XLXN_75" />
        <signal name="XLXN_77" />
        <port polarity="Input" name="clk_p" />
        <blockdef name="InBuffer_Entity">
            <timestamp>2017-3-7T13:49:27</timestamp>
            <rect width="64" x="416" y="84" height="24" />
            <line x2="480" y1="96" y2="96" x1="416" />
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
            <rect width="352" x="64" y="-192" height="320" />
        </blockdef>
        <blockdef name="OutBuffer_Entity">
            <timestamp>2017-3-7T13:46:55</timestamp>
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
            <rect width="352" x="64" y="-256" height="320" />
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
        <block symbolname="InBuffer_Entity" name="XLXI_13">
            <blockpin signalname="XLXN_77" name="CLK" />
            <blockpin signalname="XLXN_75" name="CLR" />
            <blockpin signalname="XLXN_45(3:2)" name="STATE_IN(1:0)" />
            <blockpin signalname="XLXN_44(67:4)" name="DATA_IN(63:0)" />
            <blockpin signalname="XLXN_48(3:2)" name="STATE_OUT(1:0)" />
            <blockpin name="state_buffer_in(2:0)" />
            <blockpin signalname="XLXN_70(63:0)" name="DATA_OUT(63:0)" />
        </block>
        <block symbolname="OutBuffer_Entity" name="XLXI_14">
            <blockpin signalname="XLXN_77" name="CLK" />
            <blockpin signalname="XLXN_75" name="CLR" />
            <blockpin signalname="XLXN_46(1:0)" name="STATE_IN(1:0)" />
            <blockpin signalname="XLXN_71(63:0)" name="DATA_IN(63:0)" />
            <blockpin signalname="XLXN_49(1:0)" name="STATE_OUT(1:0)" />
            <blockpin signalname="XLXN_47(67:4)" name="DATA_OUT(63:0)" />
            <blockpin name="state_buf_out(2:0)" />
        </block>
        <block symbolname="inc" name="XLXI_20">
            <blockpin signalname="XLXN_77" name="CLK" />
            <blockpin signalname="XLXN_75" name="CLR" />
            <blockpin signalname="XLXN_72(3:0)" name="d(3:0)" />
            <blockpin signalname="XLXN_70(63:0)" name="DATA_IN(63:0)" />
            <blockpin name="CLR_O" />
            <blockpin signalname="XLXN_72(3:0)" name="q(3:0)" />
            <blockpin signalname="XLXN_71(63:0)" name="DATA_OUT(63:0)" />
        </block>
        <block symbolname="cs_vio" name="XLXI_23">
            <blockpin signalname="clk_p" name="clk_p" />
            <blockpin signalname="XLXN_47(67:4)" name="data_out(67:4)" />
            <blockpin signalname="XLXN_49(1:0)" name="outbuffer_out(1:0)" />
            <blockpin signalname="XLXN_48(3:2)" name="inbuffer_out(3:2)" />
            <blockpin signalname="XLXN_75" name="clr_out" />
            <blockpin signalname="XLXN_77" name="clk_out" />
            <blockpin signalname="XLXN_44(67:4)" name="data_in(67:4)" />
            <blockpin signalname="XLXN_46(1:0)" name="outbuffer_in(1:0)" />
            <blockpin signalname="XLXN_45(3:2)" name="inbuffer_in(3:2)" />
        </block>
    </netlist>
    <sheet sheetnum="1" width="5440" height="3520">
        <instance x="2304" y="1376" name="XLXI_13" orien="R0">
        </instance>
        <instance x="2272" y="2064" name="XLXI_14" orien="R0">
        </instance>
        <instance x="3424" y="1248" name="XLXI_20" orien="R0">
        </instance>
        <branch name="XLXN_44(67:4)">
            <wire x2="2112" y1="1664" y2="1664" x1="1936" />
            <wire x2="2112" y1="1344" y2="1664" x1="2112" />
            <wire x2="2304" y1="1344" y2="1344" x1="2112" />
        </branch>
        <branch name="XLXN_45(3:2)">
            <wire x2="2288" y1="1792" y2="1792" x1="1936" />
            <wire x2="2304" y1="1408" y2="1408" x1="2288" />
            <wire x2="2288" y1="1408" y2="1792" x1="2288" />
        </branch>
        <branch name="XLXN_46(1:0)">
            <wire x2="2256" y1="1728" y2="1728" x1="1936" />
            <wire x2="2256" y1="1728" y2="1968" x1="2256" />
            <wire x2="2272" y1="1968" y2="1968" x1="2256" />
        </branch>
        <branch name="XLXN_47(67:4)">
            <wire x2="1440" y1="1664" y2="1664" x1="1360" />
            <wire x2="1360" y1="1664" y2="2624" x1="1360" />
            <wire x2="2768" y1="2624" y2="2624" x1="1360" />
            <wire x2="2768" y1="2032" y2="2032" x1="2752" />
            <wire x2="2768" y1="2032" y2="2624" x1="2768" />
        </branch>
        <branch name="XLXN_48(3:2)">
            <wire x2="1392" y1="1504" y2="1792" x1="1392" />
            <wire x2="1440" y1="1792" y2="1792" x1="1392" />
            <wire x2="2800" y1="1504" y2="1504" x1="1392" />
            <wire x2="2800" y1="1280" y2="1280" x1="2784" />
            <wire x2="2800" y1="1280" y2="1504" x1="2800" />
        </branch>
        <branch name="XLXN_49(1:0)">
            <wire x2="1440" y1="1728" y2="1728" x1="1376" />
            <wire x2="1376" y1="1728" y2="2576" x1="1376" />
            <wire x2="2800" y1="2576" y2="2576" x1="1376" />
            <wire x2="2800" y1="1840" y2="1840" x1="2752" />
            <wire x2="2800" y1="1840" y2="2576" x1="2800" />
        </branch>
        <instance x="1440" y="1824" name="XLXI_23" orien="R0">
        </instance>
        <branch name="clk_p">
            <wire x2="1440" y1="1600" y2="1600" x1="1184" />
        </branch>
        <text style="alignment:VLEFT;fontsize:64;fontname:Arial" x="3076" y="1828">Interface</text>
        <rect width="1744" x="1264" y="1052" height="1624" />
        <branch name="XLXN_70(63:0)">
            <wire x2="3104" y1="1344" y2="1344" x1="2784" />
            <wire x2="3104" y1="1216" y2="1344" x1="3104" />
            <wire x2="3424" y1="1216" y2="1216" x1="3104" />
        </branch>
        <branch name="XLXN_71(63:0)">
            <wire x2="2272" y1="2032" y2="2032" x1="2208" />
            <wire x2="2208" y1="2032" y2="2368" x1="2208" />
            <wire x2="4304" y1="2368" y2="2368" x1="2208" />
            <wire x2="4304" y1="1216" y2="1216" x1="3904" />
            <wire x2="4304" y1="1216" y2="2368" x1="4304" />
        </branch>
        <branch name="XLXN_72(3:0)">
            <wire x2="3424" y1="1152" y2="1152" x1="3344" />
            <wire x2="3344" y1="1152" y2="1488" x1="3344" />
            <wire x2="3968" y1="1488" y2="1488" x1="3344" />
            <wire x2="3968" y1="1120" y2="1120" x1="3904" />
            <wire x2="3968" y1="1120" y2="1488" x1="3968" />
        </branch>
        <branch name="XLXN_75">
            <wire x2="2096" y1="1600" y2="1600" x1="1936" />
            <wire x2="2096" y1="1280" y2="1600" x1="2096" />
            <wire x2="2240" y1="1280" y2="1280" x1="2096" />
            <wire x2="2304" y1="1280" y2="1280" x1="2240" />
            <wire x2="2240" y1="1280" y2="1904" x1="2240" />
            <wire x2="2272" y1="1904" y2="1904" x1="2240" />
            <wire x2="3424" y1="1088" y2="1088" x1="2240" />
            <wire x2="2240" y1="1088" y2="1280" x1="2240" />
        </branch>
        <branch name="XLXN_77">
            <wire x2="2096" y1="1856" y2="1856" x1="1936" />
            <wire x2="3424" y1="1024" y2="1024" x1="2064" />
            <wire x2="2064" y1="1024" y2="1216" x1="2064" />
            <wire x2="2064" y1="1216" y2="1840" x1="2064" />
            <wire x2="2096" y1="1840" y2="1840" x1="2064" />
            <wire x2="2096" y1="1840" y2="1856" x1="2096" />
            <wire x2="2272" y1="1840" y2="1840" x1="2096" />
            <wire x2="2304" y1="1216" y2="1216" x1="2064" />
        </branch>
        <rect style="linewidth:W;linecolor:rgb(0,128,0);linestyle:Dot;fillcolor:rgb(192,220,192)" width="96" x="3032" y="992" height="1400" />
        <text style="fontsize:52;fontname:Arial" x="1300" y="1092">CHIP SCOPE AND BUFFERS</text>
        <iomarker fontsize="28" x="1184" y="1600" name="clk_p" orien="R180" />
        <rect width="844" x="3296" y="1352" height="804" />
        <text style="fontsize:40;fontname:Arial" x="3644" y="2092">USER</text>
        <rect width="360" x="3484" y="1440" height="364" />
        <rect width="1144" x="3216" y="880" height="412" />
        <text style="fontsize:44;fontname:Arial" x="3464" y="836">GENERATED ELEMENTS</text>
    </sheet>
</drawing>