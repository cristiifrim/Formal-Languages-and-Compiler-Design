using ConsoleApp1.Models;

var identifierTable = new SymbolTable(128);
var constantTable = new SymbolTable(128);

identifierTable.AddSymbol("a");
Console.WriteLine("Position of a: " + identifierTable.GetByKey("a"));

identifierTable.AddSymbol("b");
Console.WriteLine("Key: " + identifierTable.GetPair("b")?.Key ?? "Not found" + ", Position: " + identifierTable.GetPair("b")?.Value ?? "Not found");

constantTable.AddSymbol(5);
Console.WriteLine("Position of 5:" + constantTable.GetByKey(5));

Console.WriteLine("Identifier Table size: " + identifierTable.Capacity);
Console.WriteLine("Constant Table size: " + constantTable.Capacity);