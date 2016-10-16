using System;

namespace Patterns.RandomCode
{
    public delegate void TurumbaTenefaHandler(int time, string place);

    public class EventsAndDelegates2
    {
        public static void Run()
        {
            EventsAndDelegates2 e = new EventsAndDelegates2();
            e.TurumbaNefa(5, "kebele");
        }

        public virtual void TurumbaNefa(int time, string place)
        {
            for (int i = 0; i < 3; i++)
            {
                this.OnTurumbaTenefa(time, place);
            }
            this.OnTurumbaTesema();
        }

        public virtual void OnTurumbaTenefa(int time, string place)
        {
            var turumbaTenefa1 = turumbaTenefa as TurumbaTenefaHandler;
            turumbaTenefa1 += this.EdertegnochJoro;
            turumbaTenefa1 += this.NonEdertegnochJoro;
            if (turumbaTenefa1 != null)
            {
                turumbaTenefa1(time, place);
            }
            //You can also attach the EventHandler directly to the event and invoke the event. Weird tho!
            //turumbaTenefa += this.EdertegnochJoro;
            //'turumbaTenefa += this.NonEdertegnochJoro;
            //if (turumbaTenefa != null)
            //{
            //    turumbaTenefa(time, place);
            //}
        }

        public void OnTurumbaTesema()
        {
            //EventHandler turumbaTesema1 = TurumbaTesema as EventHandler;
            //turumbaTesema1 += this.EderDeresu;
            //Or you can declare as below since there is only a single handler for this delegate.

            EventHandler turumbaTesema1 = new EventHandler(this.EderDeresu);
            if (turumbaTesema1 != null)
            {
                turumbaTesema1(this, EventArgs.Empty);
            }
        }

        private void EdertegnochJoro(int time, string place)
        {
            Console.WriteLine("I heard we have to go to {0} at {1}", place, time);
        }

        private void NonEdertegnochJoro(int time, string place)
        {
            Console.WriteLine("I heard edertegnoch have to go to {0} at {1}", place, time);
            Console.WriteLine("Lucky I am not edertegna :).");
        }

        public void EderDeresu(object s, EventArgs e)
        {
            Console.WriteLine("Hulum dersu");
        }
        public event TurumbaTenefaHandler turumbaTenefa;
        public event EventHandler TurumbaTesema;
    }

}
