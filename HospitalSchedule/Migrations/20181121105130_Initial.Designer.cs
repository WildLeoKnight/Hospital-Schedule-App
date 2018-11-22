﻿// <auto-generated />
using System;
using HospitalSchedule.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalSchedule.Migrations
{
    [DbContext(typeof(HospitalScheduleDbContext))]
    [Migration("20181121105130_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HospitalSchedule.Models.Nurse", b =>
                {
                    b.Property<int>("NurseID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CellPhoneNumber")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Specialties")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.Property<DateTime>("YoungestChildBirthDate");

                    b.HasKey("NurseID");

                    b.ToTable("Nurse");
                });

            modelBuilder.Entity("HospitalSchedule.Models.OperationBlock", b =>
                {
                    b.Property<int>("OperationBlockID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlockName")
                        .IsRequired();

                    b.Property<int>("CurrentNurses");

                    b.Property<int>("MaxNumOfNurses");

                    b.Property<int>("ScheduleFK");

                    b.HasKey("OperationBlockID");

                    b.HasIndex("ScheduleFK")
                        .IsUnique();

                    b.ToTable("OperationBlock");
                });

            modelBuilder.Entity("HospitalSchedule.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("NurseName")
                        .IsRequired();

                    b.Property<int>("OperationBlockFK");

                    b.Property<string>("OperationBlockName")
                        .IsRequired();

                    b.Property<string>("ShiftType")
                        .IsRequired();

                    b.HasKey("ScheduleId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("HospitalSchedule.Models.Shift", b =>
                {
                    b.Property<int>("ShiftID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FinishingHour");

                    b.Property<string>("ShiftName");

                    b.Property<DateTime>("StartingHour");

                    b.HasKey("ShiftID");

                    b.ToTable("Shift");
                });

            modelBuilder.Entity("HospitalSchedule.Models.Shift_Schedule", b =>
                {
                    b.Property<int>("Shift_ScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ScheduleFK");

                    b.Property<int>("ScheduleId");

                    b.Property<DateTime>("ShiftDate");

                    b.Property<int>("ShiftFK");

                    b.Property<int>("ShiftID");

                    b.HasKey("Shift_ScheduleID");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("ShiftID");

                    b.ToTable("Shift_Schedule");
                });

            modelBuilder.Entity("HospitalSchedule.Models.OperationBlock", b =>
                {
                    b.HasOne("HospitalSchedule.Models.Schedule", "Schedule")
                        .WithOne("OperationBlock")
                        .HasForeignKey("HospitalSchedule.Models.OperationBlock", "ScheduleFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HospitalSchedule.Models.Shift_Schedule", b =>
                {
                    b.HasOne("HospitalSchedule.Models.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HospitalSchedule.Models.Shift", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
