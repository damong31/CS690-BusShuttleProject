namespace BusShuttle;


using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Select Mode (Driver or Manager): ");
        string mode = Console.ReadLine();

        if(mode == "Driver")  {
            
            string command;

            do {
                
                Console.Write("Enter Stop Name: ");

                Console.Write("Enter number of boarded passengers: ");
                int boarded = int.Parse(Console.ReadLine());

                File.AppendAllText("passenger-data.txt" ,stopName+":"+boarded+Environment.NewLine);

                Console.Write("Enter Command (end OR continue): ");
                command = Console.ReadLine();




        } while(command!="end");
    }
}
