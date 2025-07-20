using System;
using UnityEngine;
using Zenject;

namespace Core.Base
{
    public abstract class BaseView<TViewModel> : MonoBehaviour 
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
            ViewModel.MessageEvent += OnMessageReceived;
            ViewModel.OnViewShown();
        }
        
        protected virtual void Initialize(){ }

        protected virtual void OnDisable()
        {
            if (ViewModel != null)
            {
                ViewModel.MessageEvent -= OnMessageReceived;
                ViewModel.OnViewHidden();
            }
        }

        protected virtual void OnMessageReceived(string message) { }
    }
}