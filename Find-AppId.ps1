param (
    [Parameter(Mandatory=$true)]
    [string]
    $AppName
)

get-StartApps | Where-Object { $_.Name.Contains("Calculator") }