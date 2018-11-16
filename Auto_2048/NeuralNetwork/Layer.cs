﻿using System;
using System.Linq;

namespace FeedForwardNeuralNetwork
{
    public class Layer
    {
        public Neuron[] Neurons;
        public double[] Output => Neurons.Select(n => n.Output).ToArray();

        public Layer(Func<double, double> activation, int inputCount, int neuronCount)
        {
            Neurons = new Neuron[neuronCount];
            for (int i = 0; i < Neurons.Length; i++)
            {
                Neurons[i] = new Neuron(activation, inputCount);
            }
        }

        public void Randomize(Random rand)
        {
            for (int i = 0; i < Neurons.Length; i++)
            {
                Neurons[i].Randomize(rand);
            }
        }

        public double[] Compute(double[] input)
        {
            for (int i = 0; i < Neurons.Length; i++)
            {
                Neurons[i].Compute(input);
            }
            return Output;
        }
    }
}