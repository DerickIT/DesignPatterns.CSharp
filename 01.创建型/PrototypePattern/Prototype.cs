using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    internal abstract class Prototype
    {
        public string Id { get; }

        protected Prototype(string id) => Id = id;

        public abstract Prototype Clone();
    }

    internal class ConcretePrototypeChild : Prototype
    {
        public ConcretePrototypeChild(string id) : base(id)
        {
        }

        public override Prototype Clone()
        {
            return (Prototype)MemberwiseClone();
        }
    }
}
