using Microsoft.EntityFrameworkCore;
using Peter_Darius_Lab2.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<Peter_Darius_Lab2Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Peter_Darius_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Peter_Darius_Lab2Context' not found.")));

var app = builder.Build();

// aplica automat migrarile (creeaza tabelele) la pornire
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<Peter_Darius_Lab2Context>();
    if (db.Database.GetMigrations().Any())
        db.Database.Migrate();
    else
        db.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
