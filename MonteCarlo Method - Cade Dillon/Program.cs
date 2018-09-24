using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MonteCarlo_Method___Cade_Dillon
{
    class Program
    {
        static Random rndm = new Random();
        static void Main(string[] args)
        {
            
            Console.WriteLine("Please enter the number of coordinates you wish to test.");
            string input = Console.ReadLine();
            int arraySize = int.Parse(input);
            double[] coordinates = new double[arraySize];

            for (int index = 0; index < arraySize; index++)
            {
                coordinates[index] = rndm.NextDouble();
                //Console.Write("\n\t" + coordinates[index] + ", ");
            }

            Console.WriteLine();
            int overlap = 0;

            for (int index = 0; index < coordinates.Length; index++)
            {
                Coordinates rndCoord = new Coordinates(coordinates);
                double hypotenuse = GetHypotenuse(rndCoord);
                if (hypotenuse <= 1)
                {
                    overlap++;
                }
                
            }
            double convertedOverlap = Convert.ToDouble(overlap);
            double convertedLength = Convert.ToDouble(coordinates.Length);


            double piEstimate = (convertedOverlap / convertedLength) * 4;
            double diff = Math.Abs(piEstimate) - Math.Abs(Math.PI);
            double absDiff = Math.Abs(diff);
            Console.WriteLine($"The number of overlapping coordinates is: {overlap}.");
            Console.WriteLine($"The Monte-Carlo estimate for pi is : {piEstimate}");
            Console.WriteLine($"The absolute difference between my estimate and the Math.Pi function is: {absDiff}.");
        
        }
        
        struct Coordinates
        {
            
            private double x, y;

            public Coordinates(double x, double y)
            {
                this.x = 1;
                this.y = 1;
            }

            public Coordinates(object random)
            {
                
                this.x = rndm.NextDouble();
                this.y = rndm.NextDouble();
            }

            public double GetX()
            {
                return this.x;
            }

            public double GetY()
            {
                return this.y;
            }
        }

        static double GetHypotenuse(Coordinates coords)
        {
            double legA = coords.GetX();
            double legB = coords.GetY();
            double leftOperand = legA * legA;
            double rightOperand = legB * legB;
            double hypotenuse = Math.Sqrt(leftOperand + rightOperand);
            //Console.WriteLine("\n\t" + hypotenuse);

            return hypotenuse;
        }
    }
}
