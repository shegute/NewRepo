using System;
using System.Collections.Generic;

namespace Patterns
{
    class MediatorPatternMainApp
    {
        public static void Run()
        {
            AbstractVendorCompanyRepresentative vendorRepresentative = new VendorCompanyRepresentative();
            Manager manager1 = new Manager("Kojo",null, vendorRepresentative);
            Worker vendor1 = new Vendor("Hamid", manager1, vendorRepresentative);
            Worker vendor2 = new Vendor("Alem",manager1, vendorRepresentative);
            Worker vendor3 = new Vendor("Gurba",manager1, vendorRepresentative);
            Worker vendor4 = new Vendor("Mike",manager1, vendorRepresentative);
            manager1.AddVendor(vendor1);
            manager1.AddVendor(vendor2);
            manager1.AddVendor(vendor3);
            manager1.AddVendor(vendor4);

            manager1.Send();
            manager1.Send();
            manager1.Send();
            manager1.Send();
            manager1.Send();
            vendor1.Send();
            vendor2.Send();
            vendor3.Send();
            vendor4.Send();
            vendor4.Send();
            vendor3.Send();
            vendor2.Send();
            vendor1.Send();
        }
    }

    public abstract class AbstractVendorCompanyRepresentative
    {
        public abstract void Register(Worker worker);
        public abstract void Send(Worker sender, Worker receiver, string message);

    }

    public class VendorCompanyRepresentative : AbstractVendorCompanyRepresentative
    {
        List<Worker> workers = new List<Worker>();
        public override void Register(Worker worker)
        {
            workers.Add(worker);
            worker.abstractVendorCompanyRepresentative = this;
        }
        public override void Send(Worker sender,Worker receiver, string message)
        {
            receiver.Receive(sender, message);
        }
    }

    public abstract class Worker
    {
       public  List<Worker> receivers = new List<Worker>();
        public string Name { get; set; }
        public AbstractVendorCompanyRepresentative abstractVendorCompanyRepresentative { get; internal set; }
       
        public Worker(string name ,Worker receiver, AbstractVendorCompanyRepresentative vendorRep)
        { Name = name; receivers.Add( receiver); abstractVendorCompanyRepresentative = vendorRep; }

        public abstract void Send();

        public abstract void Receive(Worker sender, string message);
    }

    public class Manager : Worker
    {
        public Manager(string name, Worker receiver, AbstractVendorCompanyRepresentative vendorRep)
            : base(name, receiver,vendorRep)
        { }

        public void AddVendor(Worker vendor) { receivers.Add(vendor); }

        public override void Send()
        {
            int vendorNumber = new Random().Next(receivers.Count);
            if (vendorNumber > receivers.Count/2)
            {
                abstractVendorCompanyRepresentative.Send(
                    this, receivers[vendorNumber], string.Format("I am  renewing employment contract for vendor: {0}.", receivers[vendorNumber].Name));
            }
            else
            {
                abstractVendorCompanyRepresentative.Send(
                    this, receivers[vendorNumber], string.Format("I am sadly not renewing employment contract for vendor: {0}.", receivers[vendorNumber].Name));
            }
        }

        public override void Receive(Worker sender, string message)
        {
            Console.WriteLine("I have received message:{0} from: {1}", message, sender.Name);
        }
    }

    public class Vendor : Worker
    {
        public Vendor(string name, Worker receiver, AbstractVendorCompanyRepresentative vendorRep)
            : base(name, receiver,vendorRep)
        { }
        public override void Send()
        {
            if (new Random(100000).Next() > 50000)
            {
                abstractVendorCompanyRepresentative.Send(
                    this, receivers[0], string.Format("I am  accepting employment contract from manager: {0}.", receivers[0].Name));
            }
            else
            {
                abstractVendorCompanyRepresentative.Send(
                    this, receivers[0], string.Format("I am sadly not renewing employment contract for vendor: {0}.", receivers[0].Name));
            }
        }

        public override void Receive(Worker sender, string message)
        {
            Console.WriteLine("I have received message:{0} from: {1}", message, sender.Name);
        }
    }
}
