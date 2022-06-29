using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class BuildUserTable
    {
        ApplicationContext db = new ApplicationContext();

        public void FillTable()
        {
            if (!db.Users.Any())
            {
                var lines = File.ReadAllLines("Users.csv");

                foreach (var line in lines)
                {
                    var values = line.Split(',');
                    User user = new User { Date = values[0], FirstName = values[1], SecondName = values[2], City = values[3], Country = values[4] };
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }

        }
    }
}
