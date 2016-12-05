using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publish_Subscribe_Pattern_EventAgregator
{
    class Publisher
    {
        private int integerMsg;
        private string stringMsg;

        EventAggregator EventAggregator;
        public Publisher(EventAggregator eventAggregator, int intMsg, string strMsg)
        {
            integerMsg = intMsg;
            stringMsg = strMsg;
            EventAggregator = eventAggregator;
        }

        public void PublishMessage()
        {
            EventAggregator.Publish(integerMsg);
            EventAggregator.Publish(stringMsg);
        }
    }
}
