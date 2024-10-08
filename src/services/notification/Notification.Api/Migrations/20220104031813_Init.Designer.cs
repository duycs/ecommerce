﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Notification.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Notification.Api.Migrations
{
    [DbContext(typeof(NotificationDbContext))]
    [Migration("20220104031813_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("notification")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Notification.Domain.AggregateModels.NotificationAggregate.NotificationHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTimeOffset>("LastUpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_updated_date");

                    b.Property<string>("NotificationTemplateId")
                        .HasColumnType("text")
                        .HasColumnName("notification_template_id");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_notification_histories");

                    b.HasIndex("NotificationTemplateId")
                        .HasDatabaseName("ix_notification_histories_notification_template_id");

                    b.ToTable("notification_histories");
                });

            modelBuilder.Entity("Notification.Domain.AggregateModels.TemplateAggregate.NotificationTemplate", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_notification_templates");

                    b.ToTable("notification_templates");
                });

            modelBuilder.Entity("Notification.Domain.AggregateModels.NotificationAggregate.NotificationHistory", b =>
                {
                    b.HasOne("Notification.Domain.AggregateModels.TemplateAggregate.NotificationTemplate", "NotificationTemplate")
                        .WithMany()
                        .HasForeignKey("NotificationTemplateId")
                        .HasConstraintName("fk_notification_histories_notification_templates_notification_");

                    b.Navigation("NotificationTemplate");
                });
#pragma warning restore 612, 618
        }
    }
}
