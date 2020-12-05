using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business;

namespace Infrastructure
{
    public interface IPersonRepository
    {
        int SavePerson(Person person);
    }
}
