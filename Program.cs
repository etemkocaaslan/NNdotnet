using NNdotnet;

NeuralNetwork network = new(3);

LayerFactory layerFactory = new();

network.Add(layerFactory.CreateNeuralLayer(3, new RectifiedActivation(), new WeigthedInput()));
network.Add(layerFactory.CreateNeuralLayer(1, new SigmoidActivation(0.1), new WeigthedInput()));

network.PushExpectedValues(
    [
        [0],
        [1],
        [1],
        [0],
        [1],
        [0],
        [0],
    ]);

network.Train(
    [
        [150, 2, 0],
        [1002, 56, 1],
        [1060, 59, 1],
        [200, 3, 0],
        [300, 3, 1],
        [120, 1, 0],
        [80, 1, 0],
    ], 10000000);

network.PushInputValues([1054, 54, 1]);
var outputs = network.GetOutput();