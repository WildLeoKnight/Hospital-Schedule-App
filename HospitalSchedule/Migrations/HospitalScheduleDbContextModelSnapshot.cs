﻿// <auto-generated />
using System;
using HospitalSchedule.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalSchedule.Migrations
{
    [DbContext(typeof(HospitalScheduleDbContext))]
    partial class HospitalScheduleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HospitalSchedule.Models.Nurse", b =>
                {
                    b.Property<int>("NurseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("CellPhoneNumber")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("IDCard")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("SpecialtyId");

                    b.Property<int>("Type");

                    b.Property<DateTime?>("YoungestChildBirthDate");

                    b.HasKey("NurseId");

                    b.HasIndex("SpecialtyId");

                    b.ToTable("Nurse");
                });

            modelBuilder.Entity("HospitalSchedule.Models.OperationBlock", b =>
                {
                    b.Property<int>("OperationBlockId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlockName")
                        .IsRequired();

                    b.HasKey("OperationBlockId");

                    b.ToTable("OperationBlock");
                });

            modelBuilder.Entity("HospitalSchedule.Models.OperationBlock_Shifts", b =>
                {
                    b.Property<int>("OperationBlock_ShiftsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OperationBlockId");

                    b.Property<int>("ShiftId");

                    b.HasKey("OperationBlock_ShiftsId");

                    b.HasIndex("OperationBlockId");

                    b.HasIndex("ShiftId");

                    b.ToTable("OperationBlock_Shifts");
                });

            modelBuilder.Entity("HospitalSchedule.Models.Rules", b =>
                {
                    b.Property<int>("RulesId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChildAge");

                    b.Property<string>("InBetweenShiftTime")
                        .IsRequired();

                    b.Property<int>("NurseAge");

                    b.Property<string>("RulesName")
                        .IsRequired();

                    b.Property<int>("WeeklyHours");

                    b.HasKey("RulesId");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("HospitalSchedule.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("NurseId");

                    b.Property<int>("OperationBlock_ShiftsId");

                    b.HasKey("ScheduleId");

                    b.HasIndex("NurseId");

                    b.HasIndex("OperationBlock_ShiftsId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("HospitalSchedule.Models.Shift", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Duration")
                        .IsRequired();

                    b.Property<string>("ShiftName")
                        .IsRequired();

                    b.Property<string>("StartingHour")
                        .IsRequired();

                    b.HasKey("ShiftId");

                    b.ToTable("Shift");
                });

            modelBuilder.Entity("HospitalSchedule.Models.Specialty", b =>
                {
                    b.Property<int>("SpecialtyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("SpecialtyId");

                    b.ToTable("Specialty");
                });

            modelBuilder.Entity("HospitalSchedule.Models.Nurse", b =>
                {
                    b.HasOne("HospitalSchedule.Models.Specialty", "Specialty")
                        .WithMany("Nurses")
                        .HasForeignKey("SpecialtyId");
                });

            modelBuilder.Entity("HospitalSchedule.Models.OperationBlock_Shifts", b =>
                {
                    b.HasOne("HospitalSchedule.Models.OperationBlock", "OperationBlock")
                        .WithMany("OperationBlock_Shifts")
                        .HasForeignKey("OperationBlockId");

                    b.HasOne("HospitalSchedule.Models.Shift", "Shift")
                        .WithMany("OperationBlock_Shifts")
                        .HasForeignKey("ShiftId");
                });

            modelBuilder.Entity("HospitalSchedule.Models.Schedule", b =>
                {
                    b.HasOne("HospitalSchedule.Models.Nurse", "Nurse")
                        .WithMany("Schedules")
                        .HasForeignKey("NurseId");

                    b.HasOne("HospitalSchedule.Models.OperationBlock_Shifts", "OperationBlock_Shifts")
                        .WithMany("Schedules")
                        .HasForeignKey("OperationBlock_ShiftsId");
                });
#pragma warning restore 612, 618
        }
    }
}
