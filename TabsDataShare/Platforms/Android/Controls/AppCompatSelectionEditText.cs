using Android.Content;
using Android.Runtime;
using AndroidX.AppCompat.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabsDataShare.Models;

namespace TabsDataShare.Platforms.Android.Controls
{
    public class AppCompatSelectionEditText : AppCompatEditText
    {
        public Command<EntryTextSelection>? OnSelectionCommand { get; set; }

        public AppCompatSelectionEditText(Context context) : base(context) { }

        protected override void OnSelectionChanged(int selStart, int selEnd)
        {
            base.OnSelectionChanged(selStart, selEnd);

            if (OnSelectionCommand != null)
            {
                EntryTextSelection selection = new EntryTextSelection
                {
                    Text = Text?[selStart..selEnd] ?? string.Empty
                };
                OnSelectionCommand.Execute(selection);
            }
        }
    }
}
