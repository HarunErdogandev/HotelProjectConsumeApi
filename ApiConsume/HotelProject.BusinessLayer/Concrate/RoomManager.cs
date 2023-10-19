
using Hotel.ProjectDataAccessLayer.Abstract;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrate
{
    public class RoomManager : IRoomService
    {
        private readonly IRoomDal _roomDal;
        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }
        public void TDelete(TestiMonial entity)
        {
            _roomDal.Delete(entity);
        }

        public TestiMonial TGetById(int id)
        {
           return _roomDal.GetById(id);
        }

        public List<TestiMonial> TGetList()
        {
            return _roomDal.GetList();
        }

        public void TInsert(TestiMonial entity)
        {
            _roomDal.Insert(entity);
        }

        public void TUpdate(TestiMonial entity)
        {
           _roomDal.Update(entity);
        }
    }
}
