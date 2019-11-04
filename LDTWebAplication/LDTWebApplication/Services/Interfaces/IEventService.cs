using System;
using System.Collections.Generic;
using System.Text;
using WebViewModels;

namespace Services.Interfaces
{
    public interface IEventService
    {
        void CreateEvent(EventViewModel entity);
        void DeleteEvent(int entityId);
        void EditEvent(int entityId);

    }
}
