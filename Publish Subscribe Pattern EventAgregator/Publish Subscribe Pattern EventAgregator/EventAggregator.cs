using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publish_Subscribe_Pattern_EventAgregator
{
    class EventAggregator
    {
        //private readonly object lockObj = new object();
        private Dictionary<Type, IList> subscriber;

        public EventAggregator()
        {
            subscriber = new Dictionary<Type, IList>();
        }

        public void Publish<TMessageType>(TMessageType message)
        {
            var newMessage = EventAggregator.ConvertValue<TMessageType>(message);

            Type t = typeof(TMessageType);
            IList sublst;
            if (subscriber.ContainsKey(t))
            {
                //lock (lockObj)
                //{
                    sublst = new List<Subscription<TMessageType>>(subscriber[t].Cast<Subscription<TMessageType>>());
                //}

                foreach (Subscription<TMessageType> sub in sublst)
                {
                    var action = sub.CreatAction();
                    if (action != null)
                        action(newMessage);
                }
            }
        }

        public static TMessageType ConvertValue<TMessageType>(TMessageType value)
        {
            if (value.GetType().Name == "Int32")
            {
                var newValue = Int32.Parse(value.ToString()) + Int32.Parse(value.ToString());
                return (TMessageType)Convert.ChangeType(newValue, typeof(TMessageType));
            }
            else
            {
                var newValue = value +" and "+ value;
                return (TMessageType)Convert.ChangeType(newValue, typeof(TMessageType));
            }
        }

        public Subscription<TMessageType> Subscribe<TMessageType>(Action<TMessageType> action)
        {
            Type t = typeof(TMessageType);
            IList actionlst;
            var actiondetail = new Subscription<TMessageType>(action, this);

            //lock (lockObj)
            //{
                if (!subscriber.TryGetValue(t, out actionlst))
                {
                    actionlst = new List<Subscription<TMessageType>>();
                    actionlst.Add(actiondetail);
                    subscriber.Add(t, actionlst);
                }
                else
                {
                    actionlst.Add(actiondetail);
                }
            //}

            return actiondetail;
        }

        public void UnSubscribe<TMessageType>(Subscription<TMessageType> subscription)
        {
            Type t = typeof(TMessageType);
            if (subscriber.ContainsKey(t))
            {
                //lock (lockObj)
                //{
                    subscriber[t].Remove(subscription);
                //}
                subscription = null;
            }
        }

    }
}
