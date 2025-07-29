using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityGameSqlMvc.Controller;
using CityGameSqlMvc.Model;

namespace CityGameSqlMvc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ModelSqlGame modelSqlGame = new ModelSqlGame();
            modelSqlGame.TestConnection();
            /*
            Console.WriteLine(modelSqlGame.Idnext("Lists"));
            Console.WriteLine("Выберите Название нового списка");
            string NewList = Console.ReadLine();
            modelSqlGame.Addlist(NewList);
           
            foreach (var item in modelSqlGame.Base("select * from Lists"))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Выберите список");
            int lst = Convert.ToInt32(Console.ReadLine());
            foreach (var item in modelSqlGame.Base("select * from Cities"))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Выберите город");
            int cit = Convert.ToInt32(Console.ReadLine());
            modelSqlGame.AddCityXList(lst, cit);
            foreach (var item in modelSqlGame.Base("SELECT Lists.Name, Cities.Name FROM ListXCity lxc join Lists on lxc.id_List = Lists.id join Cities on lxc.id_City = Cities.id"))
            {
                Console.WriteLine(item);
            }
             lst = Convert.ToInt32(Console.ReadLine());
            foreach (var item in modelSqlGame.Base($"SELECT Lists.Name, Cities.Name FROM ListXCity lxc join Lists on lxc.id_List = Lists.id join Cities on lxc.id_City = Cities.id where lxc.id_List = {lst}"))
            {
                Console.WriteLine(item);
            }
            */
            MainControler mainControler = new MainControler();
            mainControler.Game();

        }
    }
}
