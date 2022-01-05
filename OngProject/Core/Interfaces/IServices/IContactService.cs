using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IServices
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> GetContact(int id);
        Task InsertContact(ContactDto contactDto);
        Task<bool> UpdateContact(Contact contact);
        Task<bool> DeleteContact(int id);

    }


}