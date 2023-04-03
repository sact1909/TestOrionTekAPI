using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOrionTekAPI.Data
{
    public static class DbContants
    {
        public static string DbRoute
        {
            get
            {
                var folder = Environment.SpecialFolder.LocalApplicationData;
                var path = Environment.GetFolderPath(folder);
                return System.IO.Path.Join(path, "OrionTekDbContext.db");
            }
        }
    }
}
