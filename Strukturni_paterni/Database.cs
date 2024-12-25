using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strukturni_paterni
{
    // Интерфейс, который определяет методы доступа
    public interface IDatabase
    {
        void Query(string sql);
    }

    // Реальный объект
    public class RealDatabase : IDatabase
    {
        public void Query(string sql)
        {
            Console.WriteLine("Executing query: " + sql);
        }
    }

    // Прокси-объект
    public class DatabaseProxy : IDatabase
    {
        private RealDatabase _realDatabase;
        private bool _hasAccess;

        public DatabaseProxy(bool hasAccess)
        {
            _realDatabase = new RealDatabase();
            _hasAccess = hasAccess;
        }

        public void Query(string sql)
        {
            if (_hasAccess)
            {
                _realDatabase.Query(sql);
            }
            else
            {
                Console.WriteLine("Access denied. Query cannot be executed.");
            }
        }
    }

}
