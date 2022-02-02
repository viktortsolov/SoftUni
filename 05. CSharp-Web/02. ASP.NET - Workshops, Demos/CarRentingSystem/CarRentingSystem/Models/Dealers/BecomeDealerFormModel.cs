namespace CarRentingSystem.Models.Dealers
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class BecomeDealerFormModel
    {
        [Required]
        [StringLength(DealerNameMaxLength, MinimumLength = DealerNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
