using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace TaskApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private bool _secondButtonEnabled = true;
        public bool SecondButtonEnabled
        {
            get => _secondButtonEnabled;
            set
            {
                if (_secondButtonEnabled != value)
                {
                    _secondButtonEnabled = value;
                    OnPropertyChanged(nameof(SecondButtonEnabled));
                    ((Command)IncrementCounterCommand).ChangeCanExecute();
                }
            }
        }

        private int _counter = 0;
        public int Counter
        {
            get => _counter;
            set
            {
                if (_counter != value)
                {
                    _counter = value;
                    OnPropertyChanged(nameof(Counter));
                }
            }
        }

        public ICommand ToggleSecondButtonEnabledCommand { get; }
        public ICommand IncrementCounterCommand { get; }

        public MainPage()
        {
            InitializeComponent();
            ToggleSecondButtonEnabledCommand = new Command(() => SecondButtonEnabled = !SecondButtonEnabled);
            IncrementCounterCommand = new Command(() => Counter++);
            BindingContext = this;
        }
    }
}
