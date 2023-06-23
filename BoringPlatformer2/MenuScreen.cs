using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace BoringPlatformer2
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void MenuScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SoundPlayer confirmBeep = new SoundPlayer(Properties.Resources.confirmBeep);
                confirmBeep.Play();

                Form1.ChangeScreen(this, new SavesScreen());
            }
            else if (e.KeyCode == Keys.Escape)
            {
                SoundPlayer confirmBeep = new SoundPlayer(Properties.Resources.confirmBeep);
                confirmBeep.Play();

                Application.Exit();
            }
        }
    }
}
