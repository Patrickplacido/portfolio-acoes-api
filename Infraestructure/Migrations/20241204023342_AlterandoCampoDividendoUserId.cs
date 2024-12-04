﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioAcoes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoCampoDividendoUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Dividendos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Dividendos");
        }
    }
}
