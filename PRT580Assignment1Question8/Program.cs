// See https://aka.ms/new-console-template for more information
using PRT580Assignment1Question8;

var x = "1011010111";
var y = "1010101010101011111111";

Console.WriteLine($"Finding the product of {x} and {y}");

var logic = new BinaryOperationMethods();
var result = logic.ProductOf(x.ToBinary(), y.ToBinary());

Console.WriteLine($"Product was {result.ToReadableBinary()}");
