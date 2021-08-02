using System.Drawing;

namespace TrappedKnight
{
    interface IColourChooser
    {
        void Init(int colours);
        Color NextColour();
    }
}
