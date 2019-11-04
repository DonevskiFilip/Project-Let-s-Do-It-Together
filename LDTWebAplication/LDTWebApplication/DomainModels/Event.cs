using DomainModels.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModels
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public string EventLocation { get; set; }
        [Required]
        public string EventStart { get; set; }
        public int EventDuration { get; set; }
        public int? EventOpenPleaces { get; set; }
        [Required]
        public string EventDiscription { get; set; }
        [Required]
        public EventTypeEnums EventType { get; set; }
       public IEnumerable<Event> Events { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
