using NNdotnet.src.Utilities;

namespace NNdotnet.src.Models
{
    public class NeuralNetwork
    {
        readonly LayerFactory _layerFactory;

        readonly List<Layer> _layers;
        readonly double alpha;
        double[][] _target;

        public NeuralNetwork(int numberOfInputNeurons)
        {
            _layers = [];
            _layerFactory = new LayerFactory();

            CreateInputLayer(numberOfInputNeurons);

            alpha = 0.2;
        }

        public void Add(Layer layer)
        {
            if (_layers.Count != 0)
            {
                layer.Connect(_layers.Last());
            }
            _layers.Add(layer);
        }

        public void PushInputValues(double[] inputs)
        {
            _layers.First().Neurons.ForEach(x => x.PushValueOnInput(inputs[_layers.First().Neurons.IndexOf(x)]));
        }

        public void PushExpectedValues(double[][] expectedOutputs)
        {
            _target = expectedOutputs;
        }

        public List<double> GetOutput()
        {
            List<double> outputValue = [];

            _layers.Last().Neurons.ForEach(neuron =>
            {
                outputValue.Add(neuron.CalculateOutput());
            });

            return outputValue;
        }

        public void Train(double[][] inputs, int Epochs)
        {
            double errorSum = 0;

            for (int epoch = 0; epoch < Epochs; epoch++)
            {
                for (int j = 0; j < inputs.GetLength(0); j++)
                {
                    PushInputValues(inputs[j]);

                    var outputs = new List<double>();

                    // outputs.
                    _layers.Last().Neurons.ForEach(x =>
                    {
                        outputs.Add(x.CalculateOutput());
                    });

                    errorSum = CalculateTotalError(outputs, j);
                    Console.WriteLine(errorSum);
                    HandleOutputLayer(j);
                    HandleHiddenLayers();
                }
            }
        }

        private void CreateInputLayer(int numberOfInputNeurons)
        {
            var inputLayer = LayerFactory.Create(numberOfInputNeurons, new RectifiedActivation(), new WeigthedInput());
            inputLayer.Neurons.ForEach(neuron => neuron.AddInputSynapse(0));
            Add(inputLayer);
        }

        private double CalculateTotalError(List<double> outputs, int row)
        {
            return outputs.Sum(output => Math.Pow(output - _target[row][outputs.IndexOf(output)], 2));
        }

        private void HandleOutputLayer(int row)
        {
            _layers.Last().Neurons.ForEach(neuron =>
            {
                neuron.Inputs.ForEach(connection =>
                {
                    var output = neuron.CalculateOutput();
                    var netInput = connection.GetOutput();

                    var expectedOutput = _target[row][_layers.Last().Neurons.IndexOf(neuron)];

                    var nodeDelta = (expectedOutput - output) * output * (1 - output);

                    connection.UpdateWeight(alpha, -1 * netInput * nodeDelta);

                    neuron.PartialDerivate = nodeDelta;
                });
            });
        }

        private void HandleHiddenLayers()
        {
            for (int k = _layers.Count - 2; k > 0; k--)
            {
                _layers[k].Neurons.ForEach(neuron =>
                {
                    neuron.Inputs.ForEach(connection =>
                    {
                        var output = neuron.CalculateOutput();
                        var netInput = connection.GetOutput();
                        double sumPartial = 0;

                        _layers[k + 1].Neurons
                        .ForEach(outputNeuron =>
                        {
                            outputNeuron.Inputs.Where(i => i.IsFromNeuron(neuron.Id))
                            .ToList()
                            .ForEach(outConnection =>
                            {
                                sumPartial += outConnection.PreviousWeight * outputNeuron.PartialDerivate;
                            });
                        });

                        var delta = -1 * netInput * sumPartial * output * (1 - output);
                        connection.UpdateWeight(alpha, delta);
                    });
                });
            }
        }
    }
}