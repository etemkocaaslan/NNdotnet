using NNdotnet.src.Interfaces;

namespace NNdotnet.src.ActivationFunctions
{
    public class SigmoidActivation(double coeficient) : IActivation
    {
        private double _coeficient = coeficient;
        public double CalculateOutput(double weightedInput)
        {
            return 1 / (1 + Math.Exp(-weightedInput * _coeficient));
        }

        //public double Coeficient { get => _coeficient; set => _coeficient = value; }
    }
}
