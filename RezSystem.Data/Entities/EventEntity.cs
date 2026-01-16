using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezSystem.Data.Entities
{
    public class EventEntity : BaseEntity
    {
        // kötümser yaklışım kullandım
        public string Title { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public List<ReservationEntity> Reservations { get; set; }
    }

    public class EventConfiguration : BaseConfiguration<EventEntity>
    {
        public override void Configure(EntityTypeBuilder<EventEntity> builder)
        {
            base.Configure(builder);
        }
    }

}
