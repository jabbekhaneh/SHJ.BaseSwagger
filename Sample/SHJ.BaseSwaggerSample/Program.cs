using Microsoft.AspNetCore.Authentication;
using SHJ.BaseSwagger;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddAuthentication("Bearer")
          .AddJwtBearer("Bearer", options =>
          {
              
              
          });
builder.Services.AddAuthorization(options =>
{

});

builder.Services.RegisterSwagger(options =>
{
    options.DocumentName = "*** TEST API VERSIONING ***";
    
});

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.RegisterUseSwaggerAndUI();

}
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
