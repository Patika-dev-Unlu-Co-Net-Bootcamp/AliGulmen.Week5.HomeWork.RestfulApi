using Microsoft.EntityFrameworkCore.Migrations;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Migrations
{
    public partial class insertDataToTables5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Containers (ProductId, UomId, Quantity, LocationId, Weight, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES(22, 1, 200, 16, 300, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Containers (ProductId, UomId, Quantity, LocationId, Weight, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES(22, 1, 240, 17, 310, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Containers (ProductId, UomId, Quantity, LocationId, Weight, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES(22, 2, 260, 18, 320, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Containers (ProductId, UomId, Quantity, LocationId, Weight, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES(24, 2, 240, 19, 330, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Containers (ProductId, UomId, Quantity, LocationId, Weight, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES(25, 2, 210, 20, 340, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Containers (ProductId, UomId, Quantity, LocationId, Weight, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES(26, 2, 250, 21, 350, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Containers (ProductId, UomId, Quantity, LocationId, Weight, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES(27, 2, 300, 22, 360, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Containers (ProductId, UomId, Quantity, LocationId, Weight, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES(28, 3, 200, 23, 370, 1, '', 0, '', 0);");



         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
