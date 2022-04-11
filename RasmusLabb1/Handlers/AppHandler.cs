using Microsoft.EntityFrameworkCore;
using RasmusLabb1.Contexts;
using RasmusLabb1.Entities;
using RasmusLabb1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RasmusLabb1.Handlers
{
    class AppHandler
    {
        public static int CheckEmployee(string input, List<Employee> list)
        {
            var success = int.TryParse(input, out var output);

            if (success)
            {
                if (output <= list.Count)
                {
                    return output;
                }

                return -1;
            }

            return -1;
        }

        //SE LEDIGHETSANSÖKNINGAR FÖR SPECIFIK MÅNAD//
        public static void GetMonth()
        {
            try
            {
            int month;
            Array values = Enum.GetValues(typeof(Months));

            Console.Clear();
            Console.WriteLine("Välj den månad du vill se ledighetsansökningar för:\n");

            foreach (Months val in values)
            {
                Console.WriteLine($"{(int)val}. {Enum.GetName(typeof(Months), val)}");
            }

            month = int.Parse(Console.ReadLine());
            if ((month < 0) || (month > 12))
            {
                Console.Clear();
                Console.WriteLine("Invalid input! Enter a valid number, Press enter and try again!");
                Console.ReadLine();
                GetMonth();
            }
            else
                using (var db = new AppDbContext())
                {
                    List<Employee> employees = db.Employees.ToList();
                    var apps = from a in db.LeaveApplications
                               where a.StartDate.Month == month
                               select a;

                    

                    Console.Clear();
                    Console.WriteLine($"Dessa löneansökningar finns för: {month}:\n\n" +
                                      "---------------------------------------------------------------------------------------------------------------------");
                    foreach (var item in apps)
                    {
                        Console.WriteLine($"Anställd: {item.EmployeeId} | Ledighetstyp: {item.LeaveReason} | Startdatum: {item.StartDate.ToShortDateString()} | Slutdatum: {item.EndDate.ToShortDateString()} | Skapades: {item.ApplicationCreated.ToShortDateString()} |");
                    }
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                    RunApp.ReturnToMenu();
                }
            }
            catch (Exception)
            {
                GetMonth();
            }
            

        }

        //LEDIGHETSANSÖKNINGAR FÖR SPECIFIK ANSTÄLLD.
        public static void GetApplicationsByEmployee()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Välj vilken medarbetares ledighetsansökningar du vill se med hjälp av deras ID.");

                GetEmployees();

                var chosenEmployee = int.Parse(Console.ReadLine());

                Console.Clear();
                Console.WriteLine($"Ledighetsansökningar för: {chosenEmployee}\n" +
                                  $"" +
                                  "----------------------------------------------------------------------------");
                using (var db = new AppDbContext())
                {
                    List<LeaveApplication> applications = db.LeaveApplications.ToList();
                    var apps = from a in db.LeaveApplications
                               where a.EmployeeId == chosenEmployee
                               select a;


                    foreach (var item in apps)
                    {
                        Console.WriteLine($"Anställd: {item.EmployeeId} Ledighetstyp: {item.LeaveReason} Startdatum: {item.StartDate.ToShortDateString()} Slutdatum: {item.EndDate.ToShortDateString()}");
                    }
                    Console.WriteLine("----------------------------------------------------------------------------");
                    RunApp.ReturnToMenu();
                }
            }
            catch (Exception)
            {
                GetApplicationsByEmployee();
            }
            
        }

        //HÄMTAR IN ALLA ANSTÄLLDA FRÅN DATABASEN//
        public static void GetEmployees()
        {
            try
            {
            using (var db = new AppDbContext())
            {
                List<Employee> employees = db.Employees.ToList();
                foreach (Employee p in employees)
                {
                    Console.WriteLine("Namn: {0}\t| Id: {1}", p.FullName, p.EmployeeId);
                }
            }
            return;
            }
            catch (Exception)
            {
                Console.WriteLine("Inga anställda finns i databasen.");
                throw;
            }

        }

        //VISAR ALLA LEDIGHETSANSÖKNINGAR//
        public static void AllLeaveApplications()
        {
            try
            {
            Console.Clear();

            GetEmployees();

            Console.WriteLine("\n\n\t\t\t---------------- AKTUELLA LEDIGHETSANSÖKNINGAR ----------------\n");
            using (var db = new AppDbContext())
            {

                List<LeaveApplication> products = db.LeaveApplications.ToList();
                foreach (LeaveApplication p in products)
                {
                    Console.WriteLine("AnställningsID: {0} \t|   Ledighetstyp: {1} \t|   Från: {2} \t|   Till: {3} |", p.EmployeeId, p.LeaveReason, p.StartDate.ToShortDateString(), p.EndDate.ToShortDateString());
                }
            }
            RunApp.ReturnToMenu();
            return;
            }
            catch (Exception)
            {
                RunApp.RunApplication();
                throw;
            }

        }
    }
}
