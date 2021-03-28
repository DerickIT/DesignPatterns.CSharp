using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodPattern
{
   internal interface IWorkFactory
    {
        worker CreateWorker();
    }

    internal class UndergraduteFactory : IWorkFactory
    {
        public worker CreateWorker()
        {
            return new Undergradute();
        }
    }

    internal class VolunteerFactory : IWorkFactory
    {
        public worker CreateWorker()
        {
            return new Volunteer();
        }
    }
}
