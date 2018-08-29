using Cuti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuti.Controller
{
    class UserController
    {
        ModelCuti context = new ModelCuti();

        public void Menu()
        {
            int pilihan;
            string input;
            do
            {
                Console.Clear();
                Console.WriteLine("==========================");
                Console.WriteLine("1. Get All");
                Console.WriteLine("2. Get By Id");
                Console.WriteLine("3. Insert");
                Console.WriteLine("4. Update");
                Console.WriteLine("5. Delete");
                Console.WriteLine("6. Exit");
                Console.WriteLine("==========================");
                Console.Write("Pilih Action : ");
                pilihan = Convert.ToInt32(Console.ReadLine());

                switch (pilihan)
                {
                    case 1:
                        getAll();
                        Console.ReadKey(true);
                        break;
                    case 2:
                        Console.Write("Masukan ID User yang ingin dicari : ");
                        input = Console.ReadLine();
                        GetById2(input);
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Insert();
                        //Console.ReadKey(true);
                        break;
                    case 4:
                        Console.Write("Masukan ID User yang ingin di Update : ");
                        input = Console.ReadLine();
                        Update(input);
                        Console.ReadKey(true);
                        break;
                    case 5:
                        Console.Write("Masukan ID User yang ingin di Delete : ");
                        input = Console.ReadLine();
                        Delete(input);
                        Console.ReadKey(true);
                        break;
                    default: break;
                }
            } while (pilihan != 6);
        }

        public List<User> getAll()
        {
            var getAll = context.Users.ToList();
            foreach (User users in getAll)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id                : " + users.Id);
                Console.WriteLine("Role Id           : " + users.RoleId);
                Console.WriteLine("Name              : " + users.Name);
                Console.WriteLine("Email             : " + users.Email);
                Console.WriteLine("Company           : " + users.Company);
                Console.WriteLine("Department        : " + users.Department);
                Console.WriteLine("Job Title         : " + users.Job_Title);
                Console.WriteLine("Jenis Kelamin     : " + users.Jenis_Kelamin);
                Console.WriteLine("Username          : " + users.Username);
                Console.WriteLine("Password          : " + users.Password);
                Console.WriteLine("Tanggal Lahir     : " + users.Tanggal_Lahir);
                Console.WriteLine("This Year Balance : " + users.This_Year_Balance);
                Console.WriteLine("Last Year Balance : " + users.Last_Year_Balance);
                Console.WriteLine("-------------------------");
            }

            return getAll;
        }

        public void Insert()
        {
            string id, role_id, name, email, company, department, jobtitle, jenis_kelamin, username, password;
            DateTime tanggal_lahir;
            int this_year_balance, last_year_balance;
            // inputan by user
            Console.Write("Masukkan Id User           : ");
            id = Console.ReadLine();
            Console.Write("Masukkan Role Id           : ");
            role_id = Console.ReadLine();
            Console.Write("Masukkan Nama              : ");
            name = Console.ReadLine();
            Console.Write("Masukkan Email             : ");
            email = Console.ReadLine();
            Console.Write("Masukkan Perusahaan        : ");
            company = Console.ReadLine();
            Console.Write("Masukkan Departement       : ");
            department = Console.ReadLine();
            Console.Write("Masukkan Job Title         : ");
            jobtitle = Console.ReadLine();
            Console.Write("Masukkan Gender            : ");
            jenis_kelamin = Console.ReadLine();
            Console.Write("Masukkan Username          : ");
            username = Console.ReadLine();
            Console.Write("Masukkan Password          : ");
            password = Console.ReadLine();
            Console.Write("Masukkan Birth Date        : ");
            tanggal_lahir = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Masukkan This Year Balance : ");
            this_year_balance = Convert.ToInt16(Console.ReadLine());
            Console.Write("Masukkan Last Year Balance : ");
            last_year_balance = Convert.ToInt16(Console.ReadLine());

            // proses save ke database


            User users = new User()
            {
                Id = id,
                RoleId = role_id,
                Name = name,
                Email = email,
                Company = company,
                Department = department,
                Job_Title = jobtitle,
                Jenis_Kelamin = jenis_kelamin,
                Username = username,
                Password = password,
                Tanggal_Lahir = tanggal_lahir,
                This_Year_Balance = this_year_balance,
                Last_Year_Balance = last_year_balance
                //department_id = id_dept,
                //role_id = id_rol

            };
            try
            {
                context.Users.Add(users);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
                Console.Write(ex.Message);
                Console.Write(ex.StackTrace);
            }
        }

        public User GetById(string input)
        {
            User user = context.Users.Find(input);
            if (user == null)
            {
                Console.Write("Id " + input + " Tidak Ada");
                Console.Read();
            }
            return user;
        }

        public User GetById2(string input)
        {
            User users = context.Users.Find(input);
            if (users == null)
            {
                Console.Write("Id " + input + " Tidak Ada");
                Console.Read();
            }
            else
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id        : " + users.Id);
                Console.WriteLine("Name      : " + users.Name);
                Console.WriteLine("Email     : " + users.Email);
                Console.WriteLine("Job Title : " + users.Job_Title);
                Console.WriteLine("Gender    : " + users.Jenis_Kelamin);
                Console.WriteLine("Birth Date: " + users.Tanggal_Lahir);
                Console.WriteLine("Username  : " + users.Username);
                Console.WriteLine("Password  : " + users.Password);
                Console.WriteLine("-------------------------");
            }
            return users;
        }

        public string Update(string input)
        {
            string name, email, jobtitle, jenis_kelamin, username, password;
            DateTime tanggal_lahir;
            var users = context.Users.Find(input);

            Console.WriteLine("--------Data Sebelum di Update---------");
            Console.WriteLine("Id           : " + users.Id);
            Console.WriteLine("Role         : " + users.RoleId);
            Console.WriteLine("Name         : " + users.Name);
            Console.WriteLine("Email        : " + users.Email);
            Console.WriteLine("Job Title    : " + users.Job_Title);
            Console.WriteLine("Gender       : " + users.Jenis_Kelamin);
            Console.WriteLine("Birth Date   : " + users.Tanggal_Lahir);
            Console.WriteLine("Password     : " + users.Username);
            Console.WriteLine("Password     : " + users.Password);
            Console.WriteLine("-------------------------\n");

            Console.Write("Masukkan Nama            : ");
            name = Console.ReadLine();
            Console.Write("Masukkan Email           : ");
            email = Console.ReadLine();
            Console.Write("Masukkan Job Title       : ");
            jobtitle = Console.ReadLine();
            Console.Write("Masukkan Gender          : ");
            jenis_kelamin = Console.ReadLine();
            Console.Write("Masukkan Birth Date      : ");
            tanggal_lahir = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Username             : ");
            username = Console.ReadLine();
            Console.Write("Masukkan Password        : ");
            password = Console.ReadLine();
            /*Console.Write("Masukkan Department ID : ");
            id_dept = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Role ID : ");
            id_rol = Convert.ToInt32(Console.ReadLine());*/


            User user = GetById(input);
            user.Name = name;
            user.Email = email;
            user.Job_Title = jobtitle;
            user.Jenis_Kelamin = jenis_kelamin;
            user.Tanggal_Lahir = tanggal_lahir;
            user.Username = username;
            user.Password = password;

            context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            Console.WriteLine("\n--------Data Sesudah di Update---------");
            Console.WriteLine("Id           : " + users.Id);
            Console.WriteLine("Name         : " + users.Name);
            Console.WriteLine("Email        : " + users.Email);
            Console.WriteLine("Job Title    : " + users.Job_Title);
            Console.WriteLine("Gender       : " + users.Jenis_Kelamin);
            Console.WriteLine("Birth Date   : " + users.Tanggal_Lahir);
            Console.WriteLine("Username     : " + users.Username);
            Console.WriteLine("Password     : " + users.Password);
            Console.WriteLine("-------------------------");

            return input;
        }

        public string Delete(string input)
        {
            User users = context.Users.Find(input);
            context.Entry(users).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            Console.Write("User dengan ID User " + input + " Berhasil terhapus!");
            return input;
        }
    }
}
