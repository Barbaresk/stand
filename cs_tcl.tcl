######################################################################
# Copyright (c) 2009 Xilinx, Inc.  All rights reserved.
#
#                 XILINX CONFIDENTIAL PROPERTY                        
# This   document  contains  proprietary information  which   is    
# protected by  copyright. All rights  are reserved. No  part of    
# this  document may be photocopied, reproduced or translated to    
# another  program  language  without  prior written  consent of    
# XILINX Inc., San Jose, CA. 95124                                  
# 
# Xilinx, Inc.
# XILINX IS PROVIDING THIS DESIGN, CODE, OR INFORMATION "AS IS" AS A
# COURTESY TO YOU.  BY PROVIDING THIS DESIGN, CODE, OR INFORMATION AS
# ONE POSSIBLE   IMPLEMENTATION OF THIS FEATURE, APPLICATION OR
# STANDARD, XILINX IS MAKING NO REPRESENTATION THAT THIS IMPLEMENTATION
# IS FREE FROM ANY CLAIMS OF INFRINGEMENT, AND YOU ARE RESPONSIBLE
# FOR OBTAINING ANY RIGHTS YOU MAY REQUIRE FOR YOUR IMPLEMENTATION.
# XILINX EXPRESSLY DISCLAIMS ANY WARRANTY WHATSOEVER WITH RESPECT TO
# THE ADEQUACY OF THE IMPLEMENTATION, INCLUDING BUT NOT LIMITED TO
# ANY WARRANTIES OR REPRESENTATIONS THAT THIS IMPLEMENTATION IS FREE
# FROM CLAIMS OF INFRINGEMENT, IMPLIED WARRANTIES OF MERCHANTABILITY
# AND FITNESS FOR A PARTICULAR PURPOSE.
#
######################################################################

#
#  For Tcl Manual for builtin commands, see
#        http://www.tcl.tk/man/tcl8.4
#
#
#

#  Example scanning devices for VIO cores, in a JTAG Chain,
#  using the Cse api.

# Get the Cse DLL's and globals
if {[info exists env(XIL_CSE_TCL)]} {
    if {[string length $env(XIL_CSE_TCL)] > 0} {
       # puts "Sourcing from XIL_CSE_TCL: $env(XIL_CSE_TCL) ..."
        source $env(XIL_CSE_TCL)/csejtag.tcl
        source $env(XIL_CSE_TCL)/csefpga.tcl
        source $env(XIL_CSE_TCL)/csecore.tcl
        source $env(XIL_CSE_TCL)/csevio.tcl
    } else {
        #puts "Sourcing from XILINX: $env(XILINX)/cse/tcl ..."
        source $env(XILINX)/cse/tcl/csejtag.tcl
        source $env(XILINX)/cse/tcl/csefpga.tcl
        source $env(XILINX)/cse/tcl/csecore.tcl
        source $env(XILINX)/cse/tcl/csevio.tcl
    }
} else {
    #puts "Sourcing from XILINX: $env(XILINX)/cse/tcl ..."
    source $env(XILINX)/cse/tcl/csejtag.tcl
    source $env(XILINX)/cse/tcl/csefpga.tcl
    source $env(XILINX)/cse/tcl/csecore.tcl
    source $env(XILINX)/cse/tcl/csevio.tcl

    #source G:/csejtag.tcl
    #source G:/csefpga.tcl
    #source G:/csecore.tcl
    #source G:/csevio.tcl
}

namespace import ::chipscope::*

# Create global variables
set ILA_STATUS_WORD_BIT_LEN  512

# Parallel IV Cable
set PARALLEL_CABLE_ARGS [list "port=LPT1" \
                              "frequency=2500000"]
                              # "frequency=5000000 | 2500000 | 1250000 | 625000 | 200000"

# Platform USB Cable
set PLATFORM_USB_CABLE_ARGS [list "port=USB2" \
                                  "frequency=3000000"]
                                  # frequency="12000000 | 6000000 | 3000000 | 1500000 | 750000"

# Digilent Cable
# Digilent Cables have default arguments, if there is only one cable
# connected it will automatically connect to it.
set DIGILENT_CABLE_ARGS {}

set CABLE_NAME $CSEJTAG_TARGET_PLATFORMUSB                                 
set CABLE_ARGS $PLATFORM_USB_CABLE_ARGS
set debug 0

proc main {argc argv} {
    global debug
    global PLATFORM_USB_CABLE_ARGS
    global CSEJTAG_TARGET_PLATFORMUSB
    global PARALLEL_CABLE_ARGS
    global CSEJTAG_TARGET_PARALLEL
    global DIGILENT_CABLE_ARGS
    global CSEJTAG_TARGET_DIGILENT
    global CABLE_NAME
    global CABLE_ARGS
    global CSE_MSG_INFO
    #global VVarray
    if {[expr ($argc > 0) && [string equal "-h" [lindex $argv 0]]]} {
        set scriptname [info script]
        writeMessage 0 $CSE_MSG_INFO "\
Usage: xtclsh $scriptname \[-usb\] \[-par\] \[-dig\]\
\n  -usb    Open Platform USB cable, default cable without any flag\
\n  -par    Open Parallel IV cable\
\n  -dig    Open Digilent cable\n"
        exit
    }
    
    # Checks to see if usb or debug flag is set
    for {set i 0} {$i < $argc} {incr i} {
        if {[string equal "-usb" [lindex $argv $i]]} {
            set CABLE_NAME $CSEJTAG_TARGET_PLATFORMUSB
            set CABLE_ARGS $PLATFORM_USB_CABLE_ARGS
        } elseif {[string equal "-par" [lindex $argv $i]]} {
            set CABLE_NAME $CSEJTAG_TARGET_PARALLEL
            set CABLE_ARGS $PARALLEL_CABLE_ARGS
        } elseif {[string equal "-dig" [lindex $argv $i]]} {
            set CABLE_NAME $CSEJTAG_TARGET_DIGILENT
            set CABLE_ARGS $DIGILENT_CABLE_ARGS
        } elseif {[string equal "-d" [lindex $argv $i]]} {
            set debug 1
        }
    }
    
    # Create Session. Pass location of idcode.lst to override default.
    set handle [csejtag_session create "writeMessage" $argv]

    # Scan the JTAG chain
    scanChain $handle	
  
    csejtag_session destroy $handle    
}

proc scanChain {handle } {
    global CABLE_NAME
    global CABLE_ARGS
    global CSE_MSG_ERROR
    global CSE_MSG_INFO
    global CSEJTAG_SCAN_DEFAULT
    global CSEJTAG_LOCKED_ME

    # Open cable
    csejtag_target open $handle \
                        $CABLE_NAME \
                        0 \
                        $CABLE_ARGS

    # CseJtag_session sendMessage will call the messageRouter
    # function specified in csejtag_session create
    csejtag_session send_message $handle $CSE_MSG_INFO "Open Cable successfully\n"
    
    # Need to lock cable before actually accessing JTAG chain
    set cablelock [csejtag_target lock $handle 5000]
    if {$cablelock != $CSEJTAG_LOCKED_ME} {
        csejtag_session send_message $handle $CSE_MSG_ERROR "cse_lock_target failed"
        csejtag_target close $handle
        return
    }
    
    csejtag_session send_message $handle $CSE_MSG_INFO "Obtained cable lock\n"
    
    # Catch all errors that may occur when using the CSE commands.  This should be done
    # so that the cable can be unlocked and closed correctly.
    if {[catch {
    
    # Scan the JTAG chain, reading idcodes, 
    # setting IR lengths for known devices in the CseJtag 
    # data structures.  
    # CseJtag needs to know in order to do JTAG shifts.
    csejtag_tap autodetect_chain $handle $CSEJTAG_SCAN_DEFAULT
    
    # Get number of devices
    set deviceCount [csejtag_tap get_device_count $handle]
    
    set str [format "Found %u devices\n" $deviceCount]
    csejtag_session send_message $handle $CSE_MSG_INFO $str
    for {set deviceIndex 0} {$deviceIndex < $deviceCount} {incr deviceIndex} {
        scanDevice $handle $deviceIndex }
   
    #  End of catch statement
    } result]} {
        global errorCode
        global errorInfo
     #   puts stderr "\nCaught error: $result"
      #  puts stderr "**** Error Code ***"
      # puts stderr $errorCode
       # puts stderr "**** Tcl Trace ****"
        #puts stderr $errorInfo
        #puts stderr "*******************"
    }  
    
    csejtag_target unlock $handle
    csejtag_target close $handle
    csejtag_session send_message $handle $CSE_MSG_INFO "Closed cable successfully\n"
}

# Note that this function (with the exception of the call to
# scanUserReg() ) does not get any information
# which requires a new scan of the device chain.
# It is just lookup in the 'idcode.lst' file or
# information which CseJtag data structures already has such as:
# deviceCount and device idcodes.
proc scanDevice {handle deviceIndex } {
    global CSE_MSG_INFO

    # Get idcode without scanning the JTAG chain
    set idcode [csejtag_tap get_device_idcode $handle $deviceIndex]
    
    # Convert to an integer
    set idcodeInt [binaryStringToInt $idcode]
    
    # Get IR length without scanning JTAG chain
    set irLength 0
    set irLength [csejtag_db get_irlength_for_idcode $handle $idcode]
    
    # NOTE If (irLength == 0) an application program needs to set it,
    #     ( using function csejtag_tap_set_irlength $handle $deviceIndex $irLength)
    #     perhaps after asking the user or looking it up someway.
    #     Without irLength known for all devices in the chain,
    #     JTAG communication will fail.
    
    # Check if api supports cores for device
    set coreSupported 0
    set coreSupported [csecore_is_cores_supported $handle $idcode]
    
    # Check if api supports configuration of device
    set configurationSupported 0
    set configurationSupported [csefpga_is_config_supported $handle $idcode]
    
    # Get how many user chains the device has
    set userChainCount [csefpga_get_user_chain_count $handle $idcode]
    
    # Get device name
    set deviceName [csejtag_db get_device_name_for_idcode $handle $idcode]
    
    # print out device info
    set str [format "\nDEVICE %u, idcode:%x, IRLength:%u, chains:%u, coreSupport:%u, config support:%u, %s\n" \
                    $deviceIndex $idcodeInt $irLength $userChainCount $coreSupported \
                    $configurationSupported $deviceName]
    csejtag_session send_message $handle $CSE_MSG_INFO $str
    
    # Scan user chains
    for {set userChain  1} {$userChain <= $userChainCount} {incr userChain} {
        scanUserReg $handle $deviceIndex $userChain 
    }
}

proc scanUserReg {handle deviceIndex userRegNumber} {
    global CSE_MSG_INFO
    
    #  NOTE!
    #  Use csecore_get_core_count before accessing any core.
    #  Otherwise you may upset other non ChipScope cores.
    
    set coreCount 0
    set coreCount [csecore_get_core_count $handle $deviceIndex $userRegNumber]
    
    set str [format "Found %u cores, for device %u, user register %u\n" \
		            $coreCount $deviceIndex $userRegNumber]
    csejtag_session send_message $handle $CSE_MSG_INFO $str
    # Scan cores
    for {set coreIndex 0} {$coreIndex < $coreCount} {incr coreIndex} {
        scanCore $handle $deviceIndex $userRegNumber $coreIndex 
    }
}

proc scanCore { handle deviceIndex userRegNumber coreIndex  } {
    global ILA_STATUS_WORD_BIT_LEN
    global CSE_MSG_INFO
    
    set coreRef [list $deviceIndex $userRegNumber $coreIndex]
    
    # Read core status
    set coreStatus [csecore_get_core_status $handle \
                                            $coreRef \
                                            $ILA_STATUS_WORD_BIT_LEN]
    set coreInfo [lindex $coreStatus 0]
    set statusWord [lindex $coreStatus 1]
 
    # Dump status word
    set str [format "\n\nDevice %u, user reg. %u, core index %u, status word:\n" \
                    $deviceIndex $userRegNumber $coreIndex]
    csejtag_session send_message $handle $CSE_MSG_INFO $str
    dumpInHex $statusWord
    
    # Print CSE_CORE_INFO values
    set str [format \
                    "\nCSE_CORE_INFO: manufacturerId:%u, coreType:%u, coreMajorVersion:%u, coreMinorVersion:%u, coreRevision:%u\n\n" \
                    [lindex $coreInfo 0] \
                    [lindex $coreInfo 1] \
                    [lindex $coreInfo 2] \
                    [lindex $coreInfo 3] \
                    [lindex $coreInfo 4] ]
    csejtag_session send_message $handle $CSE_MSG_INFO $str
    
    set isviocore [csevio_is_vio_core $handle \
                                      $coreRef]
    if {$isviocore} {
        set viocoreanswer "YES"
    } else {
        set viocoreanswer "NO"
    }
    set str [format \
                    "\nIs VIO Core? %s\n"\
                    $viocoreanswer]
    csejtag_session send_message $handle $CSE_MSG_INFO $str
    
    if {$isviocore} {
        scanVIOCore $handle $coreRef 
    }
}

proc scanVIOCore { handle coreRef } {
    global CSE_MSG_INFO
    global CSEVIO_MANUFACTURER_ID
    global CSEVIO_CORE_TYPE
    global CSEVIO_CORE_MAJOR_VERSION
    global CSEVIO_CORE_MINOR_VERSION
    global CSEVIO_CORE_REVISION
    global CSEVIO_CG_MAJOR_VERSION
    global CSEVIO_CG_MINOR_VERSION
    global CSEVIO_CG_MINOR_VERSION_ALPHA
    global CSEVIO_ASYNC_INPUT_COUNT
    global CSEVIO_SYNC_INPUT_COUNT
    global CSEVIO_ASYNC_OUTPUT_COUNT
    global CSEVIO_SYNC_OUTPUT_COUNT
  
    
    csevio_get_core_info $handle \
                         $coreRef \
                         coreInfoTclArray
    set str [format \
                    "\CSEVIO_CORE_INFO: manufacturerId:%u, coreType:%u, coreMajorVersion:%u, coreMinorVersion:%u, coreRevision:%u, cgMajorVersion:%u, cgMinorVersion:%u, cgMinorVersionAlpha:%u, asyncInputCount:%u, syncInputCount:%u, asyncOutputCount:%u, syncOutputCount:%u\n\n" \
                    $coreInfoTclArray($CSEVIO_MANUFACTURER_ID) \
                    $coreInfoTclArray($CSEVIO_CORE_TYPE) \
                    $coreInfoTclArray($CSEVIO_CORE_MAJOR_VERSION) \
                    $coreInfoTclArray($CSEVIO_CORE_MINOR_VERSION) \
                    $coreInfoTclArray($CSEVIO_CORE_REVISION) \
                    $coreInfoTclArray($CSEVIO_CG_MAJOR_VERSION) \
                    $coreInfoTclArray($CSEVIO_CG_MINOR_VERSION) \
                    $coreInfoTclArray($CSEVIO_CG_MINOR_VERSION_ALPHA) \
                    $coreInfoTclArray($CSEVIO_ASYNC_INPUT_COUNT) \
                    $coreInfoTclArray($CSEVIO_SYNC_INPUT_COUNT) \
                    $coreInfoTclArray($CSEVIO_ASYNC_OUTPUT_COUNT) \
                    $coreInfoTclArray($CSEVIO_SYNC_OUTPUT_COUNT) ]
    csejtag_session send_message $handle $CSE_MSG_INFO $str
	  
# --------------------------------------------------------------------------------------------------------------------------
	#puts "000000000000000000000000000000000000000000000000000000000000000000000" 
	#puts $coreInfoTclArray($CSEVIO_ASYNC_INPUT_COUNT)
	#puts $coreInfoTclArray($CSEVIO_SYNC_INPUT_COUNT)
	#puts $coreInfoTclArray($CSEVIO_ASYNC_OUTPUT_COUNT)
	#puts $coreInfoTclArray($CSEVIO_SYNC_OUTPUT_COUNT)
	#puts ""
	set fileid [open "check_line5.txt" w]
	
    global CSEVIO_SYNC_OUTPUT
    global CSEVIO_ASYNC_OUTPUT
    global CSEVIO_SYNC_INPUT
    global CSEVIO_ASYNC_INPUT
	csevio_init_core $handle \
                     $coreRef
	csevio_define_bus $handle $coreRef "data_in" $CSEVIO_ASYNC_OUTPUT [list 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52 53 54 55 56 57 58 59 60 61 62 63 64 65 66 67 68 69 70 71]
	csevio_define_bus $handle $coreRef "data_out" $CSEVIO_ASYNC_INPUT [list 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52 53 54 55 56 57 58 59 60 61 62 63 64 65 66 67 68 69 70 71]
	set x 1
	while {$x < 5} {
		set data [gets stdin]
		puts $fileid $data
	#	set VVarray5 ""
	#	set bit5 ""
		set VVarray5 [string range $data 0 17]
		set bit5 [string range $data 19 19]
		set x [string range $data 21 21]
		if {[expr $bit5==1]} then {	
			set STR_ING ""
			set outputTclArray(data_in) $VVarray5
		#	set fileid1 [open "check_line1.txt" w]
		#	puts $fileid1 $outputTclArray(data_in)
			csevio_write_values $handle $coreRef outputTclArray
		#	csevio_read_values $handle $coreRef inputTclArray
		#	append STR_ING $inputTclArray(data_out.value)
		#	set fileid [open "check_line.txt" w]
		#	puts $fileid $STR_ING
		#	puts $STR_ING
		#	puts $fileid1 $STR_ING
		#	close $fileid
		#	close $fileid1
		} else {
		set inputarray ""
		csevio_read_values $handle $coreRef inputTclArray
		append inputarray $inputTclArray(data_out.value)
		#set fileid [open "check_line.txt" w]
		#puts $fileid $inputarray
		puts $inputarray
		
		#close $fileid
		}
	}
   # set outputTclArray(data_in) ffffccccaaaaeeee
	#set outputTclArray(wr_en.pulsetrain) 0000110000000000
    #csevio_write_values $handle $coreRef outputTclArray
	
	#csevio_read_values $handle $coreRef inputTclArray
	#puts "data_out = $inputTclArray(data_out.value)"
	
	csevio_terminate_core $handle \
                           $coreRef
						   
	#puts "000000000000000000000000000000000000000000000000000000000000000000000"
# --------------------------------------------------------------------------------------------------------------------------
    
    # Some CseVIO functions to try...
    # global CSEVIO_SYNC_OUTPUT
    # global CSEVIO_ASYNC_OUTPUT
    # global CSEVIO_SYNC_INPUT
    # global CSEVIO_ASYNC_INPUT
    
    # csevio_init_core $handle \
    #                  $coreRef

    # csevio_define_signal $handle $coreRef "reset" $CSEVIO_SYNC_OUTPUT 0
    # csevio_define_bus $handle $coreRef "instruction" $CSEVIO_ASYNC_OUTPUT [list 0 1 2 3 4 5 6 7]
    # csevio_define_signal $handle $coreRef "status" $CSEVIO_SYNC_INPUT 0
    
    # set outputTclArray(reset) 0
    # set outputTclArray(instruction) FF
    # csevio_write_values $handle $coreRef outputTclArray
    
    # csevio_read_values $handle $coreRef inputTclArray
    # puts "status = $inputTclArray(status.value)"
    # puts "up = $inputTclArray(status.activity_up)"
    # puts "dn = $inputTclArray(status.activity_down)"
    # puts "sup = $inputTclArray(status.sync_activity_up)"
    # puts "sdn = $inputTclArray(status.sync_activity_down)"
    
    # csevio_terminate_core $handle \
    #                       $coreRef
}

proc writeMessage {handle msgFlags msg} {
    global debug
    global CSE_MSG_ERROR
    global CSE_MSG_WARNING
    global CSE_MSG_STATUS
    global CSE_MSG_INFO
    global CSE_MSG_NOISE
    global CSE_MSG_DEBUG
    if {[expr $debug || ($msgFlags != $CSE_MSG_DEBUG)]} {
        if {$msgFlags == $CSE_MSG_ERROR}      {
     #       puts -nonewline "Error:"
        } elseif {$msgFlags == $CSE_MSG_WARNING}         {
     #       puts -nonewline "Warning:"
        } elseif {$msgFlags == $CSE_MSG_INFO}            {
     #       puts -nonewline "Info:"
        } elseif {$msgFlags == $CSE_MSG_STATUS}          {
      #      puts -nonewline "Status:"
        } elseif {$msgFlags == $CSE_MSG_DEBUG}           {
       #     puts -nonewline "Debug:"
        }        
        #puts -nonewline $msg
        flush stdout
    }
}

proc binaryStringToInt {binarystring} {
    set len [string length $binarystring]
    set retval 0
    for {set i 0} {$i < $len} {incr i} {
        set retval [expr $retval << 1]
        if {[string index $binarystring $i] == "1"} {
            set retval [expr $retval | 1]
        }
    }
    return $retval
}

proc dumpInHex {buffer} {
    global CSE_MSG_NOISE
    set start 0
    set end 15
    
    while {$end < [string length $buffer]} {
        set buf [string range $buffer $start $end]
        writeMessage 0 $CSE_MSG_NOISE "$buf\n"
        set start [expr $start + 16]
        set end [expr $end + 16]
    }
}

# Start the program
main $argc $argv
