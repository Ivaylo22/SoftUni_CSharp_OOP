using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private readonly List<IBooking> models;
        public BookingRepository()
        {
            this.models = new List<IBooking>();
        }
        public void AddNew(IBooking model) => models.Add(model);


        public IReadOnlyCollection<IBooking> All() => this.models;


        public IBooking Select(string criteria) 
            => this.models.FirstOrDefault(m => m.BookingNumber == int.Parse(criteria));

    }
}
