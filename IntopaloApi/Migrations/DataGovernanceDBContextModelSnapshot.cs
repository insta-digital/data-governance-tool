﻿// <auto-generated />
using System;
using IntopaloApi.System_for_data_governance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IntopaloApi.Migrations
{
    [DbContext(typeof(DataGovernanceDBContext))]
    partial class DataGovernanceDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Annotation", b =>
                {
                    b.Property<int>("AnnotationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BaseId");

                    b.Property<string>("Description");

                    b.HasKey("AnnotationId");

                    b.HasIndex("BaseId");

                    b.ToTable("Annotations");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Base", b =>
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

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.CompositeKeyField", b =>
                {
                    b.Property<int>("FieldId");

                    b.Property<int>("CompositeKeyId");

                    b.HasKey("FieldId", "CompositeKeyId");

                    b.HasIndex("CompositeKeyId");

                    b.ToTable("CompositeKeyFields");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Datastore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Datastores");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.KeyRelationship", b =>
                {
                    b.Property<int>("FromId");

                    b.Property<int>("ToId");

                    b.Property<string>("Type");

                    b.HasKey("FromId", "ToId");

                    b.HasIndex("ToId");

                    b.ToTable("KeyRelationships");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.CompositeKey", b =>
                {
                    b.HasBaseType("IntopaloApi.System_for_data_governance.Base");


                    b.ToTable("CompositeKey");

                    b.HasDiscriminator().HasValue("CompositeKey");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Database", b =>
                {
                    b.HasBaseType("IntopaloApi.System_for_data_governance.Base");

                    b.Property<int>("DatastoreId");

                    b.Property<string>("Type");

                    b.HasIndex("DatastoreId");

                    b.HasIndex("Name", "DatastoreId")
                        .IsUnique();

                    b.ToTable("Database");

                    b.HasDiscriminator().HasValue("Database");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Field", b =>
                {
                    b.HasBaseType("IntopaloApi.System_for_data_governance.Base");

                    b.Property<int>("StructuredId");

                    b.Property<string>("Type")
                        .HasColumnName("Field_Type");

                    b.HasIndex("StructuredId");

                    b.HasIndex("Name", "StructuredId")
                        .IsUnique();

                    b.ToTable("Field");

                    b.HasDiscriminator().HasValue("Field");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Schema", b =>
                {
                    b.HasBaseType("IntopaloApi.System_for_data_governance.Base");

                    b.Property<int>("DatabaseId")
                        .HasColumnName("Schema_DatabaseId");

                    b.Property<string>("SchemaName");

                    b.HasIndex("DatabaseId");

                    b.HasIndex("Name", "DatabaseId")
                        .IsUnique();

                    b.ToTable("Schema");

                    b.HasDiscriminator().HasValue("Schema");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Structured", b =>
                {
                    b.HasBaseType("IntopaloApi.System_for_data_governance.Base");


                    b.ToTable("Structured");

                    b.HasDiscriminator().HasValue("Structured");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.UnstructuredFile", b =>
                {
                    b.HasBaseType("IntopaloApi.System_for_data_governance.Base");

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

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Collection", b =>
                {
                    b.HasBaseType("IntopaloApi.System_for_data_governance.Structured");

                    b.Property<int>("DatabaseId");

                    b.HasIndex("DatabaseId");

                    b.HasIndex("Name", "DatabaseId")
                        .IsUnique();

                    b.ToTable("Collection");

                    b.HasDiscriminator().HasValue("Collection");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.StructuredFile", b =>
                {
                    b.HasBaseType("IntopaloApi.System_for_data_governance.Structured");

                    b.Property<int>("DatastoreId")
                        .HasColumnName("StructuredFile_DatastoreId");

                    b.Property<string>("FilePath");

                    b.HasIndex("DatastoreId");

                    b.HasIndex("FilePath", "DatastoreId")
                        .IsUnique();

                    b.ToTable("StructuredFile");

                    b.HasDiscriminator().HasValue("StructuredFile");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Table", b =>
                {
                    b.HasBaseType("IntopaloApi.System_for_data_governance.Structured");

                    b.Property<int?>("KeyId");

                    b.Property<int>("SchemaId");

                    b.Property<string>("TableName");

                    b.HasIndex("KeyId");

                    b.HasIndex("SchemaId");

                    b.ToTable("Table");

                    b.HasDiscriminator().HasValue("Table");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Annotation", b =>
                {
                    b.HasOne("IntopaloApi.System_for_data_governance.Base", "Base")
                        .WithMany("Annotations")
                        .HasForeignKey("BaseId");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.CompositeKeyField", b =>
                {
                    b.HasOne("IntopaloApi.System_for_data_governance.CompositeKey", "CompositeKey")
                        .WithMany("CompositeKeyFields")
                        .HasForeignKey("CompositeKeyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IntopaloApi.System_for_data_governance.Field", "Field")
                        .WithMany("CompositeKeyFields")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.KeyRelationship", b =>
                {
                    b.HasOne("IntopaloApi.System_for_data_governance.Base", "From")
                        .WithMany("PrimaryKeyTo")
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IntopaloApi.System_for_data_governance.Base", "To")
                        .WithMany("ForeignKeyTo")
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Database", b =>
                {
                    b.HasOne("IntopaloApi.System_for_data_governance.Datastore", "Datastore")
                        .WithMany("Databases")
                        .HasForeignKey("DatastoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Field", b =>
                {
                    b.HasOne("IntopaloApi.System_for_data_governance.Structured", "Structured")
                        .WithMany("Fields")
                        .HasForeignKey("StructuredId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Schema", b =>
                {
                    b.HasOne("IntopaloApi.System_for_data_governance.Database", "Database")
                        .WithMany("Schemas")
                        .HasForeignKey("DatabaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.UnstructuredFile", b =>
                {
                    b.HasOne("IntopaloApi.System_for_data_governance.Datastore", "Datastore")
                        .WithMany("UnstructuredFiles")
                        .HasForeignKey("DatastoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Collection", b =>
                {
                    b.HasOne("IntopaloApi.System_for_data_governance.Database", "Database")
                        .WithMany("Collections")
                        .HasForeignKey("DatabaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.StructuredFile", b =>
                {
                    b.HasOne("IntopaloApi.System_for_data_governance.Datastore", "Datastore")
                        .WithMany("StructuredFiles")
                        .HasForeignKey("DatastoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Table", b =>
                {
                    b.HasOne("IntopaloApi.System_for_data_governance.CompositeKey", "Key")
                        .WithMany()
                        .HasForeignKey("KeyId");

                    b.HasOne("IntopaloApi.System_for_data_governance.Schema", "Schema")
                        .WithMany("Tables")
                        .HasForeignKey("SchemaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
