namespace TheHumbleProgrammer.TaskModalDialogsWithSpecialHandling
{
    public partial class WpfModalDialog
    {
        /// <summary>
        /// Sets and gets the name of the calling application window in case when the dialog does not have owner.
        /// In case the dialog has the owner this property must be set to the <see cref="Owner.Title"/>.
        /// </summary>
        public string CallingApplicationWindowTitle { get; set; }

        public WpfModalDialog()
        {
            InitializeComponent();
        }

        private void OnWindowLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            string ownerWindowIsSetMessage = "My owner window is {0}.";
            string dialogWillBeFocusedMessage = "If you cover me with some other window and than click on {0}, I will {1}be automatically focused.";

            if (Owner == null)
            {
                ownerWindowIsSetMessage = string.Format(ownerWindowIsSetMessage, "not set");
                dialogWillBeFocusedMessage = string.Format(dialogWillBeFocusedMessage, CallingApplicationWindowTitle, "not ");
            }
            else
            {
                ownerWindowIsSetMessage = string.Format(ownerWindowIsSetMessage, CallingApplicationWindowTitle);
                dialogWillBeFocusedMessage = string.Format(dialogWillBeFocusedMessage, CallingApplicationWindowTitle, string.Empty);
            }

            DataContext = new
            {
                CallingApplicationWindowTitle,
                OwnerWindowIsSetMessage = ownerWindowIsSetMessage,
                DialogWillBeFocusedMessage = dialogWillBeFocusedMessage
            };
        }
    }
}
