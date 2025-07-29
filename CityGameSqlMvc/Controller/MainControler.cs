using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using CityGameSqlMvc.Model;
using CityGameSqlMvc.View;

namespace CityGameSqlMvc.Controller
{
    internal class MainControler
    {
        ModelSqlGame msg = new ModelSqlGame();
        ModelCities mc = new ModelCities();
        Viewshka vs = new Viewshka();
        public string Game()
        {
            
            vs.ViewList(msg.Base("select * from Lists"));
            Console.WriteLine("Выбирите Список");

            mc.ListCities = msg.SwitchList(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Введите город или 0 если признаёте поражение");
            string Player = Console.ReadLine();

            if (Player == "0")
            {
                Console.WriteLine("Computer Win");
                return Player;
            }
            

            while (true) 
            {
                mc.DeleteCity(Player);
                string pc = mc.Play(Player);

                if (pc == "player")
                {
                    Console.WriteLine("player Win");
                    break;
                }

                Console.WriteLine("Следующий город " + pc);
                Player = Console.ReadLine();
                if (Player == "0" || Player.ToLower()[0] != pc[pc.Length-1])
                {
                    Console.WriteLine("Computer Win");
                    return Player;
                }

            }
            return Player;

        }
    }
}
