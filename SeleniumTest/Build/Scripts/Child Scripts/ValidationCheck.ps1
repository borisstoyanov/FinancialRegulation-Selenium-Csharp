# Script to ensure all TF_BUILD properties are set and populated before executing any scripts
[CmdletBinding()]
Param()
Write-Host("{0} Begin" -f $MyInvocation.MyCommand)
try
{
	if (-not $Env:TF_BUILD)
	{
		Write-Warning ("TF_BUILD environment variable is missing.")
		$LASTEXITCODE=-1
	}
	else
	{
		Write-Verbose ("TF_BUILD: $Env:TF_BUILD")
	}

	if (-not $Env:TF_BUILD_BINARIESDIRECTORY)
	{
		Write-Warning ("TF_BUILD_BINARIESDIRECTORY environment variable is missing.")
		$LASTEXITCODE=-1
	}
	else
	{
		Write-Verbose ("TF_BUILD_BINARIESDIRECTORY: $Env:TF_BUILD_BINARIESDIRECTORY")
	}

	if (-not $Env:TF_BUILD_BUILDDEFINITIONNAME)
	{
		Write-Warning ("TF_BUILD_BUILDDEFINITIONNAME environment variable is missing.")
		$LASTEXITCODE=-1
	}
	else
	{
		Write-Verbose ("TF_BUILD_BUILDDEFINITIONNAME: $Env:TF_BUILD_BUILDDEFINITIONNAME")
	}

	if (-not $Env:TF_BUILD_BUILDDIRECTORY)
	{
		Write-Warning ("TF_BUILD_BUILDDIRECTORY environment variable is missing.")
		$LASTEXITCODE=-1
	}
	else
	{
		Write-Verbose ("TF_BUILD_BUILDDIRECTORY: $Env:TF_BUILD_BUILDDIRECTORY")
	}

	if (-not $Env:TF_BUILD_BUILDNUMBER)
	{
		Write-Warning ("TF_BUILD_BUILDNUMBER environment variable is missing.")
		$LASTEXITCODE=-1
	}
	else
	{
		Write-Verbose ("TF_BUILD_BUILDNUMBER: $Env:TF_BUILD_BUILDNUMBER")
	}

	if (-not $Env:TF_BUILD_BUILDREASON)
	{
		Write-Warning ("TF_BUILD_BUILDREASON environment variable is missing.")
		$LASTEXITCODE=-1
	}
	else
	{
		Write-Verbose ("TF_BUILD_BUILDREASON: $Env:TF_BUILD_BUILDREASON")
	}

	if (-not $Env:TF_BUILD_BUILDURI)
	{
		Write-Warning ("TF_BUILD_BUILDURI environment variable is missing.")
		$LASTEXITCODE=-1
	}
	else
	{
		Write-Verbose ("TF_BUILD_BUILDURI: $Env:TF_BUILD_BUILDURI")
	}

	if (-not $Env:TF_BUILD_COLLECTIONURI)
	{
		Write-Warning ("TF_BUILD_COLLECTIONURI environment variable is missing.")
		$LASTEXITCODE=-1
	}
	else
	{
		Write-Verbose ("TF_BUILD_COLLECTIONURI: $Env:TF_BUILD_COLLECTIONURI")
	}

	if (-not $Env:TF_BUILD_DROPLOCATION)
	{
		Write-Warning ("TF_BUILD_DROPLOCATION environment variable is missing.")
	}
	else
	{
		Write-Verbose ("TF_BUILD_DROPLOCATION: $Env:TF_BUILD_DROPLOCATION")
	}

	if (-not $Env:TF_BUILD_SOURCEGETVERSION)
	{
		Write-Warning ("TF_BUILD_SOURCEGETVERSION environment variable is missing.")
		$LASTEXITCODE=-1
	}
	else
	{
		Write-Verbose ("TF_BUILD_SOURCEGETVERSION: $Env:TF_BUILD_SOURCEGETVERSION")
	}

	if (-not $Env:TF_BUILD_SOURCESDIRECTORY)
	{
		Write-Warning ("TF_BUILD_SOURCESDIRECTORY environment variable is missing.")
		$LASTEXITCODE=-1
	}
	else
	{
		Write-Verbose ("TF_BUILD_SOURCESDIRECTORY: $Env:TF_BUILD_SOURCESDIRECTORY")
	}

	if (-not $Env:TF_BUILD_TESTRESULTSDIRECTORY)
	{
		Write-Warning ("TF_BUILD_TESTRESULTSDIRECTORY environment variable is missing.")
	$LASTEXITCODE=-1
	}
	else
	{
		Write-Verbose ("TF_BUILD_TESTRESULTSDIRECTORY: $Env:TF_BUILD_TESTRESULTSDIRECTORY")
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