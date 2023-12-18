using DockCheckWindows.Repositories;
using System.Threading.Tasks;
using System.Threading;
using System;

public class BackgroundTaskManager
{
    private CancellationTokenSource cancellationTokenSource;
    private UserRepository userRepository; // Assuming UserRepository is accessible here

    public BackgroundTaskManager(UserRepository userRepository)
    {
        cancellationTokenSource = new CancellationTokenSource();
        this.userRepository = userRepository;
    }

    public void StartBackgroundTask()
    {
        Task.Run(() => RunPeriodicTask(cancellationTokenSource.Token));
    }

    private async Task RunPeriodicTask(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var nextRunTime = GetNextRunTime();
                var delay = nextRunTime - DateTime.Now;

                if (delay.TotalMilliseconds > 0)
                {
                    await Task.Delay(delay, cancellationToken);
                }

                await ExecuteTaskAsync();

                // Wait for 24 hours before the next run
                await Task.Delay(TimeSpan.FromHours(24), cancellationToken);
            }
            catch (TaskCanceledException)
            {
                // Task was canceled
                break;
            }
        }
    }

    private DateTime GetNextRunTime()
    {
        var now = DateTime.Now;
        var nextRunTime = now.Date.AddHours(1); // 1 AM today

        // If it's already past 1 AM today, schedule for 1 AM next day
        if (now > nextRunTime)
        {
            nextRunTime = nextRunTime.AddDays(1);
        }

        return nextRunTime;
    }

    private async Task ExecuteTaskAsync()
    {
        try
        {
            // Call GetAllApprovedUsersAsync method here
            var response = await userRepository.GetAllApprovedUsersAsync();
            // Process the response as required
        }
        catch (Exception ex)
        {
            // Handle exceptions
        }
    }

    public void StopBackgroundTask()
    {
        cancellationTokenSource.Cancel();
    }
}
