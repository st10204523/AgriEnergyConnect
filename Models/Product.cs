using AgriEnergyConnect.Models;
using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public string ProductID { get; set; }
    public string ProductName { get; set; }
    public string ProductCategory { get; set; }
    public DateTime ProductProductionDate { get; set; }

    public string FarmerEmail { get; set; }
    public User Farmer { get; set; }
}