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

                    b.Property<string>("CCBI")
                        .IsRequired();

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

                    b.HasKey("NurseId");

                    b.ToTable("Nurse");
                });

            modelBuilder.Entity("HospitalSchedule.Models.OperationBlock", b =>
                {
                    b.Property<int>("OperationBlockId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlockName")
                        .IsRequired();

                    b.Property<string>("TypeOfShift")
                        .IsRequired();

                    b.HasKey("OperationBlockId");

                    b.ToTable("OperationBlock");
                });

            modelBuilder.Entity("HospitalSchedule.Models.Rules", b =>
                {
                    b.Property<int>("RulesId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.HasKey("ScheduleId");

                    b.HasIndex("NurseId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("HospitalSchedule.Models.Shift", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FinishingHour");

                    b.Property<string>("ShiftName");

                    b.Property<DateTime>("StartingHour");

                    b.HasKey("ShiftId");

                    b.ToTable("Shift");
                });

            modelBuilder.Entity("HospitalSchedule.Models.Shift_Schedule_OperationBlock", b =>
                {
                    b.Property<int>("Shift_Schedule_OperationBlockId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OperationBlockId");

                    b.Property<int>("ScheduleId");

                    b.Property<DateTime>("ShiftDate");

                    b.Property<int>("ShiftId");

                    b.HasKey("Shift_Schedule_OperationBlockId");

                    b.HasIndex("OperationBlockId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("ShiftId");

                    b.ToTable("Shift_Schedule_OperationBlock");
                });

            modelBuilder.Entity("HospitalSchedule.Models.Schedule", b =>
                {
                    b.HasOne("HospitalSchedule.Models.Nurse", "Nurse")
                        .WithMany("Schedules")
                        .HasForeignKey("NurseId");
                });

            modelBuilder.Entity("HospitalSchedule.Models.Shift_Schedule_OperationBlock", b =>
                {
                    b.HasOne("HospitalSchedule.Models.OperationBlock", "OperationBlock")
                        .WithMany("Shift_Schedule_OperationBlock")
                        .HasForeignKey("OperationBlockId");

                    b.HasOne("HospitalSchedule.Models.Schedule", "Schedule")
                        .WithMany("Shift_Schedule_OperationBlock")
                        .HasForeignKey("ScheduleId");

                    b.HasOne("HospitalSchedule.Models.Shift", "Shift")
                        .WithMany("Shift_Schedule_OperationBlock")
                        .HasForeignKey("ShiftId");
                });
#pragma warning restore 612, 618
        }
    }
}
