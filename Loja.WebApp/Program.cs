using Loja.WebApp;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o Startup explicitamente
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Chama o Configure do Startup de forma segura
var startupInstance = new Startup(builder.Configuration);
startupInstance.Configure(app, app.Environment);

app.Run();