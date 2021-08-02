using System.Drawing;

namespace TrappedKnight
{
    class GreenYellowColourChooser : IColourChooser
    {
        private float step = 0f;
        private float offset = 0f;

        public void Init(int colours)
        {
            step = 255f / (float)colours;
            offset = 255;
        }

        public Color NextColour()
        {
            float lastOffset = offset;
            offset -= step;
            return Color.FromArgb((int)lastOffset, 255, 0);
        }
    }
}
