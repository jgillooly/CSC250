// See https://aka.ms/new-console-template for more information
using CSC250;
Console.WriteLine("Enter a number for n");
string? line = Console.ReadLine();
int number = (line != null) ? int.Parse(line) : 1;
//change guardrail parameter to false for n values above 14
Queens.FindSolutions(number, true);
var solutions = Queens.solutions;
//change verbose parameter to false to only print total number
Queens.PrintBoards(solutions.Distinct(), false);