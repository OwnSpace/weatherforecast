# Weather forecast service

Данный сервис представляет собой совокупность трёх компонентов:
- граббер погоды (Selenium)
- WebAPI-сервис получения данных о погоде
- WinForms-приложение просмотра прогноза погоды

Перед запуском необходимо:
- установить dotnet-ef [выполнив скрипт](https://github.com/OwnSpace/weatherforecast/blob/master/scripts/tools/install%20dotnet-ef%20tool.cmd)
- скачать chromedriver.exe для Selenium [выполнив скрипт](https://github.com/OwnSpace/weatherforecast/blob/master/scripts/selenium/install%20chromdriver.ps1)
- убедиться что установлен MySql версии 5.7.29, скорректировать строку подключения к БД в файлах appsettings.json
- [накатить миграцию в БД](https://github.com/OwnSpace/weatherforecast/blob/master/scripts/migrations/update.cmd)
- при желании изменить расписание запуска граббера скорректировать CRON в настройках
- при желании установить граббер как сервис (см. scripts/svc/*.cmd)

Граббер при запуске осуществляет заполнение БД первым набором записей, после чего можно запускать WinForms-приложение
