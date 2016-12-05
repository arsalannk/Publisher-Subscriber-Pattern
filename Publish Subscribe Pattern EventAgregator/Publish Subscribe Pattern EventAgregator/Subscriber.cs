using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publish_Subscribe_Pattern_EventAgregator
{
    class Subscriber
    {
        string Name { get; set; }
        Subscription<int> intToken;
        Subscription<string> strToken;
        EventAggregator eventAggregator;

        public Subscriber(EventAggregator eve, int isMessage, string name)
        {
            eventAggregator = eve;
            if (isMessage == 1)
            {
                eve.Subscribe<int>(this.IntAction);
            }
            else if (isMessage == 2)
            {
                eve.Subscribe<string>(this.StringAction);
            }


            Name = name;
        }

        private void IntAction(int value)
        {
            Console.WriteLine("Subscriber : " + Name + " value : " + value);
        }

        private void StringAction(string value)
        {
            Console.WriteLine("Subscriber : " + Name + " value : " + value.ToString());
        }
    }
}
