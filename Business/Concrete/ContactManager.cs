﻿using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal contactDal;
        public ContactManager(IContactDal contactDal)
        {
            this.contactDal = contactDal;
        }

        public void Add(Contact contact)
        {
            contactDal.Add(contact);
        }
    }
}