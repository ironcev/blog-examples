using System;
using System.Windows;
using System.Windows.Forms;

namespace TheHumbleProgrammer.TaskModalDialogsWithSpecialHandling
{
    public static class TaskModalDialogHandler
    {
        private static readonly object sync = new object();
        private static int numberOfOpenDialogs;

        public static bool? ShowAsTaskModal(this Window dialog)
        {
            return ShowAsTaskModal(dialog.ShowDialog);
        }

        public static DialogResult ShowAsTaskModal(this CommonDialog dialog)
        {
            return ShowAsTaskModal(dialog.ShowDialog);
        }

        internal static T ShowAsTaskModal<T>(Func<T> openDialog)
        {
            lock(sync)
            {
                numberOfOpenDialogs++;    
            }
            
            T result = openDialog();

            lock(sync)
            {
                numberOfOpenDialogs--;    
            }
            
            return result;  
        }

        public static bool IsAnyModalDialogOpen
        {
            get { lock(sync) return numberOfOpenDialogs > 0; }
        }
    }
}
