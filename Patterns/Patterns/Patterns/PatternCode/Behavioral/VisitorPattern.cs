using System;
using System.Collections.Generic;

namespace Patterns
{
    class VisitorPatternMainApp
    {
        public static void Run()
        {
            ICarInspector engineInspector = new EngineInspector();
            ICarInspector exhaustInspector = new ExhaustInspector();

            VehicleQueue vehicleQueue = new VehicleQueue();
            vehicleQueue.Attach(new Sedan(  "BMW" ));
            vehicleQueue.Attach(new Sedan(  "NISSAN" ));
            vehicleQueue.Attach(new Truck(  "MACK" ));
            vehicleQueue.Accept(engineInspector);
            vehicleQueue.Accept(exhaustInspector);
        }

        public abstract class ICarInspector
        {
            public abstract void Inspect(IVehicle vehicle);
        }

        public class EngineInspector : ICarInspector
        {
            public override void Inspect(IVehicle vehicle)
            { Console.WriteLine("EngineInspector is inspecting {0}", vehicle.Name); }
        }
        public class ExhaustInspector : ICarInspector
        {
            public override void Inspect(IVehicle vehicle)
            { Console.WriteLine("ExhaustInspector is inspecting {0}", vehicle.Name); }
        }

        public abstract class IVehicle
        {
            public string Name { get; set; }
            public IVehicle(string n) { Name = n; }
            public abstract void Accept(ICarInspector carInspector);
        }

        public class Sedan : IVehicle
        { public Sedan(string n) :base(n) { }
            public override void Accept(ICarInspector carInspector)
            {
                carInspector.Inspect(this);
            }
        }

        public class Truck : IVehicle
        {
            public Truck(string n) :base(n) { }
            public override void Accept(ICarInspector carInspector)
            {
                carInspector.Inspect(this);
            }
        }

        public class VehicleQueue
        {
            List<IVehicle> vehicleQueue = new List<IVehicle>();

            public void Attach(IVehicle vehicle)
            {
                vehicleQueue.Add(vehicle);
            }

            public void Dettach(IVehicle vehicle)
            {
                vehicleQueue.Remove(vehicle);
            }

            public void Accept(ICarInspector carInspector)
            { 
                foreach(IVehicle vehicle in vehicleQueue)
                {
                    vehicle.Accept(carInspector);
                }
            }
        }

    }


}
