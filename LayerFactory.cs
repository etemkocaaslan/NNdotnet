namespace NNdotnet
{ 
    public class LayerFactory
    {
        public Layer CreateNeuralLayer(int numberOfNeurons, IActivation activationFunction, IInput inputFunction)
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
