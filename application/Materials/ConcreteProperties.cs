using domain.Materials;

namespace application.Materials
{
    public class ConcreteProperties
    {
        private readonly Concrete _concrete;

        public ConcreteProperties(
            Concrete concrete,
            float coefficientForLongTermEffects,
            float coefficientForLoadArrangement,
            float partialSafetyFactor)
        {
            _concrete = concrete;
            SetDesignCompressiveStrength(coefficientForLongTermEffects, partialSafetyFactor);
            DesignTensileStrength(coefficientForLoadArrangement, partialSafetyFactor);
        }

        public void SetDesignCompressiveStrength(
            float coefficientForLongTermEffects,
            float partialSafetyFactor)
        {
            _concrete.DesignCompressiveStrength = _concrete.CharacteristicCompressiveStrength * coefficientForLongTermEffects / partialSafetyFactor;
        }

        public void DesignTensileStrength(
            float coefficientForLoadArrangement,
            float partialSafetyFactor)
        {
            _concrete.DesignTensileStrength = _concrete.CharacteristicTensileStrength * coefficientForLoadArrangement / partialSafetyFactor;
        }
    }
}