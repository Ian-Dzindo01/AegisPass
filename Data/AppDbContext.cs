using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        string appFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "AegisPass");

        Directory.CreateDirectory(appFolder);

        string dbPath = Path.Combine(appFolder, "users.db");

        options.UseSqlite($"Data Source={dbPath}");
    }
}