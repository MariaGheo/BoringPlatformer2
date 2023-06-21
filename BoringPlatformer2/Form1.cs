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

namespace BoringPlatformer2
{
    public partial class Form1 : Form
    {
        public static List<List<string>> saves = new List<List<string>>();
        public static int saveIndex = -1;
        public static int level = 1;
        public static int gameTime = 0;
        public static int deaths = 0;
        public static List<int> jumpYSpeed = new List<int>(new int[] { -25, -18, -13, -9, -5, -2, -1, 0, 1, 2, 5, 9, 13, 18, 25, 32, 37, 40, 41, 41, 41, 41, 41, 41, 41, 41, 41, 41, 41, 41, 41 });

        public Form1()
        {
            InitializeComponent();

            ReadSaves();

            ChangeScreen(this, new MenuScreen()); // open menu screen when the program starts
        }

        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f; // will either be the sender or parent of sender

            if (sender is Form)
            {
                f = (Form)sender;                          //f is sender
            }
            else
            {
                UserControl current = (UserControl)sender;  //create UserControl from sender
                f = current.FindForm();                     //find Form UserControl is on
                f.Controls.Remove(current);                 //remove current UserControl
            }

            // add the new UserControl to the middle of the screen and focus on it
            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
                (f.ClientSize.Height - next.Height) / 2);
            f.Controls.Add(next);
            next.Focus();
        }

        public static void ReadSaves()
        {
            saves.Clear();

            for (int i = 1; i <= 5; i++)
            {
                List<string> save = File.ReadAllLines($"Save{i}.txt").ToList();
                saves.Add(save);
            }
        }
    }
}
