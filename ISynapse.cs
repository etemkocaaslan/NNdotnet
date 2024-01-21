namespace NNdotnet
{
    public interface ISynapse
    {
        double Weight { get; set; }
        double PreviousWeight { get; set; }
        
        double GetOutput();

        bool IsFromNeuron(Guid transmiterNeuronId);

        void UpdateWeight(double alpha, double delta);
    }
}
