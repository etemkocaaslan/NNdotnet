
namespace NNdotnet
{
    public class Synapse : ISynapse
    {
        protected INeuron _transmiterNeuron;
        protected INeuron _reciverNeuron;

        public double Weight { get; set; }
        public double PreviousWeight { get; set; } = 0;

        public Synapse(INeuron transmiterNeuron, INeuron reciverNeuron, double weight)
        {
            _transmiterNeuron = transmiterNeuron;
            _reciverNeuron = reciverNeuron;
            Weight = weight;
        }
        
        public Synapse(INeuron transmiterNeuron, INeuron reciverNeuron)
        {
            _transmiterNeuron = transmiterNeuron;
            _reciverNeuron= reciverNeuron;
        }

        public double GetOutput()
        {
            return _transmiterNeuron.CalculateOutput();
        }

        public bool IsFromNeuron(Guid transmiterNeuronId)
        {
            return _transmiterNeuron.Id.Equals(transmiterNeuronId);
        }

        public void UpdateWeight(double alpha, double delta)
        {
            PreviousWeight = Weight;
            Weight += alpha * delta;
        }
    }
}
