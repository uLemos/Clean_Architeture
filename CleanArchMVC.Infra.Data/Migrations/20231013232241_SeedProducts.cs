using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMVC.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES('Caderno espiral', 'Caderno espiral 100 folhas', 7.45,50, 'caderno1,jpg', 1 )");

            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES('Estojo escolar', 'Estoja escolar cinza', 5.65,70, 'estojo1,jpg', 1 )");

            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" +
            "VALUES('Borracha escolar', 'Borracha escolar branca', 5.75,70, 'borracha1,jpg', 1 )");

            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" +
            "VALUES('Calculadora escolar', 'Calculadora simples', 15.95,80, 'calculadora1,jpg', 1 )");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FORM Products");
        }
    }
}
