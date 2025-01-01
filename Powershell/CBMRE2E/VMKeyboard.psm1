#
# Copyright (c) 2022  Microsoft Corporation
#
# Module Name:
#
#     VMKeyboard.psm1
#
# Abstract:
#
#     This module implements routines to perform keyboard operation on a VM
#
# Author:
#
#     Vineel Kovvuri (vineelko) 21-Feb-2022
#
# Environment:
#
#     User mode only.
#

# Common Keys
$global:ShiftKey = 160
$global:ControlKey = 162
$global:EnterKey = 0x0D
$global:F1Key  = 0x70
$global:F2Key  = 0x71
$global:F3Key  = 0x72
$global:F4Key  = 0x73
$global:F5Key  = 0x74
$global:F6Key  = 0x75
$global:F7Key  = 0x76
$global:F8Key  = 0x77
$global:F9Key  = 0x78
$global:F10Key = 0x79
$global:F11Key = 0x7A
$global:F12Key = 0x7B

Function CbmrVMKeyboardTypeTextWithNewLine {
    param($VMName, $Text)

    CbmrVMKeyboardTypeText -VMName $VMName -Text $Text

    CbmrVMKeyboardSendKey -VMName $VMName -Key $global:EnterKey
}

Function CbmrVMKeyboardTypeText {
    param($VMName, $Text)

    $vmms = Get-WmiObject -Namespace root\virtualization\v2 -Class Msvm_VirtualSystemManagementService
    $vmcs = Get-WmiObject -Namespace root\virtualization\v2 -Class Msvm_ComputerSystem -Filter "ElementName='$($VMName)'"

    # Wakeup the VM
    $mouse = $vmcs.GetRelated("Msvm_SyntheticMouse")
    $mouse.SetAbsolutePosition(300,450) | out-null
    # $mouse.ClickButton(2) | out-null

    $keyboard = $vmcs.GetRelated("Msvm_Keyboard")
    $keyboard.TypeText($Text) | out-null
}

Function CbmrVMKeyboardSendKey {
    param($VMName, $Key, $ShiftOrControl)

    $vmms = Get-WmiObject -Namespace root\virtualization\v2 -Class Msvm_VirtualSystemManagementService
    $vmcs = Get-WmiObject -Namespace root\virtualization\v2 -Class Msvm_ComputerSystem -Filter "ElementName='$($VMName)'"

    # Wakeup the VM
    $mouse = $vmcs.GetRelated("Msvm_SyntheticMouse")
    $mouse.SetAbsolutePosition(300,450) | out-null

    $keyboard = $vmcs.GetRelated("Msvm_Keyboard")
    if ($ShiftOrControl) {
        $keyboard.PressKey($ShiftOrControl)  | out-null
        $keyboard.PressKey($Key)  | out-null
        $keyboard.ReleaseKey($Key)  | out-null
        $keyboard.ReleaseKey($ShiftOrControl)  | out-null
    } else {
        $keyboard.TypeKey($Key)  | out-null
    }
}
