using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockCheckWindows
{
    public class DatabaseManager
    {
        private static LiteDatabase instance;

        public static LiteDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LiteDatabase(@"C:\Users\lucas\DockCheckWindows\banco.db");
                }
                return instance;
            }
        }
    }
}
