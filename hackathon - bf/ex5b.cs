using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Text.RegularExpressions;
using Microsoft.Bot.Builder.FormFlow;

namespace Bot_Application1.Dialogs
{
    [Serializable]
    public class RootDialog
    {
        public static IDialog<Forms.AgeAndLocation> MakeAgeAndLocationDialog()
        {
            return Chain.From(() => FormDialog.FromForm(Forms.AgeAndLocation.BuildForm))
                .Do(async (context, result) => {

                    var form = await result;

                    await context.PostAsync($"your age is {form.Age} and your location is {form.Location}");
                });
        }

    }
}