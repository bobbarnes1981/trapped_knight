using System;
using System.Drawing;

namespace TrappedKnight
{
    class ColourChooser : IColourChooser
    {
        private float step = 0f;
        private float offset = 0f;

        public void Init(int colours)
        {
            step = 511f / (float)colours;
            offset = 511;
        }

        public Color NextColour()
        {
            float lastOffset = offset;
            offset -= step;

            int red = Math.Max((int)lastOffset - 256, 0);
            int green = Math.Min((int)lastOffset, 255);
            int blue = 255 - red;

//            return Color.FromArgb(blue, green, red);
            return Color.FromArgb(red, green, blue);
        }
    }
}
