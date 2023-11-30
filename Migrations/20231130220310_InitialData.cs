using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tareas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb402"), null, "Actividades personales", 50 },
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb410"), new Guid("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), null, new DateTime(2023, 11, 30, 16, 3, 10, 335, DateTimeKind.Local).AddTicks(9141), 2, "Pago de servicios publicos" },
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb411"), new Guid("fe2de405-c38e-4c90-ac52-da0540dfb402"), null, new DateTime(2023, 11, 30, 16, 3, 10, 335, DateTimeKind.Local).AddTicks(9161), 0, "Terminar de ver pelicula en netflix" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "TareaId",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb410"));

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "TareaId",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb411"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb402"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb4ef"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tareas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
