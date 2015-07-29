# Script to set version number from build in all AssemblyInfo files
[CmdletBinding()]
Param()

Write-Host("{0} Begin" -f $MyInvocation.MyCommand)
try
{
	Write-Verbose "---------- Updating version number for AssemblyInfo files ----------"
	$AssemblyFileVersionRegex = "AssemblyFileVersion\(`"\d+\.\d+\.\d+\.\d+"	
	$AssemblyVersionRegex = "AssemblyVersion\(`"\d+\.\d+\.*.*"	
	$files = gci $Env:TF_BUILD_SOURCESDIRECTORY -recurse -include "*Properties*","My Project" | 
	?{ $_.PSIsContainer } | 
	foreach { gci -Path $_.FullName -Recurse -include AssemblyInfo.* }
	if($files)
	{
		Write-Verbose "Will apply $Global:BuildNumber to $($files.count) files."
		foreach ($file in $files)
		{			
			Set-ItemProperty $file -name IsReadOnly -value $false
			$filecontent = Get-Content($file)
			$filecontent -replace $AssemblyFileVersionRegex, "AssemblyFileVersion(`"$Global:BuildNumber" | Out-File $file
			$filecontent = Get-Content($file)
			$filecontent -replace $AssemblyVersionRegex, "AssemblyVersion(`"$Global:BuildNumber`")]" | Out-File $file
			Write-Verbose "$file - $Global:BuildNumber applied to AssemblyVersion and AssemblyFileVersion"
		}
	}
	else
	{
		Write-Warning "Found no AssemblyInfo files to modify"
	}

	Write-Verbose "------- Updating version number for Elements Service install -------"
	$VersionRegex ="Version=`"1.0.0.0`""
	$UpdatedVersionRegex="Version=`"$Global:BuildNumber`""
	$file = Join-Path -Path "$Env:TF_BUILD_SOURCESDIRECTORY" -Childpath "Software\VS\IceMvc\Ice.ElementsServiceWixInstaller\Product.wxs"
	if (Test-Path $file)
	{
		Set-ItemProperty $file -name IsReadOnly -value $false
		$filecontent = Get-Content($file)
		$filecontent -replace $VersionRegex, $UpdatedVersionRegex | Out-File $file -Encoding utf8
		Write-Verbose "$file - $Global:BuildNumber applied"
	}
	else
	{
		Write-Warning "Cannot find $file to modify it"
	}

    if (-not $LASTEXITCODE -eq 0)
    {
        Write-Warning("Error in {0}" -f $MyInvocation.MyCommand)
        exit -1
    }
	
	Write-Verbose "------- Updating version number for MapForce Bundler install -------"
	$releaseVersionRegex ="\<\?define releaseVersion = `"\d+\.\d+\.\d+\.\d+`" \?\>"
	$UpdatedreleaseVersionRegex="<?define releaseVersion = `"$Global:BuildNumber`" ?>"
	$file = Join-Path -Path "$Env:TF_BUILD_SOURCESDIRECTORY" -Childpath "Software\VS\Installers\MapForceBundlerSetup\Product.wxi"
	if (Test-Path $file)
	{
		Set-ItemProperty $file -name IsReadOnly -value $false
		$filecontent = Get-Content($file)
		$filecontent -replace $releaseVersionRegex, $UpdatedreleaseVersionRegex | Out-File $file -Encoding utf8
		Write-Verbose "$file - $Global:BuildNumber applied"
	}
	else
	{
		Write-Warning "Cannot find $file to modify it"
	}

    if (-not $LASTEXITCODE -eq 0)
    {
        Write-Warning("Error in {0}" -f $MyInvocation.MyCommand)
        exit -1
    }
}
catch
{
	Write-Error $Error[0]
	exit -1
}
Write-Host("-=-=-=-=-=-=-=-=-=-= {0} End =-=-=-=-=-=-=-=-=-=-" -f $MyInvocation.MyCommand)
Write-Host