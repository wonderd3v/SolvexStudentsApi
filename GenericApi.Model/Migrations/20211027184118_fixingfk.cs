using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericApi.Model.Migrations
{
    public partial class fixingfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassStudent_Students_StudentsId",
                table: "ClassStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassStudent",
                table: "ClassStudent");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "ClassStudent",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassStudent_StudentsId",
                table: "ClassStudent",
                newName: "IX_ClassStudent_StudentId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ClassStudent",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ClassStudent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "ClassStudent",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ClassStudent",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ClassStudent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedDate",
                table: "ClassStudent",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ClassStudent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "ClassStudent",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassStudent",
                table: "ClassStudent",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudent_ClassId",
                table: "ClassStudent",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudent_Students_StudentId",
                table: "ClassStudent",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassStudent_Students_StudentId",
                table: "ClassStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassStudent",
                table: "ClassStudent");

            migrationBuilder.DropIndex(
                name: "IX_ClassStudent_ClassId",
                table: "ClassStudent");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ClassStudent");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ClassStudent");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ClassStudent");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ClassStudent");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ClassStudent");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ClassStudent");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ClassStudent");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ClassStudent");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "ClassStudent",
                newName: "StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassStudent_StudentId",
                table: "ClassStudent",
                newName: "IX_ClassStudent_StudentsId");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassStudent",
                table: "ClassStudent",
                columns: new[] { "ClassId", "StudentsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudent_Students_StudentsId",
                table: "ClassStudent",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
