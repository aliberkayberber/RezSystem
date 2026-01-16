using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RezSystem.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezSystem.Data.Entities
{
    public class ReservationEntity : BaseEntity
    {
        public int EventId { get; set; }
        public EventEntity Event { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public ReservationStatus Status { get; set; }
        public DateTime? HoldExpirationTime { get; set; }
    }

    public class ReservationConfiguration : BaseConfiguration<ReservationEntity>
    {
        public override void Configure(EntityTypeBuilder<ReservationEntity> builder)
        {
            builder.Ignore(x => x.Id);
            builder.HasKey("EventId","UserId");

            base.Configure(builder);
        }
    }


}
