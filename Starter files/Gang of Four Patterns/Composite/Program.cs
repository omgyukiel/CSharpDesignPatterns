Console.Title = "Composite";


var root = new Composite.Directory("root", 0);
var topLevelFile = new Composite.File("toplevel.txt", 100);

var topLevelDirectory1 = new Composite.Directory("topleveldirectory1", 4);
var topLevelDirectory2 = new Composite.Directory("topleveldirectory2", 4);


root.Add(topLevelFile);
root.Add(topLevelDirectory1);
root.Add(topLevelDirectory2);


var subLevelFile1 = new Composite.File("sublevel1.txt", 200);
var subLevelFile2 = new Composite.File("sublevel2.txt", 300);

topLevelDirectory1.Add(subLevelFile1);
topLevelDirectory1.Add(subLevelFile2);


Console.WriteLine($"Size of {root.Name} is {root.GetSize()} bytes.");
Console.WriteLine($"Size of {topLevelDirectory1.Name} is {topLevelDirectory1.GetSize()} bytes.");
Console.WriteLine($"Size of {topLevelDirectory2.Name} is {topLevelDirectory2.GetSize()} bytes.");

Console.ReadKey();