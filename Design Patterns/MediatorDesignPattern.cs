using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    /// <summary>
    /// Centralize Interaction Between Object
    /// </summary>
       

    public class MediatorProgramCS
    {
        public void ExecMain()
        {
            Component1Mediator component1 = new Component1Mediator();
            Component2Mediator component2 = new Component2Mediator();
            new ConcreteMediator(component1, component2);

            Console.WriteLine("Client triggers operation A.");
            component1.DoA();

            Console.WriteLine();

            Console.WriteLine("Client triggers operation D.");
            component2.DoD();
        }
    }
    public interface IMediator
    {
        //method used by components to nofify the mediator
        //mediator reacts to those
        void Notify(object sender, string receiver);
    }
    public class ConcreteMediator : IMediator
    {
        private Component1Mediator component1Mediator;
        private Component2Mediator component2Mediator;

        public ConcreteMediator(Component1Mediator component1Mediator , Component2Mediator component2Mediator)
        {
            this.component1Mediator = component1Mediator;
            this.component1Mediator.SetMediator(this);
            this.component2Mediator = component2Mediator;
            this.component2Mediator.SetMediator(this);  
        }

        public void Notify(object sender, string receiver)
        {
            if (receiver == "A")
            {   
                Console.WriteLine("Mediator reacts on A and triggers following operations:");
                this.component2Mediator.DoC();
            }
            if (receiver == "D")
            {
                Console.WriteLine("Mediator reacts on D and triggers following operations:");
                this.component1Mediator.DoB();
                this.component2Mediator.DoC();
            }
        }
    }

    public class BaseComponentMediator
    {
        protected IMediator _mediator;
        public BaseComponentMediator(IMediator mediator = null!)
        {
            _mediator = mediator;
        }
        public void SetMediator(IMediator mediator)
        {
            this._mediator = mediator;
        }
    }

    public class Component1Mediator : BaseComponentMediator
    {
        public void DoA()
        {
            Console.WriteLine("Como 1 doing A");
            this._mediator.Notify(this, "A");
        }
        public void DoB()
        {
            Console.WriteLine("Comp 1 doing B");
            this._mediator.Notify(this, "B");
        }
    }

    public class Component2Mediator : BaseComponentMediator
    {
        public void DoC()
        {
            Console.WriteLine("Component 2 does C.");

            this._mediator.Notify(this, "C");
        }

        public void DoD()
        {
            Console.WriteLine("Component 2 does D.");

            this._mediator.Notify(this, "D");
        }
    }

}
