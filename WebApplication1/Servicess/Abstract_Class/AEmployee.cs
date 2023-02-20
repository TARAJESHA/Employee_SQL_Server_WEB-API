using WebApplication1.Servicess.Interface;
namespace WebApplication1.Servicess.Abstract_Class
{
    public abstract class AEmployee  
    { 
        
        public void EmpDetails(string firstName, string lastName)
        {
            Console.WriteLine(firstName + " " + lastName);
        } 
        public abstract int CalculateSalary(int baseSalary);

    }

}
