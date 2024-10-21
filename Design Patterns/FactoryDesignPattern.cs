using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    internal class FactoryDesignPattern
    {

    }
    // we will have an interface that will provide all the method needed for the calling code to
    //call any Variant of the car 

    public interface ICar
    {
        void Drive();
        void Honk();
    }
    public class Carolla : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Driving Caroola");
        }

        public void Honk()
        {
            Console.WriteLine("Caroola's Honk");
        }
    }

    public class Sidan : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Driving Sidan");
        }

        public void Honk()
        {
            Console.WriteLine("Sidan's BEEEEEEEEEP!");
        }
    }

    //now we willl create a factory to create a instace of car on run 
    //calling code can change the variant on run time 

}
