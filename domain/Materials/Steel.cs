using System.ComponentModel.DataAnnotations;

namespace domain.Materials
{
    public class Steel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Class { get; set; }
    }
}