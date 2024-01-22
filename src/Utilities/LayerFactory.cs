using NNdotnet.src.Interfaces;
using NNdotnet.src.Models;

namespace NNdotnet.src.Utilities
{
    public class LayerFactory
    {
        public static Layer Create(int numberOfNeurons, IActivation activationFunction, IInput inputFunction)
        {
            var layer = new Layer();
            for (int i = 0; i < numberOfNeurons; i++)
            {
                layer.Neurons.Add(new Neuron(activationFunction, inputFunction));
            }
            return layer;
        }
    }
}
