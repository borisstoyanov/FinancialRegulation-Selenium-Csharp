# Script to set all properties required during the build
[CmdletBinding()]
Param()
Write-Host("{0} Begin" -f $MyInvocation.MyCommand)
try
{
	Write-Verbose "---------------------- Setting all properties ----------------------"
	$FullBuildNumber=$Env:TF_BUILD_BUILDNUMBER.Split("_")
	$Global:BuildNumber=$FullBuildNumber[1]
	$SplitBuildNumber=$BuildNumber.Split(".")
	$Global:MajorBuildNumber=$BuildNumber[0]
	$Global:Release=$SplitBuildNumber[1]

	Write-Verbose "Build Number: $Global:BuildNumber"
	Write-Verbose "Major Build Number: $Global:MajorBuildNumber"
	Write-Verbose "Release: $Global:Release"
}
catch
{
	Write-Error $Error[0]
	exit -1
}
Write-Host("-=-=-=-=-=-=-=-=-=-= {0} End =-=-=-=-=-=-=-=-=-=-" -f $MyInvocation.MyCommand)
Write-Host