using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityGameSqlMvc.Model;

namespace CityGameSqlMvc.View
{
    internal class Viewshka
    {
        public void ViewList(List<string> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
