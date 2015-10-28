using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    class StrategyPatteryMainApp
    {
        public static void Run()
        {
            Plane b52Plane = new B52();
            Plane f16Plane = new F16();
            Plane mig32Plane = new Mig32();
            Pilot pilot1 = new Pilot("Teddy Bridgewater");
            pilot1.AddPlaneQualification(new B52());
            pilot1.AddPlaneQualification(new F16());
            pilot1.CurrentPlane = new B52();
            pilot1.SetCurrentPlane(b52Plane);
            pilot1.SetCurrentPlane(mig32Plane);
            pilot1.SetCurrentPlane(f16Plane);
            
            // Wait for user
            Console.ReadKey();
        }
    }

    public abstract class Plane
    {
        public string PlaneName;
        public abstract void FlyPlane(string pilotName);
    }

    public class B52 : Plane
    {
        public new string PlaneName = "B52";
        public override void FlyPlane(string pilotName)
        {
            Console.WriteLine("{0} is flying this B52 plane", pilotName);
        }
    }

    public class F16 : Plane
    {
        public new string PlaneName = "F16";
        public override void FlyPlane(string pilotName)
        {
            Console.WriteLine("{0} is flying this F16 plane", pilotName);
        }
    }

    public class Mig32 : Plane
    {
        public string PlaneName = "Mig32";
        public override void FlyPlane(string pilotName)
        {
            Console.WriteLine("{0} is flying this Mig32 plane", pilotName);
        }
    }

    public class Pilot
    {
        private string pilotName;
        private Plane currentPlane;
        private List<Plane> planeQualifications = new List<Plane>();

        public Pilot(string name)
        {
            pilotName = name;
        }

        public void AddPlaneQualification(Plane plane)
        {
            planeQualifications.Add(plane);
        }

        public bool SetCurrentPlane(Plane plane)
        {
            bool qualified =
                this.planeQualifications.Any(p => p.GetType() == plane.GetType());
            if (qualified)
            {
                CurrentPlane = plane;
                Console.WriteLine(
                        "{0} is qualified to fly plane {1}.",
                        this.pilotName,
                        plane.GetType());
                CurrentPlane.FlyPlane(this.pilotName);
            }
            else
            {
                if (CurrentPlane != null)
                {
                    Console.WriteLine(
                        "{0} is not qualified to fly plane {1}. Pilot is flying currently {2}",
                        this.pilotName, 
                        plane.GetType(),
                        CurrentPlane.GetType());
                }
            }
            return qualified;
        }

        public Plane CurrentPlane
        {
            get
            {
                return this.currentPlane ;
            }
            set
            {
                this.currentPlane = value;
            }
        }
    }


}
