namespace AgriEnergyConnect.Models
{
    public class Employee
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public List<Farmer> Farmers { get; set; }
    }
}
