using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Media;

namespace BoringPlatformer2
{
    public partial class GameScreen : UserControl
    {
        Player player;
        Door door;
        List<Platform> platforms = new List<Platform>();
        int currentPlatformIndex = -1;
        List<int> belowPlatforms = new List<int>();
        Obstacle obstacle;
        int timer;

        //player control variables
        bool aDown = false;
        bool dDown = false;
        bool spaceDown = false;

        //Brush
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        public GameScreen()
        {
            InitializeComponent();

            timer = 0;

            //get data from level file
            levelLabel.Text = $"Level {Form1.level}";

            List<String> levelData = File.ReadAllLines($"Level{Form1.level}.txt").ToList();

            player = new Player(Convert.ToInt32(levelData[1]), Convert.ToInt32(levelData[2]));

            int index;

            if (levelData[3] == "Door")
            {
                door = new Door(Convert.ToInt32(levelData[4]), Convert.ToInt32(levelData[5]));

                index = 7;
            }
            else
            {
                List<Point> points = new List<Point>();

                bool loop = true;
                index = 4;

                while (loop)
                {
                    points.Add(new Point(Convert.ToInt32(levelData[index]), Convert.ToInt32(levelData[index + 1])));

                    index += 2;

                    if (levelData[index] == "Obstacle")
                    {
                        loop = false;
                    }
                }

                door = new Door(Convert.ToInt32(levelData[4]), Convert.ToInt32(levelData[5]), points);
                index += 1;
            }

            if (levelData[index] != "none")
            {
                if (levelData[index + 3] == "true")
                {
                    obstacle = new Obstacle(Convert.ToInt32(levelData[index]), Convert.ToInt32(levelData[index + 1]), Convert.ToInt32(levelData[index + 2]), true, Convert.ToInt32(levelData[index + 4]), Convert.ToInt32(levelData[index + 5]));
                }
                else
                {
                    obstacle = new Obstacle(Convert.ToInt32(levelData[index]), Convert.ToInt32(levelData[index + 1]), Convert.ToInt32(levelData[index + 2]), false, Convert.ToInt32(levelData[index + 4]), Convert.ToInt32(levelData[index + 5]));
                }

                index += 7;
            }
            else
            {
                index += 2;
            }

            if (levelData[index] != "none")
            {
                platforms.Add(new Platform(Convert.ToInt32(levelData[index]), Convert.ToInt32(levelData[index + 1]), Convert.ToInt32(levelData[index + 2]), Convert.ToInt32(levelData[index + 3]), Convert.ToInt32(levelData[index + 4]), Convert.ToInt32(levelData[index + 5]), Convert.ToInt32(levelData[index + 6])));

                index += 8;
            }
            else
            {
                index += 2;
            }

            for (int i = index; i < levelData.Count - 5; i += 6)
            {
                Platform platform = new Platform(Convert.ToInt32(levelData[i]), Convert.ToInt32(levelData[i + 1]), Convert.ToInt32(levelData[i + 2]), Convert.ToInt32(levelData[i + 3]));

                if (levelData[i + 4] == "true")
                {
                    platform.willFall = true;
                }
                else
                {
                    platform.willFall = false;
                }
                
                if (levelData[i + 5] == "true")
                {
                    platform.visible = true;
                }
                else
                {
                    platform.visible = false;
                }

                platforms.Add(platform);
            }

            Refresh();
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (gameEngine.Enabled == false)
            {
                gameEngine.Enabled = true;
            }
            
            switch (e.KeyCode)
            {
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;
            }
        }

        private void gameEngine_Tick(object sender, EventArgs e)
        {
            timer++;

            foreach (Platform platform in platforms)
            {
                platform.Move();
            }

            for(int i = 0; i < platforms.Count; i++)
            {
                if (player.IsOnTopOf(platforms[i]))
                {
                    currentPlatformIndex = i;
                    break;
                }
                else
                {
                    currentPlatformIndex = -1;
                }
            }

            player.Move(aDown, dDown, spaceDown);

            //if the player was on a platform and started jumping, make the platform start falling (if applicable to the level)
            if (currentPlatformIndex != -1 && spaceDown)
            {
                platforms[currentPlatformIndex].Fall();
            }

            //if the player is in the air:
            //check if the platform(s) it was above last tick are now above it. if so, place the player on the platform and stop jumping (reset all jumping variables)
            //check which platform(s) it is currently above. store the index(es) of the platform(s).
            if (belowPlatforms != null)
            {
                for (int i = 0; i < belowPlatforms.Count; i++)
                {
                    if (player.IsBelow(platforms[belowPlatforms[i]]))
                    {
                        SoundPlayer blip = new SoundPlayer(Properties.Resources.blip);
                        blip.Play();

                        player.y = platforms[belowPlatforms[i]].y - player.height;
                        player.inAir = false;
                        player.jumpCount = 0;
                        belowPlatforms.Clear();

                        break;
                    }
                }
            }

            belowPlatforms.Clear();

            if (player.inAir)
            {
                for (int i = 0; i < platforms.Count; i++)
                {
                    if (player.IsAbove(platforms[i]))
                    {
                        belowPlatforms.Add(i);
                    }
                }
            }
            else
            {
                bool fall = true;

                foreach (Platform platform in platforms)
                {
                    if (player.IsOnTopOf(platform))
                    {
                        fall = false;
                    }
                }

                if (fall)
                {
                    player.inAir = true;
                    player.jumpCount = 8;
                }
            }

            //update obstacles
            if (obstacle != null)
            {
                obstacle.Move();

                if (player.IntersectsWith(obstacle))//end game if the player hits an obstacle
                {
                    EndGame(false);
                }
            }

            //end game if the player hits the bottom of the screen
            if (player.y + player.height >= 400)
            {
                SoundPlayer fall = new SoundPlayer(Properties.Resources.fall);
                fall.Play();

                EndGame(false);
            }

            //end game if the player touches the door
            if (player.IntersectsWith(door))
            {
                EndGame(true);
            }

            //if player is going to intersect with the door in the next frame, move the door (if applicable)
            Player futurePlayer = new Player(player.x, player.y);

            futurePlayer.Move(aDown, dDown, spaceDown);

            if (futurePlayer.IntersectsWith(door))
            {
                door.Move();
            }

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //Paint player
            e.Graphics.FillRectangle(whiteBrush, player.x, player.y, player.width, player.height);

            //Paint door
            e.Graphics.FillRectangle(whiteBrush, door.rectangle);
            e.Graphics.FillEllipse(whiteBrush, door.ellipse);

            //Paint platforms
            foreach (Platform platform in platforms)
            {
                if (platform.visible)
                {
                    e.Graphics.FillRectangle(whiteBrush, platform.x, platform.y, platform.width, platform.height);
                }
            }
        }

        public void EndGame(bool won)
        {
            gameEngine.Enabled = false; //stop game engine
            Form1.gameTime += timer * 17 / 1000; //update total game time

            //go to transition screen with appropriate title based on whether the player won or lost
            if (won)
            {
                SoundPlayer winBeep = new SoundPlayer(Properties.Resources.winBeep);
                winBeep.Play();

                Form1.level++;
                Form1.ChangeScreen(this, new TransitionScreen("won"));
            }
            else
            {
                Form1.deaths++;
                Form1.ChangeScreen(this, new TransitionScreen("died"));
            }
        }
    }
}
