using AgendaTelefonica.Domain.Entities;
using AgendaTelefonica.Domain.Queries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaTelefonica.Domain
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Contact, ContactQueryResult>();
            CreateMap<ContactQueryResult, Contact>();
            //CreateMap<IEnumerable<Contact>, IEnumerable<ContactQueryResult>>();
            //CreateMap<IEnumerable<ContactQueryResult>, IEnumerable<Contact>>();            
        }
        
       
    }
}
