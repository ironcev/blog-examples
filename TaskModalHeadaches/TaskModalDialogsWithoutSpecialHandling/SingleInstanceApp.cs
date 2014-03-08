using System.Linq;
using System.Windows;

namespace TheHumbleProgrammer.TaskModalDialogsWithoutSpecialHandling
{
    class SingleInstanceApp : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            CreateMainWindow();

            CreateAndShowApplicationWindow();
        }

        private void CreateMainWindow()
        {
            Current.MainWindow = new Window { Title = "Task-Modal Dialogs Sample" }; // Create dummy main window. This way we are sure that none of the application windows will be set as main window.
        }

        internal void CreateAndShowApplicationWindow()
        {
            int numberOfOpenApplicationWindows = Current.Windows.Cast<Window>().Where(x => x is ApplicationWindow).Count();

            ApplicationWindow applicationWindow = new ApplicationWindow();
            applicationWindow.Title = "Application Window #" + (numberOfOpenApplicationWindows + 1);

            applicationWindow.Closed += OnApplicationWindowClosed;

            applicationWindow.Show();
        }

        /// <remarks>
        /// We didn't change the standard value of the <see cref="Application.ShutdownMode"/> property
        /// (which is <see cref="ShutdownMode.OnLastWindowClose"/>).
        /// The application process will stop when the (invisible) main window is closed.
        /// Therefore we have to close the main window manually after all application windows are closed.
        /// </remarks>        
        private void OnApplicationWindowClosed(object sender, System.EventArgs e)
        {
            int numberOfOpenApplicationWindows = Current.Windows.Cast<Window>().Where(x => x is ApplicationWindow).Count();
            if (numberOfOpenApplicationWindows <= 0) Current.MainWindow.Close();
        }
    }
}
