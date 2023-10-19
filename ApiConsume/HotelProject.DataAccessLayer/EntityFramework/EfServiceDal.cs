using Hotel.ProjectDataAccessLayer.Abstract;
using Hotel.ProjectDataAccessLayer.Concrete;
using Hotel.ProjectDataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ProjectDataAccessLayer.EntityFramework
{
    public class EfServiceDal : GenericRepository<Service>, IServiceDal
    {
        private readonly Context _context;
        public EfServiceDal(Context context) : base(context)
        {
            
        }
    }
}
