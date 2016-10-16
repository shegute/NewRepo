
using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns.RandomCode
{
    public class EnumDisplay
    {
        public static void Run()
        {
            EnumDisplay ed = new EnumDisplay();
            ed.EnumDisplayer();
        }

        public enum AutoBridgeSettings
        {
            UseServiceLevelSettings = 0,

            OverrideServiceLevelSettings = 1,

            InAdditionToServiceLevelSettings = 2
        }

        public void EnumDisplayer()
        {
            IEnumerable<AutoBridgeSettings> list =
                Enum.GetValues(typeof(AutoBridgeSettings))
                    .Cast<AutoBridgeSettings>()
                    .ToList();
            foreach (AutoBridgeSettings t in list)
            {
                Console.WriteLine("{0}", t.ToString());
            }
        }
    }
}
