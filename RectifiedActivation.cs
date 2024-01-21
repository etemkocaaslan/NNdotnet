﻿namespace NNdotnet
{
    public class RectifiedActivation : IActivation
    {
        public double CalculateOutput(double weightedInput)
        {
            return Math.Max(0, weightedInput);
        }
    }
}
