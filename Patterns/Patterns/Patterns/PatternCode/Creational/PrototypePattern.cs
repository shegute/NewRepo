using System;
using System.Collections.Generic;

namespace Patterns
{
    public class PrototypePattern
    {
        public static void Run()
        {
            Parent par = new Parent();
            par["j"] = new Twin("jotti", 612, 200, new School("StJoe","Meskal Square"));
            par["r"] = new Twin("robel", 58, 180, new School("ICS", "Piassa"));

            Twin hani = par["j"].Clone() as Twin;
            hani.school.name = "5kilo"; hani.school.address = "5 kilo";
            Twin heikel = par["r"].Clone() as Twin;
            ((Twin)par["r"]).school.name = "BahrainHigh"; ((Twin)par["r"]).school.address = "Bahrain";

            ((Twin)par["j"]).name = "jottiiii";
            par["j"].Display();
            hani.Display();
            heikel.name = "heikel";
            par["r"].Display();
            heikel.Display();

        }
    }
}
public abstract class ChildProtoType
{
    public abstract ChildProtoType Clone();
    public abstract void Display();
}

public class Twin : ChildProtoType
{
    public string name;
    public int ht;
    public int wt;
    public School school;
    public Twin(string n, int h, int w, School s)
    {
        name = n; ht = h; wt = w; school = s;
    }

    public override ChildProtoType Clone()
    {
        Console.WriteLine("Cloning twin: {0,3} {1,3} {2,3}", name, ht, wt);
        Console.WriteLine("----who went to school at: {0}; {1}", school.name, school.address);
        return this.MemberwiseClone() as ChildProtoType;
    }

    public override void Display()
    {
        Console.WriteLine("Display: {0,3} {1,3} {2,3}", name, ht, wt);
        Console.WriteLine("----who went to school at: {0}; {1}", school.name, school.address);
    }
}

public class Parent
{
    private Dictionary<string, ChildProtoType> kids = new Dictionary<string, ChildProtoType>();
    public ChildProtoType this[string key]
    {
        get { return kids[key]; }
        set { kids.Add(key, value); }
    }

    public Parent() { }
}

public class School
{
    public string name;
    public string address;
    public School(string n, string addy)
    {
        name = n; address = addy;
    }
}