using System.Windows.Forms;

namespace TheHumbleProgrammer.TaskModalDialogsWithSpecialHandling
{
    public static class TaskModalMessageBox
    {
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return TaskModalDialogHandler.ShowAsTaskModal(() => MessageBox.Show(text, caption, buttons, icon, defaultButton));
        }
    }
}