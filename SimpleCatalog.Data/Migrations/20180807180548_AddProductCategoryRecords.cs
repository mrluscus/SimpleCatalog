using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SimpleCatalog.Data.Migrations
{
    public partial class AddProductCategoryRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Initial populate of ProductCategory table

            /*
             * Одежда, обувь, аксессуары
             *   Женская одежда
             *     Верхняя
             *       Плащи
             *       Куртки
             *       Шубы
             *     Одежда для спорта и фитнеса
             *       Топы
             *       Леггинсы
             *       Спортивная обувь
             *   Мужская одежда
             *     Аксессуары
             *       Галстуки
             *       Ремни
             *       Шарфы
             *       Солнцезащитные очки
             *     Обувь
             *       Ботинки
             *       Кроссовки
             *       Сапоги
             */
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var id3 = Guid.NewGuid();
            var id4 = Guid.NewGuid();
            var id5 = Guid.NewGuid();
            var id6 = Guid.NewGuid();
            var id7 = Guid.NewGuid();
            var id8 = Guid.NewGuid();
            var id9 = Guid.NewGuid();
            var id10 = Guid.NewGuid();
            var id11 = Guid.NewGuid();
            var id12 = Guid.NewGuid();
            var id13 = Guid.NewGuid();
            var id14 = Guid.NewGuid();
            var id15 = Guid.NewGuid();
            var id16 = Guid.NewGuid();
            var id17 = Guid.NewGuid();
            var id18 = Guid.NewGuid();
            var id19 = Guid.NewGuid();
            var id20 = Guid.NewGuid();

            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id1, "Одежда, обувь, аксессуары", null });
            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id2, "Женская одежда", id1 });
            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id3, "Верхняя", id2 });
            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id4, "Плащи", id3 });
            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id5, "Куртки", id3 });
            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id6, "Шубы", id3 });
            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id7, "Одежда для спорта и фитнеса", id2 });
            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id8, "Топы", id7 });
            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id9, "Леггинсы", id7 });
            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id10, "Спортивная обувь", id7 });
            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id11, "Мужская одежда", id1 });
            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id12, "Аксессуары", id11 });
            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id13, "Галстуки", id12 });
            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id14, "Ремни", id12 });
            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id15, "Шарфы", id12 });
            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id16, "Солнцезащитные очки", id12 });
            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id17, "Обувь", id11 });
            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id18, "Ботинки", id17 });
            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id19, "Кроссовки", id17 });
            migrationBuilder.InsertData("ProductCategory", new[] { "Id", "Name", "ParentId" }, new object[] { id20, "Сапоги", id17 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}