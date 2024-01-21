namespace NNdotnet
{
    public class WeigthedInput : IInput
    {
        public double CalculateInput(List<ISynapse> inputs)
        {
            return inputs.Select(x=> x.Weight * x.GetOutput()).Sum();
        }
    }
}
