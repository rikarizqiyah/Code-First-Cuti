using Cuti.Controller;
using Cuti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuti
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var db = new ModelCuti())
            //{
            //    db.Roles.Add(new Role { Id = "H001", Name = "HR" });
            //    db.SaveChanges();

            //    Console.WriteLine("All roles in the database:");
            //    foreach (var item in db.Roles)
            //    {
            //        Console.WriteLine(item.Id);
            //        Console.WriteLine(item.Name);
            //    }
            //}
            //Console.WriteLine("Press any key to exit...");
            //Console.ReadKey();

            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("=======MENU=======");
                Console.WriteLine("1. User");
                Console.WriteLine("2. Special Leave");
                Console.WriteLine("==================");
                Console.Write("Pilih Action : ");
                choice = Convert.ToInt32(System.Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        UserController panggil_user = new UserController();
                        panggil_user.Menu();
                        break;
                    case 2:
                        SpecialLeaveController panggil_sl = new SpecialLeaveController();
                        panggil_sl.Menu();
                        break;
                    default:
                        System.Console.Write("Terima Kasih :)");
                        System.Console.Read();
                        break;
                }
            } while (choice != 3);
        }
    }
}
