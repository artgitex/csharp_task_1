using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;


namespace Task_1
{
    public class UserRepository : IUserRepository
    {
        ApplicationContext db = new ApplicationContext();
                
        public IEnumerable<User> GetAllUsers() => db.Users;
        public User GetUser(int id) => db.Users.Find(id);
        public bool Delete(int id)
        {
            bool removed = false;

            User user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                removed =  true;
            }
            
            return removed;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
