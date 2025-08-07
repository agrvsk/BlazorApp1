using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Server.Components
{
    public partial class TimerComponent : ComponentBase
    {
        private int timeLeft = 20 * 60;

        public string remaining => TimeSpan.FromSeconds(timeLeft).ToString(@"mm\:ss");

        PeriodicTimer? timer;

        protected async Task Start()
        {
            timer = new PeriodicTimer(TimeSpan.FromSeconds(1));

            while (await timer.WaitForNextTickAsync())
            {
                if (timeLeft > 0)
                {
                    timeLeft -= 1;
                    await InvokeAsync(StateHasChanged);
                }
            }
        }

        protected void Stopp()
        {
            timer?.Dispose();
        }
    }
}