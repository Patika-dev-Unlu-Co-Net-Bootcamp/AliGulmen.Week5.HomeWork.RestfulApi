using Microsoft.EntityFrameworkCore.Migrations;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Migrations
{
    public partial class insertDataToTables4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(ProductCode, Description, RotationId, LifeTime, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('87965493291', 'Prod1', 9, 365, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Products(ProductCode, Description, RotationId, LifeTime, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('83245433291', 'Prod2', 10, 365, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Products(ProductCode, Description, RotationId, LifeTime, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('87965434534', 'Prod3', 9, 365, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Products(ProductCode, Description, RotationId, LifeTime, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('21365493291', 'Prod4', 11, 365, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Products(ProductCode, Description, RotationId, LifeTime, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('89786324541', 'Prod5', 9, 365, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Products(ProductCode, Description, RotationId, LifeTime, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('21432547867', 'Prod6', 11, 365, 1, '', 0, '', 0);");
            migrationBuilder.Sql("INSERT INTO Products(ProductCode, Description, RotationId, LifeTime, IsActive, CreationDate, CreatedBy, UpdateDate, UpdatedBy) VALUES('75665453434', 'Prod7', 11, 365, 1, '', 0, '', 0);");



        

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
