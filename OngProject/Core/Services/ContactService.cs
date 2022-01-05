using Microsoft.Extensions.Configuration;
using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;
        public ContactService(IUnitOfWork unitOfWork, IMailService mailService, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mailService = mailService;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _unitOfWork.ContactRepository.GetAll();
        }

        public async Task<Contact> GetContact(int id)
        {
            return await _unitOfWork.ContactRepository.GetById(id);
        }

        public async Task InsertContact(ContactDto contactDto)
        {
            EntityMapper mapper = new();

            var contact = mapper.FromContactDtoToContact(contactDto);

            await _unitOfWork.ContactRepository.Insert(contact);

            await _unitOfWork.SaveChangesAsync();

            await _mailService.SendMail(
                contact.Email,
                _configuration["MailService:ContactBodyMessage"],
                _configuration["MailService:ContactMessage"]
             );

        }
        public async Task<bool> UpdateContact(Contact contact)
        { 
            await _unitOfWork.ContactRepository.Update(contact);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteContact(int id)
        {
            await _unitOfWork.ContactRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

    }
}