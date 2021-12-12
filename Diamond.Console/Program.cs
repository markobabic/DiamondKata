namespace Diamond.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Please enter a char (A-Z):");
            var seed = System.Console.ReadKey().KeyChar;

            var diamond = new Diamond();

            System.Console.WriteLine();

            foreach (var line in diamond.Generate(seed))
                System.Console.WriteLine(line);

            System.Console.ReadKey();
        }
    }
}
