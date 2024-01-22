using NNdotnet.src.Interfaces;

namespace NNdotnet.src.ActivationFunctions
{
    public class SigmoidActivation : IActivation
    {
        private double _coeficient;

        public SigmoidActivation(double coeficient)
        {
            _coeficient = coeficient;
        }
        public double CalculateOutput(double weightedInput)
        {
            return 1 / (1 + Math.Exp(-weightedInput * _coeficient));
        }
    }
}
