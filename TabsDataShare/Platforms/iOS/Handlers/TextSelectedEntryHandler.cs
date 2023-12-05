using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using TabsDataShare.Controls;
using UIKit;

namespace TabsDataShare.Handlers
{
    public partial class TextSelectedEntryHandler
    {
        public TextSelectedEntryHandler() : base()
        {
            Mapper.Add(nameof(TextSelectedEntry.SelectionChangedCommand), MapSelectionChangedCommand);
        }

        protected override MauiTextField CreatePlatformView()
        {
            TextSelectedEntry? textEntry = VirtualView as TextSelectedEntry;
            var textField = new SelectionTextField
            {
                BorderStyle = UITextBorderStyle.RoundedRect,
                ClipsToBounds = true
            };

            if (textEntry != null)
            {
                textField.OnSelectionCommand = textEntry.SelectionChangedCommand;
            }

            return textField;
        }

        public static void MapSelectionChangedCommand(IEntryHandler handler, IEntry entry)
        {
            SelectionTextField? nativeEntry = handler.PlatformView as SelectionTextField;
            TextSelectedEntry? textEntry = entry as TextSelectedEntry;
            if (nativeEntry != null && textEntry != null)
            {
                nativeEntry.OnSelectionCommand = textEntry.SelectionChangedCommand;
            }
        }
    }
}
