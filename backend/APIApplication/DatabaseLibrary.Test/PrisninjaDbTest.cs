using System;
using System.Threading.Tasks;
using ApiApplication.Database;
using ApiApplication.Database.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace DatabaseLibrary.Test;

public class PrisninjaDbTest
{
    private PrisninjaDb uut;
    
    [SetUp]
    public void Setup()
    {
        uut = new PrisninjaDb(GetDbContext());
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
    
    private PrisninjaDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<PrisninjaDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var context = new PrisninjaDbContext(options);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        
        return context;
    }
}