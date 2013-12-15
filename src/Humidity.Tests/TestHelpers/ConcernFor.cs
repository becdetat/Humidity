using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humidity.Tests.TestHelpers
{
    public abstract class ConcernFor<T>
    {
        protected T Subject { get; private set; }

        public ConcernFor()
        {
            Context();
            Subject = Given();
            When();
        }

        protected virtual void Context()
        {
        }

        protected abstract T Given();

        protected virtual void When()
        {
        }
    }
}
