using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                titleLabel.Text = "You won!";
            }
            else if (state == "died")
            {
                titleLabel.Text = "You died";
            }
        }

        private void TransitionScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(state == "new level")
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
                Form1.saves[Form1.saveIndex][0] = Convert.ToString(Form1.level);
                Form1.saves[Form1.saveIndex][1] = Convert.ToString(Form1.gameTime);
                Form1.saves[Form1.saveIndex][2] = Convert.ToString(Form1.deaths);

                Form1.ChangeScreen(this, new MenuScreen());
            }
        }
    }
}
