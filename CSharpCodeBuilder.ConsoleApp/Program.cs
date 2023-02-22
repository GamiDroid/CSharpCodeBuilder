using CSharpCodeBuilder;

var sourceBuilder = new SourceBuilder("MyCoolNamespace");

var sourceString = sourceBuilder
    .AddHeaderComment(" <generated-code/>")
    .AddUsings("System", "System.Collection.Generic")
    .AddUsings("System.Text.Json", "System.Collection.Generic")
    .AddClass(new ClassSyntax("Class1") { AccessModifiers = AccessModifier.Public })
    .ToString();

Console.WriteLine(sourceString);

Console.WriteLine();
Console.WriteLine("End of program. Press any key to exit.");
Console.ReadKey();