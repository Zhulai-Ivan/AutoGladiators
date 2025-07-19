using System;

namespace Core.Base
{
    public abstract class BaseViewModel
    {
        public virtual void OnViewShown() { }
        public virtual void OnViewHidden() { }

        public event Action<string> MessageEvent;

        public void SendMessage(string message)
        {
            MessageEvent?.Invoke(message);
        }
    }
}