using System;

namespace Patterns.RandomCode
{
    public delegate void TurumbaTenefaHandler3(object sender, turumbaTenefaEventArgs e);

    public class EventsAndDelegates3
    {
        public static void Run()
        {
            EventsAndDelegates3 e = new EventsAndDelegates3();
            e.turumbaTenefa += new EventHandler<turumbaTenefaEventArgs>(turumbaNefi_TurumbaTenefa);
            e.TurumbaTesema += new EventHandler(turumbaSemi_TurumbaTesema);
            e.TurumbaNefa(5, "kebele");
        }

        public virtual void TurumbaNefa(int time, string place)
        {
            for (int i = 0; i < time; i++)
            {
                System.Threading.Thread.Sleep(1000);
                this.OnTurumbaTenefa(time, place);
            }
            this.OnTurumbaTesema();
        }

        public virtual void OnTurumbaTenefa(int time, string place)
        {
            //var turumbaTenefa1 = turumbaTenefa as TurumbaTenefaHandler3;
            //turumbaTenefa1 += this.EdertegnochJoro;
            //turumbaTenefa1 += this.NonEdertegnochJoro;

            var turumbaTenefa1 = turumbaTenefa as EventHandler<turumbaTenefaEventArgs>;
            if (turumbaTenefa1 != null)
            {
                turumbaTenefa1(this, new turumbaTenefaEventArgs(time, place));
            }
            //if (turumbaTenefa != null)
            //{
            //    turumbaTenefa(time, place);
            //}
        }

        public void OnTurumbaTesema()
        {
            EventHandler turumbaTesema1 = TurumbaTesema as EventHandler;
            if (turumbaTesema1 != null)
            {
                turumbaTesema1(this, EventArgs.Empty);
            }
        }

        private void EdertegnochJoro(object sender, turumbaTenefaEventArgs e)
        {
            Console.WriteLine("I heard we have to go to {0} at {1}", e.Place, e.Time);
        }

        private void NonEdertegnochJoro(object sender, turumbaTenefaEventArgs e)
        {
            Console.WriteLine("I heard edertegnoch have to go to {0} at {1}", e.Place, e.Time);
            Console.WriteLine("Lucky I am not edertegna :).");
        }
        //public event TurumbaTenefaHandler3 turumbaTenefa;
        public event EventHandler<turumbaTenefaEventArgs> turumbaTenefa;
        public event EventHandler TurumbaTesema;

        static void turumbaNefi_TurumbaTenefa(object sender, turumbaTenefaEventArgs e)
        {
            Console.WriteLine("Ato entena selarefu, edertegnoch go to {0} at {1} PM", e.Place, e.Time);
            Console.WriteLine("I heard we have to go to {0} at {1}", e.Place, e.Time);
            Console.WriteLine("I heard edertegnoch have to go to {0} at {1}", e.Place, e.Time);
            Console.WriteLine("Lucky I am not edertegna :).");
        }
        static void turumbaSemi_TurumbaTesema(object sender, EventArgs e)
        {

            Console.WriteLine("All one hundred edertegnoch showed up :).");
        }
    }


    public class turumbaTenefaEventArgs : EventArgs
    {
        public turumbaTenefaEventArgs(int time, string place)
        {
            Time = time;
            Place = place;
        }
        public int Time { get; set; }
        public string Place { get; set; }
    }
}
