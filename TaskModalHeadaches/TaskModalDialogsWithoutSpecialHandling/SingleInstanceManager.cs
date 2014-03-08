using System;
using Microsoft.VisualBasic.ApplicationServices;

namespace TheHumbleProgrammer.TaskModalDialogsWithoutSpecialHandling
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

            App.CreateAndShowApplicationWindow();
        }
    }
}