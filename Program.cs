using EFCorePostgreSQL.Models;
using EFCorePostgreSQL.Models.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Config Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Config PostgreSQL Connection
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/product/", async (DataContext db) => await db.products.ToListAsync());

app.MapGet("/product/{id}", async (DataContext db, int id) => await db.products.FindAsync(id));

app.MapPost("/product/insert/", async (DataContext db, Product addProduct) =>
{
    db.products.Add(addProduct);
    await db.SaveChangesAsync();

    return Results.Redirect("/product/");
});

app.MapPut("/product/edit/", async (DataContext db, Product EdditProduct) =>
{
    var dataedit = await db.products.FindAsync(EdditProduct.id);

    if (dataedit != null)
    {
        dataedit.name = EdditProduct.name;
        dataedit.category = EdditProduct.category;

        await db.SaveChangesAsync();

        return Results.Ok(await db.products.FindAsync(dataedit.id));
    }

    return Results.NotFound();
});

app.MapDelete("/product/delete/{id}", async (DataContext db, int id) =>
{
    var data = await db.products.FindAsync(id);

    if (data != null)
    {
        db.products.Remove(data);
        await db.SaveChangesAsync();

        return Results.Ok(await db.products.ToListAsync());
    }

    return Results.NotFound();
});

app.Run();

