using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Design_Patterns
{
    /// <summary>
    /// The Abstract Factory Pattern is a creational design pattern that allows you to create families of related objects without specifying their concrete classes
    /// </summary>
    /// use case 
    /// 2 different Carnival Futuristic , Medieval each have there own themed rides and restraunts
    /// 
    internal class AbstractFactory
    {

    }
    // interface for rides and Restraunts 
    public interface IRide
    {
        public string name { get; set; }
        void Operate();
    }
    public interface IRestraunt
    {
        string name { get; }
        void Serve();
    }

    public class FutureisticRide : IRide
    {
        public string name { get; set; }
        public FutureisticRide()
        {
            name = "Ride Of Future";
        }

        public void Operate()
        {
            Console.WriteLine($"Operating {name} in 30 second as it is from the future");
        }

    }
    public class FutureisticRestraunt : IRestraunt
    {
        public string name { get; set; }
        public FutureisticRestraunt()
        {
            name = "Ride Of Future";
        }

        public void Serve()
        {
            Console.WriteLine($"Serving {name} in 30 second as it is from the future");
        }
    }

    public class MedEvilRide : IRide
    {
        public string name { get; set; }
        public MedEvilRide()
        {
            name = " Ride Old ";
        }

        public void Operate()
        {
            Console.WriteLine($"Operating {name} in 1000 second as it is from the past");
        }

    }
    public class MedEvilRestraunt : IRestraunt
    {
        public string name { get; set; }
        public MedEvilRestraunt()
        {
            name = "Restraunt Of Past";
        }

        public void Serve()
        {
            Console.WriteLine($"Serving {name} in 1000 second as it is from the Past");
        }
    }

    //Interface for Abstract Method
    public interface IThemeParkFactory
    {
        IRide CreateRide();
        IRestraunt CreateRestaurant();
    }

    public class FuturisticThemeParkFactory : IThemeParkFactory
    {
        public IRestraunt CreateRestaurant()
        {
            return new FutureisticRestraunt();
        }

        public IRide CreateRide()
        {
            return new FutureisticRide();
        }
    }

    public class MidevilThemeParkFactory : IThemeParkFactory
    {
        public IRestraunt CreateRestaurant()
        {
            return new MedEvilRestraunt();
        }

        public IRide CreateRide()
        {
            return new MedEvilRide();
        }
    }

    public class themepark 
    {
        private readonly IRide _ride;
        private readonly IRestraunt _restaurant;

        public themepark(IThemeParkFactory factory)
        {
            _ride = factory.CreateRide();
            _restaurant = factory.CreateRestaurant();
        }

        public void operate()
        {
            _ride.Operate();
            _restaurant.Serve();
        }
    }
    public class AbstractFactoryExecuteMain
    {
        public void ProcessExec()
        {
            IThemeParkFactory futureFactory = new FuturisticThemeParkFactory();
            IThemeParkFactory medievalFactory = new MidevilThemeParkFactory();

            themepark makeingFutureisticThemePark = new themepark(futureFactory);
            themepark midievalFutureisticThemePark = new themepark(medievalFactory);

            makeingFutureisticThemePark.operate();
            midievalFutureisticThemePark.operate();
        }
    }

}
