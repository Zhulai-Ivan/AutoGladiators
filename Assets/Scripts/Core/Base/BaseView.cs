using System;
using UnityEngine;
using Zenject;

namespace Core.Base
{
    public abstract class BaseView<TViewModel> : MonoBehaviour, IDisposable
        where TViewModel : BaseViewModel
    {
        protected TViewModel ViewModel;

        [Inject]
        public void Construct(TViewModel viewModel)
        {
            ViewModel = viewModel;
            
            Initialize();
        }
        
        protected virtual void OnEnable()
        {
            ViewModel.OnViewShown();
        }

        protected virtual void Initialize()
        {
            ViewModel.MessageEvent += OnMessageReceived;
        }

        protected virtual void OnDisable()
        {
            
        }

        protected virtual void OnMessageReceived(string message) { }
        public void Dispose()
        {
            if (ViewModel != null)
            {
                ViewModel.MessageEvent -= OnMessageReceived;
                ViewModel.OnViewHidden();
            }
        }
    }
}