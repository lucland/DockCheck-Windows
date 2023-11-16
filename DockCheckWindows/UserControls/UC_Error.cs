using System;
using System.Windows.Forms;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Error : UserControl
    {
        // Define a delegate that represents the signature of the retry function
        public delegate void RetryAction();

        private RetryAction retryAction;
        private String errorMessage;

        public UC_Error(RetryAction retryAction = null, string errorMessage = null)
        {
            InitializeComponent();
            this.retryAction = retryAction;
            this.errorMessage = errorMessage;
            if (errorMessage != null || errorMessage != "")
            {
                labelError.Text = errorMessage;
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            // Assuming you want to hide this UserControl
            this.Hide();
        }

        private void retryButton_Click(object sender, EventArgs e)
        {
            // Execute the retry action if it's assigned
            this.Hide();
            retryAction?.Invoke();
        }

        // Method to set or change the retry action
        public void SetRetryAction(RetryAction newRetryAction)
        {
            retryAction = newRetryAction;
        }
    }
}

