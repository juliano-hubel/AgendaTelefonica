using AgendaTelefonica.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaTelefonica.Domain.Entities
{
    public class Contact : Entity
    {
        public Contact(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }        
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
    }
}
