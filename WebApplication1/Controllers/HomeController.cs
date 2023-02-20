using Microsoft.AspNetCore.Mvc; 
using System.Text.Json;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Servicess.Interface;

 
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IPermanent pEmployeeService;
        private readonly Temporary temporary;
        private readonly ApplicationDbContext contexDB;
        public HomeController(IPermanent _pEmployeeService, Temporary _temporary, ApplicationDbContext _contex)
        {
            pEmployeeService = _pEmployeeService;
            contexDB = _contex;
            temporary = _temporary;
        }

        [HttpPost("Create")]
        public IActionResult Create(Employee empobj)
        {
            Console.WriteLine(empobj.baseSalary);
            if (empobj == null)
            {
                return BadRequest();
            }
            try
            {
                if (empobj.empyeeType == 1)
                {
                    Employee emp = pEmployeeService.AddEmployee(empobj);
                    return Ok(new
                    {
                        Message = "Permanent Employee Succsessfully registerd!"
                    });
                }
                else
                {
                    Employee emp = temporary.AddEmployee(empobj);
                    return Ok(new
                    {
                        Message = "Temporary Employee Succsessfully registerd!"
                    });

                }
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }

        }
        [HttpPost("GetEmployee{IdNumber}")]
        public IActionResult GetEmployee(int IdNumber)
        {

            try
            {
                Employee empType = contexDB.Employees.FirstOrDefault(p => p.IdNumber == IdNumber);

                if (empType.empyeeType == 1)
                {
                    var emp = pEmployeeService.GetEmployee(IdNumber);
                    Console.WriteLine(empType.empyeeType);
                    return Ok(emp);

                }
                else
                {
                    Console.WriteLine(empType.empyeeType);
                    var emp = temporary.GetEmployee(IdNumber);
                    Console.WriteLine(empType.empyeeType);
                    return Ok(emp);
                }
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }

        }
        [HttpPost("GetSalary{IdNumber}")]
        public IActionResult GetSalary(int IdNumber)
        {

            try
            {
                Employee empType = contexDB.Employees.FirstOrDefault(p => p.IdNumber == IdNumber);

                if (empType.empyeeType == 1)
                {
                    var emp = pEmployeeService.GetSalary(IdNumber);
                    Console.WriteLine(empType.empyeeType);

                    return Ok(emp);
                }
                else
                {
                    Console.WriteLine(empType.empyeeType);
                    var emp = temporary.GetSalary(IdNumber);
                    return Ok(emp);
                }
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }

        [HttpPost("GetPhoneNumber{IdNumber}")]
        public IActionResult GetPhoneNumber(int IdNumber)
        {

            try
            {
                Employee empType = contexDB.Employees.FirstOrDefault(p => p.IdNumber == IdNumber);

                if (empType.empyeeType == 1)
                {
                    Employee emp = pEmployeeService.GetPhoneNumber(IdNumber);
                    Console.WriteLine(empType.empyeeType);

                    return Ok(emp.phoneNumber);
                }
                else
                {
                    Console.WriteLine(empType.empyeeType);
                    Employee emp = temporary.GetPhoneNumber(IdNumber);
                    return Ok(emp.phoneNumber);
                }
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }
    }
}