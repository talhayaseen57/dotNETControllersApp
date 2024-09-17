using System.ComponentModel.DataAnnotations;

namespace dotNETControllersApp.Models
{
    public class Animal
    {
        [Required]
        public string? Name { get; set; }
        public string? ScientificName { get; set; }
        public override string ToString()
        {
            return $"{Name} - {ScientificName}.";
        }
    }
}
