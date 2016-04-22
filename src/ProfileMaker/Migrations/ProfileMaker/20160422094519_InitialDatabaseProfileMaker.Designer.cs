using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ProfileMaker.Models;

namespace ProfileMaker.Migrations.ProfileMaker
{
    [DbContext(typeof(ProfileMakerContext))]
    [Migration("20160422094519_InitialDatabaseProfileMaker")]
    partial class InitialDatabaseProfileMaker
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProfileMaker.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int?>("ProfileUserId");

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime>("StopDate");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("ProfileMaker.Models.OtherCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int?>("ProfileUserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("ProfileMaker.Models.ProfileUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("CompanyName");

                    b.Property<string>("Country");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("PostNumber");

                    b.Property<string>("Summary");

                    b.Property<string>("UserImage");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("ProfileMaker.Models.ProjectExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int?>("ProfileUserId");

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime>("StopDate");

                    b.Property<string>("Summary");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("ProfileMaker.Models.TechnicalEnvironment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int?>("ProjectExperienceId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("ProfileMaker.Models.TechniqueArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int?>("ProfileUserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("ProfileMaker.Models.Education", b =>
                {
                    b.HasOne("ProfileMaker.Models.ProfileUser")
                        .WithMany()
                        .HasForeignKey("ProfileUserId");
                });

            modelBuilder.Entity("ProfileMaker.Models.OtherCourse", b =>
                {
                    b.HasOne("ProfileMaker.Models.ProfileUser")
                        .WithMany()
                        .HasForeignKey("ProfileUserId");
                });

            modelBuilder.Entity("ProfileMaker.Models.ProjectExperience", b =>
                {
                    b.HasOne("ProfileMaker.Models.ProfileUser")
                        .WithMany()
                        .HasForeignKey("ProfileUserId");
                });

            modelBuilder.Entity("ProfileMaker.Models.TechnicalEnvironment", b =>
                {
                    b.HasOne("ProfileMaker.Models.ProjectExperience")
                        .WithMany()
                        .HasForeignKey("ProjectExperienceId");
                });

            modelBuilder.Entity("ProfileMaker.Models.TechniqueArea", b =>
                {
                    b.HasOne("ProfileMaker.Models.ProfileUser")
                        .WithMany()
                        .HasForeignKey("ProfileUserId");
                });
        }
    }
}
