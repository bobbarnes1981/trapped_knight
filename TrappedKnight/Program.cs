namespace TrappedKnight
{
    class Program
    {
        static void Main(string[] args)
        {
            new Visualisation(new Simulation(61, 61, new AntiClockwiseGridGenerator(), new KnightMoveGenerator(), new LowestUnusedValueMoveFilter()), 610, 610, new PurpleCyanYellowColourChooser()).Run(0.01f);
        }
    }
}
