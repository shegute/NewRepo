using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.RandomCode
{/// <summary>The status of the incident in the incident queue.</summary>
    public enum ProcessingStatus
    {
        /// <summary>Indicates the incident queue incident object is in a new state.</summary>
        New = 0,

        /// <summary>Indicates the incident queue incident object is in a processing state.</summary>
        Processing = 1,

        /// <summary>Indicates the incident queue incident object is in a processed state.</summary>
        Processed = 2,

        /// <summary>Indicates the incident queue incident object is in a failed state.</summary>
        Failed = 3
    }

    public class Cash
    {
        public long amount;

        public ProcessingStatus status;

        public static void Run()
        {
            Cash c = new Cash();
            Console.WriteLine(c.amount);
            Console.WriteLine(c.status);
        }
    }
}
