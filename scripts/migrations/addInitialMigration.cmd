set projectPath=..\..\src\WeatherForecast.Migrations\WeatherForecast.Migrations.csproj
set startupProjectPath=..\..\src\WeatherForecast\WeatherForecast.csproj
set ctx=DataContext

pushd %projectPath%

dotnet-ef migrations add InitialMigration --context %ctx% --verbose --startup-project %startupProjectPath% --project %projectPath%
dotnet-ef database update --context %ctx% --verbose --startup-project %startupProjectPath% --project %projectPath%

popd
