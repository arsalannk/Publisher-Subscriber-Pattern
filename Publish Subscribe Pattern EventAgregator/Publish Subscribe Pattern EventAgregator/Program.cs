using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publish_Subscribe_Pattern_EventAgregator
{
    class Program
    {
        static void Main(string[] args)
        {
            EventAggregator eve = new EventAggregator();
            
            Publisher pub = new Publisher(eve, 10, "Some Message");
            
            Subscriber sub1 = new Subscriber(eve, 1, "subscriber 1");
            Subscriber sub2 = new Subscriber(eve, 2, "subscriber 2");
            Subscriber sub3 = new Subscriber(eve, 2, "subscriber 3");
            Subscriber sub4 = new Subscriber(eve, 1, "subscriber 4");

            pub.PublishMessage();

            Console.ReadLine();
        }
    }
}
