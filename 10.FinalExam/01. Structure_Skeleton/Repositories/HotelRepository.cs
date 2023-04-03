using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private readonly List<IHotel> models;

        public HotelRepository()
        {
            this.models = new List<IHotel>();
        }
        public void AddNew(IHotel model) => models.Add(model);


        public IReadOnlyCollection<IHotel> All() => this.models;


        public IHotel Select(string criteria) => models.FirstOrDefault(x => x.FullName == criteria);

    }
}
