using Microsoft.EntityFrameworkCore.Migrations;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Migrations
{
    public partial class insertDataToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Uoms(UomCode, Description, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy)VALUES('PK', 'Package', 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Uoms(UomCode, Description, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy)VALUES('PC', 'Piece', 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Uoms(UomCode, Description, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy)VALUES('BOX', 'Box', 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Uoms(UomCode, Description, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy)VALUES('CTN', 'CTN', 1, '', 0, '', 0);");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
