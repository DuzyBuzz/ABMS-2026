using System.Windows.Forms;

namespace ABMS_2026.Common.Helpers
{
    public static class UserControlLoaderHelper
    {
        public static void Load(
            Panel containerPanel,
            UserControl userControl)
        {
            if (containerPanel == null)
            {
                throw new ArgumentNullException(nameof(containerPanel));
            }

            if (userControl == null)
            {
                throw new ArgumentNullException(nameof(userControl));
            }

            containerPanel.SuspendLayout();

            try
            {
                containerPanel.Controls.Clear();

                userControl.Dock = DockStyle.Fill;

                containerPanel.Controls.Add(userControl);

                userControl.BringToFront();
            }
            finally
            {
                containerPanel.ResumeLayout();
            }
        }

        public static T Load<T>(
            Panel containerPanel,
            T userControl)
            where T : UserControl
        {
            Load(containerPanel, (UserControl)userControl);

            return userControl;
        }
    }
}