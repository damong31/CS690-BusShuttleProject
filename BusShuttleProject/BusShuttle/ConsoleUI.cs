using System.ComponentModel.Design;
using Spectre.Console;

namespace BusShuttle;

public class ConsoleUI  {
    
    DataManager dataManager;

    

    public ConsoleUI() {
        

        dataManager = new DataManager();


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
            .AddChoices(dataManager.Drivers)
        );
        Console.WriteLine("You are driving as "+selectedDriver.Name);
        

            Loop selectedLoop = AnsiConsole.Prompt(
            new SelectionPrompt<Loop>()
            .Title("Select Loop")
            .AddChoices(dataManager.Loops)
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

                
                int boarded = AnsiConsole.Prompt(new TextPrompt<int>("Enter number of boarded passengers: "));


                PassengerData data = new PassengerData(boarded, selectedStop, selectedLoop, selectedDriver);

                
                
                dataManager.AddNewPassengerData(data);
                

                
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