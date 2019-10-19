using AgendaTelefonica.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaTelefonica.Domain.Commands.Contatct.Input
{
    public class UpdateContactCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Email, "Email", "O e-mail é invalido")
                .IsNotNullOrEmpty(Name, "Name", "O nome é obrigatório")
                .IsNotNullOrEmpty(Phone, "Phone", "O telefone é obrigatório")
                .IsGreaterOrEqualsThan(Phone.Length, 8, "Phone", "O telefone deve ter no minimo 8 caracteres"));
        }
    }
}
