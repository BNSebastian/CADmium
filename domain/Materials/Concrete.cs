using System.ComponentModel.DataAnnotations;

namespace domain.Materials
{
    public class Concrete
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Class { get; set; }

        [Required]
        public float? CharacteristicCompressiveStrength { get; set; }

        public float? DesignCompressiveStrength { get; set; }

        [Required]
        public float? CharacteristicTensileStrength { get; set; }

        public float? DesignTensileStrength { get; set; }
    }
}