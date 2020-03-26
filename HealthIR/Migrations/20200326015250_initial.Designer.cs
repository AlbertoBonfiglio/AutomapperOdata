﻿// <auto-generated />
using System;
using HealthIR.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HealthIR.Migrations
{
    [DbContext(typeof(HealthDbContext))]
    [Migration("20200326015250_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Benton.HealthIR.Models.Action", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Complete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("ReportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Type")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24)
                        .HasDefaultValue("IncidentAction");

                    b.HasKey("Id");

                    b.HasIndex("Complete");

                    b.HasIndex("Date");

                    b.HasIndex("ReportId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("Benton.HealthIR.Models.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("MediaType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("ReportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Benton.HealthIR.Models.EventType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Type")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24)
                        .HasDefaultValue("EventType");

                    b.HasKey("Id");

                    b.HasIndex("Deleted");

                    b.HasIndex("Type");

                    b.ToTable("EventTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("319ab0d2-fe70-4a06-aaa3-c9809b8f7b09"),
                            CreatedBy = "SYSTEM",
                            CreatedDate = new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 196, DateTimeKind.Unspecified).AddTicks(5720), new TimeSpan(0, -7, 0, 0, 0)),
                            Deleted = false,
                            Description = "",
                            Name = "Medication Error"
                        },
                        new
                        {
                            Id = new Guid("4f805c2a-2f98-46ec-a928-e718fa6adcaf"),
                            CreatedBy = "SYSTEM",
                            CreatedDate = new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 196, DateTimeKind.Unspecified).AddTicks(5807), new TimeSpan(0, -7, 0, 0, 0)),
                            Deleted = false,
                            Description = "",
                            Name = "Lab Error"
                        },
                        new
                        {
                            Id = new Guid("26de5c77-d0ec-455b-8764-b6422cc6fe71"),
                            CreatedBy = "SYSTEM",
                            CreatedDate = new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 196, DateTimeKind.Unspecified).AddTicks(5815), new TimeSpan(0, -7, 0, 0, 0)),
                            Deleted = false,
                            Description = "",
                            Name = "Medical Alert"
                        });
                });

            modelBuilder.Entity("Benton.HealthIR.Models.IncidentEventType", b =>
                {
                    b.Property<Guid>("ReportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReportId", "EventTypeId");

                    b.HasIndex("EventTypeId");

                    b.ToTable("IncidentEventType");
                });

            modelBuilder.Entity("Benton.HealthIR.Models.IncidentType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("IsCritical")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Type")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24)
                        .HasDefaultValue("IncidentType");

                    b.HasKey("Id");

                    b.HasIndex("Deleted");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Type");

                    b.ToTable("IncidentTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("03ab5e22-f2b7-409f-b9bc-6627cb36246b"),
                            CreatedBy = "SYSTEM",
                            CreatedDate = new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 182, DateTimeKind.Unspecified).AddTicks(6191), new TimeSpan(0, -7, 0, 0, 0)),
                            Deleted = false,
                            Description = "",
                            IsCritical = false,
                            Name = "Incident"
                        },
                        new
                        {
                            Id = new Guid("f01326f6-f5d3-4109-9f5e-ca62ecae498f"),
                            CreatedBy = "SYSTEM",
                            CreatedDate = new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 193, DateTimeKind.Unspecified).AddTicks(6392), new TimeSpan(0, -7, 0, 0, 0)),
                            Deleted = false,
                            Description = "",
                            IsCritical = false,
                            Name = "Near Miss"
                        });
                });

            modelBuilder.Entity("Benton.HealthIR.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Type")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24)
                        .HasDefaultValue("Location");

                    b.HasKey("Id");

                    b.HasIndex("Deleted");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Type");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("29be4b00-82a7-4542-9ccc-71c2c55afca3"),
                            CreatedBy = "SYSTEM",
                            CreatedDate = new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 202, DateTimeKind.Unspecified).AddTicks(5351), new TimeSpan(0, -7, 0, 0, 0)),
                            Deleted = false,
                            Description = "",
                            Name = "BHC"
                        },
                        new
                        {
                            Id = new Guid("88c5b999-91be-4e3b-aa5d-0d013d51af25"),
                            CreatedBy = "SYSTEM",
                            CreatedDate = new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 202, DateTimeKind.Unspecified).AddTicks(5395), new TimeSpan(0, -7, 0, 0, 0)),
                            Deleted = false,
                            Description = "",
                            Name = "ELHC"
                        },
                        new
                        {
                            Id = new Guid("0827b871-cb71-4e2c-bd6b-91f04e19f5be"),
                            CreatedBy = "SYSTEM",
                            CreatedDate = new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 202, DateTimeKind.Unspecified).AddTicks(5403), new TimeSpan(0, -7, 0, 0, 0)),
                            Deleted = false,
                            Description = "",
                            Name = "LHC"
                        },
                        new
                        {
                            Id = new Guid("1e5f0070-2bc0-4f26-9baf-b8b420d7d025"),
                            CreatedBy = "SYSTEM",
                            CreatedDate = new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 202, DateTimeKind.Unspecified).AddTicks(5410), new TimeSpan(0, -7, 0, 0, 0)),
                            Deleted = false,
                            Description = "",
                            Name = "MHC"
                        },
                        new
                        {
                            Id = new Guid("6005c635-f9c2-474d-bbc2-1886f6fd4872"),
                            CreatedBy = "SYSTEM",
                            CreatedDate = new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 202, DateTimeKind.Unspecified).AddTicks(5416), new TimeSpan(0, -7, 0, 0, 0)),
                            Deleted = false,
                            Description = "",
                            Name = "AHC"
                        },
                        new
                        {
                            Id = new Guid("24eb134d-a990-41ce-b601-aa741d748399"),
                            CreatedBy = "SYSTEM",
                            CreatedDate = new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 202, DateTimeKind.Unspecified).AddTicks(5423), new TimeSpan(0, -7, 0, 0, 0)),
                            Deleted = false,
                            Description = "",
                            Name = "SHHC"
                        },
                        new
                        {
                            Id = new Guid("3ec90d4a-0d4b-4773-a092-3ba699c9742b"),
                            CreatedBy = "SYSTEM",
                            CreatedDate = new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 202, DateTimeKind.Unspecified).AddTicks(5429), new TimeSpan(0, -7, 0, 0, 0)),
                            Deleted = false,
                            Description = "",
                            Name = "SUNSET"
                        });
                });

            modelBuilder.Entity("Benton.HealthIR.Models.PersonType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Type")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24)
                        .HasDefaultValue("PersonType");

                    b.HasKey("Id");

                    b.HasIndex("Deleted");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Type");

                    b.ToTable("PersonTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e61d2dc9-3824-4376-a561-2e6350817f58"),
                            CreatedBy = "SYSTEM",
                            CreatedDate = new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 198, DateTimeKind.Unspecified).AddTicks(2684), new TimeSpan(0, -7, 0, 0, 0)),
                            Deleted = false,
                            Description = "",
                            Name = "Employee"
                        },
                        new
                        {
                            Id = new Guid("c1a8a91c-7606-40e2-9291-4b7a1a6b23cc"),
                            CreatedBy = "SYSTEM",
                            CreatedDate = new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 198, DateTimeKind.Unspecified).AddTicks(2751), new TimeSpan(0, -7, 0, 0, 0)),
                            Deleted = false,
                            Description = "",
                            Name = "Visitor"
                        },
                        new
                        {
                            Id = new Guid("e0a12ab9-3aa1-4ace-9ebb-0b8a5f52276f"),
                            CreatedBy = "SYSTEM",
                            CreatedDate = new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 198, DateTimeKind.Unspecified).AddTicks(2760), new TimeSpan(0, -7, 0, 0, 0)),
                            Deleted = false,
                            Description = "",
                            Name = "Client/Patient"
                        });
                });

            modelBuilder.Entity("Benton.HealthIR.Models.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<bool>("Finalized")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<Guid>("IncidentTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MRN")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("PersonTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24)
                        .HasDefaultValue("IncidentReport");

                    b.HasKey("Id");

                    b.HasIndex("Date");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("IncidentTypeId");

                    b.HasIndex("LocationId");

                    b.HasIndex("PersonTypeId");

                    b.ToTable("Incidents");
                });

            modelBuilder.Entity("Benton.HealthIR.Models.Settings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Type")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24)
                        .HasDefaultValue("JSONSetting");

                    b.Property<string>("document")
                        .IsRequired()
                        .HasColumnName("JSONDocument")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Deleted");

                    b.HasIndex("Type");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4a478f30-00bd-4172-aa58-3ed61ddcbc7f"),
                            CreatedBy = "SYSTEM",
                            CreatedDate = new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 356, DateTimeKind.Unspecified).AddTicks(1417), new TimeSpan(0, -7, 0, 0, 0)),
                            Deleted = false,
                            Type = "HIRConfiguration",
                            document = @"{
  ""complianceManager"": ""Korey_Rempel24@gmail.com"",
  ""himManager"": ""America.Huel51@gmail.com"",
  ""safetyCoordinator"": ""Lea.Kulas18@hotmail.com"",
  ""financeDirector"": ""Maggie.Denesik@gmail.com"",
  ""countyCouncil"": ""Kelvin84@gmail.com""
}"
                        });
                });

            modelBuilder.Entity("Benton.HealthIR.Models.Action", b =>
                {
                    b.HasOne("Benton.HealthIR.Models.Report", "Report")
                        .WithMany("Actions")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Benton.HealthIR.Models.Attachment", b =>
                {
                    b.HasOne("Benton.HealthIR.Models.Report", "Report")
                        .WithMany("Attachments")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Benton.HealthIR.Models.IncidentEventType", b =>
                {
                    b.HasOne("Benton.HealthIR.Models.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Benton.HealthIR.Models.Report", "Report")
                        .WithMany("IncidentEventTypes")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Benton.HealthIR.Models.Report", b =>
                {
                    b.HasOne("Benton.HealthIR.Models.IncidentType", "IncidentType")
                        .WithMany()
                        .HasForeignKey("IncidentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Benton.HealthIR.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Benton.HealthIR.Models.PersonType", "PersonType")
                        .WithMany()
                        .HasForeignKey("PersonTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
