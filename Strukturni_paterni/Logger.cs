using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strukturni_paterni
{
    // Старый интерфейс (несовместимый)
    public class ExternalLogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("External log: " + message);
        }
    }

    // Новый интерфейс, который нам нужно использовать
    public interface ILogger
    {
        void Log(string message);
    }

    // Адаптер, который будет переводить запросы в нужный формат
    public class LoggerAdapter : ILogger
    {
        private readonly ExternalLogger _externalLogger;

        public LoggerAdapter(ExternalLogger externalLogger)
        {
            _externalLogger = externalLogger;
        }

        public void Log(string message)
        {
            _externalLogger.LogMessage(message); // Переводим запрос
        }
    }

}
