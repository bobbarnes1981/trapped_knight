using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrappedKnight
{
    class Program
    {
        static void Main(string[] args)
        {
            new Visualisation(new Simulation(61, 61), 610, 610).Run(0.01f);
        }

    }
}
