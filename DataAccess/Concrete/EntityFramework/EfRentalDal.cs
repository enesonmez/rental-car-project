using System;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalsDetail()
        {
            using (var context = new RentCarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars!
                             on r.CarId equals c.CarId
                             join b in context.Brands!
                             on c.BrandId equals b.BrandId
                             join cus in context.Customers!
                             on r.CustomerId equals cus.CustomerId
                             join u in context.Users!
                             on cus.UserId equals u.UserId
                             select new RentalDetailDto { RentalId = r.RentalId, BrandName = b.BrandName, 
                                                        CustomerName = u.FirstName + " " + u.LastName, 
                                                        RentDate = r.RentDate, ReturnDate = r.ReturnDate };
                return result.ToList();
            }
        }
    }
}