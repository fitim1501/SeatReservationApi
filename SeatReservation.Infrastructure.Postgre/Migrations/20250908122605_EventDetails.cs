using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeatReservation.Infrastructure.Postgre.Migrations
{
    /// <inheritdoc />
    public partial class EventDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_events_event_details_EventDetailsEventId",
                table: "events");

            migrationBuilder.DropIndex(
                name: "IX_events_EventDetailsEventId",
                table: "events");

            migrationBuilder.DropColumn(
                name: "EventDetailsEventId",
                table: "events");

            migrationBuilder.AddForeignKey(
                name: "FK_event_details_events_event_id",
                table: "event_details",
                column: "event_id",
                principalTable: "events",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_event_details_events_event_id",
                table: "event_details");

            migrationBuilder.AddColumn<Guid>(
                name: "EventDetailsEventId",
                table: "events",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_events_EventDetailsEventId",
                table: "events",
                column: "EventDetailsEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_events_event_details_EventDetailsEventId",
                table: "events",
                column: "EventDetailsEventId",
                principalTable: "event_details",
                principalColumn: "event_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
