using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            HerbsFactory factory = new ConcreteHerbsFactory();

            IFactory paproc = factory.GetHerbs("Paproc");
            paproc.Cena(20);

            IFactory mech = factory.GetHerbs("Mech");
            mech.Cena(10);
            Console.ReadKey();
        }
    }
    class Mech : IFactory
    {
        public void Cena(int cena)
        {
            Console.WriteLine("Cena mchu wynosi: " + cena.ToString() + " zł za gram");
        }
    }
    class Paproc : IFactory
    {
        public void Cena(int cena)
        {
            Console.WriteLine("Cena paproci wynosi: " + cena.ToString() + " zł za gram");
        }
    }
    interface IFactory
    {
        void Cena(int cena);
    }
    abstract class HerbsFactory
    {
        public abstract IFactory GetHerbs(string Herbs);
    }
    class ConcreteHerbsFactory : HerbsFactory
    {
        public override IFactory GetHerbs(string Herb)
        {
            switch (Herb)
            {
                case "Mech":
                    return new Mech();
                case "Paproc":
                    return new Paproc();
                default:
                    throw new ApplicationException(string.Format("Herb '{0}' cannot be created", Herb));
            }
        }
    }
}