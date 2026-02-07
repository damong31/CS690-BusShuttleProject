using System.ComponentModel.Design;
using Spectre.Console;

namespace BusShuttle;

public class ConsoleUI  {
    FileSaver fileSaver;

    List<Loop> loops;

    List<Stop> stops;

    List<Driver> drivers;

    public ConsoleUI() {
        this.fileSaver = new FileSaver("passenger-data.txt");

        loops = new List<Loop>();
        loops.Add(new Loop("Red"));
        loops.Add(new Loop("Blue"));
        loops.Add(new Loop("Green"));


        stops = new List<Stop>();
        stops.Add(new Stop("Music"));
        stops.Add(new Stop("Tower"));
        stops.Add(new Stop("Oakwood"));
        stops.Add(new Stop("Anthony"));
        stops.Add(new Stop("Letterman"));

        loops[0].Stops.Add(stops[0]);
        loops[0].Stops.Add(stops[1]);
        loops[0].Stops.Add(stops[2]);
        loops[0].Stops.Add(stops[3]);
        loops[0].Stops.Add(stops[4]);


        drivers = new List<Driver>();
        drivers.Add(new Driver("Jane Doe"));
        drivers.Add(new Driver("John Doe"));


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


            var selectedDriver = AnsiConsole.Prompt(
            new SelectionPrompt<Driver>()
            .Title("Select a driver")
            .AddChoices(drivers)
        );
        Console.WriteLine("You are driving as "+selectedDriver.Name);
        

            Loop selectedLoop = AnsiConsole.Prompt(
            new SelectionPrompt<Loop>()
            .Title("Select Loop")
            .AddChoices(loops)
        );
        Console.WriteLine("You selected "+selectedLoop.Name+" Loop");
            
            string command;

            do {
                
                

                Stop selectedStop = AnsiConsole.Prompt(
                        new SelectionPrompt<Stop>()
                        .Title("Select Stop")
                        .AddChoices(selectedLoop.Stops)
                    );

                Console.WriteLine("You selected "+selectedStop.Name+" Stop");

                
                int boarded = int.Parse(AskForInput("Enter number of boarded passengers: "));

                PassengerData data = new PassengerData(boarded, selectedStop, selectedLoop, selectedDriver);

                fileSaver.AppendData(data);

                
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