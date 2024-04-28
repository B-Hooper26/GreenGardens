﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenGardens.Migrations
{
    public partial class addingproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    f_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    s_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    Customerid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    f_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    s_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    loyalty_points = table.Column<int>(type: "int", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.Customerid);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Productid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Stock_Quantity = table.Column<int>(type: "int", nullable: true),
                    Expected_Stock = table.Column<int>(type: "int", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Productid);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    customerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => new { x.productId, x.customerId });
                    table.ForeignKey(
                        name: "FK_order_customer_customerId",
                        column: x => x.customerId,
                        principalTable: "customer",
                        principalColumn: "Customerid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_product_productId",
                        column: x => x.productId,
                        principalTable: "product",
                        principalColumn: "Productid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_customerId",
                table: "order",
                column: "customerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "product");
        }
    }
}
