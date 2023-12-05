using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TabsDataShare.Models;

namespace TabsDataShare.ViewModels
{
    public class Page1ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int _counter = 0;

        public Page1ViewModel(SharedViewModel sharedViewModel)
        {
            SharedData = sharedViewModel;

            ButtonClickCommand = new Command(ButtonClick);
            TextSelectionCommand = new Command<EntryTextSelection>(TextSelection);
        }

        public SharedViewModel SharedData { get; set; }

        private string _buttonText = "Click me";

        public string ButtonText
        {
            get => _buttonText;
            set
            {
                _buttonText = value;
                OnPropertyChanged();
            }
        }

        public ICommand ButtonClickCommand { get; private set; }

        private void ButtonClick()
        {
            ButtonText = $"Clicked {++_counter} times";
        }

        private string _selectedText = string.Empty;

        public string SelectedText
        {
            get => _selectedText;
            set
            {
                _selectedText = value;
                OnPropertyChanged();
            }
        }

        public ICommand TextSelectionCommand { get; private set; }

        private void TextSelection(EntryTextSelection textSelection) 
        {
            SelectedText = textSelection.Text;
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
