using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Domain.Core.Entities
{
    public class Friend: BaseEntity
    {
        public int PersonOne { get; set; }

        public int PersonTwo { get; set; }

        public Status Status { get; set; }

        public Person Person { get; set; } = new Person();
        public int PersonId { get; set; }
    }
}
