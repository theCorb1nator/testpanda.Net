﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestPanda.Api;

namespace TestPanda.Api.Migrations
{
    [DbContext(typeof(TestPandaContext))]
    partial class TestPandaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestPanda.Api.DomainEntities.TestCase", b =>
                {
                    b.Property<int>("TestCaseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorTestUserId");

                    b.Property<string>("Comments");

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Reason");

                    b.Property<int>("State");

                    b.Property<int?>("TestPlanId");

                    b.Property<string>("Title");

                    b.HasKey("TestCaseId");

                    b.HasIndex("AuthorTestUserId");

                    b.HasIndex("TestPlanId");

                    b.ToTable("TestCases");
                });

            modelBuilder.Entity("TestPanda.Api.DomainEntities.TestPlan", b =>
                {
                    b.Property<int>("TestPlanId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorTestUserId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<int?>("TestRunId");

                    b.Property<string>("Title");

                    b.Property<int?>("UpdatedByTestUserId");

                    b.HasKey("TestPlanId");

                    b.HasIndex("AuthorTestUserId");

                    b.HasIndex("TestRunId");

                    b.HasIndex("UpdatedByTestUserId");

                    b.ToTable("TestPlans");
                });

            modelBuilder.Entity("TestPanda.Api.DomainEntities.TestRun", b =>
                {
                    b.Property<int>("TestRunId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("TesterTestUserId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("TestRunId");

                    b.HasIndex("TesterTestUserId");

                    b.ToTable("TestRuns");
                });

            modelBuilder.Entity("TestPanda.Api.DomainEntities.TestUser", b =>
                {
                    b.Property<int>("TestUserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<int>("Role");

                    b.HasKey("TestUserId");

                    b.ToTable("TestUsers");
                });

            modelBuilder.Entity("TestPanda.Api.DomainEntities.TestCase", b =>
                {
                    b.HasOne("TestPanda.Api.DomainEntities.TestUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorTestUserId");

                    b.HasOne("TestPanda.Api.DomainEntities.TestPlan")
                        .WithMany("TestCases")
                        .HasForeignKey("TestPlanId");
                });

            modelBuilder.Entity("TestPanda.Api.DomainEntities.TestPlan", b =>
                {
                    b.HasOne("TestPanda.Api.DomainEntities.TestUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorTestUserId");

                    b.HasOne("TestPanda.Api.DomainEntities.TestRun")
                        .WithMany("TestPlans")
                        .HasForeignKey("TestRunId");

                    b.HasOne("TestPanda.Api.DomainEntities.TestUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByTestUserId");
                });

            modelBuilder.Entity("TestPanda.Api.DomainEntities.TestRun", b =>
                {
                    b.HasOne("TestPanda.Api.DomainEntities.TestUser", "Tester")
                        .WithMany()
                        .HasForeignKey("TesterTestUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
