using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Publish_Subscribe_Pattern_EventAgregator
{
    class Subscription<Tmessage> : IDisposable
   {
       public readonly MethodInfo MethodInfo;
       private readonly EventAggregator EventAggregator;
       //public readonly WeakReference TargetObject;
       public readonly object TargetMethod;
       public readonly bool IsStatic;

       private bool isDisposed;
       public Subscription(Action<Tmessage> action, EventAggregator eventAggregator)
       {
           MethodInfo = action.Method;
           TargetMethod = action.Target;
           EventAggregator = eventAggregator;
       }

       ~Subscription()
       {
           if (!isDisposed)
               Dispose();
       }

       public void Dispose()
       {
           EventAggregator.UnSubscribe(this);
           isDisposed = true;
       }

       public Action<Tmessage> CreatAction()
       {
           return (Action<Tmessage>)Delegate.CreateDelegate(typeof(Action<Tmessage>), TargetMethod, MethodInfo);
       }
   }
}
