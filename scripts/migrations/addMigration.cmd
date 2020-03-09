@echo off

if [%1]==[] (
    echo Usage: addMigration *migration name*
    exit /B 1
)

set startupProjectPath=..\..\src\WeatherForecast\WeatherForecast.csproj

pushd %startupProjectPath%

dotnet-ef migrations add %1 --verbose --context DataContext --startup-project %startupProjectPath%

if [%2]==[update] (
    dotnet-ef database update --context DataContext --verbose --startup-project %startupProjectPath%
)

popd
