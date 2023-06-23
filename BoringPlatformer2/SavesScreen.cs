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
    public partial class SavesScreen : UserControl
    {
        public SavesScreen()
        {
            InitializeComponent();

            List<Button> buttons = new List<Button>(new Button[] { save1Button, save2Button, save3Button, save4Button, save5Button });

            //update save button text
            Form1.ReadSaves();

            for(int i = 0; i < 5; i++)
            {
                if (Form1.saves[i][0] == "Empty")
                {
                    buttons[i].Text = "Empty Save";
                }
                else
                {
                    if (Form1.saves[i][0] != "6")
                    {
                        buttons[i].Text = $"Save {i + 1}: Level " + Form1.saves[i][0];
                    }
                    else
                    {
                        buttons[i].Text = $"Save {i + 1}: Game Complete";
                    }
                }
            }
        }

        //gets variables set up for playing the selected save, and changes to GameScreen
        private void saveButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Form1.saveIndex = Convert.ToInt16(button.Tag);

            if (Form1.saves[Form1.saveIndex][0] != "Empty" && Form1.saves[Form1.saveIndex][0] != "6")
            {
                Form1.level = Convert.ToInt32(Form1.saves[Form1.saveIndex][0]);
                Form1.gameTime = Convert.ToInt32(Form1.saves[Form1.saveIndex][1]);
                Form1.deaths = Convert.ToInt32(Form1.saves[Form1.saveIndex][2]);
            }
            else
            {
                Form1.level = 1;
                Form1.gameTime = 0;
                Form1.deaths = 0;
            }

            Form1.ChangeScreen(this, new TransitionScreen("new level"));
        }

        //change to menu screen
        private void menuButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }
    }
}
