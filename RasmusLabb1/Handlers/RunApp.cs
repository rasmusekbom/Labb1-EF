using RasmusLabb1.Contexts;
using RasmusLabb1.Entities;
using RasmusLabb1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RasmusLabb1.Handlers
{
    class RunApp
    {
        public static void RunApplication()
        {
            var employeeId = 0;

            Console.Clear();
            Console.WriteLine("Välkommen! Vilken medarbetare vill du logga in som?");

            AppHandler.GetEmployees();

            Console.WriteLine("\n\nVar god välj med hjälp av ID-numret, följt av Enter.\n" +
                              "Till exempel: 22");

            using (var db = new AppDbContext())
            {
                List<Employee> employees = db.Employees.ToList();
                employeeId = AppHandler.CheckEmployee(Console.ReadLine(), employees); 
                if ((employeeId < 0) || (employeeId > employees.Count()))
                {
                    Console.WriteLine("Fel input. Var god skriv ett av de ID-nummer som visas ovan, följt av Enter.");
                    Console.ReadLine();
                    RunApplication();
                }
            }

            Console.Clear();
            Console.WriteLine("Du är nu inloggad som: " + employeeId + "\n\n");

            Console.WriteLine("Vad vill du göra nu? Var god välj med hjälp av föreskriven siffra följt av Enter. \n" +
                               "(1) Ansöka om ledighet.\n" +
                               "(2) Se mina tidigare ledighetsansökningar." +
                               "\n\n---------------- ADMIN-VAL ----------------\n\n" +
                               "(3) Se alla ledighetsansökningar.\n" +
                               "(4) Se alla ledighetsansökningar för en specifik månad.\n" +
                               "(5) Se alla ledighetsansökningar för en specifik anställd.");


            var userChoice = Console.ReadLine();

            //ANSÖK OM NY LEDIGHET//

            if (userChoice == "1")
            {
                Console.Clear();
                Console.WriteLine("---------------- LEDIGHETSANSÖKAN ----------------\n\n" +
                                  "Var god fyll i den information som vi frågar efter." +
                                  "Vilken typ av ledighet ansöker du om? \n" +
                                  "(1) Barnledigt.\n" +
                                  "(2) Semester.\n" +
                                  "(3) Sjukdom.");

                var reasonOfLeave = Console.ReadLine();
                LeaveReason reason = (LeaveReason)Convert.ToInt32(reasonOfLeave);

                Console.WriteLine("Okej! För vilken period söker du ledighet?\n" +
                                  "Skriv i denna datumform: YYYY/MM/DD.\nExempelvis: 2022/06/20" +
                                  "\n\nBörja med startdatum följt av Enter.");

                DateTime startDate = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Okej! Och när ska din ledighet sluta?");

                DateTime endDate = Convert.ToDateTime(Console.ReadLine());

                using AppDbContext myContext = new AppDbContext();
                myContext.LeaveApplications.Add(new LeaveApplication()
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    LeaveReason = reason,
                    ApplicationCreated = DateTime.Now,
                    EmployeeId = employeeId

                });

                myContext.SaveChanges();

                ReturnToMenu();
            }

            //SE MINA TIDIGARE ANSÖKNINGAR//

            if (userChoice == "2")
            {
                using (var db = new AppDbContext())
                {
                    var apps = from a in db.LeaveApplications
                               where a.EmployeeId == employeeId
                               select a;

                    Console.Clear();
                    Console.WriteLine("Du har tidigare ansökt om semester för dessa perioder:\n\n" +
                                      "----------------------------------------------------------------------------");
                    foreach (var item in apps)
                    {
                        Console.WriteLine($"Ledighetstyp: {item.LeaveReason} Startdatum: {item.StartDate.ToShortDateString()} Slutdatum: {item.EndDate.ToShortDateString()}");
                    }
                    Console.WriteLine("----------------------------------------------------------------------------");
                    ReturnToMenu();
                }
                return;
            }

            //SE ALLA AKTUELLA LEDIGHETSANSÖKNINGAR//

            if (userChoice == "3")
            {
                AppHandler.AllLeaveApplications();
            }


            //SE LEDIGHETSANSÖKNINGAR FÖR SPECIFIK MÅNAD.//
            if (userChoice == "4")
            {
                AppHandler.GetMonth();
            }

            //SE LEDIGHETSANSÖKNINGAR FÖR SPECIFIK ANSTÄLLD//
            if (userChoice == "5")
            {
                AppHandler.GetApplicationsByEmployee();
            }

        }
        public static void ReturnToMenu()
        {
            Console.WriteLine("\nKlicka på valfri tangent för att återgå till startmenyn.");
            Console.ReadKey();
            RunApplication();
        } 
    }
}

