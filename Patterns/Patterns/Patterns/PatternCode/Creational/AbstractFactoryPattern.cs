using System;

namespace DoFactory.GangOfFour.Abstract.RealWorld
{
    public class AbstractFactoryMainApp
    {
        public static void Run()
        {
            CarShow show = new CarShow(new FordFactory());
            show.RunShow();

            show = new CarShow(new ChevroletFactory());
            show.RunShow();
        }
    }

    public abstract class Engine
    {
        public abstract void Sound();
    }

    public abstract class Transmission
    {
        public abstract void AttachToEngine(Engine engine);
    }

    abstract class CarFactory
    {
        public abstract Engine CreateEngine();
        public abstract Transmission CreateTransmission();
    }

    class FordFactory : CarFactory
    {
        public override Engine CreateEngine() { return new ExplorerEngine(); }
        public override Transmission CreateTransmission() { return new ExplorerTransmission(); }
    }

    public class ExplorerEngine : Engine
    {
        public override void Sound() { Console.WriteLine("{0} makes this sound: Bom bom bom bom bom", this.GetType().Name); }
    }

    public class ExplorerTransmission : Transmission
    {
        public override void AttachToEngine(Engine engine)
        { Console.WriteLine("{0} attaches to {1}", this.GetType().Name, engine.GetType().Name); }
    }

    class ChevroletFactory : CarFactory
    {
        public override Engine CreateEngine() { return new TahoeEngine(); }
        public override Transmission CreateTransmission() { return new TahoeTransmission(); }
    }

    public class TahoeEngine : Engine
    {
        public override void Sound() { Console.WriteLine("{0} makes this sound: Buk buk buk buk buk", this.GetType().Name); }
    }

    public class TahoeTransmission : Transmission
    {
        public override void AttachToEngine(Engine engine)
        { Console.WriteLine("{0} attaches to {1}", this.GetType().Name, engine.GetType().Name); }
    }

    class CarShow
    {
        private Engine engine;
        private Transmission transmission;

        public CarShow(CarFactory factory)
        {
            engine = factory.CreateEngine();
            transmission = factory.CreateTransmission();
        }

        public void RunShow()
        {
            engine.Sound();
            transmission.AttachToEngine(engine);
        }
    }


}
