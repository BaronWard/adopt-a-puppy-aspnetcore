using adopt_a_puppy_aspnetcore.Repositories;
using adopt_a_puppy_aspnetcore.Repositories.Interfaces;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                              "http://adopt-a-puppy-testapp.s3-website-ap-southeast-1.amazonaws.com"
                              //Add your localhost url if it is different from above
                              );
                      });
});

// Add services to the container.

builder.Services.AddControllers();

//Add Repository Services
builder.Services.AddScoped<IPuppyRepository, PuppyRepository>();
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

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
