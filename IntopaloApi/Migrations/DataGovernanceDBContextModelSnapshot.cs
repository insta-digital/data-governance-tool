﻿// <auto-generated />
using System;
using IntopaloApi.System_for_data_governance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
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
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Annotation", b =>
                {
                    b.Property<int>("AnnotationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BaseId");

                    b.Property<string>("Description");

                    b.HasKey("AnnotationId");

                    b.HasIndex("BaseId");

                    b.ToTable("Annotations");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Base", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("Type");

                    b.ToTable("Database");

                    b.HasDiscriminator().HasValue("Database");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Field", b =>
                {
                    b.HasBaseType("IntopaloApi.System_for_data_governance.Base");

                    b.Property<int?>("StructuredBaseId");

                    b.Property<string>("Type")
                        .HasColumnName("Field_Type");

                    b.HasIndex("StructuredBaseId");

                    b.ToTable("Field");

                    b.HasDiscriminator().HasValue("Field");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Schema", b =>
                {
                    b.HasBaseType("IntopaloApi.System_for_data_governance.Base");

                    b.Property<int?>("DatabaseId")
                        .HasColumnName("Schema_DatabaseId");

                    b.Property<string>("SchemaName");

                    b.HasIndex("DatabaseId");

                    b.ToTable("Schema");

                    b.HasDiscriminator().HasValue("Schema");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.StructuredBase", b =>
                {
                    b.HasBaseType("IntopaloApi.System_for_data_governance.Base");


                    b.ToTable("StructuredBase");

                    b.HasDiscriminator().HasValue("StructuredBase");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.UnstructuredFile", b =>
                {
                    b.HasBaseType("IntopaloApi.System_for_data_governance.Base");

                    b.Property<string>("FilePath")
                        .HasColumnName("UnstructuredFile_FilePath");

                    b.ToTable("UnstructuredFile");

                    b.HasDiscriminator().HasValue("UnstructuredFile");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Collection", b =>
                {
                    b.HasBaseType("IntopaloApi.System_for_data_governance.StructuredBase");

                    b.Property<int?>("DatabaseId");

                    b.HasIndex("DatabaseId");

                    b.ToTable("Collection");

                    b.HasDiscriminator().HasValue("Collection");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.StructuredFile", b =>
                {
                    b.HasBaseType("IntopaloApi.System_for_data_governance.StructuredBase");

                    b.Property<string>("FilePath");

                    b.ToTable("StructuredFile");

                    b.HasDiscriminator().HasValue("StructuredFile");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Table", b =>
                {
                    b.HasBaseType("IntopaloApi.System_for_data_governance.StructuredBase");

                    b.Property<int?>("SchemaId");

                    b.Property<string>("TableName");

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
                        .OnDelete(DeleteBehavior.Restrict);

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
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Field", b =>
                {
                    b.HasOne("IntopaloApi.System_for_data_governance.StructuredBase", "StructuredBase")
                        .WithMany("Fields")
                        .HasForeignKey("StructuredBaseId");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Schema", b =>
                {
                    b.HasOne("IntopaloApi.System_for_data_governance.Database", "Database")
                        .WithMany("Schemas")
                        .HasForeignKey("DatabaseId");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Collection", b =>
                {
                    b.HasOne("IntopaloApi.System_for_data_governance.Database", "Database")
                        .WithMany("Collections")
                        .HasForeignKey("DatabaseId");
                });

            modelBuilder.Entity("IntopaloApi.System_for_data_governance.Table", b =>
                {
                    b.HasOne("IntopaloApi.System_for_data_governance.Schema", "Schema")
                        .WithMany("Tables")
                        .HasForeignKey("SchemaId");
                });
#pragma warning restore 612, 618
        }
    }
}
