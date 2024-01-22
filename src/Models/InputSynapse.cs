using NNdotnet.src.Interfaces;

namespace NNdotnet.src.Models
{
    public class InputSynapse : ISynapse
    {
        protected INeuron _reciverNeuron;

        public double Weight { get; set; }
        public double PreviousWeight { get; set; }
        public double Output { get; set; }

        public InputSynapse(INeuron reciverNeuron)
        {
            _reciverNeuron = reciverNeuron;
            Weight = 1.0;
        }

        public InputSynapse(INeuron reciverNeuron, double output)
        {
            _reciverNeuron = reciverNeuron;
            Weight = output;
            Weight = 1.0;
            PreviousWeight = 1.0;
        }

        public double GetOutput()
        {
            return Output;
        }

        public bool IsFromNeuron(Guid transmiterNeuronId)
        {
            return false;
        }

        public void UpdateWeight(double alpha, double delta)
        {
            throw new NotSupportedException("UpdateWeight is not supported for InputSynapse.");
        }
    }
}
