using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        public class Neuron
        {
            private decimal weight = 0.5m;

            public decimal lasterror { get; private set; }

            public decimal Smooth { get; set; } = 0.00001m;

            public decimal ProcessInputData(decimal input)
            {
                return input * weight;
            }
            public decimal RestoreInputData(decimal output)
            {
                return output / weight;
            }

            public void train(decimal input, decimal result)
            {
                var actualresult = input * weight;
                lasterror = result - actualresult;
                var correct = (lasterror / actualresult) * Smooth;
                weight += correct;
            }
        }

        static void Main(string[] args)
        {
            decimal km = 100;
            decimal miles = 62.1331m;
            
            

            Neuron neuron = new Neuron();

            int i = 0;
            do
            {
                i++;
                neuron.train(km, miles);
                Console.WriteLine($"error\t{i} \t{neuron.lasterror}");
            } while (neuron.lasterror > neuron.Smooth || neuron.lasterror < -neuron.Smooth);

            Console.WriteLine("Обучение заверщено");
            Console.WriteLine(neuron.ProcessInputData(km));
            Console.ReadKey();
        }
    }
}
