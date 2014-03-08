using System;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using MessageBoxOptions = System.Windows.MessageBoxOptions;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace TheHumbleProgrammer.TaskModalDialogsWithoutSpecialHandling
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
            dialog.ShowDialog();
        }

        private void OnOpenWpfModalDialogWithMeAsOwnerClick(object sender, RoutedEventArgs e)
        {
            WpfModalDialog dialog = new WpfModalDialog();
            dialog.CallingApplicationWindowTitle = Title;
            dialog.Owner = this;
            dialog.ShowDialog();
        }

        private void OnOpenStandardWpfMessageBoxWithoutOwnerClick(object sender, RoutedEventArgs e)
        {
            string message = string.Format(
                "I'm a standard WPF message box.{0}{0}" +

                "You opened me from the {1}.{0}{0}" +

                "My owner was not explicitely specified and .NET set it automatically to the window that was currently active when you opened me.{0}" +
                "That means my owner is actually the {1}.{0}{0}" +
                
                "I disable only that application window and not all off them.{0}" +
                "Go ahead, try clicking on one of them. You will be able to select it.{0}{0}" +

                "So you don't have to close me if you want to access any other of the open application windows.{0}{0}" +

                "If you cover me with some other window and than click on the {1}, I will be automatically focused.",

                Environment.NewLine, Title
            );

            MessageBox.Show(message, "Information", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.None);
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

            System.Windows.Forms.MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void OnOpenStandardWpfDialogClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = string.Format("You opened me from the {0}. Same as the standard WPF message box, I disable only that application window and not all off them.", Title);
            dialog.ShowDialog();
        }

        private void OnOpenStandardWinFormsDialogClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Title = string.Format("You opened me from the {0}. Unlike my WPF counterpart, I disable all application windows and not only the {0}.", Title);
            dialog.ShowDialog();
        }

        private void OnOpenTaskModalWpfMessageBoxClick(object sender, RoutedEventArgs e)
        {
            // This hack will not work.
            // The line below throws InvalidEnumArgumentException with the message:
            // The value of argument 'options' (8192) is invalid for Enum type 'MessageBoxOptions'.
            MessageBox.Show("This line actually throws exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, (MessageBoxOptions)0x2000);
        }

        private void OnOpenTaskModalWinFormsMessageBoxClick(object sender, RoutedEventArgs e)
        {
            const int mbTaskModal = 0x2000; // MB_TASKMODAL constant.

            string message = string.Format(
                "I'm a task-modal WinForms message box.{0}{0}" +

                "You opened me from the {1}.{0}{0}" +

                "I behave exactly the same as the standard WPF modal dialog whose owner is the {1}.{0}{0}" +
                
                @"Actually, I behave exactly the same as the standard WinForms message box whose message box options are not ""hacked"" with the MB_TASKMODAL flag.",

                Environment.NewLine, Title
            );

            System.Windows.Forms.MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                                                 (System.Windows.Forms.MessageBoxOptions)mbTaskModal);
        }
    }
}