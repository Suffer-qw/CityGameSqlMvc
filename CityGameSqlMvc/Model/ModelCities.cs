using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGameSqlMvc.Model
{
    internal class ModelCities
    {

        public List<string> ListCities = new List<string>();

        public void DeleteCity(string city)
        {
            ListCities.Remove(city.Trim());
        }
        public string Serch(char last)
        {
            foreach (string c in ListCities) 
            {
                string w = c.ToLower();
                if (w[0]==last)
                {
                    DeleteCity(c);
                    return c;
                }
            }
            return null;

        }
        public string Play(string first) 
        { 
            char last = first.Trim()[first.Length - 1];
            string tmp = Serch(last);
            if (tmp is null)
                return "player";
            return tmp.ToLower();

        }
    }
}
