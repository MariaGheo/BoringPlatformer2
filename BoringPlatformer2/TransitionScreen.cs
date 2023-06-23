using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BoringPlatformer2
{
    public partial class TransitionScreen : UserControl
    {
        string state;

        public TransitionScreen(string newState)
        {
            InitializeComponent();

            state = newState;

            if (state == "new level")
            {
                titleLabel.Text = $"Level {Form1.level}";
            }
            else if (state == "won")
            {
                if (Form1.level != 6)
                {
                    titleLabel.Text = "Level Complete!";
                }
                else
                {
                    titleLabel.Text = "Game complete!";
                    subtitleLabel.Text = $"Total Deaths: {Form1.deaths}\nTotal Play Time: {Form1.gameTime} seconds\nPress any button to return to main menu";
                }
            }
            else if (state == "died")
            {
                titleLabel.Text = "You died";
            }
        }

        private void TransitionScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (Form1.level == 6)
            {
                SoundPlayer confirmBeep = new SoundPlayer(Properties.Resources.confirmBeep);
                confirmBeep.Play();

                Form1.SaveData();
                Form1.ChangeScreen(this, new MenuScreen());
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SoundPlayer confirmBeep = new SoundPlayer(Properties.Resources.confirmBeep);
                    confirmBeep.Play();

                    if (state == "new level")
                    {
                        Form1.ChangeScreen(this, new GameScreen());
                    }
                    else
                    {
                        Form1.ChangeScreen(this, new TransitionScreen("new level"));
                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    SoundPlayer confirmBeep = new SoundPlayer(Properties.Resources.confirmBeep);
                    confirmBeep.Play();

                    Form1.SaveData();

                    Form1.ChangeScreen(this, new MenuScreen());
                }
            }
        }
    }
}
