namespace Citrix.Models
{
    public interface IManager
    {
        string FirstName { get; set; }
        int ID { get; set; }
        string LastName { get; set; }
        string PhotoPath { get; set; }       
    }
}