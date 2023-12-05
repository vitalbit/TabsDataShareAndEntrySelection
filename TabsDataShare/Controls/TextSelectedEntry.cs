using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TabsDataShare.Models;

namespace TabsDataShare.Controls
{
    public class TextSelectedEntry : Entry
    {
        public static readonly BindableProperty SelectionChangedCommandProperty = BindableProperty.Create(nameof(SelectionChangedCommand), typeof(Command<EntryTextSelection>), typeof(TextSelectedEntry), null, BindingMode.OneTime);

        public Command<EntryTextSelection> SelectionChangedCommand
        {
            get => (Command<EntryTextSelection>)GetValue(SelectionChangedCommandProperty);
            set => SetValue(SelectionChangedCommandProperty, value);
        }
    }
}
