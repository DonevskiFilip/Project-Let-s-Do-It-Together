using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModels
{
   public class UserEvents
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int UserId { get; set; }
        public int CreatedEventId { get; set; }
        public int GoingEventId { get; set; }
        public virtual User User { get; set; }
        public virtual Event Event { get; set; }
    }
}
