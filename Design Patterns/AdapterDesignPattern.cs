using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public interface IAdapter
    {
        public void ExecOldMethod();
    }
    public class ClassAdapter : oldAdapteeThatIsntCompatible, IAdapter
    {
        public ClassAdapter()
        {

        }

        public void ExecOldMethod()
        {
            OldConsoleMethodthatisntcompatible();
        }
    }

    public class ObjectAdapter : IAdapter
    {
        private readonly oldAdapteeThatIsntCompatible _oldAdapteeThatIsntCompatible;
        public ObjectAdapter(oldAdapteeThatIsntCompatible oldAdapteeThatIsntCompatible)
        {
            _oldAdapteeThatIsntCompatible = oldAdapteeThatIsntCompatible;
        }
        public void ExecOldMethod()
        {
            _oldAdapteeThatIsntCompatible.OldConsoleMethodthatisntcompatible();
        }
    }

    public class oldAdapteeThatIsntCompatible
    {
        public void OldConsoleMethodthatisntcompatible()
        {
            Console.WriteLine("This is old method");
        }
    }
}
