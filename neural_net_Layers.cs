public class Layer {
    int numNodesIn, numNodesOut;
    double[,] weights;
    double[] biases;

    // Create the layer
    public Layer(int numNodesIn, int numNodesOut) {
        this.numNodesIn = numNodesIn;
        this.numNodesOut = numNodesOut;

        weights = new double[numNodesIn, numNodesOut];
        biases = new double[numNodesOut];
    }

    // Calculate the output of the layer
    public double[] CalculateOutputs(double[] inputs) {
        double activations = new double[numNodesOut];

        for (int nodeOut = 0; nodeOut < numNodesOut; nodeOut++) {
            double weightedInputs = biases[nodeOut];
            for (int nodeIn = 0; nodeIn < numNodesIn; nodeIn++) {
                weightedInputs += inputs[nodeIn] * weights[nodeIn, nodeOut];
            }
            activations[nodeOut] = SigmoidActivationFunction(weightedInputs);
        }

        return activations; 
    }

    double ActivationFunction(double weightedInputs) {
        return (weightedInputs > 0) ? 1 : 0;
    }

    // Sigmoid
    double SigmoidActivationFunction(double weightedInputs) {
        return 1 / (1 + Exp(-weightedInputs));
    }

    // Hyperbolic Tangent
    double HyperbolicTangentActivationFunction(double weightedInputs) {
        double e2w = Exp(2 * weightedInputs);
        return (e2w - 1) / (e2w + 1);
    }

    // SiLU
    double SiluActivationFunction(double weightedInputs) {
        return weightedInputs / (1 + Exp(-weightedInputs));
    }

    // ReLU
    double ReluActivationFunction(double weightedInputs) {
        return Max(0, weightedInputs);
    }
}