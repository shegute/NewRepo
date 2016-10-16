using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Builder.RealWorld
{
    public class BuilderMainApp
    {
        public static void Run()
        { 
            ShoeBuilder bootBuilder = new BootBuilder();
            ShoeShop shoeShop = new ShoeShop();
            shoeShop.MakeShoe(bootBuilder);
            bootBuilder.Shoe.Show();
            ShoeBuilder chukaBuilder = new ChukaBuilder();
            shoeShop.MakeShoe(chukaBuilder);
            chukaBuilder.Shoe.Show();
        }
    }

    class ShoeShop
    {
        public void MakeShoe(ShoeBuilder shoeBuilder)
        {
            shoeBuilder.MakeSole();
            shoeBuilder.MakeCover();
            shoeBuilder.MakeLaces();
        }
    }

    abstract class ShoeBuilder
    {
        protected Shoe shoe;
        public Shoe Shoe { get { return shoe; } }
        public abstract void MakeCover();
        public abstract void MakeLaces();
        public abstract void MakeSole();
    }

    class Shoe
    {
        private string type;
        private Dictionary<string, string> parts = new Dictionary<string, string>();

        public Shoe(string type) { this.type = type; }
        public string this[string key] { get { return parts[key]; } set { parts[key] = value; } }
        public void Show()
        {
            Console.WriteLine("Sole:{0}", parts["sole"]);
            Console.WriteLine("Cover:{0}", parts["cover"]);
            Console.WriteLine("Laces:{0}", parts["laces"]);
        }
    }

    class BootBuilder : ShoeBuilder
    {
        public BootBuilder()
        {
            shoe = new Shoe("Boot");
        }

        public override void MakeCover() { shoe["cover"] = "Boot cover."; }

        public override void MakeLaces() { shoe["laces"] = "Boot laces."; }

        public override void MakeSole() { shoe["sole"] = "Boot sole."; }
    }


    class ChukaBuilder : ShoeBuilder
    {
        public ChukaBuilder()
        {
            shoe = new Shoe("Chuka");
        }

        public override void MakeCover() { shoe["cover"] = "Chuka cover."; }

        public override void MakeLaces() { shoe["laces"] = "Chuka laces."; }

        public override void MakeSole() { shoe["sole"] = "Chuka sole."; }
    }
}