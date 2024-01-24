using NNdotnet.src.Interfaces;

namespace NNdotnet.src.Models
{
    public class Layer
    {
        public List<INeuron> Neurons;

        public Layer()
        {
            Neurons = [];
        }

        /* Neurons (A, B, C)
           InputLayer Neurons (X , Y)
           (A, X), (A, Y), (B, X), (B, Y), (C, X), (C, Y)
        */
        public void Connect(Layer inputLayer)
        {
            Neurons.SelectMany(neuron => inputLayer.Neurons, (neuron, input) => new { neuron, input })
                    .ToList()
                    .ForEach(cartesianProductResult => cartesianProductResult.neuron.AddInputNeuron(cartesianProductResult.input));
        }
    }
}
