using System;
using System.Threading.Tasks;
using Samples.Entities;

namespace Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var userManager = new UserManager();
            var user1 = new User(1,"Majdee");
            var user2 = new User(2, "Zoabi");

            Task.Run(() => userManager.EditUser(user1));
            Task.Run(() => userManager.EditUser(user2));
            Task.Run(() => userManager.EditUser(user1));

            Console.ReadKey();
        }
    }
}
