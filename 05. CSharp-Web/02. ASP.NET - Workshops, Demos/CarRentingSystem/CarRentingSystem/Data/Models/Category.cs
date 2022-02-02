namespace CarRentingSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public int Id { get; init; }

        [Required]
        public string Name { get; init; }

        public IEnumerable<Car> Cars { get; init; } = new List<Car>();
    }
}
