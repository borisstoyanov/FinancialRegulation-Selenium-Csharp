# Wrapper script to be called on the "Post-Build" event of a TFS build
# List all scripts to be called within the "try" block - remember to include an "ErrorAction" of "Stop" to prevent runaway scripts
# All parameters are to be listed here and supplied on the command line via the TFS build definition.

[CmdletBinding()]
Param(
	[switch]$Disable,
	[switch]$IncludeDeployScripts,
	[switch]$IncludeMappingInstallsets,
	[switch]$IncludeSQLScripts,
	[switch]$IncludeOtherFolder,
	[switch]$MoveSchemaFilesFolder,
	[switch]$IncludeConfigurationFolder
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
			if ($IncludeDeployScripts -eq $true)
			{
				$path=Join-Path -Path "$ScriptRoot" -Childpath "Child Scripts\AddDeployScriptsToBinaries.ps1"
				& "$path" -ErrorAction Stop
			}
			else
			{
				Write-Host "IncludeDeployScripts not requested"
			}
		}

		if ($LASTEXITCODE -eq 0)
		{
			if ($IncludeMappingInstallsets -eq $true)
			{
				$path=Join-Path -Path "$ScriptRoot" -Childpath "Child Scripts\AddMappingInstallSetsToBinaries.ps1"
				& "$path" -ErrorAction Stop
			}
			else
			{
				Write-Host "IncludeMappingInstallsets not requested"
			}
		}

		if ($LASTEXITCODE -eq 0)
		{
			if ($IncludeSQLScripts -eq $true)
			{
				$path=Join-Path -Path "$ScriptRoot" -Childpath "Child Scripts\AddSQLScriptsToBinaries.ps1"
				& "$path" -ErrorAction Stop
			}
			else
			{
				Write-Host "IncludeSQLScripts not requested"
			}
		}

		if ($LASTEXITCODE -eq 0)
		{
			if ($IncludeOtherFolder -eq $true)
			{
				$path=Join-Path -Path "$ScriptRoot" -Childpath "Child Scripts\AddReleaseNotesToBinaries.ps1"
				& "$path" -ErrorAction Stop
			}
			else
			{
				Write-Host "IncludeOtherFolder not requested"
			}
		}
		if ($LASTEXITCODE -eq 0)
		{
			if ($MoveSchemaFilesFolder -eq $true)
			{
				$path=Join-Path -Path "$ScriptRoot" -Childpath "Child Scripts\MoveSchemaFilesFolder.ps1"
				& "$path" -ErrorAction Stop
			}
			else
			{
				Write-Host "MoveSchemaFilesFolder not requested"
			}
		}
		if ($LASTEXITCODE -eq 0)
		{
			if ($IncludeConfigurationFolder -eq $true)
			{
				$path=Join-Path -Path "$ScriptRoot" -Childpath "Child Scripts\AddConfigurationFolderToBinaries.ps1"
				& "$path" -ErrorAction Stop
			}
			else
			{
				Write-Host "MoveSchemaFilesFolder not requested"
			}
		}
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