$apiKey = Read-Host "Please enter your nuget api key"
Get-ChildItem -File -Filter GrouveeCollectionParser.*nupkg | Remove-Item -Force
nuget pack .\GrouveeCollectionParser\GrouveeCollectionParser.csproj -Symbols -Prop Configuration=Release
nuget push GrouveeCollectionParser.*.nupkg -ApiKey $apiKey -source nuget.org
nuget push GrouveeCollectionParser.*.symbols.nupkg -ApiKey $apiKey -source https://nuget.smbsrc.net/

Read-Host