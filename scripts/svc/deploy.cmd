set publishPath=../../publish
set path=../../src/WeatherForecast
set projectPath=%path%/WeatherForecast.csproj
set binPath=%path%/bin/Debug/netcoreapp3.1/WeatherForecast.exe

cd %path%

dotnet restore
dotnet publish %projectPath% -o %publishPath% --framework netcoreapp3.1 -r win-x64 -c Release

sc create "WeatherForecast Grabber" BinPath=%publishPath%/WeatherForecast.exe
