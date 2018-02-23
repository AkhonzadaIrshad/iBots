using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace OurFirstBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {

            await context.PostAsync("Hello tell me your sweet name?");

            context.Wait(NameToldAsync);
        }

        private async Task NameToldAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            string userName = activity.Text;
            await context.PostAsync($"Hey {userName} welcome to Bot");
            context.Wait(NameToldAsync);
 
        }
    }
}