using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaTelefonica.Shared.Entities
{
    public abstract  class Entity : Notifiable
    {
        protected Entity()
        {
            Id = new Guid();
        }

        public Guid Id { get; private set; }
    }
}
