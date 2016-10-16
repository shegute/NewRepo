using System;

namespace Patterns
{
    class TemplatePatternMainApp
    {
        public static void Run()
        {
            DrivingInstructions drivingInstructions = new ManualCarDrivingInstructions();
            drivingInstructions.Drive();
            drivingInstructions = new AutomaticCarDrivingInstructions();
            drivingInstructions.Drive();
            drivingInstructions = new MotorbikeDrivingInstructions();
            drivingInstructions.Drive();

            // Wait for user
            Console.ReadKey();
        }
    }

    public abstract class DrivingInstructions
    {
        public abstract void StartEngine();
        public abstract void OperateTransmission();
        public abstract void OperateAccelerator();
        public void Drive()
        {
            Console.WriteLine("***   Print instructions for {0} ***", this.GetType().Name);
            StartEngine();
            OperateTransmission();
            OperateAccelerator();
            Console.WriteLine("***   End ***");
            Console.WriteLine("");
        }
    }

    public class ManualCarDrivingInstructions : DrivingInstructions
    {
        public override void StartEngine() { Console.WriteLine("Press clutch with left foot, put gear in neutral with right hand. Put in key and turn with right hand."); }
        public override void OperateTransmission() { Console.WriteLine("Press clutch with left foot and put in 1st gear with right hand."); }
        public override void OperateAccelerator() { Console.WriteLine("Press accelerator with right foot and release clutch slowly."); }
    }


    public class AutomaticCarDrivingInstructions : DrivingInstructions
    {
        public override void StartEngine() { Console.WriteLine("Press brake with right foot, put in key with right hand  and press start engine."); }
        public override void OperateTransmission() { Console.WriteLine("Press brake with right foot and put in Drive gear."); }
        public override void OperateAccelerator() { Console.WriteLine("Press accelerator with right foot."); }
    }


    public class MotorbikeDrivingInstructions : DrivingInstructions
    {
        public override void StartEngine() { Console.WriteLine("Press clutch with hand and put gear in neutral with left foot. Put in key and turn. Press start engine button with right hand."); }
        public override void OperateTransmission() { Console.WriteLine("Press clutch with left hand, kick gear and put in 1st gear."); }
        public override void OperateAccelerator() { Console.WriteLine("Turn accelerator with right hand and release clutch slowly."); }
    }
}
