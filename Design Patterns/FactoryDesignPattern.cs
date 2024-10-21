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
        public string typeOfCar { get; set; }
    }
    public class Carolla : ICar
    {
        public Carolla()
        {
            typeOfCar = "carolla";
        }
        public string typeOfCar { get; set; }

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
        public Sidan()
        {
            typeOfCar = "Sidan";
        }
        public string typeOfCar { get; set; }

        
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
    public interface ICarFactory
    {
        //a method to return a new instance of car
        ICar CreateCar();
    }
    // create a factory for Sidan and carolla
    public class SidanFactory : ICarFactory
    {
        public ICar CreateCar()
        {
            return new Sidan();
        }
    }

    public class CarollaFactory : ICarFactory
    {
        public ICar CreateCar()
        {
            return new Carolla();
        }
    }

    public class CarClient
    {
        //client Get teh Instace of child and it depends on run time
        private readonly ICar _car;
        public CarClient(ICarFactory carfactory)
        {
            //call the factory method to get the car
            _car = carfactory.CreateCar();
        }
        public void Drive()
        {
            _car.Drive();
        }
        public void Honk()
        {
            _car.Honk();
        }
        public void getType()
        {
            Console.WriteLine(_car.typeOfCar);
        }
    }

    public class FactoryPAtternMainProcess
    {
        public void ExecMain()
        {
            ICarFactory sedanFactory = new SidanFactory();
            ICarFactory carollaFactory = new CarollaFactory();
            CarClient carClient = new CarClient(sedanFactory);
            CarClient carClient1 = new CarClient(carollaFactory);

            carClient.Drive();
            carClient.Honk();
            carClient.getType();


            carClient1.Drive();
            carClient1.Honk();
            carClient1.getType();

        }
    }

}
