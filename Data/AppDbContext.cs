using AegisPass.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        string dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "AegisPass",
            "users.db");

        Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);

        options.UseSqlite($"Data Source={dbPath}");
    }
}
