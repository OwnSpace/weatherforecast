cd ../../src/WeatherForecast/bin/Debug/netcoreapp3.1/;
Invoke-WebRequest -Uri "https://chromedriver.storage.googleapis.com/80.0.3987.106/chromedriver_win32.zip" -OutFile ./chromedriver_win32.zip;
Expand-Archive ./chromedriver_win32.zip -DestinationPath ./chromedriver_win32;
Copy-Item ./chromedriver_win32/chromedriver.exe -Destination .;