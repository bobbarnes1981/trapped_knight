using System;
using System.Drawing;

namespace TrappedKnight
{
    class PurpleCyanYellowColourChooser : IColourChooser
    {
        private float step = 0f;
        private float offset = 0f;
        private float max = 255f;

        public void Init(int colours)
        {
            step = 3*max / (float)colours;
            offset = 3*max;
        }

        public Color NextColour()
        {
            float lastOffset = offset;
            offset -= step;

            int red = 0;
            int green = 0;
            int blue = 0;
            switch ((int)offset / (int)max)
            {
                case 0:
                    // r b
                    red = (int)max - (int)offset;
                    green = 0;
                    blue = (int)max;
                    break;
                case 1:
                    //  gb
                    red = 0;
                    green = (int)offset - (int)max;
                    blue = (int)max;
                    break;
                case 2:
                    // rg
                    red = (int)offset - ((int)max * 2);
                    green = (int)max;
                    blue = (int)max - red;
                    break;
            }

            return Color.FromArgb(red, green, blue);
        }
    }
}
