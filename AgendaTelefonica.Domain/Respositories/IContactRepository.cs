using AgendaTelefonica.Domain.Entities;
using AgendaTelefonica.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaTelefonica.Domain.Respositories
{
    public interface IContactRepository
    {
        IEnumerable<ContactQueryResult> Get();
        ContactQueryResult Get(Guid Id);

        IEnumerable<ContactQueryResult> Get(string search);

        void Add(Contact contact);
    }
}
