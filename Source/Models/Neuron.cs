using NNdotnet.src.Interfaces;

namespace NNdotnet.src.Models
{
    public class Neuron(IActivation activation, IInput input) : INeuron
    {
        private readonly IActivation activationFunction = activation;
        private readonly IInput inputFunction = input;
        public List<ISynapse> Inputs { get; set; } = new List<ISynapse>();
        public List<ISynapse> Outputs { get; set; } = new List<ISynapse>();

        public Guid Id { get; private set; } = Guid.NewGuid();

        public double PartialDerivate { get; set; }

        public void AddInputNeuron(INeuron inputNeuron)
        {
            Synapse synapse = new(inputNeuron, this);
            Inputs.Add(synapse);
            inputNeuron.Outputs.Add(synapse);
        }

        public void AddOutputNeuron(INeuron outputNeuron)
        {
            Synapse synapse = new(outputNeuron, this);
            Outputs.Add(synapse);
            outputNeuron.Inputs.Add(synapse);
        }

        public void AddInputSynapse(double inputValue)
        {
            InputSynapse inputSynapse = new(this, inputValue);
            Inputs.Add(inputSynapse);
        }

        public double CalculateOutput()
        {
            return activationFunction.CalculateOutput(inputFunction.CalculateInput(Inputs));
        }

        public void PushValueOnInput(double inputValue)
        {
            ((InputSynapse)Inputs.First()).Output = inputValue;
        }
    }
}
