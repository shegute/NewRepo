using System;

namespace Patterns.PatternCode
{
    class StrategyPattern2
    {
        public static void Run()
        {
            StrategyPattern2 stPattern2 = new StrategyPattern2();
            IContact viberContact = new ViberContact() { ContactName = "Nate", ContactMedium = "425-768-2490" };
            IPhoneSystem viberSytem = new Viber(viberContact);
            IContact messengerContact = new MessengerContact() { ContactName = "Nate", ContactMedium = "Nate.iam" };
            IPhoneSystem messengerSytem = new FaceBookMessenger(messengerContact);

            PhoneDialer dialer = new PhoneDialer();
            dialer.MakePhoneCall(viberSytem);
            dialer.MakePhoneCall(messengerSytem);
        }


        public interface IPhoneSystem
        {
            IContact iContact { get; set; }
            void Dial();
            void MakeCall();
        }

        public class Viber : IPhoneSystem
        {
            public IContact iContact { get; set; }
            public Viber(IContact iContact)
            {
                this.iContact = iContact;
            }

            public void Dial()
            {
                //Actuall implementaion is different since they are using different approaches. Only for display purposes.
                Console.WriteLine($"Dialing to {this.iContact.ContactName} at {this.iContact.ContactMedium}");
            }

            public void MakeCall()
            {
                Console.WriteLine(
                    $"Making a call to {this.iContact.ContactName} " +
                    $"via {this.iContact.ContactMedium}" +
                    $"as a {this.iContact.ContactMediumType}");
            }
        }

        public class FaceBookMessenger : IPhoneSystem
        {
            public IContact iContact { get; set; }
            public FaceBookMessenger(IContact iContact)
            {
                this.iContact = iContact;
            }

            public void Dial()
            {//Actuall implementaion is different since they are using different approaches. Only for display purposes.
                Console.WriteLine($"Dialing to {this.iContact.ContactName} at {this.iContact.ContactMedium}");
            }

            public void MakeCall()
            {
                Console.WriteLine(
                    $"Making a call to {this.iContact.ContactName} " +
                    $"via {this.iContact.ContactMedium} " +
                    $"as a {this.iContact.ContactMediumType}");
            }
        }

        public class PhoneDialer
        {
            public void MakePhoneCall(IPhoneSystem phoneSystem)
            {
                phoneSystem.Dial();
                phoneSystem.MakeCall();
            }
        }

    }

    public interface IContact
    {
        string ContactName { get; set; }
        string ContactMediumType { get; set; }
        string ContactMedium { get; set; }
    }

    public class ViberContact : IContact
    {
        public string ContactName { get; set; }
        public string ContactMediumType
        {
            get { return "Viber"; }
            set {; }
        }
        public string ContactMedium { get; set; }
    }


    public class MessengerContact : IContact
    {
        public string ContactName { get; set; }
        public string ContactMediumType
        {
            get { return "Messenger"; }
            set {; }
        }
        public string ContactMedium { get; set; }
    }
}
