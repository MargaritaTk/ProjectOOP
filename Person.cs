using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public abstract class Person
    {
        public string Name { get; protected set; }

        // Абстрактна властивість
        public abstract string RoleDescription { get; set; }

        protected Person(string name)
        {
            Name = name;
        }

        // Абстрактний метод
        public abstract void Role();
    }
}
