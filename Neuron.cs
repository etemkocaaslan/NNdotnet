
namespace NNdotnet
{
    public class Neuron : INeuron
    {
        private IActivation activationFunction;
        private IInput inputFunction;

        public List<ISynapse> Inputs { get; set; }
        public List<ISynapse> Outputs { get; set; }

        public Guid Id { get; private set; }

        public double PartialDerivate { get; set; }

        public Neuron(IActivation activation, IInput input)
        {
            Id = Guid.NewGuid();
            Inputs = []; //List<ISynapse>
            Outputs = []; //List<ISynapse>

            inputFunction = input;
            activationFunction = activation;
        }

        public void AddInputNeuron(INeuron inputNeuron)
        {
            Synapse synapse = new Synapse(inputNeuron, this);
            Inputs.Add(synapse);
            inputNeuron.Outputs.Add(synapse);
        }

        public void AddOutputNeuron(INeuron outputNeuron)
        {
            Synapse synapse = new Synapse(outputNeuron, this);
            Outputs.Add(synapse);
            outputNeuron.Inputs.Add(synapse);
        }

        public void AddInputSynapse(double inputValue)
        {
            InputSynapse inputSynapse = new InputSynapse(this, inputValue);
            Inputs.Add(inputSynapse);
        }



        public double CalculateOutput()
        {
            return activationFunction.CalculateOutput(inputFunction.CalculateInput(this.Inputs));
        }

        public void PushValueOnInput(double inputValue)
        {
            ((InputSynapse)Inputs.First()).Output = inputValue;
        }
    }
}
