﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WestcoastEdu.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class TitleToCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Courses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Courses");
        }
    }
}
