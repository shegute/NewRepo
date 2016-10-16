using System;
using System.Collections.Generic;

namespace Patterns
{
    class FactoryPattern
    {
        public static void Run()
        {
            Vehicle b = new Bike();
            Vehicle c = new Car();
            Vehicle t = new Truck();
            b.DisplayWheels();
            c.DisplayWheels();
            t.DisplayWheels();
        }
    }

    public abstract class Wheel
    {
        public string name;
        public Wheel(string n) { name = n; }
    }

    //public class TruckWheel : Wheel { public TruckWheel(string n) : base(n) { } }
    //public class CarWheel : Wheel { public CarWheel(string n) : base(n) { } }
    //public class BikeWheel : Wheel { public BikeWheel(string n) : base(n) { } }

    public class FrontWheel : Wheel { public FrontWheel(string n) : base(n) { } }
    public class BackWheel : Wheel { public BackWheel(string n) : base(n) { } }

    public abstract class Vehicle
    {
        private List<Wheel> wheels = new List<Wheel>();
        public Vehicle()
        { this.CreateWheels(); }
        public List<Wheel> Wheel { get { return wheels; } }
        public void DisplayWheels()
        {
            foreach (Wheel w in wheels)
            { Console.Write(w.name + ", "); }
            Console.WriteLine();
        }
        public abstract void CreateWheels();
    }
    public class Bike : Vehicle
    {
        public override void CreateWheels()
        {
            //Wheel.Add(new BikeWheel("1Bikewheel"));
            //Wheel.Add(new BikeWheel("2Bikewheel"));
            Wheel.Add(new FrontWheel("FrontBikeWheel"));
            Wheel.Add(new BackWheel("BackBikeWheel"));
        }
    }

    public class Car : Vehicle
    {
        public override void CreateWheels()
        {
            //for (int i = 1; i < 5; i++)
            //{ Wheel.Add(new CarWheel(i.ToString() + "Carwheel")); }

            for (int i = 1; i < 2; i++)
            { Wheel.Add(new FrontWheel(i.ToString() + "FrontCarwheel")); }

            for (int i = 1; i < 2; i++)
            { Wheel.Add(new BackWheel(i.ToString() + "BackCarwheel")); }
        }
    }

    public class Truck : Vehicle
    {
        public override void CreateWheels()
        {
            //for (int i = 1; i < 11; i++)
            //{ Wheel.Add(new TruckWheel(i.ToString() + "Truckwheel")); }

            for (int i = 1; i < 6; i++)
            { Wheel.Add(new FrontWheel(i.ToString() + "FrontCarwheel")); }

            for (int i = 1; i < 12; i++)
            { Wheel.Add(new BackWheel(i.ToString() + "BackCarwheel")); }
        }
    }
}
