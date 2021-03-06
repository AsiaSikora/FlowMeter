// <auto-generated />
using System;
using FlowMeter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlowMeter.Data.Migrations
{
    [DbContext(typeof(FlowMeterDbContext))]
    [Migration("20220214151602_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlowMeter.Domain.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeviceNumber")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("FlowMeter.Domain.Localization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CanalRadius")
                        .HasColumnType("float");

                    b.Property<decimal?>("GpsCoordinate1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("GpsCoordinate2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Localizations");
                });

            modelBuilder.Entity("FlowMeter.Domain.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("AverageFlow")
                        .HasColumnType("float");

                    b.Property<string>("Battery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("CurrentFlow")
                        .HasColumnType("float");

                    b.Property<bool>("IsSpecialPoint")
                        .HasColumnType("bit");

                    b.Property<double?>("MedianFlow")
                        .HasColumnType("float");

                    b.Property<double?>("Pressure")
                        .HasColumnType("float");

                    b.Property<int>("SurveyId")
                        .HasColumnType("int");

                    b.Property<double?>("Temperature")
                        .HasColumnType("float");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("FlowMeter.Domain.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<int?>("LocalizationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("LocalizationId");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("FlowMeter.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FlowMeter.Domain.Device", b =>
                {
                    b.HasOne("FlowMeter.Domain.User", "User")
                        .WithMany("Devices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlowMeter.Domain.Measurement", b =>
                {
                    b.HasOne("FlowMeter.Domain.Survey", "Survey")
                        .WithMany("Measurements")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("FlowMeter.Domain.Survey", b =>
                {
                    b.HasOne("FlowMeter.Domain.Device", "Device")
                        .WithMany("Surveys")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlowMeter.Domain.Localization", null)
                        .WithMany("Surveys")
                        .HasForeignKey("LocalizationId");

                    b.Navigation("Device");
                });

            modelBuilder.Entity("FlowMeter.Domain.Device", b =>
                {
                    b.Navigation("Surveys");
                });

            modelBuilder.Entity("FlowMeter.Domain.Localization", b =>
                {
                    b.Navigation("Surveys");
                });

            modelBuilder.Entity("FlowMeter.Domain.Survey", b =>
                {
                    b.Navigation("Measurements");
                });

            modelBuilder.Entity("FlowMeter.Domain.User", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
