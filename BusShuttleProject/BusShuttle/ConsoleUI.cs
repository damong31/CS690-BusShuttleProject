using Spectre.Console;

namespace BusShuttle;

public class ConsoleUI  {
    FileSaver fileSaver;

    public ConsoleUI() {
        this.fileSaver = new FileSaver("passenger-data.txt");
    }

    public void Show() {
    
        


        var mode = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select mode")
            .AddChoices(new[]
            {
                "Driver","Manager"
            }
            )
        );




        if(mode=="Driver")  {
            
            string command;

            do {
                
                
                string stopName = AskForInput("Enter Stop Name: ");

                
                int boarded = int.Parse(AskForInput("Enter number of boarded passengers: "));

                fileSaver.AppendLine(stopName+":"+boarded);

                
                command = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Make a selection")
                            .AddChoices(new[]
                            {
                                "continue","end"
                            }
                            )
        );




            } while(command!="end");
        }
    }
    

    public static string AskForInput(string message) {
        Console.Write(message);
        return Console.ReadLine();
    }



}