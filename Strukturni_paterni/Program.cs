using Strukturni_paterni;
using System;

class Program
{
    static void Main()
    {
        // Proxy pattern test
        IDatabase userDb = new DatabaseProxy(false);
        IDatabase adminDb = new DatabaseProxy(true);

        userDb.Query("SELECT * FROM users"); // Вывод: Access denied.
        adminDb.Query("SELECT * FROM users"); // Вывод: Executing query: SELECT * FROM users

        // Adapter pattern test
        ExternalLogger externalLogger = new ExternalLogger();
        ILogger logger = new LoggerAdapter(externalLogger);

        logger.Log("This is a test message."); // Вывод: External log: This is a test message.

        // Bridge pattern test
        IDevice monitor = new Strukturni_paterni.Monitor(); // Указание полного пути
        IDevice printer = new Printer();

        Output textOnMonitor = new TextOutput(monitor);
        Output textOnPrinter = new TextOutput(printer);

        textOnMonitor.Render("Hello, world!"); // Вывод: Displaying on monitor: Text: Hello, world!
        textOnPrinter.Render("Hello, world!"); // Вывод: Printing to paper: Text: Hello, world!

        Output imageOnMonitor = new ImageOutput(monitor);
        imageOnMonitor.Render("101010101"); // Вывод: Displaying on monitor: Image: [Binary data: 101010101]
    }
}
