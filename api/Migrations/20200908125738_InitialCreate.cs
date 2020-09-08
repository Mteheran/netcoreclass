using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    IdCategory = table.Column<Guid>(nullable: false),
                    Description_Category = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    IdUser_Type = table.Column<Guid>(nullable: false),
                    Description_Type = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.IdUser_Type);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    IdProduct = table.Column<Guid>(nullable: false),
                    DescriptionProduct = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    IdCategory = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.IdProduct);
                    table.ForeignKey(
                        name: "FK_Product_Category_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Category",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    IdUser_Type = table.Column<Guid>(nullable: false),
                    UserTypeIdUser_Type = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_User_UserType_UserTypeIdUser_Type",
                        column: x => x.UserTypeIdUser_Type,
                        principalTable: "UserType",
                        principalColumn: "IdUser_Type",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    IdInvoice = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IdUser = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.IdInvoice);
                    table.ForeignKey(
                        name: "FK_Invoice_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    IdSale = table.Column<Guid>(nullable: false),
                    IdInvoice = table.Column<Guid>(nullable: false),
                    IdProduct = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Product_Price = table.Column<decimal>(nullable: false),
                    InvoiceIdInvoice = table.Column<Guid>(nullable: true),
                    ProductIdProduct = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.IdSale);
                    table.ForeignKey(
                        name: "FK_Sale_Invoice_InvoiceIdInvoice",
                        column: x => x.InvoiceIdInvoice,
                        principalTable: "Invoice",
                        principalColumn: "IdInvoice",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sale_Product_ProductIdProduct",
                        column: x => x.ProductIdProduct,
                        principalTable: "Product",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "IdCategory", "Description_Category" },
                values: new object[,]
                {
                    { new Guid("02cd4648-c78d-4341-b328-c0b17eaea6bf"), "Category 1" },
                    { new Guid("c9fa1367-b405-4dbc-a966-bb8c15715857"), "Category 2" },
                    { new Guid("f8450dd5-4f27-4f21-97da-eb5599a6d3c9"), "Category 3" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "IdUser", "Email", "IdUser_Type", "Password", "UserTypeIdUser_Type", "Username" },
                values: new object[,]
                {
                    { new Guid("ae6862d0-8c01-4eb4-97e6-611ecd74ac13"), "correo82@correo.com", new Guid("646a1b54-f6c4-4680-9f6c-016a47f2c929"), "Pass82", null, "Usuario82" },
                    { new Guid("c9a1626b-1fdd-40fc-b479-d7927dd85b5a"), "correo82@correo.com", new Guid("646a1b54-f6c4-4680-9f6c-016a47f2c929"), "Pass82", null, "Usuario82" },
                    { new Guid("41a0b586-44a9-438d-9b55-83a54e9e77e3"), "correo82@correo.com", new Guid("06212072-5316-48ee-9da5-18a6dbde8188"), "Pass82", null, "Usuario82" },
                    { new Guid("14f7a527-440f-4992-8e9e-32d2763961b7"), "correo82@correo.com", new Guid("06212072-5316-48ee-9da5-18a6dbde8188"), "Pass82", null, "Usuario82" },
                    { new Guid("d733e78e-fbf5-49d3-b5eb-73d121a155e3"), "correo82@correo.com", new Guid("60ac4f26-657d-4a3e-9a6d-1798112a2d0c"), "Pass82", null, "Usuario82" },
                    { new Guid("1604c687-befd-4076-83fa-0445d00fe53f"), "correo82@correo.com", new Guid("60ac4f26-657d-4a3e-9a6d-1798112a2d0c"), "Pass82", null, "Usuario82" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "IdUser_Type", "Description_Type" },
                values: new object[,]
                {
                    { new Guid("646a1b54-f6c4-4680-9f6c-016a47f2c929"), "Tipo Usuario 1" },
                    { new Guid("06212072-5316-48ee-9da5-18a6dbde8188"), "Tipo Usuario 2" },
                    { new Guid("60ac4f26-657d-4a3e-9a6d-1798112a2d0c"), "Tipo Usuario 3" }
                });

            migrationBuilder.InsertData(
                table: "Invoice",
                columns: new[] { "IdInvoice", "CreateTime", "IdUser" },
                values: new object[,]
                {
                    { new Guid("ca4b3b71-29ef-409c-a257-b1f22a5118ba"), new DateTime(2020, 9, 8, 7, 57, 38, 83, DateTimeKind.Local).AddTicks(298), new Guid("ae6862d0-8c01-4eb4-97e6-611ecd74ac13") },
                    { new Guid("610526ca-4cd2-48af-899c-cfec156ceb12"), new DateTime(2020, 9, 8, 7, 57, 38, 83, DateTimeKind.Local).AddTicks(737), new Guid("c9a1626b-1fdd-40fc-b479-d7927dd85b5a") },
                    { new Guid("6f9ef91a-b261-4e20-9f04-d741989a2716"), new DateTime(2020, 9, 8, 7, 57, 38, 83, DateTimeKind.Local).AddTicks(754), new Guid("41a0b586-44a9-438d-9b55-83a54e9e77e3") },
                    { new Guid("13cb25b4-251d-4494-8368-0f83bd5c45db"), new DateTime(2020, 9, 8, 7, 57, 38, 83, DateTimeKind.Local).AddTicks(757), new Guid("14f7a527-440f-4992-8e9e-32d2763961b7") },
                    { new Guid("206f6555-aa36-4b33-b3c9-3c4692f3f9ff"), new DateTime(2020, 9, 8, 7, 57, 38, 83, DateTimeKind.Local).AddTicks(760), new Guid("d733e78e-fbf5-49d3-b5eb-73d121a155e3") },
                    { new Guid("b1ec9013-efa0-41cd-a7d0-e8a9c4a5f6f4"), new DateTime(2020, 9, 8, 7, 57, 38, 83, DateTimeKind.Local).AddTicks(766), new Guid("1604c687-befd-4076-83fa-0445d00fe53f") }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "IdProduct", "DescriptionProduct", "IdCategory", "Price" },
                values: new object[,]
                {
                    { new Guid("70252e29-75d6-401b-9523-d3af982d554f"), "Producto77", new Guid("02cd4648-c78d-4341-b328-c0b17eaea6bf"), 838.5605164051804m },
                    { new Guid("8a1cd0d7-ddab-4b63-93e0-d23776a8abe5"), "Producto78", new Guid("02cd4648-c78d-4341-b328-c0b17eaea6bf"), 945.6941801801762m },
                    { new Guid("66118f36-1d7c-484d-94db-89e103486b1c"), "Producto78", new Guid("c9fa1367-b405-4dbc-a966-bb8c15715857"), 714.1263292702504m },
                    { new Guid("bdabc22c-6564-4e81-a5bb-2ce38c62901e"), "Producto78", new Guid("c9fa1367-b405-4dbc-a966-bb8c15715857"), 549.8297109966305m },
                    { new Guid("3dc20695-ac3b-44e9-8629-7bc7ef7bf4b8"), "Producto78", new Guid("f8450dd5-4f27-4f21-97da-eb5599a6d3c9"), 729.0270276037171m },
                    { new Guid("4c39d5bb-2873-45b2-b386-010e8be3b9b8"), "Producto78", new Guid("f8450dd5-4f27-4f21-97da-eb5599a6d3c9"), 314.4367776412688m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_IdUser",
                table: "Invoice",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdCategory",
                table: "Product",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_InvoiceIdInvoice",
                table: "Sale",
                column: "InvoiceIdInvoice");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ProductIdProduct",
                table: "Sale",
                column: "ProductIdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeIdUser_Type",
                table: "User",
                column: "UserTypeIdUser_Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "UserType");
        }
    }
}
