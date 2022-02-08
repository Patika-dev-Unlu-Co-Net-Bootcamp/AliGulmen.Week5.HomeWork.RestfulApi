using Microsoft.EntityFrameworkCore.Migrations;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Migrations
{
    public partial class insertDataToTables6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Stocks (ProductId, ReadyToShip, StockOnRack, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES(22, 12, 145, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Stocks (ProductId, ReadyToShip, StockOnRack, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES(23, 1, 56, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Stocks (ProductId, ReadyToShip, StockOnRack, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES(24, 32, 44, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Stocks (ProductId, ReadyToShip, StockOnRack, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES(25, 56, 3, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Stocks (ProductId, ReadyToShip, StockOnRack, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES(26, 23, 1, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Stocks (ProductId, ReadyToShip, StockOnRack, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES(27, 12, 354, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Stocks (ProductId, ReadyToShip, StockOnRack, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES(28, 90, 32, 1, '', 0, '', 0);");
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
