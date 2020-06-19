using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSalonAPI.Models.SalonServices
{
    public abstract class Service
    {
        public int Id { get; set; }

        public uint Price { get; set; }

        public string Title { get; set; }
    }
}
