using System.ComponentModel.DataAnnotations;

namespace domain.Materials
{
    public class ConcreteDTO
    {
        public string? Class { get; set; }

        public float? CharacteristicCompressiveStrength { get; set; }

        public float? DesignCompressiveStrength { get; set; }

        public float? CharacteristicTensileStrength { get; set; }

        public float? DesignTensileStrength { get; set; }
    }
}