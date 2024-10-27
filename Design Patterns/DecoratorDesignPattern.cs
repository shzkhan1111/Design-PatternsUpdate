using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public interface ICarDec
    {
        string Make();
    }

    public class BasicCar : ICarDec
    {
        public string Make()
        {
            return "BasicCar";
        }
    }
    public class CarDecorator : ICarDec
    {
        protected ICarDec _carDec;
        public CarDecorator(ICarDec carDec)
        {
            _carDec = carDec;
        }
    
        public virtual string Make()
        {
            return _carDec.Make();
        }
    }

    public class SportsCar : CarDecorator
    {
        public SportsCar(ICarDec car):base(car)
        {

        }
        public override string Make()
        {
            return base.Make() + " with Sports features";
        }
    }
    public class LuxsCar : CarDecorator
    {
        public LuxsCar(ICarDec car) : base(car)
        {

        }
        public override string Make()
        {
            return base.Make() + " with LuxsCar  features";
        }
    }

    public interface IDumbData
    {
        public int MyProperty { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
    public class DumbData : IDumbData
    {
        public int MyProperty { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public abstract class BaseDecorator : IDumbData
    {
        protected IDumbData data;
        public BaseDecorator(IDumbData data)
        {
            this.data = data;
        }
        public virtual int MyProperty { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? Description { get; set; }
    }

    public class InjectedFunctionality : BaseDecorator
    {
        public InjectedFunctionality(IDumbData data) : base(data)
        {
            
        }
        public override string Name
        {
            get => data?.Name ?? "";
            set
            {
                data.Name = value;
                EmitValue(value);
            }
        }

        private void EmitValue(string value)
        {
            Console.WriteLine("Value is ");
            Console.WriteLine(value);
        }
    }

    public class decmain
    {
        public void execmain()
        {
            //ICarDec basicCar = new BasicCar();
            //ICarDec sportsCar = new SportsCar(basicCar);
            //ICarDec luxCar = new LuxsCar(sportsCar);

            //Console.WriteLine(luxCar.Make());

        }
    }
}
