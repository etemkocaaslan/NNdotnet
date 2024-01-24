using NNdotnet.src.Interfaces;

namespace NNdotnet.src.ActivationFunctions
{
    public class RectifiedActivation : IActivation
    {
        public double CalculateOutput(double weightedInput)
        {
            return Math.Max(0, weightedInput);
        }
    }
}
