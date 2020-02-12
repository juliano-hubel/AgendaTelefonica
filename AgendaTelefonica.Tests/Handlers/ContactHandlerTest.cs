using AgendaTelefonica.Domain.Commands.Contatct.Input;
using AgendaTelefonica.Domain.Entities;
using AgendaTelefonica.Domain.Handlers;
using AgendaTelefonica.Domain.Respositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaTelefonica.Tests.Handlers
{
    [TestFixture]
    class ContactHandlerTest
    {
        ContactHandler _handler;
        Mock<IContactRepository> _repository;
        AddContactCommand _addContactCommand;
        UpdateContactCommand _updateContactCommand;
        AddContactCommand _deleteContactCommand;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IContactRepository>();
            var contact = new Contact("name", "4188888888", "mail@example.com");        
            _repository.Setup(s => s.GetById(It.IsAny<Guid>())).Returns(contact);

            _handler = new ContactHandler(_repository.Object);            
        }        

        [Test]
        public void AddContact_WhenCalled_ReturnSuccess()
        {
            _addContactCommand = new AddContactCommand();
            _addContactCommand.Email = "mail@example.com";
            _addContactCommand.Name = "Juliano";
            _addContactCommand.Phone = "41-8866544";

            var result =  _handler.Handle(_addContactCommand);
            Assert.That(result.Success);
        }


        [Test]               
        [TestCase("", "email@example.com", "4188888888")]
        [TestCase("name", "", "4188888888")]
        [TestCase("name", "email@example.com", "")]
        public void AddContact_WhenMissingInformation_ReturnError(string name, string email, string phone)
        {
            _addContactCommand = new AddContactCommand();
            _addContactCommand.Email = email;
            _addContactCommand.Name = name;
            _addContactCommand.Phone = phone;

            var result = _handler.Handle(_addContactCommand);

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void UpdateContact_WhenCalled_ReturnSuccess()
        {
            _updateContactCommand = new UpdateContactCommand();
            _updateContactCommand.Email = "mail@example.com";
            _updateContactCommand.Name = "name";
            _updateContactCommand.Id = new Guid();
            _updateContactCommand.Phone = "41898556622";

            var result =  _handler.Handle(_updateContactCommand);

            Assert.IsTrue(result.Success);            
        }


      

    }
}
