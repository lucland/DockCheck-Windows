using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

public class BackgroundTaskManager
{
    private CancellationTokenSource cancellationTokenSource;

    public BackgroundTaskManager()
    {
        cancellationTokenSource = new CancellationTokenSource();
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
                // Trigger the function every 5 seconds
                await Task.Delay(5000, cancellationToken);

                // Safe way to call a function that interacts with the UI
                UpdateUI();
            }
            catch (TaskCanceledException)
            {
                // Task was canceled
                break;
            }
        }
    }

    private void UpdateUI()
    {
        // Check if the call is from a different thread than the UI thread
        if (Application.OpenForms[0].InvokeRequired)
        {
            Application.OpenForms[0].Invoke(new MethodInvoker(ShowMessage));
        }
        else
        {
            ShowMessage();
        }
    }

    private void ShowMessage()
    {
        MessageBox.Show("Triggered every 5 seconds");
    }

    public void StopBackgroundTask()
    {
        cancellationTokenSource.Cancel();
    }
}
