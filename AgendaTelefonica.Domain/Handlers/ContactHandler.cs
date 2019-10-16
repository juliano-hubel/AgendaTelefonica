using AgendaTelefonica.Domain.Commands.Contatct.Input;
using AgendaTelefonica.Domain.Commands.Contatct.Output;
using AgendaTelefonica.Domain.Entities;
using AgendaTelefonica.Domain.Respositories;
using AgendaTelefonica.Shared.Commands;
using AgendaTelefonica.Shared.Handlers;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaTelefonica.Domain.Handlers
{
    public class ContactHandler : Notifiable,
        IHandler<AddContactCommand>
    {
        private IContactRepository _repository;

        public ContactHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AddContactCommand command)
        {
            //Valida
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Não foi possivel cadastrar um novo contato", command.Notifications);


            //Cria o Objeto
            var contact = new Contact(command.Name, command.Phone, command.Email);

            //Valida o Objeto
            AddNotifications(contact);

            if(Invalid)
                return new CommandResult(false, "Não foi possivel cadastrar um novo contato", Notifications);

            //Persiste no repositório
            _repository.Add(contact);

            //Retorna com sucesso
            return new CommandResult(true, "Contato cadastrado com sucesso", new { Id = contact.Id, Name = contact.Name });


        }
    }
}
