using System;
using System.Collections.Generic;
using TrafficLights;

public class StartUp
{
    public static void Main()
    {
        var allTraficLights = new List<TrafficLight>();

        var inputSignal = Console.ReadLine().Split();
        var stateChangeCount = int.Parse(Console.ReadLine());

        foreach (var signal in inputSignal)
        {
            var initialColorState = (LightColor)Enum.Parse(typeof(LightColor), signal);
            allTraficLights.Add(new TrafficLight(initialColorState));
        }

        for (int i = 0; i < stateChangeCount; i++)
        {
            foreach (var trafficLight in allTraficLights)
            {
                trafficLight.ChangeState();
            }

            Console.WriteLine(string.Join(" ", allTraficLights));
        }
    }
}