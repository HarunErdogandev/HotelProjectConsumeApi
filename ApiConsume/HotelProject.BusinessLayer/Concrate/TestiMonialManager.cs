
using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.ProjectDataAccessLayer.Abstract;

namespace HotelProject.BusinessLayer.Concrate
{
    public class TestiMonialManager:ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;
        public TestiMonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }
        public void TDelete(TestiMonial entity)
        {
            _testimonialDal.Delete(entity);
        }

        public TestiMonial TGetById(int id)
        {
            return _testimonialDal.GetById(id);
        }

        public List<TestiMonial> TGetList()
        {
            return _testimonialDal.GetList();
        }

        public void TInsert(TestiMonial entity)
        {
            _testimonialDal.Insert(entity);
        }

        public void TUpdate(TestiMonial entity)
        {
            _testimonialDal.Update(entity);
        }
    }
}
