using Microsoft.EntityFrameworkCore.Migrations;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Migrations
{
    public partial class insertDataToTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Rotations(RotationCode, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('CatA', 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Rotations(RotationCode, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('CatB', 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Rotations(RotationCode, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('CatC', 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Rotations(RotationCode, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('CatD', 1, '', 0, '', 0);");


           }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
