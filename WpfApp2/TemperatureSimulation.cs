using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp2
{
    class TemperatureSimulation: IGenerator
    {
        private List<double?> nTempValues = new List<double?>();
        private double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
        private Nullable<double> Random(int rangeFrom,int rangeTo)
        {
            Random randObj = new Random(1);
            Nullable<double> tempValue = null;
            double randomValue = GetRandomNumber(rangeFrom, rangeTo);
            Thread.Sleep(100);
            if (randomValue==null) { }
            else
            {
                tempValue = randomValue;
            }

            return tempValue;
        }
        
        private List<double?> generateNTemperature(int N, int L, int R)
        {
            for(int i = 0; i < N; i++)
            {
                nTempValues.Add(Random(L,R));
            }
            return nTempValues;
        }
        public List<double?> GetData(int number,int rangeFrom, int rangeTo)
        {
            nTempValues.Clear();
            generateNTemperature(number,rangeFrom, rangeTo);
            return nTempValues;
        }

    }
}
