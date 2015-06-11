using System;

namespace EventBinding.MVVM
{
    public class ViewModelBase : BindableBase, IViewModel
    {
        public virtual void Init() { }

        protected DelegateCommand CreateCommand(Action<object> executeMethod)
        {
            return CreateCommand(executeMethod, (o) => true);
        }

        protected DelegateCommand CreateCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            return new DelegateCommand(executeMethod, canExecuteMethod);
        }
    }

    public interface IViewModel
    {
        void Init();
    }
}
