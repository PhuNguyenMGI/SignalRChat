using Microsoft.EntityFrameworkCore;
using SignalRChat.Data;
using SignalRChat.Hubs;
using Swashbuckle.AspNetCore.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(o => o.AddPolicy("Policy", builder => {
    builder.WithOrigins("http://localhost:3000")
      .AllowAnyMethod()
      .SetIsOriginAllowed((host) => true)
      .AllowAnyHeader()
      .AllowCredentials();
}));
builder.Services.AddSpaStaticFiles(options => options.RootPath = "SignalRClientApp/dist");
builder.Services.AddSignalR();

var app = builder.Build();

app.UseDefaultFiles();
app.UseCors("Policy");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSpaStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapHub<ChatHub>("/hubs/general");

var users = app.MapGroup("/api/users");
//var groups = app.MapGroup("/api/groups");

app.MapGet("/login", UsersServices.LoginRequest);
app.MapGet("/user/{groupId}", UsersServices.GetUsersByGroup);
app.MapGet("/{id}", UsersServices.GetUserById);
app.MapPost("/loginData", UsersServices.InsertUser);
app.MapPut("/{id}", UsersServices.UpdateUser);
app.MapDelete("/{id}", UsersServices.DeleteUser);

// app.MapGet("/", GroupsServices.GetAllGroups);
// app.MapGet("/{id}", GroupsServices.GetGroupById);
// app.MapPost("/", GroupsServices.InsertGroup);
// app.MapPut("/{id}", GroupsServices.UpdateGroup);
// app.MapDelete("/{id}", GroupsServices.DeleteGroup);

app.Run();
