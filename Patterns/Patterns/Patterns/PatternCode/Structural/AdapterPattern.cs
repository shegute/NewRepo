using System;

namespace Patterns.PatternCode.Structural
{
    class AdapterPattern
    {
        /// <summary> Entry point into console application.</summary>
        public static void Run()
        {

            Speaker alemayehu = new Speaker("Alem", Languages.Amharic);

            Speaker eddie = new Speaker("Eddie", Languages.Spanish);

            Speaker guide = new Translator("Meraw",  Languages.English);
            guide.SayHello("Tena Yistelegn", alemayehu.Language);
            guide.SayHello("Hola", eddie.Language);
            guide.Language = Languages.Amharic;
            guide.SayHello("Hola", eddie.Language);


        }

        public enum Languages
        {
            English, Amharic, Spanish, Swahili
        };

        public class Speaker
        {
            public string Name { get; set; }

            public Languages Language { get; set; }
            public Speaker(string n, Languages l)
            { Name = n; Language = l; }
            public virtual void SayHello(string input, Languages language)
            {
                Console.WriteLine("{0} ---in --- {1}", input, language);
            }

        }

        public class Translator : Speaker
        {
            private RosettaStone rosetta; 
            public Translator(string n, Languages l) : base(n, l) {   }
            public override void SayHello(string input, Languages language)
            {
                base.SayHello(input, language);
                rosetta = new RosettaStone();
                Console.WriteLine("Translated to {0} : {1}", this.Language, rosetta.SayHello(this.Language));
            }
        }

        public class RosettaStone
        {
            public string SayHello(Languages language)
            {
                switch (language)
                {
                    case Languages.Amharic: return "Tena yistelegn aleka";
                    case Languages.English: return "Hello sir";
                    case Languages.Spanish: return "Hola senor";
                    case Languages.Swahili: return "Hakuna matata bogna";
                    default: return "Hi";
                }
            }

        }
    }
}