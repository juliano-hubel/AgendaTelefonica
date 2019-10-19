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
        IHandler<AddContactCommand>,
        IHandler<UpdateContactCommand>,
        IHandler<DeleteContactCommand>
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

            if (Invalid)
                return new CommandResult(false, "Não foi possivel cadastrar um novo contato", Notifications);

            //Persiste no repositório
            _repository.Add(contact);

            //Retorna com sucesso
            return new CommandResult(true, "Contato cadastrado com sucesso", new { Id = contact.Id, Name = contact.Name });


        }

        public ICommandResult Handle(UpdateContactCommand command)
        {
            //Valida
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Não foi possível editar o contato", command.Notifications);
            //Cria Objeto
            var contact = _repository.GetById(command.Id);
            if (contact == null)
                return new CommandResult(false, "Contato não existe.", null);

            contact.UpdateContact(command.Name, command.Phone, command.Email);
            //ValidaObjeto
            AddNotifications(contact);

            if (Invalid)
                return new CommandResult(false, "Não foi possível editar o contato", command.Notifications);
            //Persiste
            _repository.Update(contact);
            //Retorna
            return new CommandResult(true, "Contato atualizado com sucesso.", new { contact.Id, contact.Name });

        }

        public ICommandResult Handle(DeleteContactCommand command)
        {

            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Não foi possível deletar o contato", command.Notifications);

            var contact = _repository.GetById(command.Id);

            if (contact == null)
                return new CommandResult(false, "Contato não existe.", null);

            _repository.Delete(command.Id);

            return new CommandResult(true, "Contato removido", null);

        }
    }
}
