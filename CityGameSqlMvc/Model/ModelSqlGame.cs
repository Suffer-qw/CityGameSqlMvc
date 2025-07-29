using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGameSqlMvc.Model
{
    internal class ModelSqlGame
    {

        string connectionString = "Server=DESKTOP-E0DFHR1\\SQLEXPRESS;Database=CityGameSql;Trusted_Connection=True;";

        public List<string> ListCities = new List<string>();   



        public bool TestConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Открываем подключение
                connection.Open();
                Console.WriteLine("Подключение открыто");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // закрываем подключение
                connection.Close();
                Console.WriteLine("Подключение закрыто...");
            }
            return true;
        }

        public int Idnext(string sqltabel)
        {
            int id = Convert.ToInt32(Base($"SELECT count(id) FROM {sqltabel}")[0]);
            return ++id;
        }
        public void Addlist(string Name)
        {
            Base($"INSERT INTO Lists VALUES({Idnext("Lists")}, '{Name}')");
        }
        public void AddCityXList(int list, int city)
        {
            Base($"INSERT INTO ListXCity VALUES  ({Idnext("ListXCity")}, {list}, {city})");
        }
        public List<string> SwitchList(int list)
        {
           return Base($"SELECT Cities.Name FROM ListXCity lxc join Lists on lxc.id_List = Lists.id join Cities on lxc.id_City = Cities.id where lxc.id_List = {list}");
        }


        public List<string> Base(string BaseCommand)
        {
            List<string> list = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               
                connection.Open();
                SqlCommand command = new SqlCommand(BaseCommand, connection);

                /*
                 * В СУБД был добавлен код 
                 * ALTER TABLE ListXCity
                 * ADD CONSTRAINT uq_fk1_fk2 UNIQUE (id_List, id_City);
                 * который запрещает повторения зависимостей список-город
                 * если пользователь всё же решит в один список добавить один и тот же город больше одного раза чтобы программа не заканчивалась полностью с ошибкой
                 * в код был добавлен блок try-catch
                 * 
                 */
                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string tmp = "";
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            tmp += reader.GetValue(i);
                        }
                        list.Add(tmp);
                    }
                    reader.Close();
                }
                catch (Exception ex) 
                { 
                    Console.WriteLine(ex.Message);
                }
            }

            return list;
        }
    }
}
