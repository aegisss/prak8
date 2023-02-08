using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Users
    {
        public string Name;
        public string Time;
        private List<Users> ListUser = new List<Users>();

        public List<Users> AddTableRecords(Users user)
        {
            if (File.Exists("D:\\TableRecords.json"))
            {
                ListUser = JsonConvert.DeserializeObject<List<Users>>(File.ReadAllText("D:\\TableRecords.json"));
                for(int i =0;i<ListUser.Count();i++)
                {
                    if (ListUser[i].Name == user.Name)
                    {
                        ListUser[i].Time = user.Time;
                    }else if (i == ListUser.Count-1)
                    {
                        ListUser.Add(user);
                    }

                }
            }
            else
            {
                ListUser.Add(user);
            }
            File.WriteAllText("D:\\TableRecords.json", JsonConvert.SerializeObject(ListUser));
            return (ListUser);
        }
        public void DrewTableRecords()
        {
            Console.WriteLine("Таблица рекордов");
            foreach (var element in ListUser)
            {
                Console.Write(" " + element.Name + " - " + element.Time);
                Console.WriteLine();
            }
        }
    }
}
