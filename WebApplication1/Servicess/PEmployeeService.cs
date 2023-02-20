using WebApplication1.Models;
using WebApplication1.Servicess.Abstract_Class;
using WebApplication1.Servicess.Interface;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication1.Servicess
{
    public class PEmployeeService : AEmployee, IPermanent
    { 
        static List<Employee> Employees = new List<Employee>();

        private readonly ApplicationDbContext contexDB;
        public PEmployeeService(ApplicationDbContext _contex)
        {
            contexDB = _contex;
        }


        public Employee GetEmployee(int IdNumber)
        {
            return contexDB.Employees.FirstOrDefault(p => p.IdNumber == IdNumber);
        }

        public  Employee AddEmployee(Employee employee)
        {
            try
            { 
                contexDB.Employees.Add(employee);
                contexDB.SaveChanges();
                return contexDB.Employees.FirstOrDefault(p => p.IdNumber == employee.IdNumber);
            }                   
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Error");
                return (null);
            }
        }

        public int GetSalary(int IdNumber)
        {
            Employee EmplSalary = contexDB.Employees.FirstOrDefault(p => p.IdNumber == IdNumber);
            int baseSalary = CalculateSalary(EmplSalary.baseSalary);    
            return baseSalary;

        }

        public Employee GetPhoneNumber(int IdNumber)
        {
            Employee EmplPhoneNumber = contexDB.Employees.FirstOrDefault(p => p.IdNumber == IdNumber);
            return EmplPhoneNumber;
        }

        public override int CalculateSalary(int baseSalary)
        {
            return (int)(baseSalary + baseSalary * 0.3);

        }


    }

}



