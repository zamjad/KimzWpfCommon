using System;
using System.Runtime.Serialization;

namespace KimzWpfCommon.Utils
{
    public class DisposableWeakReference : DisopsableObject, ISerializable
    {
        private readonly WeakReference _handle;

        public DisposableWeakReference(object target)
        {
            _handle = new WeakReference(target);
        }

        public DisposableWeakReference(object target, bool trackResurrection)
        {
            _handle = new WeakReference(target, trackResurrection);
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            _handle.GetObjectData(info, context);
        }

        public object Target
        {
            get => this._handle.Target;
            set => this._handle.Target = value;
        }

        public bool IsAlive => this._handle.IsAlive;

        public bool TrackResurrection => this._handle.TrackResurrection;

        public void Close()
        {
            this.Dispose(true);
        }

        ~DisposableWeakReference()
        {
            this.Dispose(true);
        }
    }
}
