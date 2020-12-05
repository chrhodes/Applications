using System.Collections.Generic;
using Business;
using System;

namespace Infrastructure.Services
{
    public interface IPersonService
    {
        IList<Person> GetPeople();
        void GetPeopleAsync(EventHandler<ServiceResult<IList<Person>>> callback);
    }
}