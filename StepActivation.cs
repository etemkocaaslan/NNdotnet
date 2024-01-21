namespace NNdotnet
{
    public class StepActivation : IActivation
    {
        private double _treshold;

        public StepActivation(double treshold)
        {
            _treshold = treshold;
        }

        public double CalculateOutput(double weightedInput)
        {
            return (weightedInput > _treshold) ? 1.0 : 0; // step function 
        }
    }
}
