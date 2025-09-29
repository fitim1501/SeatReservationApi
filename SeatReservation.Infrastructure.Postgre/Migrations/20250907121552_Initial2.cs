﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeatReservation.Infrastructure.Postgre.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "socials",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "details",
                table: "users",
                type: "jsonb",
                nullable: false,
                defaultValue: "{}");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "details",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "socials",
                table: "users",
                type: "jsonb",
                nullable: true);
        }
    }
}
