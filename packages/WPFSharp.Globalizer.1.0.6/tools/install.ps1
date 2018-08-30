# Runs every time a package is installed in a project

param($installPath, $toolsPath, $package, $project)

# $installPath is the path to the folder where the package is installed.
# $toolsPath is the path to the tools directory in the folder where the package is installed.
# $package is a reference to the package object.
# $project is a reference to the project the package was installed to.

function SetFilePropertiesRecursively
{
	$folderKind = "{6BB5F8EF-4483-11D3-8BCF-00C04F8EC28C}";
	foreach ($subItem in $args[0].ProjectItems)
	{
		$path = $args[1]
	    if ($subItem.Kind -eq $folderKind)
		{
			SetFilePropertiesRecursively $subItem ("{0}{1}{2}" -f $path, $args[0].Name, "\")
		}
		else
		{
			Write-Host -NoNewLine ("{0}{1}{2}" -f $path, $args[0].Name, "\")
			SetFileProperties $subItem 2 2 ""
		}
	}
}

function SetFileProperties
{
	param([__ComObject]$item, [int]$buildAction, [int]$copyTo, [string]$customTool)
	Write-Host $item.Name
	Write-Host "  Setting Build Action to Content"
	$item.Properties.Item("BuildAction").Value = $buildAction
	Write-Host "  Setting Copy To Output Directory to Copy if newer"
	$item.Properties.Item("CopyToOutputDirectory").Value = $copyTo
	Write-Host "  Setting Custom Tool to blank"
	$item.Properties.Item("CustomTool").Value = $customTool
}

SetFilePropertiesRecursively $project.ProjectItems.Item("Globalization")
SetFilePropertiesRecursively $project.ProjectItems.Item("Styles")
SetFileProperties $project.ProjectItems.Item("App.xaml") 4 0 "MSBuild:Compile"