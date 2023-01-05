using GOLconsole.Source;

internal class Program
{
    private static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        
        Grid grid = new Grid(10, 10);
        
        grid.Initialize();
        
        while(true)
        {
            Console.WriteLine(grid.ToString());
            grid.NextState();
            Console.ReadLine();
            Console.Clear();
        }
    }
}