using Microsoft.Maui.Platform;
using TabsDataShare.Models;
using UIKit;

namespace TabsDataShare;

public class SelectionTextField : MauiTextField
{
    public Command<EntryTextSelection>? OnSelectionCommand { get; set; }

    public override UITextRange? SelectedTextRange
    { 
        get => base.SelectedTextRange;
        set
        {
            var old = base.SelectedTextRange;

            base.SelectedTextRange = value;

            if (value != null && OnSelectionCommand != null && (old?.Start != value?.Start || old?.End != value?.End))
            {
                EntryTextSelection selection = new EntryTextSelection
                {
                     Text = this.TextInRange(value)
                };
                OnSelectionCommand.Execute(selection);
            }
        }
    }
}
