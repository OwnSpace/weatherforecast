@echo off

set startupProjectPath=..\..\src\WeatherForecast\WeatherForecast.csproj

pushd %startupProjectPath%

dotnet-ef migrations remove --verbose --context DataContext --startup-project %startupProjectPath%

popd
