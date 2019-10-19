using AgendaTelefonica.Domain.Entities;
using AgendaTelefonica.Domain.Queries;
using AgendaTelefonica.Domain.Respositories;
using AgendaTelefonica.Infra.Context.DataContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaTelefonica.Infra.Context.Repositories
{
    public class ContactRepository : IContactRepository
    {
        AgendaTelefonicaDataContext _context;
        IMapper _mapper;

        public ContactRepository(AgendaTelefonicaDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;                
        }

        public void Add(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }
        public void Update(Contact contact)
        {            
            _context.Entry(contact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<ContactQueryResult> Get()
        {
            var contacts = _context.Contacts;

           return _mapper.Map<IEnumerable<ContactQueryResult>>(contacts);
        }

        public ContactQueryResult Get(Guid Id)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.Id == Id);

            return _mapper.Map<ContactQueryResult>(contact);
        }

        public IEnumerable<ContactQueryResult> Get(string search)
        {
            var contacts = _context.Contacts.Where(x => x.Name ==  search);

            return _mapper.Map<IEnumerable<ContactQueryResult>>(contacts);
        }

        public Contact GetById(Guid Id)
        {
            return _context.Contacts.FirstOrDefault(c => c.Id == Id);
        }

        public void Delete(Guid Id)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.Id == Id);
            _context.Entry(contact).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
