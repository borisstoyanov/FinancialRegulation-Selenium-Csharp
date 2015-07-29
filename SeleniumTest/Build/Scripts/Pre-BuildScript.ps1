# Wrapper script to be called on the "Pre-Build" event of a TFS build
# List all scripts to be called within the "try" block - remember to include an "ErrorAction" of "Stop" to prevent runaway scripts
# All parameters are to be listed here and supplied on the command line via the TFS build definition.  ExecuteAllScripts is used to
# determine if any processing other then versioning the assemblies is required, for example in a build other than CI

[CmdletBinding()]
Param(
	[Parameter(Mandatory=$false,ValueFromPipeline=$true)]
	[ValidateSet("true", "TRUE", "false", "FALSE", "1", "0")] 
	[switch]$Disable,
	[Parameter(Mandatory=$false,ValueFromPipeline=$true)]
	[ValidateSet("true", "TRUE", "false", "FALSE", "1", "0")] 
	[switch]$UpdateVersion
)
Write-Host("{0} Begin" -f $MyInvocation.MyCommand)
try
{
	if (-not $PSBoundParameters.ContainsKey('Disable'))
	{
		$ScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent
		$LASTEXITCODE=0

		# Always perform this check first - if it fails no other scripts should execute
		$path=Join-Path -Path "$ScriptRoot" -Childpath "Child Scripts\ValidationCheck.ps1"
		& "$path" -ErrorAction Stop
	
		if ($LASTEXITCODE -eq 0)
		{
			$path=Join-Path -Path "$ScriptRoot" -Childpath "Child Scripts\SetAllProperties.ps1"
			& "$path" -ErrorAction Stop
		}
	
		if ($LASTEXITCODE -eq 0)
		{
			if ($UpdateVersion -eq $true)
			{
				$path=Join-Path -Path "$ScriptRoot" -Childpath "Child Scripts\UpdateVersionNumber.ps1"
				& "$path" -ErrorAction Stop
			}
			else
			{
				Write-Host "UpdateVersion not requested"
			}
		}

		# Must have this at the end to catch any errors that were generated during the previous scripts executions
		if (-not $LASTEXITCODE -eq 0)
		{
			throw
		}
	}
	else
	{
		Write-Host "Execution of scripts disabled"
	}
}
catch
{
	Write-Error $Error[0]
	exit -1
}
Write-Host("-=-=-=-=-=-=-=-=-=-= {0} End =-=-=-=-=-=-=-=-=-=-" -f $MyInvocation.MyCommand)
Write-Host