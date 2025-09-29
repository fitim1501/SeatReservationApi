﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeatReservation.Infrastructure.Postgre.Migrations
{
    /// <inheritdoc />
    public partial class Seats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_seats_venues_VenueId",
                table: "seats");

            migrationBuilder.AlterColumn<Guid>(
                name: "VenueId",
                table: "seats",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_seats_venues_VenueId",
                table: "seats",
                column: "VenueId",
                principalTable: "venues",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_seats_venues_VenueId",
                table: "seats");

            migrationBuilder.AlterColumn<Guid>(
                name: "VenueId",
                table: "seats",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_seats_venues_VenueId",
                table: "seats",
                column: "VenueId",
                principalTable: "venues",
                principalColumn: "id");
        }
    }
}
