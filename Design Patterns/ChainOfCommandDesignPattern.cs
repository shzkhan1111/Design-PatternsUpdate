using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public interface IChainOfCommandhandler
    {
        IChainOfCommandhandler setNext(IChainOfCommandhandler chainOf);
        //recieves a command object
        object Handle(object request);
    }


    public abstract class AbstractChainOfCommandHandler : IChainOfCommandhandler
    {
        private IChainOfCommandhandler handleNext = null!;
        public virtual object Handle(object request)
        {
            if (this.handleNext is null)
            {
                Console.WriteLine("No Handler Found");
                return null!;
            }
            else
            {
                Console.WriteLine($"Passing to the next Handle {request as string}");
                return this.handleNext.Handle(request);
            }
        }



        public IChainOfCommandhandler setNext(IChainOfCommandhandler chainOf)
        {
            this.handleNext = chainOf;
            return chainOf;
        }
    }

    public class MonkeyHandler : AbstractChainOfCommandHandler
    {
        public override object Handle(object request)
        {
            if (request as string == "Monkey")
            {
                Console.WriteLine("Monkey Handler I will handle it");
                return "Monkey Handler I will handle it";
            }
            return base.Handle(request);
        }
    }
    public class SquirrelHandler : AbstractChainOfCommandHandler
    {
        public override object Handle(object request)
        {
            if (request as string == "Squirrel")
            {
                Console.WriteLine("Squirrel Handler I will handle it");
                return "Squirrel Handler I will handle it";
            }
            return base.Handle(request);
        }
    }

    public class DogHandler : AbstractChainOfCommandHandler
    {
        public override object Handle(object request)
        {
            if (request as string == "Dog")
            {
                Console.WriteLine("Dog Handler I will handle it");
                return "Dog Handler I will handle it";
            }
            return base.Handle(request);
        }
    }

    public class ChainOfCommandClient
    {
        public void ExecMain(AbstractChainOfCommandHandler handler)
        {
            foreach (var food in new List<string> { "Ape", "Monkey" ,  "Dog", "Squirrel" })
            {
                Console.WriteLine($"Client: Who wants a {food}?");
                var res = handler.Handle(food);
                if (res != null)
                {
                    Console.WriteLine($"Final Result = {res}");
                }
                else
                {
                    Console.WriteLine($"   {food} was left untouched.");

                }
            }
        }
        public void PrepareRequest()
        {
            var Monkey = new MonkeyHandler();
            var squirrel = new SquirrelHandler();
            var dog = new DogHandler();

            Monkey.setNext(squirrel).setNext(dog);
            Console.WriteLine("Chain: Monkey > Squirrel > Dog\n");

            Console.WriteLine("Subchain: Squirrel > Dog\n");

            ExecMain(Monkey);
        }
    }
}
