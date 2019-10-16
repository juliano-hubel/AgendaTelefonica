using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaTelefonica.Domain.Commands.Contatct.Input;
using AgendaTelefonica.Domain.Handlers;
using AgendaTelefonica.Domain.Queries;
using AgendaTelefonica.Domain.Respositories;
using AgendaTelefonica.Shared.Commands;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgendaTelefonica.Api.Controllers
{
    public class ContactController : Controller
    {
        IContactRepository _repository;
        ContactHandler _handler;
        IMapper _mapper;
        public ContactController(IContactRepository repository, ContactHandler handler, IMapper mapper)
        {
            _repository = repository;
            _handler = handler;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public string Home()
        {
            return "Contact works";
        }
        [HttpGet]
        [Route("contacts")]
        public IEnumerable<ContactQueryResult> Get()
        {            
            return _repository.Get();

        }
        [HttpGet]
        [Route("contacts/{id}")]
        public ContactQueryResult Get(Guid Id)
        {
            return _repository.Get(Id);                        
        }

        [HttpGet]
        [Route("/contacts/{search}")]
        public IEnumerable<ContactQueryResult> Get(string search)
        {
            return _repository.Get(search);
        }

        [HttpPost]
        [Route("/contacts")]
        public ICommandResult AddContact([FromBody] AddContactCommand command )
        {
            return _handler.Handle(command);
        }
    }
}