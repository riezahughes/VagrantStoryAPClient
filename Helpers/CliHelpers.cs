using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Silk.NET.OpenGL;
using Spectre.Console;

namespace VagrantStoryArchipelago.Helpers
{
    internal class CliHelpers
    {
        public static Layout CreateGridLayout()
        {
 
            var layout = new Layout("Root")
                .SplitColumns(
                    new Layout("Left").Ratio(1),
                    new Layout("Right").Ratio(1)
                );

            layout["Right"].SplitRows(
                new Layout("TopRight"),
                new Layout("BottomRight")
            );

            layout["Left"].Update(
                new Panel("Left Column (Full Height)")
                    .Expand()
                    .BorderColor(Color.Blue));

            layout["TopRight"].Update(
                new Panel("Right - Top Square")
                    .Expand()
                    .BorderColor(Color.Green));

            layout["BottomRight"].Update(
                new Panel("Right - Bottom Square")
                    .Expand()
                    .BorderColor(Color.Red));

            return layout;
        }
        public static void AddMessageToLeftPanel(Layout layout, List<Markup>currentMessages, string newMessage){

            currentMessages.Add(new Markup($"\n[bold yellow]{newMessage}[/]"));
            layout["Left"].Update(new Panel(new Rows(currentMessages)).Expand());
            //AnsiConsole.Write(layout);
        }
    }
}
