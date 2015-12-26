## SuperBug.Politrange.WebApi
### Описание проекта.
Веб-сервис позицируется как Restful Api, обрабатывает запросы http  и возвращает данные в виде Json.
Краулер позицируется как бота, проверяет в базу данных наличием новых сайтов и старых страниц, которые старше одного дня. Далее разбирает ссылки из страниц и ищет в них наличие ключевых слов личностей.

### Требование
1. Должна быть установлена СУБД MySql не менее 5.5 версии
2. Должен быть установлен .net framework не менее 4.5.2

### Документация
[Документация по Api](https://github.com/SuperBugCompany/politrange.webapi/wiki/%D0%94%D0%BE%D0%BA%D1%83%D0%BC%D0%B5%D0%BD%D1%82%D0%B0%D1%86%D0%B8%D1%8F-Api)

### Установка
Скачать по ссылке [архивы](https://github.com/SuperBugCompany/politrange.webapi/releases)

Примечание:
* `SuperBug.Politrange.Crawler-[version].zip` для краулера.
* `SuperBug.Politrange.WebApi-[version].zip` для веб-сервиса.

### Разработка
1. Клонировать проекта.
2. ` cd nuget `
3. ` nuget.exe restore ..\src `
4. Начать разрабатывать.
