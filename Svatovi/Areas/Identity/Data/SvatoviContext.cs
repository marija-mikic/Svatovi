﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Svatovi.Data;
using Svatovi.Models;

namespace Svatovi.Areas.Identity.Data;

public class SvatoviContext : DbContext
{
    

    public SvatoviContext(DbContextOptions<SvatoviContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
    public DbSet<SvatoviUser> Users { get; set; }
    public DbSet<Image> Datas { get; set; }
    public DbSet<ImageGallery> Gallerys { get; set; }


}