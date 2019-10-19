using AgendaTelefonica.Shared.Commands;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaTelefonica.Domain.Commands.Contatct.Input
{
    public class DeleteContactCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public void Validate()
        {            
        }
    }
}
