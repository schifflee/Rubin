﻿// <auto-generated />
using Data.University;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Data.Migrations
{
    [DbContext(typeof(UniversityModel))]
    [Migration("20180513073900_FirstMigrationTest")]
    partial class FirstMigrationTest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Data.University.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apartment");

                    b.Property<string>("Bulding");

                    b.Property<int?>("CountryId");

                    b.Property<int?>("DisctrictId");

                    b.Property<int?>("DistrictId");

                    b.Property<int?>("LocalityId");

                    b.Property<int?>("RegionId");

                    b.Property<int?>("StreetId");

                    b.Property<int?>("TownId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("LocalityId");

                    b.HasIndex("RegionId");

                    b.HasIndex("StreetId");

                    b.HasIndex("TownId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Data.University.Cathedra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.ToTable("Cathedras");
                });

            modelBuilder.Entity("Data.University.Citizenship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Citizenships");
                });

            modelBuilder.Entity("Data.University.Command", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Commands");
                });

            modelBuilder.Entity("Data.University.CommandPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CommandId");

                    b.Property<int?>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("CommandId");

                    b.HasIndex("RoleId");

                    b.ToTable("CommandPermissions");
                });

            modelBuilder.Entity("Data.University.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FiasCode");

                    b.Property<string>("KladrCode");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Data.University.Direction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<int?>("EducationLevelId");

                    b.Property<int?>("EducationProgramTypeId");

                    b.Property<int?>("EducationStandartTypeId");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.HasIndex("EducationLevelId");

                    b.HasIndex("EducationProgramTypeId");

                    b.HasIndex("EducationStandartTypeId");

                    b.ToTable("Directions");
                });

            modelBuilder.Entity("Data.University.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CathedraId");

                    b.Property<int?>("DisciplineCycleId");

                    b.Property<int?>("EducationCompetenceId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CathedraId");

                    b.HasIndex("DisciplineCycleId");

                    b.HasIndex("EducationCompetenceId");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("Data.University.DisciplineCycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DisciplineCycles");
                });

            modelBuilder.Entity("Data.University.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FiasCode");

                    b.Property<string>("KladrCode");

                    b.Property<string>("Name");

                    b.Property<string>("Prefix");

                    b.Property<int?>("RegionId");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("Data.University.EducationCompetence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("EducationCompetences");
                });

            modelBuilder.Entity("Data.University.EducationForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.ToTable("EducationForms");
                });

            modelBuilder.Entity("Data.University.EducationLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.ToTable("EducationLevels");
                });

            modelBuilder.Entity("Data.University.EducationPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CathedraId");

                    b.Property<int?>("DirectionId");

                    b.Property<int?>("EducationFormId");

                    b.Property<int?>("EducationLevelId");

                    b.Property<int?>("FacultyId");

                    b.Property<bool?>("IsAcceleratedLearning");

                    b.Property<string>("Name");

                    b.Property<int?>("Year");

                    b.HasKey("Id");

                    b.HasIndex("CathedraId");

                    b.HasIndex("DirectionId");

                    b.HasIndex("EducationFormId");

                    b.HasIndex("EducationLevelId");

                    b.HasIndex("FacultyId");

                    b.ToTable("EducationPlans");
                });

            modelBuilder.Entity("Data.University.EducationProgramType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.ToTable("EducationProgramTypes");
                });

            modelBuilder.Entity("Data.University.EducationStandartType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("EducationStandartTypes");
                });

            modelBuilder.Entity("Data.University.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("Data.University.FinanceSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("IsBudget");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FinanceSources");
                });

            modelBuilder.Entity("Data.University.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Data.University.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdmissionYear");

                    b.Property<int?>("EducationFormId");

                    b.Property<int?>("EducationPlanId");

                    b.Property<int?>("FacultyId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EducationFormId");

                    b.HasIndex("EducationPlanId");

                    b.HasIndex("FacultyId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Data.University.IdentityDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CitizenshipId");

                    b.Property<DateTime?>("Date");

                    b.Property<string>("FirstName");

                    b.Property<bool?>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<string>("Number");

                    b.Property<int?>("OrganizationId");

                    b.Property<string>("Patronimyc");

                    b.Property<int?>("PersonId");

                    b.Property<string>("Series");

                    b.Property<int?>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("CitizenshipId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("PersonId");

                    b.HasIndex("TypeId");

                    b.ToTable("IdentityDocuments");
                });

            modelBuilder.Entity("Data.University.IdentityOrganization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("IdentityOrganizations");
                });

            modelBuilder.Entity("Data.University.IdentityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("IdentityTypes");
                });

            modelBuilder.Entity("Data.University.InterfaceElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("InterfaceElements");
                });

            modelBuilder.Entity("Data.University.InterfacePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("InterfaceElementId");

                    b.Property<int?>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("InterfaceElementId");

                    b.HasIndex("RoleId");

                    b.ToTable("InterfacePermissions");
                });

            modelBuilder.Entity("Data.University.Locality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DistrictId");

                    b.Property<string>("FiasCode");

                    b.Property<string>("KladrCode");

                    b.Property<string>("Name");

                    b.Property<string>("Prefix");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Localities");
                });

            modelBuilder.Entity("Data.University.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressId");

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("FirstName");

                    b.Property<int?>("GenderId");

                    b.Property<string>("LastName");

                    b.Property<string>("Patronimyc");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("GenderId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Data.University.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CountryId");

                    b.Property<string>("FiasCode");

                    b.Property<string>("KladrCode");

                    b.Property<string>("Name");

                    b.Property<string>("Prefix");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Data.University.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Data.University.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FiasCode");

                    b.Property<string>("KladrCode");

                    b.Property<string>("Name");

                    b.Property<int?>("ParentId");

                    b.Property<int>("ParentLevel");

                    b.Property<string>("Prefix");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("Data.University.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FinanceSourceId");

                    b.Property<int?>("GroupId");

                    b.Property<string>("PersonFileNumber");

                    b.Property<int?>("PersonId");

                    b.Property<int?>("StudentStateId");

                    b.HasKey("Id");

                    b.HasIndex("FinanceSourceId");

                    b.HasIndex("GroupId");

                    b.HasIndex("PersonId");

                    b.HasIndex("StudentStateId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Data.University.StudentState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("StudentStates");
                });

            modelBuilder.Entity("Data.University.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CathedraId");

                    b.Property<int?>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("CathedraId");

                    b.HasIndex("PersonId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Data.University.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FiasCode");

                    b.Property<string>("KladrCode");

                    b.Property<string>("Name");

                    b.Property<string>("Prefix");

                    b.Property<int?>("RegionId");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Towns");
                });

            modelBuilder.Entity("Data.University.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Login");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Patronimyc");

                    b.Property<string>("Phone");

                    b.Property<int?>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Data.University.Address", b =>
                {
                    b.HasOne("Data.University.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("Data.University.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId");

                    b.HasOne("Data.University.Locality", "Locality")
                        .WithMany()
                        .HasForeignKey("LocalityId");

                    b.HasOne("Data.University.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");

                    b.HasOne("Data.University.Street", "Street")
                        .WithMany()
                        .HasForeignKey("StreetId");

                    b.HasOne("Data.University.Town", "Town")
                        .WithMany()
                        .HasForeignKey("TownId");
                });

            modelBuilder.Entity("Data.University.CommandPermission", b =>
                {
                    b.HasOne("Data.University.Command", "Command")
                        .WithMany("Permissions")
                        .HasForeignKey("CommandId");

                    b.HasOne("Data.University.Role", "Role")
                        .WithMany("AvailableCommands")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Data.University.Direction", b =>
                {
                    b.HasOne("Data.University.EducationLevel", "EducationLevel")
                        .WithMany()
                        .HasForeignKey("EducationLevelId");

                    b.HasOne("Data.University.EducationProgramType", "EducationProgramType")
                        .WithMany()
                        .HasForeignKey("EducationProgramTypeId");

                    b.HasOne("Data.University.EducationStandartType", "EducationStandartType")
                        .WithMany()
                        .HasForeignKey("EducationStandartTypeId");
                });

            modelBuilder.Entity("Data.University.Discipline", b =>
                {
                    b.HasOne("Data.University.Cathedra", "Cathedra")
                        .WithMany()
                        .HasForeignKey("CathedraId");

                    b.HasOne("Data.University.DisciplineCycle", "DisciplineCycle")
                        .WithMany("Disciplines")
                        .HasForeignKey("DisciplineCycleId");

                    b.HasOne("Data.University.EducationCompetence", "EducationCompetence")
                        .WithMany("Disciplines")
                        .HasForeignKey("EducationCompetenceId");
                });

            modelBuilder.Entity("Data.University.District", b =>
                {
                    b.HasOne("Data.University.Region", "Region")
                        .WithMany("Districts")
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("Data.University.EducationPlan", b =>
                {
                    b.HasOne("Data.University.Cathedra", "Cathedra")
                        .WithMany()
                        .HasForeignKey("CathedraId");

                    b.HasOne("Data.University.Direction", "Direction")
                        .WithMany()
                        .HasForeignKey("DirectionId");

                    b.HasOne("Data.University.EducationForm", "EducationForm")
                        .WithMany()
                        .HasForeignKey("EducationFormId");

                    b.HasOne("Data.University.EducationLevel", "EducationLevel")
                        .WithMany()
                        .HasForeignKey("EducationLevelId");

                    b.HasOne("Data.University.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId");
                });

            modelBuilder.Entity("Data.University.Group", b =>
                {
                    b.HasOne("Data.University.EducationForm", "EducationForm")
                        .WithMany()
                        .HasForeignKey("EducationFormId");

                    b.HasOne("Data.University.EducationPlan", "EducationPlan")
                        .WithMany()
                        .HasForeignKey("EducationPlanId");

                    b.HasOne("Data.University.Faculty", "Faculty")
                        .WithMany("Groups")
                        .HasForeignKey("FacultyId");
                });

            modelBuilder.Entity("Data.University.IdentityDocument", b =>
                {
                    b.HasOne("Data.University.Citizenship", "Citizenship")
                        .WithMany()
                        .HasForeignKey("CitizenshipId");

                    b.HasOne("Data.University.IdentityOrganization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId");

                    b.HasOne("Data.University.Person", "Person")
                        .WithMany("IdentityDocuments")
                        .HasForeignKey("PersonId");

                    b.HasOne("Data.University.IdentityType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("Data.University.InterfacePermission", b =>
                {
                    b.HasOne("Data.University.InterfaceElement", "InterfaceElement")
                        .WithMany("Permissions")
                        .HasForeignKey("InterfaceElementId");

                    b.HasOne("Data.University.Role", "Role")
                        .WithMany("AvailableViews")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Data.University.Locality", b =>
                {
                    b.HasOne("Data.University.District", "District")
                        .WithMany("Localities")
                        .HasForeignKey("DistrictId");
                });

            modelBuilder.Entity("Data.University.Person", b =>
                {
                    b.HasOne("Data.University.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Data.University.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");
                });

            modelBuilder.Entity("Data.University.Region", b =>
                {
                    b.HasOne("Data.University.Country", "Country")
                        .WithMany("Regions")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("Data.University.Student", b =>
                {
                    b.HasOne("Data.University.FinanceSource", "FinanceSource")
                        .WithMany()
                        .HasForeignKey("FinanceSourceId");

                    b.HasOne("Data.University.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId");

                    b.HasOne("Data.University.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("Data.University.StudentState", "State")
                        .WithMany()
                        .HasForeignKey("StudentStateId");
                });

            modelBuilder.Entity("Data.University.Teacher", b =>
                {
                    b.HasOne("Data.University.Cathedra", "Cathedra")
                        .WithMany()
                        .HasForeignKey("CathedraId");

                    b.HasOne("Data.University.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("Data.University.Town", b =>
                {
                    b.HasOne("Data.University.Region", "Region")
                        .WithMany("Towns")
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("Data.University.User", b =>
                {
                    b.HasOne("Data.University.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");
                });
#pragma warning restore 612, 618
        }
    }
}
