using System.CommandLine.Invocation;
using StorageSync.Services;
namespace StorageSync.Commands;

public static class Commands
{
    public static RootCommand GetRootCommand()
    {
        var path = new Argument<string>("--path", () => Directory.GetCurrentDirectory(), "The working directory to use. Defaults to current directory.");

        var rootCommand = new RootCommand
        {
            path
        };
        rootCommand.SetHandler<string>(ProcessRootCommand, path);
        rootCommand.AddCommand(GetInitCommand());
        rootCommand.AddCommand(GetWatchCommand());
        return rootCommand;
    }

    private static async Task ProcessRootCommand(string path)
    {
        await Task.FromResult(0);
        Console.WriteLine($"Path: {path}");
        var orchestrationService = new OrchestrationService();
        orchestrationService.Do(path);
    }

    private static Command GetInitCommand()
    {
        var force = new Option<bool>("--force", () => false, "Overwrite existing configuration.");
        var command = new Command("init", "Initialize the current working directory for StorageSync.");
        command.AddOption(force);
        command.SetHandler<bool>(ProcessInitCommand, force);
        return command;
    }

    private static async Task ProcessInitCommand(bool force)
    {
        await Task.FromResult(0);
        Console.WriteLine($"Force: {force}");
    }

    private static Command GetWatchCommand()
    {
        var path = new Argument<string>("--path", () => Directory.GetCurrentDirectory(), "The working directory to use. Defaults to current directory.");
        var command = new Command("watch", "Run StorageSync in watch mode on the current working directory.");
        command.AddArgument(path);
        command.SetHandler(ProcessWatchCommand);
        return command;
    }

    private static async Task ProcessWatchCommand()
    {
        await Task.FromResult(0);
    }

}

