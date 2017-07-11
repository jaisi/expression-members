using System;
using System.Collections.Generic;

namespace expression_members
{
    public class Bug
    {
        /*
            You can declare a typed public property, make it read-only,
            and initialize it with a default value all on the same
            line of code in C#. Readonly properties can be set in the
            class' constructors, but not by external code.
        */
        public string Name { get; } = "";
        public string Species { get; } = "";
        public ICollection<string> Predators { get; } = new List<string>();
        public ICollection<string> Prey { get; } = new List<string>();

        // Convert this readonly property to an expression member
        public string FormalName
        {
            get
            {
                return $"{this.Name} the {this.Species}";
            }
        }

        // Class constructor
        public Bug(string name, string species, List<string> predators, List<string> prey)
        {
            this.Name = name;
            this.Species = species;
            this.Predators = predators;
            this.Prey = prey;
        }

       
        /*        public int DoubleTheValue(int someValue)
        {
            return someValue * 2;
        }

        public int DoubleTheValue(int someValue) => someValue * 2;
        */
        
        // Convert this method to an expression member
        string commaDelimitedPrey;
        public string PreyList() => commaDelimitedPrey = string.Join(",", this.Prey);

/*        public string PreyList()
        {
            var commaDelimitedPrey = string.Join(",", this.Prey);
            return commaDelimitedPrey;
        }
*/
        // Convert this method to an expression member

        string commaDelimitedPredators;
        public string PredatorList() => commaDelimitedPredators = string.Join(",", this.Predators);
        /*public string PredatorList()
        {
            var commaDelimitedPredators = string.Join(",", this.Predators);
            return commaDelimitedPredators;
        }
        */
        // Convert this to expression method (hint: use a C# ternary)

        public string Eat(string food) => this.Prey.Contains(food) ? $"{this.Name} ate the {food}." : $"{this.Name} is still hungry.";
        /*public string Eat(string food)
        {
            if (this.Prey.Contains(food))
            {
                return $"{this.Name} ate the {food}.";
            } else {
                return $"{this.Name} is still hungry.";
            }
        }*/
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            Bug bug1 = new Bug("spider", "spider species", new List<string>(){"birds,frogs"}, new List<string>(){"fly"});
            Bug bug2 = new Bug("lizard", "lizard species", new List<string>(){"cat"}, new List<string>(){"fly"});
            //string bug2food = bug2.PreyList();
            Console.WriteLine(bug2.Eat("fly"));
            Console.WriteLine(bug1.PredatorList());
            Console.WriteLine(bug1.PreyList());
            Console.WriteLine(bug1.FormalName);
        }
    }
}
