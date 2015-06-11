using System.Windows;
using EventBinding.MVVM;

namespace Sample
{
    public class MainWindowViewModel : ViewModelBase
    {
        private double _currentHeight;
        public double CurrentHeight
        {
            get { return _currentHeight; }
            set { SetProperty(ref _currentHeight, value); }
        }
        private double _currentWidth;
        public double CurrentWidth
        {
            get { return _currentWidth; }
            set { SetProperty(ref _currentWidth, value); }
        }

        public DelegateCommand MouseDownCommand { get; set; }
        public DelegateCommand SizeChangedCommand { get; set; }

        public override void Init()
        {
            MouseDownCommand = CreateCommand(OnMouseDown);
            SizeChangedCommand = CreateCommand(OnSizeChanged);
        }

        void OnMouseDown(object args)
        {
            if (args == null) args = "null";
            MessageBox.Show(args.ToString());
        }

        private void OnSizeChanged(object args)
        {
            var sizeArgs = args as SizeChangedEventArgs;
            if (sizeArgs != null)
            {
                CurrentHeight = sizeArgs.NewSize.Height;
                CurrentWidth = sizeArgs.NewSize.Width;
            }
        }
    }
}
