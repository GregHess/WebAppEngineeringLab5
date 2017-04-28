﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MusicApp2017.Migrations
{
    public partial class Help2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Rating_RatingID",
                table: "Albums");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Albums_RatingID",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "RatingID",
                table: "Albums");

            migrationBuilder.AddColumn<decimal>(
                name: "AverageRating",
                table: "Albums",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Albums");

            migrationBuilder.AddColumn<int>(
                name: "RatingID",
                table: "Albums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlbumID = table.Column<int>(nullable: false),
                    AverageRating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_RatingID",
                table: "Albums",
                column: "RatingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Rating_RatingID",
                table: "Albums",
                column: "RatingID",
                principalTable: "Rating",
                principalColumn: "RatingID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
