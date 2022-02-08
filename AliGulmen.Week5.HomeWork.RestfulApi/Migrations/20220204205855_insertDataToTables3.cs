using Microsoft.EntityFrameworkCore.Migrations;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Migrations
{
    public partial class insertDataToTables3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Locations (LocationName, RotationId, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('DockArea', 9, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Locations (LocationName, RotationId, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('010102', 10, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Locations (LocationName, RotationId, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('010103', 11, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Locations (LocationName, RotationId, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('010201', 9, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Locations (LocationName, RotationId, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('010202', 10, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Locations (LocationName, RotationId, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('010203', 11, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Locations (LocationName, RotationId, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('020101', 9, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Locations (LocationName, RotationId, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('020102', 10, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Locations (LocationName, RotationId, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('020103', 11, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Locations (LocationName, RotationId, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('020201', 9, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Locations (LocationName, RotationId, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('020202', 10, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Locations (LocationName, RotationId, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('020203', 11, 1, '', 0, '', 0);");


          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
