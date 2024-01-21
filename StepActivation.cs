using System.Runtime.CompilerServices;

namespace NNdotnet
{
    public class StepActivation(double treshold) : IActivation
    {
        private double _treshold = treshold;

        public double CalculateOutput(double weightedInput)
        {
            return (weightedInput > _treshold) ? 1.0 : 0; // step function 
        }
    }
}
