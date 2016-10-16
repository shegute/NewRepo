using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Observer.RealWorld
{
    public class RealWorldObserverPattern
    {
        public static void Run()
        {
            Signal policeSignal = new PoliceSignal();
            policeSignal.Attach(new PoliceRadio(policeSignal, "Squad Car 1"));
            policeSignal.Attach(new PoliceRadio(policeSignal, "Squad Car 2"));
            policeSignal.Attach(new PoliceRadio(policeSignal, "Squad Car 3"));
            policeSignal.Subject = "Cat caught in a tree on 154th and 8th st.";
            policeSignal.Notify();
            policeSignal.Subject = "Shoe robber is back at Lincoln Square Macys, womens section.";
            policeSignal.Notify();
        }

        public abstract class Signal
        {
            public string SignalName { get; set; }
            public string Subject { get; set; }

            private List<Radio> _radios = new List<Radio>();
            public void Attach(Radio r) { _radios.Add(r); }
            public void Detach(Radio r) { _radios.Remove(r); }
            public void Notify() { foreach (Radio r in _radios) { r.Update(); } }
        }

        public class PoliceSignal : Signal
        {
            public PoliceSignal() { base.SignalName = "Police Signal"; }

        }

        public abstract class Radio
        {
            public abstract void Update();
        }

        public class PoliceRadio : Radio
        {
            private string _name;
            private Signal _signal;

            public PoliceRadio(Signal s, string n)
            {
                _signal = s;
                _name = n;
            }

            public override void Update()
            {
                Console.WriteLine(
                    "{0} received the message: {1} from signal name{2}."
                    , _name, _signal.Subject, _signal.SignalName);
            }
        }
    }
}
