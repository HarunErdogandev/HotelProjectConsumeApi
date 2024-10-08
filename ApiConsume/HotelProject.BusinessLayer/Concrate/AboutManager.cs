﻿using Hotel.ProjectDataAccessLayer.Abstract;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrate
{
    public class AboutManager:IAboutService
    {
        private readonly IAboutDal _workLocationDal;
        public AboutManager(IAboutDal workLocationDal)
        {
            _workLocationDal = workLocationDal;
        }
        public void TDelete(About entity)
        {
            _workLocationDal.Delete(entity);
        }

        public About TGetById(int id)
        {
            return _workLocationDal.GetById(id);
        }

        public List<About> TGetList()
        {
            return _workLocationDal.GetList();
        }

        public void TInsert(About entity)
        {
            _workLocationDal.Insert(entity);
        }

        public void TUpdate(About entity)
        {
            _workLocationDal.Update(entity);
        }
    }
}
