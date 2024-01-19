using Hotel.ProjectDataAccessLayer.Concrete;
using Hotel.ProjectDataAccessLayer.Repositories;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfContactDal : GenericRepository<Contact>, IContactDal
    {
        public EfContactDal(Context context) : base(context)
        {
        }

        public int GetContactCaunt()
        {
            var context = new Context();
            var result = context.Contacts.Count();
            return result;
        }
    }
}
