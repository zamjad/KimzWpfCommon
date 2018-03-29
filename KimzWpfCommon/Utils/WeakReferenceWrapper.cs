using System;

namespace KimzWpfCommon.Utils
{
    public class WeakReferenceWrapper
    {
        private WeakReference _weakReference;

        public WeakReferenceWrapper(object receiver, Delegate action)
        {
            _weakReference = new WeakReference(receiver);
            this.Action = action;
        }

        public Delegate Action { get; set; }
    }
}
