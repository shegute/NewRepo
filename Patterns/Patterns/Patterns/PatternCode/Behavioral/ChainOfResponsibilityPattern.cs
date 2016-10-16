using System;

namespace DoFactory.GangOfFour.ChainOfResponsibility.RealWorld
{
    class ChainOfResponsibilityPattern
    {
        public static void Run()
        {
            Officer one = new Commander();
            Officer two = new Lieutenant();
            Officer three = new Seargent();
            one.SetNextInLine(two);
            two.SetNextInLine(three);
            int[] requests = { 2, 5, 14, 22,55, 18, 3, 27, 20 ,99};

            foreach (int request in requests)
            {
                one.HandleProblem(request);
            }
        }
    }

    abstract class Officer
    {
        protected Officer nextInLine;
        public void SetNextInLine(Officer next) { nextInLine = next; }
        public abstract void HandleProblem(int request);
    }

    class Commander : Officer
    {
        public override void HandleProblem(int request)
        {
            if (request >= 0 && request < 10)
            { Console.WriteLine("{0} handled the problem of level {1}", GetType().Name, request); }
            else if (nextInLine != null)
            { nextInLine.HandleProblem(request); }
            else
            { Console.WriteLine("{0} handled the problem of level {1}< since there was no nextInLine", GetType().Name, request); }
        }
    }

    class Lieutenant : Officer
    {
        public override void HandleProblem(int request)
        {
            if (request >= 10 && request < 20)
            { Console.WriteLine("{0} handled the problem of level {1}", GetType().Name, request); }
            else if (nextInLine != null)
            { nextInLine.HandleProblem(request); }
            else
            { Console.WriteLine("{0} handled the problem of level {1}< since there was no nextInLine", GetType().Name, request); }
        }
    }

    class Seargent : Officer
    {
        public override void HandleProblem(int request)
        {
            if (request >= 20 && request < 50)
            { Console.WriteLine("{0} handled the problem of level {1}", GetType().Name, request); }
            else if (nextInLine != null)
            { nextInLine.HandleProblem(request); }
            else
            { Console.WriteLine("{0} handled the problem of level {1}< since there was no nextInLine", GetType().Name, request); }
        }
    }
}
