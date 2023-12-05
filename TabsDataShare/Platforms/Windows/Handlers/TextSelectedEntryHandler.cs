using Microsoft.Maui.Handlers;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabsDataShare.Controls;
using TabsDataShare.Models;

namespace TabsDataShare.Handlers
{
    public partial class TextSelectedEntryHandler
    {
        protected override void ConnectHandler(TextBox platformView)
        {
            base.ConnectHandler(platformView);

            platformView.SelectionChanged += PlatformView_SelectionChanged;
        }

        protected override void DisconnectHandler(TextBox platformView)
        {
            platformView.SelectionChanged -= PlatformView_SelectionChanged;

            base.DisconnectHandler(platformView);
        }

        private void PlatformView_SelectionChanged(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            TextSelectedEntry? textEntry = VirtualView as TextSelectedEntry;
            if (textEntry?.SelectionChangedCommand != null)
            {
                EntryTextSelection model = new()
                {
                    Text = textBox.SelectedText
                };
                textEntry.SelectionChangedCommand.Execute(model);
            }
        }
    }
}
