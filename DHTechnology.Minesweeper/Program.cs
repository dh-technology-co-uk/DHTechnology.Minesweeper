var host = Host.CreateDefaultBuilder()
    .ConfigureServices(
        services =>
        {
            services.AddSingleton<IBoard, Board>();
            services.AddSingleton<IMineSweeper, MineSweeper>();
            services.AddSingleton<IApplication, Application>();
        }).Build();

var application = host.Services.GetRequiredService<IApplication>();


Console.WriteLine("Choose difficulty: Beginner, Advanced, or Expert");
var difficulty = Console.ReadLine();

try
{
    var game = application.InitializeGame(difficulty);
    game.Play();
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}