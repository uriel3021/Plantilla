using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSH.Starter.WebApi.Migrations.MSSQL.Catalog
{
    /// <inheritdoc />
    public partial class AddCambiosCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatUnidadesAdministrativas",
                schema: "catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesCorta = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Abreviación de Unidad Administrativa"),
                    ClavePresupuestal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Clave Presupuestal de Unidad Administrativa"),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Descripción del catálogo"),
                    Activo = table.Column<bool>(type: "bit", nullable: false, comment: "Bandera para activar o desactivar el registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatUnidadesAdministrativas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatUnidadesAdministrativas",
                schema: "catalog");
        }
    }
}
