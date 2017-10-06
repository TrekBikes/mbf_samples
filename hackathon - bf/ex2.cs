using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Text.RegularExpressions;

namespace Bot_Application1.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private int step;
        private int age;
        private string location;

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            if (step==0)
            {
                await context.PostAsync("What is your age?");
                step++;
            } else if (step==1)
            {
                if(Regex.IsMatch(activity.Text,"[0-9]+"))
                {
                    age = int.Parse(Regex.Match(activity.Text, "[0-9]+").Value);
                    await context.PostAsync("What is your location?");
                    step++;
                } else
                {
                    await context.PostAsync("please enter a valid age");
                }
            } else if (step == 2)
            {
                if ((activity.Text ?? string.Empty).Trim().Length > 0)
                {
                    location = activity.Text.Trim();
                    await context.PostAsync($"Your age is {age} and your location is {location}");
                    step=0;
                }
                else
                {
                    await context.PostAsync("please enter a valid location");
                }
            } else
            {
                step = 0;
            }


            context.Wait(MessageReceivedAsync);
        }
    }
}