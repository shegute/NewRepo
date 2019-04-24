using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviews.DataStructures.Graphs
{
    public class Graphs
    {
        public static void Run()
        {
            Console.WriteLine(" #$()#$()#$()#$()#$Graphs #$()#$()#$()#$()#$() ");
            List<Tuple<string, string>> datacenterList =
                new List<Tuple<string, string>>() { new Tuple<string, string>("A", "B"), new Tuple<string, string>("A", "F"),
                new Tuple<string, string>("C", "D"), new Tuple<string, string>("D", "E"),
                new Tuple<string, string>("F", "B"),
                // new Tuple<string, string>("B", "C"),
                };
            Graphs graphs = new Graphs();
            Dictionary<string, List<string>> connectedDatacenteres = graphs.FindConnectedDatacenteres(datacenterList);
            Graphs.PrintConnectedDatacenteres(connectedDatacenteres);
        }

        public static void PrintConnectedDatacenteres(Dictionary<string, List<string>> connectedDatacenteres)
        {
            foreach (KeyValuePair<string, List<string>> kvp in connectedDatacenteres)
            {
                Console.WriteLine($"Printing:{kvp.Key}>>>> ");
                foreach (string dc in kvp.Value)
                {
                    Console.WriteLine($"{dc}, ");
                }
            }
        }

        public Dictionary<string, List<string>> FindConnectedDatacenteres(List<Tuple<string, string>> datacenterList)
        {
            Dictionary<string, List<string>> connectedDatacenteres = new Dictionary<string, List<string>>();
            int count = 0;
            foreach (Tuple<string, string> datacenterPair in datacenterList)
            {
                // For the current tuple of datacenters, find all the datacenters connected to it.
                List<string> connectedGroup1 = this.ConnectedDatacenters(datacenterPair.Item1, datacenterList);
                bool hasSameElements = false; string groupTracker = ""; List<string> groupValueTracker = new List<string>();

                // For each group of the connected datacenters, find if it has any common datacenters with the newly created group.
                foreach (KeyValuePair<string, List<string>> kvp in connectedDatacenteres)
                {
                    hasSameElements = kvp.Value.Intersect(connectedGroup1).Any();
                    if (hasSameElements) { groupTracker = kvp.Key; groupValueTracker = kvp.Value; break; }
                }

                // If any group in the dictionary has the any common datacenters as the newly created group,
                // merge the two groups into one and update the group in the dictionary.
                // TODO: consider moving this to its own method.
                if (hasSameElements)
                {
                    connectedDatacenteres[groupTracker] = groupValueTracker.Union(connectedGroup1).ToList();
                    groupTracker = ""; groupValueTracker = null; hasSameElements = false;
                }
                else
                {
                    connectedDatacenteres.Add($"Group{count++}", connectedGroup1);
                }
            }
            return connectedDatacenteres;
        }

        private List<string> ConnectedDatacenters(string targetDatacenter, List<Tuple<string, string>> datacenterList)
        {
            List<string> connectedGroup = new List<string>();
            foreach (Tuple<string, string> datacenterPair in datacenterList)
            {
                if (datacenterPair.Item1.Equals(targetDatacenter) || datacenterPair.Item2.Equals(targetDatacenter)) { connectedGroup.Add(datacenterPair.Item1); connectedGroup.Add(datacenterPair.Item2); }
                
            }
            return connectedGroup;
        }

        //public Dictionary<string, List<string>> FindConnectedDatacenteres(List<Tuple<string, string>> datacenterList)
        //{
        //    Dictionary<string, List<string>> connectedDatacenteres = new Dictionary<string, List<string>>();
        //    int count = 0;
        //    foreach (Tuple<string, string> datacenterPair in datacenterList)
        //    {
        //        List<string> connectedGroup1 = this.ConnectedDatacenter(datacenterPair.Item1, datacenterList);
        //        List<string> connectedGroup2 = this.ConnectedDatacenter(datacenterPair.Item2, datacenterList);

        //        connectedGroup1.AddRange(connectedGroup2.Where(x => !connectedGroup1.Contains(x)));
        //        if (!connectedDatacenteres.ContainsValue(connectedGroup1)) { connectedDatacenteres.Add("Group" + count++, connectedGroup1); }
        //    }

        //    return connectedDatacenteres;
        //}

        //private List<string> ConnectedDatacenter(string targetDatacenter, List<Tuple<string, string>> datacenterList)
        //{
        //    List<string> connectedGroup = new List<string>();
        //    foreach (Tuple<string, string> datacenterPair in datacenterList)
        //    {
        //        if (datacenterPair.Item1.Equals(targetDatacenter))
        //        {
        //            // connectedGroup.Add(targetDatacenter); connectedGroup.Add(datacenterPair.Item1);
        //            connectedGroup.Add(datacenterPair.Item2);
        //        }
        //        else if (datacenterPair.Item2.Equals(targetDatacenter))
        //        {
        //            connectedGroup.Add(datacenterPair.Item1);
        //        }
        //    }

        //    return connectedGroup;
        //}
    }
}
