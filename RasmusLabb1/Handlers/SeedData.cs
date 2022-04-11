using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RasmusLabb1.Contexts;
using RasmusLabb1.Entities;
using RasmusLabb1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RasmusLabb1.Handlers
{
    public class SeedData
    {
            public static void Initialize()
            {
                using AppDbContext myContext = new AppDbContext();
                {
                    //Anställda
                    if (!myContext.Employees.Any())
                    {
                        myContext.Employees.AddRange(new List<Employee>()
                    {
                        new Employee(){ FullName = "Rasmus Ekbom"},
                        new Employee(){ FullName = "Fredrik Olsson"},
                        new Employee(){ FullName = "Anitra Ngoensuwan"},
                        new Employee(){ FullName = "Daniel Ekbom"}
                    });

                        myContext.SaveChanges();
                    }
                    //Ledighetsansökningar
                    if (!myContext.LeaveApplications.Any())
                    {
                        myContext.LeaveApplications.AddRange(new List<LeaveApplication>()
                    {
                        new LeaveApplication()
                        {
                            EmployeeId = 1,
                            ApplicationCreated = DateTime.Now.AddDays(-7),
                            StartDate = DateTime.Now.AddDays(+15),
                            EndDate = DateTime.Now.AddDays(+30),
                            LeaveReason = LeaveReason.Barnledigt

                        },
                        new LeaveApplication()
                        {
                            EmployeeId = 2,
                            ApplicationCreated = DateTime.Now.AddDays(+20),
                            StartDate = DateTime.Parse("2022-07-08"),
                            EndDate = DateTime.Parse("2022-08-08"),
                            LeaveReason = LeaveReason.Semester

                        },
                        new LeaveApplication()
                        {
                            EmployeeId = 3,
                            ApplicationCreated = DateTime.Now,
                            StartDate = DateTime.Now.AddDays(-6),
                            EndDate = DateTime.Now.AddDays(+10),
                            LeaveReason = LeaveReason.Barnledigt

                        },
                        new LeaveApplication()
                        {
                        EmployeeId = 4,
                        ApplicationCreated = DateTime.Now.AddDays(-20),
                        StartDate = DateTime.Parse("2022-08-10"),
                        EndDate = DateTime.Parse("2022-08-30"),
                        LeaveReason = LeaveReason.Semester

                        },
                        new LeaveApplication()
                        {
                            EmployeeId = 4,
                            ApplicationCreated = DateTime.Now.AddDays(+20),
                            StartDate = DateTime.Parse("2022-08-12"),
                            EndDate = DateTime.Parse("2023-08-24"),
                            LeaveReason = LeaveReason.Tjänstledigt

                        },

                    });
                        myContext.SaveChanges();
                    }

                }
            }
        }
    }
