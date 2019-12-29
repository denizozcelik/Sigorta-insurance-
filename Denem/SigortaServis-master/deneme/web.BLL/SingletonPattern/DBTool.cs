using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.DAL.Context;

namespace web.BLL.SingletonPattern
{
    public class DBTool
    {
        static object _lockSync = new object();

        private DBTool() { }

        private static MyDBContext _dbInstance;

        public static MyDBContext DBInstance
        {
            get
            {
                if (_dbInstance == null)
                {
                    lock (_lockSync)
                    {
                        if (_dbInstance == null)
                        {
                            _dbInstance = new MyDBContext();
                        }
                    }
                }
                return _dbInstance;
            }
        }

    }
}
