﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrate
{
    public class MessageCategoryManager : IMessageCategoryService
    {
        private readonly IMessageCategoryDal _messageCategoryDal;
        public MessageCategoryManager(IMessageCategoryDal messageCategoryDal)
        {
            _messageCategoryDal = messageCategoryDal;
        }
        public void TDelete(MessageCategory entity)
        {
            throw new NotImplementedException();
        }

        public MessageCategory TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<MessageCategory> TGetList()
        {
            return _messageCategoryDal.GetList();   
        }

        public void TInsert(MessageCategory entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(MessageCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
