namespace BusShuttle;

public class ConsoleUI  {
    FileSaver fileSaver;

    public ConsoleUI() {
        this.fileSaver = new FileSaver("passenger-data.txt");
    }

    public void Show() {
       
    
        
        string mode = AskForInput("Select Mode (Driver or Manager): ");

        if(mode=="driver")  {
            
            string command;

            do {
                
                
                string stopName = AskForInput("Enter Stop Name: ");

                
                int boarded = int.Parse(AskForInput("Enter number of boarded passengers: "));

                fileSaver.AppendLine(stopName+":"+boarded);

                
                command = AskForInput("Enter Command (end OR continue): ");




            } while(command!="end");
        }
    }
    

    public static string AskForInput(string message) {
        Console.Write(message);
        return Console.ReadLine();
    }



}