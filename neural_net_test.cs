// Weight values connecting each input to the first output
double weight_1_1, weight_2_1;
// WEight values connecting each input to the second output
double weight_1_2, weight_2_2;
// Bias values
double bias_1, bias_2;

// Classifies the given fruit as either safe (0) or poisonous (1)
public int Classify(double input_1, double input_2) {
    double output_1 = input_1 * weight_1_1 + input_2 * weight_1_2 + bias_1;
    double output_2 = input_1 * weight_2_1 + input_2 * weight_2_2 +  bias_2;

    // Return 0 if output_1 is greater than output_2, otherwise return 1
    return (output_1 > output_2) ? 0 : 1;
}

// Run on every pixel in the graph display to visualize the output
// of the network across a range of different input values
public void Visualize(double graphX, double graphY) {
    int predictedClass = Classify(graphX, graphY);

    if (predictedClass == 0) {
        graphX.SetColour(graphX, graphY, safeColour);
    }
    else if (predictedClass == 1) {
        graph.SetColour(graphX, graphY, poisonousColour);
    }
}