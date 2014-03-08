using System;
using System.Windows;
using System.Windows.Forms;

namespace TheHumbleProgrammer.TaskModalDialogsWithSpecialHandling
{
    public partial class ApplicationWindow
    {
        public ApplicationWindow()
        {
            InitializeComponent();
        }

        private void OnOpenWpfModalDialogWithoutOwnerClick(object sender, RoutedEventArgs e)
        {
            WpfModalDialog dialog = new WpfModalDialog();
            dialog.CallingApplicationWindowTitle = Title;
            dialog.Owner = null;
            dialog.ShowAsTaskModal();
        }

        private void OnOpenWpfModalDialogWithMeAsOwnerClick(object sender, RoutedEventArgs e)
        {
            WpfModalDialog dialog = new WpfModalDialog();
            dialog.CallingApplicationWindowTitle = Title;
            dialog.Owner = this;
            dialog.ShowAsTaskModal();
        }

        private void OnOpenStandardWinFormsMessageBoxWithoutOwnerClick(object sender, RoutedEventArgs e)
        {
            string message = string.Format(
                "I'm a standard WinForms message box.{0}{0}" +

                "You opened me from the {1}.{0}{0}" +

                "My owner was not explicitely specified.{0}" + 
                "Although the documentation doesn't say it explicitly it looks that my owner is also automatically set to the window that was currently active when you opened me.{0}" +
                "That means my owner is probably the {1}.{0}{0}" +

                "Unlike my WPF counterpart, I disable all application windows and not only the {1}.{0}" +
                "Go ahead, try clicking on one of them. You will not be able to select it.{0}{0}" +

                "So you have to close me if you want to access any other of the open application windows.{0}{0}" +

                "If you cover me with some other window and than click on the {1}, I will be automatically focused.",

                Environment.NewLine, Title
            );

            TaskModalMessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void OnOpenStandardWinFormsDialogClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = string.Format("You opened me from the {0}. Unlike my WPF counterpart, I disable all application windows and not only the {0}.", Title);
            dialog.ShowAsTaskModal();
        }
    }
}