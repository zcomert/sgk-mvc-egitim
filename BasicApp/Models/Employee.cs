namespace BasicApp.Models;

public class Employee
{
    public int Id { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public Double Salary { get; set; }

    public Employee()
    {
        
    }
    
    // private Double salary;
    // public Double Salary
    // {
    //     get { return salary; }
    //     set { 
    //         if (value<11500)
    //         {
    //             salary = 11500;
    //         }
    //         else
    //         {
    //         salary = value; 
    //         }
    //     }
    // }
    
}
