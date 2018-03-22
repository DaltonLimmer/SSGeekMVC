using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSGeek
{
    public static class Calculations
    {
        public static double Weight(string planet, int weight)
        {
            double newWeight = 0.0;

            switch (planet)
            {
                case "Mercury":
                    newWeight = weight * 0.37;
                    break;
                case "Venus":
                    newWeight = weight * 0.90;
                    break;
                case "Earth":
                    newWeight = weight;
                    break;
                case "Mars":
                    newWeight = weight * 0.38;
                    break;
                case "Jupiter":
                    newWeight = weight * 2.65;
                    break;
                case "Saturn":
                    newWeight = weight * 1.13;
                    break;
                case "Uranus":
                    newWeight = weight * 1.09;
                    break;
                case "Neptune":
                    newWeight = weight * 1.43;
                    break;
            }
            return newWeight;

        }

        public static double Age(string planet, int age)
        {
            double newAge = 0;

            switch (planet)
            {
                case "Mercury":
                    newAge = (age * 365.26) / 87.96;
                    break;
                case "Venus":
                    newAge = (age * 365.26) / 224.68;
                    break;
                case "Earth":
                    newAge = age;
                    break;
                case "Mars":
                    newAge = (age * 365.26) / 686.98;
                    break;
                case "Jupiter":
                    newAge = age / 11.862;
                    break;
                case "Saturn":
                    newAge = age / 29.456;
                    break;
                case "Uranus":
                    newAge = age / 84.07;
                    break;
                case "Neptune":
                    newAge = age / 164.81;
                    break;
            }
            return Math.Round(newAge, 2);

        }

        private static int GetSpeed(string travelMethod)
        {
            int speed = 0;

            if (travelMethod.Equals("Walking"))
            {
                speed = 3;
            }
            else if (travelMethod.Equals("Car"))
            {
                speed = 100;
            }
            else if (travelMethod.Equals("Bullet Train"))
            {
                speed = 200;
            }
            else if (travelMethod.Equals("Boeing 747"))
            {
                speed = 570;
            }
            else if (travelMethod.Equals("Concorde"))
            {
                speed = 1350;
            }

            return speed;
        }

        public static double TravelTime(string planet, string transportMode)
        {
            int speed = GetSpeed(transportMode);
            double travelYears = 0;

            switch (planet)
            {
                case "Mercury":
                    travelYears = 56974146.0 / speed / 8760.0;
                    break;
                case "Venus":
                    travelYears = 25724767.0 / speed / 8760.0;
                    break;
                case "Earth":
                    travelYears = 0;
                    break;
                case "Mars":
                    travelYears = 48678219.0 / speed / 8760.0;
                    break;
                case "Jupiter":
                    travelYears = 390674710.0 / speed / 8760.0;
                    break;
                case "Saturn":
                    travelYears = 792248270.0 / speed / 8760.0;
                    break;
                case "Uranus":
                    travelYears = 1692662530.0 / speed / 8760.0;
                    break;
                case "Neptune":
                    travelYears = 2703959960.0 / speed / 8760.0;
                    break;
            }

            return Math.Round(travelYears, 2);

        }
    }
}