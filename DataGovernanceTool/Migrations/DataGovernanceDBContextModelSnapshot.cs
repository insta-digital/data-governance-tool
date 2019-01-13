﻿// <auto-generated />
using System;
using DataGovernanceTool.Data.Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataGT.Migrations
{
    [DbContext(typeof(DataGovernanceDBContext))]
    partial class DataGovernanceDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("DataGovernanceTool.Data.Annotation", b =>
                {
                    b.Property<int>("AnnotationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BaseId");

                    b.Property<string>("Description");

                    b.HasKey("AnnotationId");

                    b.HasIndex("BaseId");

                    b.ToTable("Annotations");
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Relationships.CompositeKeyField", b =>
                {
                    b.Property<int>("FieldId");

                    b.Property<int>("CompositeKeyId");

                    b.HasKey("FieldId", "CompositeKeyId");

                    b.HasIndex("CompositeKeyId");

                    b.ToTable("CompositeKeyFields");
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Relationships.KeyRelationship", b =>
                {
                    b.Property<int>("FromId");

                    b.Property<int>("ToId");

                    b.Property<string>("Type");

                    b.HasKey("FromId", "ToId");

                    b.HasIndex("ToId");

                    b.ToTable("KeyRelationships");
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Structure.Base", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Bases");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Base");
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Structure.Datastore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Datastores");
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Relationships.CompositeKey", b =>
                {
                    b.HasBaseType("DataGovernanceTool.Data.Models.Metadata.Structure.Base");


                    b.ToTable("CompositeKey");

                    b.HasDiscriminator().HasValue("CompositeKey");
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Structure.Database", b =>
                {
                    b.HasBaseType("DataGovernanceTool.Data.Models.Metadata.Structure.Base");

                    b.Property<int>("DatastoreId");

                    b.Property<string>("Type");

                    b.HasIndex("DatastoreId");

                    b.HasIndex("Name", "DatastoreId")
                        .IsUnique();

                    b.ToTable("Database");

                    b.HasDiscriminator().HasValue("Database");
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Structure.Field", b =>
                {
                    b.HasBaseType("DataGovernanceTool.Data.Models.Metadata.Structure.Base");

                    b.Property<int>("StructuredId");

                    b.Property<string>("Type")
                        .HasColumnName("Field_Type");

                    b.HasIndex("StructuredId");

                    b.HasIndex("Name", "StructuredId")
                        .IsUnique();

                    b.ToTable("Field");

                    b.HasDiscriminator().HasValue("Field");
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Structure.Schema", b =>
                {
                    b.HasBaseType("DataGovernanceTool.Data.Models.Metadata.Structure.Base");

                    b.Property<int>("DatabaseId")
                        .HasColumnName("Schema_DatabaseId");

                    b.Property<string>("SchemaName");

                    b.HasIndex("DatabaseId");

                    b.HasIndex("Name", "DatabaseId")
                        .IsUnique();

                    b.ToTable("Schema");

                    b.HasDiscriminator().HasValue("Schema");
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Structure.Structured", b =>
                {
                    b.HasBaseType("DataGovernanceTool.Data.Models.Metadata.Structure.Base");


                    b.ToTable("Structured");

                    b.HasDiscriminator().HasValue("Structured");
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Structure.UnstructuredFile", b =>
                {
                    b.HasBaseType("DataGovernanceTool.Data.Models.Metadata.Structure.Base");

                    b.Property<int>("DatastoreId")
                        .HasColumnName("UnstructuredFile_DatastoreId");

                    b.Property<string>("FilePath")
                        .HasColumnName("UnstructuredFile_FilePath");

                    b.HasIndex("DatastoreId");

                    b.HasIndex("FilePath", "DatastoreId")
                        .IsUnique();

                    b.ToTable("UnstructuredFile");

                    b.HasDiscriminator().HasValue("UnstructuredFile");
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Structure.Collection", b =>
                {
                    b.HasBaseType("DataGovernanceTool.Data.Models.Metadata.Structure.Structured");

                    b.Property<int>("DatabaseId");

                    b.HasIndex("DatabaseId");

                    b.HasIndex("Name", "DatabaseId")
                        .IsUnique();

                    b.ToTable("Collection");

                    b.HasDiscriminator().HasValue("Collection");
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Structure.StructuredFile", b =>
                {
                    b.HasBaseType("DataGovernanceTool.Data.Models.Metadata.Structure.Structured");

                    b.Property<int>("DatastoreId")
                        .HasColumnName("StructuredFile_DatastoreId");

                    b.Property<string>("FilePath");

                    b.HasIndex("DatastoreId");

                    b.HasIndex("FilePath", "DatastoreId")
                        .IsUnique();

                    b.ToTable("StructuredFile");

                    b.HasDiscriminator().HasValue("StructuredFile");
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Structure.Table", b =>
                {
                    b.HasBaseType("DataGovernanceTool.Data.Models.Metadata.Structure.Structured");

                    b.Property<int?>("KeyId");

                    b.Property<int>("SchemaId");

                    b.Property<string>("TableName");

                    b.HasIndex("KeyId");

                    b.HasIndex("SchemaId");

                    b.ToTable("Table");

                    b.HasDiscriminator().HasValue("Table");
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Annotation", b =>
                {
                    b.HasOne("DataGovernanceTool.Data.Models.Metadata.Structure.Base", "Base")
                        .WithMany("Annotations")
                        .HasForeignKey("BaseId");
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Relationships.CompositeKeyField", b =>
                {
                    b.HasOne("DataGovernanceTool.Data.Models.Metadata.Relationships.CompositeKey", "CompositeKey")
                        .WithMany("CompositeKeyFields")
                        .HasForeignKey("CompositeKeyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataGovernanceTool.Data.Models.Metadata.Structure.Field", "Field")
                        .WithMany("CompositeKeyFields")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Relationships.KeyRelationship", b =>
                {
                    b.HasOne("DataGovernanceTool.Data.Models.Metadata.Structure.Base", "From")
                        .WithMany("PrimaryKeyTo")
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataGovernanceTool.Data.Models.Metadata.Structure.Base", "To")
                        .WithMany("ForeignKeyTo")
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Structure.Database", b =>
                {
                    b.HasOne("DataGovernanceTool.Data.Models.Metadata.Structure.Datastore", "Datastore")
                        .WithMany("Databases")
                        .HasForeignKey("DatastoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Structure.Field", b =>
                {
                    b.HasOne("DataGovernanceTool.Data.Models.Metadata.Structure.Structured", "Structured")
                        .WithMany("Fields")
                        .HasForeignKey("StructuredId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Structure.Schema", b =>
                {
                    b.HasOne("DataGovernanceTool.Data.Models.Metadata.Structure.Database", "Database")
                        .WithMany("Schemas")
                        .HasForeignKey("DatabaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Structure.UnstructuredFile", b =>
                {
                    b.HasOne("DataGovernanceTool.Data.Models.Metadata.Structure.Datastore", "Datastore")
                        .WithMany("UnstructuredFiles")
                        .HasForeignKey("DatastoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Structure.Collection", b =>
                {
                    b.HasOne("DataGovernanceTool.Data.Models.Metadata.Structure.Database", "Database")
                        .WithMany("Collections")
                        .HasForeignKey("DatabaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Structure.StructuredFile", b =>
                {
                    b.HasOne("DataGovernanceTool.Data.Models.Metadata.Structure.Datastore", "Datastore")
                        .WithMany("StructuredFiles")
                        .HasForeignKey("DatastoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataGovernanceTool.Data.Models.Metadata.Structure.Table", b =>
                {
                    b.HasOne("DataGovernanceTool.Data.Models.Metadata.Relationships.CompositeKey", "Key")
                        .WithMany()
                        .HasForeignKey("KeyId");

                    b.HasOne("DataGovernanceTool.Data.Models.Metadata.Structure.Schema", "Schema")
                        .WithMany("Tables")
                        .HasForeignKey("SchemaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
