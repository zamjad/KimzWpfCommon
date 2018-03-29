using System;

namespace KimzWpfCommon.Utils
{
    public abstract class DisopsableObject : IDisposable
    {
        private bool _disposed;

        protected DisopsableObject()
        {
            _disposed = false;
        }
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                // Disposed Managed Resource
            }

            // Disposed Unmanaged Resource
            _disposed = true;
        }
    }
}
