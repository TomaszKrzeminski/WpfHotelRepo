using CoreModule.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreModule.Events
{
    public class ActivitySendEvent:PubSubEvent<List<Activity>>
    {
    }
    public class MealSendEvent : PubSubEvent<List<Meal>>
    {
        
    }
    public class MealCountEvent : PubSubEvent<int>
    {

    }

    public class ResetReservationEvent : PubSubEvent<bool>
    {

    }


}
