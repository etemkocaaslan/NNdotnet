using NNdotnet.src.Interfaces;

namespace NNdotnet.src.Models
{
    public class WeigthedInput : IInput
    {
        public double CalculateInput(List<ISynapse> inputs)
        {
            return inputs.Select(x => x.Weight * x.GetOutput()).Sum();
        }
    }
}
