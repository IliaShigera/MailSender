# MailSender
 
Реализован простой сервис с использованием Identity для отправки Email.

// Тк комментарии из кода были удалены.
В файле appsettings.json 
Данные из секции "MailSettings" будут передаваться экземпляру MailSetting, чтобы не определять напрямую(hard code) свои личные данные.
MailSettings - класс использующий данные из appsettings.json
Конфиденциальные данные указываются в appsettings.Development.json.

MailService
В конструкторе с помощью IOptions<MailSettings>  получаем данные из Json.
В методе SendMail: 
Создается объект MimeMessage(класс из Mimekit) и отправет его с помощью экземпляра SMTPClient(Mailkit).
Данные, относящиеся к сообщению(тема, тело), заполняются из mailRequest, и которые мы получаем из нашего файла Json.
