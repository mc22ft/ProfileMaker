using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ProfileMaker.Models;

namespace ProfileMaker.Migrations
{
    [DbContext(typeof(WorldContext))]
    [Migration("20160415134630_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProfileMaker.Models.Stop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Arrival");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int?>("Tripid");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("ProfileMaker.Models.Trip", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name");

                    b.Property<string>("UserName");

                    b.HasKey("id");
                });

            modelBuilder.Entity("ProfileMaker.Models.Stop", b =>
                {
                    b.HasOne("ProfileMaker.Models.Trip")
                        .WithMany()
                        .HasForeignKey("Tripid");
                });
        }
    }
}
