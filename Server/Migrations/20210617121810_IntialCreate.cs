﻿// using Microsoft.EntityFrameworkCore.Migrations;
// using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

// namespace P8.Server.Migrations
// {
//     public partial class IntialCreate : Migration
//     {
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.CreateTable(
//                 name: "Instruments",
//                 columns: table => new
//                 {
//                     Id = table.Column<int>(type: "integer", nullable: false)
//                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
//                     Name = table.Column<string>(type: "text", nullable: true),
//                     LeftInStock = table.Column<int>(type: "integer", nullable: false),
//                     Price = table.Column<int>(type: "integer", nullable: false),
//                     ImgAddress = table.Column<string>(type: "text", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Instruments", x => x.Id);
//                 });
//         }

//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropTable(
//                 name: "Instruments");
//         }
//     }
// }
