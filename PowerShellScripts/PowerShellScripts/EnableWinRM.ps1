﻿#
# Script.ps1
#
Import-Module GroupPolicy


$KeyPath = "HKLM\Software\Policies\Microsoft\Windows\WinRM\Service"
$GPOName = "Enable WinRM"
$defaultNC     = ( [ADSI]"LDAP://RootDSE" ).defaultNamingContext.Value


$GPO = New-GPO -Name $GPOName


Set-GPRegistryValue -Name $GPOName -Key $KeyPath -ValueName "AllowAutoConfig" -Type String -Value "1"
Set-GPRegistryValue -Name $GPOName -Key $KeyPath -ValueName "IPv4Filter" -Type String -Value "*"
Set-GPRegistryValue -Name $GPOName -Key $KeyPath -ValueName "IPv6Filter" -Type String -Value "*"

New-GPLink -Name $GPOName -Target $defaultNC -Enforced Yes 
