using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMarket.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                -- Categories
                SET IDENTITY_INSERT Categories ON;
                INSERT INTO Categories (Id, Name) VALUES
                (1, 'Laptop'),
                (2, 'Smartphone'),
                (3, 'Tablet'),
                (4, 'Accessories');
                SET IDENTITY_INSERT Categories OFF;

                -- Products
                SET IDENTITY_INSERT Products ON;
                INSERT INTO Products (Id, Name, Price, Description) VALUES
                (1, 'HP Pavilion 14', 407.79, 'Lightweight and powerful laptop'),
                (2, 'Lenovo IdeaPad 3', 359.99, 'Affordable and reliable laptop'),
                (3, 'Dell Inspiron 15', 549.99, 'Versatile everyday laptop'),
                (4, 'Apple iPhone 13', 799.99, 'Latest iPhone with great camera'),
                (5, 'Samsung Galaxy S21', 699.99, 'Flagship Android smartphone'),
                (6, 'Google Pixel 6', 599.99, 'Clean Android experience'),
                (7, 'iPad Air', 599.00, 'Powerful and portable tablet'),
                (8, 'Samsung Galaxy Tab S7', 649.99, 'High-performance Android tablet'),
                (9, 'Amazon Fire HD 10', 149.99, 'Budget-friendly tablet'),
                (10, 'Logitech MX Master 3', 99.99, 'Ergonomic wireless mouse'),
                (11, 'Apple Magic Keyboard', 129.99, 'Compact keyboard for Mac'),
                (12, 'Anker PowerCore 10000', 29.99, 'Portable power bank');
                SET IDENTITY_INSERT Products OFF;

                -- Product Images
                SET IDENTITY_INSERT ProductImage ON;
                INSERT INTO ProductImage (Id, ProductId, FileName) VALUES
                (1, 1, '1-1.png'), (2, 1, '1-2.png'),
                (3, 2, '2-1.png'), (4, 2, '2-2.png'),
                (5, 3, '3-1.png'), (6, 3, '3-2.png'),
                (7, 4, '4-1.png'), (8, 4, '4-2.png'),
                (9, 5, '5-1.png'), (10, 5, '5-2.png'),
                (11, 6, '6-1.png'), (12, 6, '6-2.png'),
                (13, 7, '7-1.png'), (14, 7, '7-2.png'),
                (15, 8, '8-1.png'), (16, 8, '8-2.png'),
                (17, 9, '9-1.png'), (18, 9, '9-2.png'),
                (19, 10, '10-1.png'), (20, 10, '10-2.png'),
                (21, 11, '11-1.png'), (22, 11, '11-2.png'),
                (23, 12, '12-1.png'), (24, 12, '12-2.png');
                SET IDENTITY_INSERT ProductImage OFF;

                -- CategoryProduct (join table)
                INSERT INTO CategoryProduct (CategoriesId, ProductsId) VALUES
                (1, 1), (1, 2), (1, 3),  -- Laptops
                (2, 4), (2, 5), (2, 6),  -- Smartphones
                (3, 7), (3, 8), (3, 9),  -- Tablets
                (4, 10), (4, 11), (4, 12); -- Accessories
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
