using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GrapsTrack.Models;
using Microsoft.AspNet.Identity.EntityFramework;

public class GrapsTrackDbContext : IdentityDbContext<User>
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public GrapsTrackDbContext() : base("name=GrapsTrackDbContext")
    {

    }

    public static GrapsTrackDbContext Create()
    {
        return new GrapsTrackDbContext();
    }

    public System.Data.Entity.DbSet<GrapsTrack.Models.Event> Events { get; set; }

    public System.Data.Entity.DbSet<GrapsTrack.Models.Performer> Performers { get; set; }

}
