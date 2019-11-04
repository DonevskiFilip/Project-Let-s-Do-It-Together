using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebViewModels.Enum;

namespace WebViewModels
{
   public class EventViewModel
    {
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
        public EventTypeEnumViewModel EventType { get; set; }
    }
}
