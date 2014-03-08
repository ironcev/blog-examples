using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace TheHumbleProgrammer.TaskModalDialogsWithSpecialHandling
{
    /// <summary>
    /// Ensures that only one instance of the application exists.
    /// </summary>
    /// <remarks>
    /// More details at: http://www.switchonthecode.com/tutorials/wpf-writing-a-single-instance-application
    /// </remarks>
    sealed class SingleInstanceManager : WindowsFormsApplicationBase
    {
        public SingleInstanceApp App { get; private set; }

        [STAThread]
        public static void Main(string[] args)
        {
            new SingleInstanceManager().Run(args);
        }

        public SingleInstanceManager()
        {
            IsSingleInstance = true;
        }

        protected override bool OnStartup(StartupEventArgs e)
        {
            App = new SingleInstanceApp();
            App.Run();
            return false;
        }

        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            base.OnStartupNextInstance(eventArgs);

            if (TaskModalDialogHandler.IsAnyModalDialogOpen)
            {
                TaskModalMessageBox.Show(
                    "New application window cannot be open because a dialog box is open. Close all open dialog boxes before opening a new application window.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                return;
            }

            App.CreateAndShowApplicationWindow();
        }
    }
}