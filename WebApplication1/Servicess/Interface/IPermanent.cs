using WebApplication1.Models;

namespace WebApplication1.Servicess.Interface
{
    public interface IPermanent
    {
        Employee GetEmployee(int id);
        Employee AddEmployee(Employee employee);
        Employee GetPhoneNumber(int id);
        int GetSalary(int id);
    }
}
