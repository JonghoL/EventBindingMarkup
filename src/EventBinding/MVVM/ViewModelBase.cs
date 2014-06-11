using System;

namespace EventBinding.MVVM
{
    public class ViewModelBase : BindableBase, IViewModel
    {
        public virtual void Init() { }

        protected DelegateCommnad CreateCommand(Action<object> executeMethod)
        {
            return CreateCommand(executeMethod, (o) => true);
        }

        protected DelegateCommnad CreateCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            return new DelegateCommnad(executeMethod, canExecuteMethod);
        }
    }

    public interface IViewModel
    {
        void Init();
    }
}
