﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_Apoteka.Migrations
{
    public partial class UpdateV7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "korisnik",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "korisnik");
        }
    }
}
