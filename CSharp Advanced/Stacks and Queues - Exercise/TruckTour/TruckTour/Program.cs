using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            var countOfPetrolPumps = long.Parse(Console.ReadLine());

           List<long> amontOfPetrol = new List<long>();
           List<long> distanceToPetrolPump = new List<long>();
           Queue<long> indexesOfPetrolPumps = new Queue<long>();

            long smallestIndexToStart = 0;
            long result = 0;
            long lastResult = 0;
            bool startFromTheBeginning = false;

            for (int i = 0; i < countOfPetrolPumps; i++)
            {
                var input = Console.ReadLine()
                                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(long.Parse)
                                   .ToArray();

                amontOfPetrol.Add(input[0]);
                distanceToPetrolPump.Add(input[1]);
                indexesOfPetrolPumps.Enqueue(i);
            }

            for (int i = 0; i < countOfPetrolPumps; i++)
            {
                if (startFromTheBeginning == true || i == 0)
                {
                    i = 0;
                    if (i == 0)
                    {
                        if (amontOfPetrol[i] < distanceToPetrolPump[i])
                        {

                            long lastNumberOfAmountOfPetrol = amontOfPetrol[0];
                            long lastNumberOfDistanceToPetrolPump = distanceToPetrolPump[0];

                            for (int j = 0; j < countOfPetrolPumps - 1; j++)
                            {
                                amontOfPetrol[j] = amontOfPetrol[j + 1];
                                distanceToPetrolPump[j] = distanceToPetrolPump[j + 1];
                            }

                            amontOfPetrol[amontOfPetrol.Count - 1] = lastNumberOfAmountOfPetrol;
                            distanceToPetrolPump[distanceToPetrolPump.Count - 1] = lastNumberOfDistanceToPetrolPump;
                            indexesOfPetrolPumps.Dequeue();
                            startFromTheBeginning = true;
                        }
                        else
                        {
                            result = amontOfPetrol[i] - distanceToPetrolPump[i];
                            lastResult = result;
                            smallestIndexToStart = indexesOfPetrolPumps.Peek();
                            startFromTheBeginning = false;
                        }
                    }
                }
                else
                {
                    result = lastResult + amontOfPetrol[i];
                    result -= distanceToPetrolPump[i];
                    if (result < 0)
                    {
                        long lastNumberOfArray1 = amontOfPetrol[0];
                        long lastNumberOfArray2 = distanceToPetrolPump[0];
                        for (int j = 0; j < countOfPetrolPumps - 1; j++)
                        {
                            amontOfPetrol[j] = amontOfPetrol[j + 1];
                            distanceToPetrolPump[j] = distanceToPetrolPump[j + 1];
                        }

                        amontOfPetrol[amontOfPetrol.Count - 1] = lastNumberOfArray1;
                        distanceToPetrolPump[distanceToPetrolPump.Count - 1] = lastNumberOfArray2;
                        indexesOfPetrolPumps.Dequeue();
                        startFromTheBeginning = true;
                    }
                    else
                    {
                        lastResult = result;
                        startFromTheBeginning = false;
                    }
                }
            }
            Console.WriteLine(smallestIndexToStart);
        }
    }
}