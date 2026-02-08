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

        } else if(mode=="Manager")
        {

            string command;

            do {
                
                
                command = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Make a selection")
                            .AddChoices(new[]
                            {
                                "Add Stop","Delete Stop","View Stops","end"
                            }
                            )
                            );

                if(command=="Add Stop")
                {
                var newStopName = AnsiConsole.Prompt(new TextPrompt<string>("Enter name of new stop: "));
                dataManager.AddStop(new Stop(newStopName));
                

                }
                
                else if(command=="Delete Stop")
                {
                    Stop selectedStop = AnsiConsole.Prompt(
                        new SelectionPrompt<Stop>()
                        .Title("Select Stop")
                        .AddChoices(dataManager.Stops)
                    );
                    dataManager.RemoveStop(selectedStop);
                   
                }
                
                else if(command=="View Stops")
                {
                    var table = new Table();

                    table.AddColumn("Stop Name");


                    foreach(var stop in dataManager.Stops)
                    {
                        table.AddRow(stop.Name);
                    }
                    AnsiConsole.Write(table);
                }



            } while(command!="end");
        }
    }
    

    public static string AskForInput(string message) {
        Console.Write(message);
        return Console.ReadLine();
    }



}