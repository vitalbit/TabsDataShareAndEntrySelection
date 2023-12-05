using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabsDataShare.Controls;
using TabsDataShare.Platforms.Android.Controls;

namespace TabsDataShare.Handlers
{
    public partial class TextSelectedEntryHandler
    {
        public TextSelectedEntryHandler() : base() 
        {
            Mapper.Add(nameof(TextSelectedEntry.SelectionChangedCommand), MapSelectionChangedCommand);
        }

        protected override AppCompatEditText CreatePlatformView()
        {
            TextSelectedEntry? textEntry = VirtualView as TextSelectedEntry;
            var nativeEntry = new AppCompatSelectionEditText(Context);

            if (textEntry != null)
            {
                nativeEntry.OnSelectionCommand = textEntry.SelectionChangedCommand;
            }

            return nativeEntry;
        }

        public static void MapSelectionChangedCommand(IEntryHandler handler, IEntry entry)
        {
            AppCompatSelectionEditText? nativeEntry = handler.PlatformView as AppCompatSelectionEditText;
            TextSelectedEntry? textEntry = entry as TextSelectedEntry;
            if (nativeEntry != null && textEntry != null) 
            {
                nativeEntry.OnSelectionCommand = textEntry.SelectionChangedCommand;
            }
        }
    }
}
