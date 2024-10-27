using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Design_Patterns
{

    public interface ICommandDp
    {
        void Exec();
    }

    public class SimpleCommandDp : ICommandDp
    {
        private string _payload = string.Empty;
        public SimpleCommandDp(string payload)
        {
            this._payload = payload;
        }
        public void Exec()
        {
            Console.WriteLine($"Executing the set payload {_payload}");
        }
    }

    public class ComplexCommandDp : ICommandDp
    {
        public string a = string.Empty;
        public string b = string.Empty;
        //pass the command down to receiver
        private ReceiverCDP _receiver;
        public ComplexCommandDp(string a, string b, ReceiverCDP receiver)
        {
            this.a = a;
            this.b = b;
            _receiver = receiver;
        }

        public void Exec()
        {
            Console.WriteLine("ComplexCommand: Complex stuff should be done by a receiver object.");
            this._receiver.DoSomethingA(this.a);
            this._receiver.DoSomethingB(this.b);
        }
    }

    public class ReceiverCDP
    {
        public void DoSomethingA(string  a)
        {
            Console.WriteLine($"Receiver: Working on ({a}.)");
        }
        public void DoSomethingB (string b)
        {
            Console.WriteLine($"Receiver: Working on ({b}.)");
        }
    }

    public class Invoker
    {
        private ICommandDp _start = null!;
        private ICommandDp _end = null!;


        public void SetStart(ICommandDp command)
        {
            _start = command;
        }
        public void SetEnd(ICommandDp command)
        {
            _end = command;
        }

        public void ExecStartAndEnd()
        {
            Console.WriteLine("Invoker: Does anybody want something done before I begin?");

            if (_start is ICommandDp)
            {
                this._start.Exec();
            }
            if (_end is ICommandDp)
            {
                this._end.Exec();
            }
        }

        public void CommandPatternMain()
        {
            Invoker invoker = new Invoker();
            //can be a list
            invoker.SetStart(new SimpleCommandDp("Hi Simple Command"));
            ReceiverCDP receiver = new ReceiverCDP();
            invoker.SetEnd( new ComplexCommandDp("this is complex 1 param", "this is complex 2 param",receiver));

            invoker.ExecStartAndEnd();
        }
    }

}
