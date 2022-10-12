﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PRJGBS.Data;

#nullable disable

namespace PRJGBS.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221012194136_UpDb")]
    partial class UpDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PRJGBS.Models.NPC", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Affinity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NPCDialogueID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("NPCDialogueID");

                    b.ToTable("Npc");
                });

            modelBuilder.Entity("PRJGBS.Models.NPCDialogue", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DialogueText")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("PromptA")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("PromptB")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("NpcDialogue");
                });

            modelBuilder.Entity("PRJGBS.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("SaveStateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SaveStateId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("PRJGBS.Models.SaveState", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("StoryProgress")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SaveState");
                });

            modelBuilder.Entity("PRJGBS.Models.NPC", b =>
                {
                    b.HasOne("PRJGBS.Models.NPCDialogue", "NPCDialogue")
                        .WithMany()
                        .HasForeignKey("NPCDialogueID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NPCDialogue");
                });

            modelBuilder.Entity("PRJGBS.Models.Player", b =>
                {
                    b.HasOne("PRJGBS.Models.SaveState", "SaveState")
                        .WithMany()
                        .HasForeignKey("SaveStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SaveState");
                });
#pragma warning restore 612, 618
        }
    }
}
