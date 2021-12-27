global using System.CommandLine;
using StorageSync.Commands;

var rootCommand = Commands.GetRootCommand();
return await rootCommand.InvokeAsync(args);



