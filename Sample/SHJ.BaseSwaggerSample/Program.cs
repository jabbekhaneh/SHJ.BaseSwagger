using SHJ.BaseSwagger;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();



builder.Services.RegisterSwagger(options =>
{
    options.ProjectName = "*** TEST API VERSIONING ***";
});

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.RegisterUseSwaggerAndUI();

}


app.UseRouting();

app.MapControllers();

app.Run();
