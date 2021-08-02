using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using System.Drawing;

namespace TrappedKnight
{
    class Visualisation
    {
        private Simulation simulation;

        private int screenWidth;
        private int screenHeight;
        
        private Surface video;

        private SdlDotNet.Graphics.Font font;

        private float seconds;

        private float delay;

        private bool showGrid = true;
        private bool showNumbers = false;

        private bool finished = false;

        public Visualisation(Simulation simulation, int screenWidth, int screenHeight)
        {
            this.simulation = simulation;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            font = new SdlDotNet.Graphics.Font("C:\\Windows\\Fonts\\ARIAL.TTF", 12);
        }

        public void Run(float delay)
        {
            this.delay = delay;
            seconds = 0;

            video = Video.SetVideoMode(screenWidth, screenHeight, 32, false);

            Events.Tick += Events_Tick;
            Events.Quit += Events_Quit;

            Events.KeyboardDown += Events_KeyboardDown;

            Events.Run();
        }

        private void Events_KeyboardDown(object sender, SdlDotNet.Input.KeyboardEventArgs e)
        {
            switch(e.Key)
            {
                case SdlDotNet.Input.Key.G:
                    showGrid = !showGrid;
                    break;
                case SdlDotNet.Input.Key.N:
                    showNumbers = !showNumbers;
                    break;
            }
        }

        private void Events_Quit(object sender, QuitEventArgs e)
        {
            Events.QuitApplication();
        }

        private void Events_Tick(object sender, TickEventArgs e)
        {
            video.Fill(Color.Black);

            simulation.Calculate();

            int sx = screenWidth / simulation.GridWidth;
            int sy = screenHeight / simulation.GridHeight;

            // draw grid
            if (showGrid)
            {
                for (int x = 0; x < simulation.GridWidth; x++)
                {
                    video.Draw(new Line(new Point(x * sx, 0), new Point(x * sx, screenHeight)), Color.FromArgb(0xC0, 0xC0, 0xC0));
                }
                for (int y = 0; y < simulation.GridHeight; y++)
                {
                    video.Draw(new Line(new Point(0, y * sy), new Point(screenWidth, y * sy)), Color.FromArgb(0xC0, 0xC0, 0xC0));
                }
            }

            if (!finished)
            {
                // draw knight
                video.Draw(new Box(new Point(simulation.Knight.X * sx, simulation.Knight.Y * sy), new Size(sx, sy)), Color.Red, false, true);

                // draw moves
                video.Draw(new Box(new Point(simulation.NextMove.X * sx, simulation.NextMove.Y * sy), new Size(sx, sy)), Color.Green, false, true);
                for (int c = 0; c < simulation.Moves.GetLength(0); c++)
                {
                    video.Draw(new Line(new Point((simulation.Knight.X * sx) + (sx / 2), (simulation.Knight.Y * sy) + (sx / 2)), new Point((simulation.Moves[c].X * sx) + (sx / 2), (simulation.Moves[c].Y * sy) + (sx / 2))), Color.Magenta);
                }
            }

            // draw grid numbers
            if (showNumbers)
            {
                for (int x = 0; x < simulation.GridWidth; x++)
                {
                    for (int y = 0; y < simulation.GridHeight; y++)
                    {
                        video.Blit(font.Render($"{simulation.Grid[x, y]}", Color.White, false), new Point((x * sx) + (sx / 2), (y * sy) + (sy / 2)));
                    }
                }
            }

            // draw history
            if (simulation.History.Count > 1)
            {
                float step = 255f / (float)(simulation.History.Count);
                float offset = 255;
                Color c = Color.FromArgb((int)offset, 255, 0);
                for (int h = simulation.History.Count-1; h > 0; h--)
                {
                    video.Draw(new Line(new Point((simulation.History[h].X * sx) + (sx / 2), (simulation.History[h].Y * sy) + (sy / 2)), new Point((simulation.History[h-1].X * sx) + (sx / 2), (simulation.History[h-1].Y * sy) + (sy / 2))), c);
                    c = Color.FromArgb((int)offset, 255, 0);
                    offset -= step;
                }
            }

            video.Update();

            seconds += e.SecondsElapsed;

            if (seconds > delay)
            {
                if (simulation.Step())
                {
                    finished = true;
                }
                seconds -= delay;

                Video.WindowCaption = $"Trapped Knight : {simulation.Steps}";
            }
        }

    }
}
