using Azure.Data.Tables;
using Azure.Storage.Blobs;
using Azure.Storage.Files.Shares;
using Azure.Storage.Queues;
using Microsoft.AspNetCore.Http.Features;
using Shaun_Faulkner_ST10034664_CLDV6212_POE.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton(x => new BlobServiceClient(builder.Configuration["AzureStorage:BlobConnectionString"]));
builder.Services.AddSingleton(x => new TableServiceClient(builder.Configuration["AzureStorage:TableConnectionString"]));
builder.Services.AddSingleton(x => new QueueServiceClient(builder.Configuration["AzureStorage:QueueConnectionString"]));
builder.Services.AddSingleton(x => new ShareServiceClient(builder.Configuration["AzureStorage:FileConnectionString"]));

builder.Services.AddScoped<IBlobStorageService, BlobStorageService>();
builder.Services.AddScoped<ITableStorageService, TableStorageService>();
builder.Services.AddScoped<IQueueStorageService, QueueStorageService>();
builder.Services.AddScoped<IFileShareService, FileShareService>();

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 10485760;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
