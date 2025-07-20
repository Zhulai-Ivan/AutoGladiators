using System;

namespace Core.Base
{
    public abstract class BaseViewModel : IDisposable
    {
        public virtual void OnViewShown() { }
        public virtual void OnViewHidden() { }

        public event Action<string> MessageEvent;

        public void SendMessage(string message)
        {
            MessageEvent?.Invoke(message);
        }

        public virtual void Dispose()
        {
            
        }
    }
}