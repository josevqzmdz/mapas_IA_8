using static mapas_IA_8.nodo;
using static mapas_IA_8.JSONParser;
using mapas_IA_8;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http.Cors;
using System.Web.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};


app.MapGet("/weatherforecast", (string origin) =>
{
    try
    {
        mapas_IA_8.nodo aquila = new mapas_IA_8.nodo("aquila");
    mapas_IA_8.nodo maruata = new mapas_IA_8.nodo("maruata");
    mapas_IA_8.nodo tepalcatepec = new mapas_IA_8.nodo("tepalcatepec");
    mapas_IA_8.nodo apatzingan = new mapas_IA_8.nodo("apatzingan");
    mapas_IA_8.nodo nueva_italia = new mapas_IA_8.nodo("nueva italia");
    mapas_IA_8.nodo lazaro_cardenas = new mapas_IA_8.nodo("lazaro cardenas");
    mapas_IA_8.nodo los_reyes = new mapas_IA_8.nodo("los reyes");
    mapas_IA_8.nodo uruapan = new mapas_IA_8.nodo("uruapan");
    mapas_IA_8.nodo sahuayo = new mapas_IA_8.nodo("sahuayo");
    mapas_IA_8.nodo zamora = new mapas_IA_8.nodo("zamora");
    mapas_IA_8.nodo zacapu = new mapas_IA_8.nodo("zacapu");
    mapas_IA_8.nodo patzcuaro = new mapas_IA_8.nodo("patzcuaro");
    mapas_IA_8.nodo morelia = new mapas_IA_8.nodo("morelia");
    mapas_IA_8.nodo cd_hidalgo = new mapas_IA_8.nodo("ciudad hidalgo");

    mapas_IA_8.nodo.SetVecinos(aquila, maruata, 2); //
    mapas_IA_8.nodo.SetVecinos(aquila, tepalcatepec, 3); //
    mapas_IA_8.nodo.SetVecinos(maruata, lazaro_cardenas, 3);//
    mapas_IA_8.nodo.SetVecinos(lazaro_cardenas, nueva_italia, 5); //
    mapas_IA_8.nodo.SetVecinos(nueva_italia, apatzingan, 5); //
    mapas_IA_8.nodo.SetVecinos(nueva_italia, patzcuaro, 3); //
    mapas_IA_8.nodo.SetVecinos(apatzingan, tepalcatepec, 3); //
    mapas_IA_8.nodo.SetVecinos(apatzingan, uruapan, 3); //
    mapas_IA_8.nodo.SetVecinos(tepalcatepec, los_reyes, 3); //
    mapas_IA_8.nodo.SetVecinos(los_reyes, sahuayo, 2); //
    mapas_IA_8.nodo.SetVecinos(los_reyes, uruapan, 3); //
    mapas_IA_8.nodo.SetVecinos(uruapan, zamora, 2); //
    mapas_IA_8.nodo.SetVecinos(sahuayo, zamora, 3); //
    mapas_IA_8.nodo.SetVecinos(zamora, zacapu, 4); //
    mapas_IA_8.nodo.SetVecinos(zacapu, patzcuaro, 2); //
    mapas_IA_8.nodo.SetVecinos(zacapu, morelia, 2); //
    mapas_IA_8.nodo.SetVecinos(patzcuaro, morelia, 2); //
    mapas_IA_8.nodo.SetVecinos(morelia, cd_hidalgo, 3); //

    // maldito CORS
    string _MyCors = "MyCors";
    string url = "http://127.0.0.1:5173/";

    // https://www.youtube.com/watch?v=KK7fJTXxeeE
    IServiceCollection services = new ServiceCollection();
    services.AddCors(options =>
    {
        options.AddPolicy(name: _MyCors, builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
    });

    app.UseCors(_MyCors);

    List<mapas_IA_8.nodo> list = new List<mapas_IA_8.nodo>
       {
        aquila, maruata, tepalcatepec, apatzingan, nueva_italia, lazaro_cardenas, los_reyes, uruapan, 
        sahuayo, zamora, zacapu, patzcuaro, morelia, cd_hidalgo,
       };

    
        // https://learn.microsoft.com/en-us/previous-versions/aspnet/hh833997(v=vs.118)
        // https://stackoverflow.com/questions/27504256/mvc-web-api-no-access-control-allow-origin-header-is-present-on-the-requested
        HttpConfiguration config = new HttpConfiguration();
        var cors = new EnableCorsAttribute(url, "*", "*");
        config.EnableCors(cors);

        foreach (var ciudad in list)
        {
            if (origin.ToString() == ciudad.nombre)
            {
                //https://stackoverflow.com/questions/1619518/a-dictionary-where-value-is-an-anonymous-type-in-c-sharp

                var city = ciudad.busquedaProfundidad().Select(
                    eje => new
                    {
                        weight = eje.Item3,
                        id = eje.Item1.nombre + " " + eje.Item2.nombre
                    });
                return city;
            }
        }// fin foreach
    }
    catch(Exception e)
    {
        Console.WriteLine(e.ToString());
    }
    

    //JSONParser json = new JSONParser(ser);
    //json.postHtml();
    return null;
})
.WithName("mapas");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}



