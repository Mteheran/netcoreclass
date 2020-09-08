using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AddReferencesForeignSaleAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Invoice_InvoiceIdInvoice",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Product_ProductIdProduct",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserType_UserTypeIdUser_Type",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserTypeIdUser_Type",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Sale_InvoiceIdInvoice",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_ProductIdProduct",
                table: "Sale");

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "IdInvoice",
                keyValue: new Guid("13cb25b4-251d-4494-8368-0f83bd5c45db"));

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "IdInvoice",
                keyValue: new Guid("206f6555-aa36-4b33-b3c9-3c4692f3f9ff"));

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "IdInvoice",
                keyValue: new Guid("610526ca-4cd2-48af-899c-cfec156ceb12"));

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "IdInvoice",
                keyValue: new Guid("6f9ef91a-b261-4e20-9f04-d741989a2716"));

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "IdInvoice",
                keyValue: new Guid("b1ec9013-efa0-41cd-a7d0-e8a9c4a5f6f4"));

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "IdInvoice",
                keyValue: new Guid("ca4b3b71-29ef-409c-a257-b1f22a5118ba"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: new Guid("3dc20695-ac3b-44e9-8629-7bc7ef7bf4b8"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: new Guid("4c39d5bb-2873-45b2-b386-010e8be3b9b8"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: new Guid("66118f36-1d7c-484d-94db-89e103486b1c"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: new Guid("70252e29-75d6-401b-9523-d3af982d554f"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: new Guid("8a1cd0d7-ddab-4b63-93e0-d23776a8abe5"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: new Guid("bdabc22c-6564-4e81-a5bb-2ce38c62901e"));

            migrationBuilder.DeleteData(
                table: "UserType",
                keyColumn: "IdUser_Type",
                keyValue: new Guid("06212072-5316-48ee-9da5-18a6dbde8188"));

            migrationBuilder.DeleteData(
                table: "UserType",
                keyColumn: "IdUser_Type",
                keyValue: new Guid("60ac4f26-657d-4a3e-9a6d-1798112a2d0c"));

            migrationBuilder.DeleteData(
                table: "UserType",
                keyColumn: "IdUser_Type",
                keyValue: new Guid("646a1b54-f6c4-4680-9f6c-016a47f2c929"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: new Guid("02cd4648-c78d-4341-b328-c0b17eaea6bf"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: new Guid("c9fa1367-b405-4dbc-a966-bb8c15715857"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: new Guid("f8450dd5-4f27-4f21-97da-eb5599a6d3c9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "IdUser",
                keyValue: new Guid("14f7a527-440f-4992-8e9e-32d2763961b7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "IdUser",
                keyValue: new Guid("1604c687-befd-4076-83fa-0445d00fe53f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "IdUser",
                keyValue: new Guid("41a0b586-44a9-438d-9b55-83a54e9e77e3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "IdUser",
                keyValue: new Guid("ae6862d0-8c01-4eb4-97e6-611ecd74ac13"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "IdUser",
                keyValue: new Guid("c9a1626b-1fdd-40fc-b479-d7927dd85b5a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "IdUser",
                keyValue: new Guid("d733e78e-fbf5-49d3-b5eb-73d121a155e3"));

            migrationBuilder.DropColumn(
                name: "UserTypeIdUser_Type",
                table: "User");

            migrationBuilder.DropColumn(
                name: "InvoiceIdInvoice",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "ProductIdProduct",
                table: "Sale");

            migrationBuilder.AlterColumn<string>(
                name: "Description_Category",
                table: "Category",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "IdCategory", "Description_Category" },
                values: new object[,]
                {
                    { new Guid("c84e4a52-c7cb-40d2-ab5f-ef79891823bf"), "Category 1" },
                    { new Guid("f4a6a679-54d2-46f0-9129-dfe52787b6f5"), "Category 2" },
                    { new Guid("e249a32d-81bb-4c93-8c17-8cd0c0c53c68"), "Category 3" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "IdUser_Type", "Description_Type" },
                values: new object[,]
                {
                    { new Guid("9963bb74-0a01-4f14-b013-743795f40829"), "Tipo Usuario 1" },
                    { new Guid("37402494-d2ea-4dc9-a083-625dfe62312e"), "Tipo Usuario 2" },
                    { new Guid("fb4ebe5c-9621-4e37-8d53-6644efa5e291"), "Tipo Usuario 3" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "IdProduct", "DescriptionProduct", "IdCategory", "Price" },
                values: new object[,]
                {
                    { new Guid("b75c9d57-ecd1-4a30-8a1f-6342ecb10e24"), "Producto727", new Guid("c84e4a52-c7cb-40d2-ab5f-ef79891823bf"), 747.7265110927292m },
                    { new Guid("092771ef-db98-454e-8ebe-859a6fc975ac"), "Producto729", new Guid("c84e4a52-c7cb-40d2-ab5f-ef79891823bf"), 1.7958469697254928m },
                    { new Guid("e3b22db5-4151-412a-9aba-8a7bee183d19"), "Producto729", new Guid("f4a6a679-54d2-46f0-9129-dfe52787b6f5"), 742.5219997495981m },
                    { new Guid("6ccc0031-7ee7-4333-b39b-c1761520e944"), "Producto729", new Guid("f4a6a679-54d2-46f0-9129-dfe52787b6f5"), 123.08091256910977m },
                    { new Guid("b413ec67-07ea-4ed4-832e-0a744cf169d5"), "Producto729", new Guid("e249a32d-81bb-4c93-8c17-8cd0c0c53c68"), 324.05241687039495m },
                    { new Guid("5aa3e1a5-5f52-43a6-9e88-f6c7f64f5f1a"), "Producto729", new Guid("e249a32d-81bb-4c93-8c17-8cd0c0c53c68"), 646.903195253994m }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "IdUser", "Email", "IdUser_Type", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("0e497fb1-45d7-4289-9862-168e42bc4c9e"), "correo732@correo.com", new Guid("9963bb74-0a01-4f14-b013-743795f40829"), "Pass732", "Usuario732" },
                    { new Guid("733e77f1-5807-4949-81e6-85f7bbfa6ea4"), "correo732@correo.com", new Guid("9963bb74-0a01-4f14-b013-743795f40829"), "Pass732", "Usuario732" },
                    { new Guid("cbd5784c-b61b-4620-8486-7230232c7342"), "correo732@correo.com", new Guid("37402494-d2ea-4dc9-a083-625dfe62312e"), "Pass732", "Usuario732" },
                    { new Guid("05854c59-08e3-49e5-b1a8-d766bb7c2ae4"), "correo732@correo.com", new Guid("37402494-d2ea-4dc9-a083-625dfe62312e"), "Pass732", "Usuario732" },
                    { new Guid("29d26a6d-8703-4807-bec1-720d4339be2a"), "correo732@correo.com", new Guid("fb4ebe5c-9621-4e37-8d53-6644efa5e291"), "Pass732", "Usuario732" },
                    { new Guid("70d40bcf-bf2d-44f4-8ffd-b8ee7863c222"), "correo732@correo.com", new Guid("fb4ebe5c-9621-4e37-8d53-6644efa5e291"), "Pass732", "Usuario732" }
                });

            migrationBuilder.InsertData(
                table: "Invoice",
                columns: new[] { "IdInvoice", "CreateTime", "IdUser" },
                values: new object[,]
                {
                    { new Guid("d15821d7-ecb5-4073-8600-6e5798ca5a98"), new DateTime(2020, 9, 8, 8, 7, 14, 734, DateTimeKind.Local).AddTicks(1185), new Guid("0e497fb1-45d7-4289-9862-168e42bc4c9e") },
                    { new Guid("c00dc7c9-469b-4cd2-a529-b76a6161d17e"), new DateTime(2020, 9, 8, 8, 7, 14, 734, DateTimeKind.Local).AddTicks(1663), new Guid("733e77f1-5807-4949-81e6-85f7bbfa6ea4") },
                    { new Guid("0bf1eb2b-4997-44c6-9282-c887e29d5640"), new DateTime(2020, 9, 8, 8, 7, 14, 734, DateTimeKind.Local).AddTicks(1686), new Guid("cbd5784c-b61b-4620-8486-7230232c7342") },
                    { new Guid("b82e1d12-ac42-4b9a-bddc-4d1e83ca03a5"), new DateTime(2020, 9, 8, 8, 7, 14, 734, DateTimeKind.Local).AddTicks(1693), new Guid("05854c59-08e3-49e5-b1a8-d766bb7c2ae4") },
                    { new Guid("5f6097db-7364-4426-b1d1-0764f8d92aa6"), new DateTime(2020, 9, 8, 8, 7, 14, 734, DateTimeKind.Local).AddTicks(1696), new Guid("29d26a6d-8703-4807-bec1-720d4339be2a") },
                    { new Guid("e433f928-c455-44fb-bc40-439ee0074d8c"), new DateTime(2020, 9, 8, 8, 7, 14, 734, DateTimeKind.Local).AddTicks(1702), new Guid("70d40bcf-bf2d-44f4-8ffd-b8ee7863c222") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_IdUser_Type",
                table: "User",
                column: "IdUser_Type");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_IdInvoice",
                table: "Sale",
                column: "IdInvoice");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_IdProduct",
                table: "Sale",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Invoice_IdInvoice",
                table: "Sale",
                column: "IdInvoice",
                principalTable: "Invoice",
                principalColumn: "IdInvoice",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Product_IdProduct",
                table: "Sale",
                column: "IdProduct",
                principalTable: "Product",
                principalColumn: "IdProduct",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserType_IdUser_Type",
                table: "User",
                column: "IdUser_Type",
                principalTable: "UserType",
                principalColumn: "IdUser_Type",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Invoice_IdInvoice",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Product_IdProduct",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserType_IdUser_Type",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_IdUser_Type",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Sale_IdInvoice",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_IdProduct",
                table: "Sale");

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "IdInvoice",
                keyValue: new Guid("0bf1eb2b-4997-44c6-9282-c887e29d5640"));

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "IdInvoice",
                keyValue: new Guid("5f6097db-7364-4426-b1d1-0764f8d92aa6"));

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "IdInvoice",
                keyValue: new Guid("b82e1d12-ac42-4b9a-bddc-4d1e83ca03a5"));

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "IdInvoice",
                keyValue: new Guid("c00dc7c9-469b-4cd2-a529-b76a6161d17e"));

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "IdInvoice",
                keyValue: new Guid("d15821d7-ecb5-4073-8600-6e5798ca5a98"));

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "IdInvoice",
                keyValue: new Guid("e433f928-c455-44fb-bc40-439ee0074d8c"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: new Guid("092771ef-db98-454e-8ebe-859a6fc975ac"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: new Guid("5aa3e1a5-5f52-43a6-9e88-f6c7f64f5f1a"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: new Guid("6ccc0031-7ee7-4333-b39b-c1761520e944"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: new Guid("b413ec67-07ea-4ed4-832e-0a744cf169d5"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: new Guid("b75c9d57-ecd1-4a30-8a1f-6342ecb10e24"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: new Guid("e3b22db5-4151-412a-9aba-8a7bee183d19"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: new Guid("c84e4a52-c7cb-40d2-ab5f-ef79891823bf"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: new Guid("e249a32d-81bb-4c93-8c17-8cd0c0c53c68"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: new Guid("f4a6a679-54d2-46f0-9129-dfe52787b6f5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "IdUser",
                keyValue: new Guid("05854c59-08e3-49e5-b1a8-d766bb7c2ae4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "IdUser",
                keyValue: new Guid("0e497fb1-45d7-4289-9862-168e42bc4c9e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "IdUser",
                keyValue: new Guid("29d26a6d-8703-4807-bec1-720d4339be2a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "IdUser",
                keyValue: new Guid("70d40bcf-bf2d-44f4-8ffd-b8ee7863c222"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "IdUser",
                keyValue: new Guid("733e77f1-5807-4949-81e6-85f7bbfa6ea4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "IdUser",
                keyValue: new Guid("cbd5784c-b61b-4620-8486-7230232c7342"));

            migrationBuilder.DeleteData(
                table: "UserType",
                keyColumn: "IdUser_Type",
                keyValue: new Guid("37402494-d2ea-4dc9-a083-625dfe62312e"));

            migrationBuilder.DeleteData(
                table: "UserType",
                keyColumn: "IdUser_Type",
                keyValue: new Guid("9963bb74-0a01-4f14-b013-743795f40829"));

            migrationBuilder.DeleteData(
                table: "UserType",
                keyColumn: "IdUser_Type",
                keyValue: new Guid("fb4ebe5c-9621-4e37-8d53-6644efa5e291"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserTypeIdUser_Type",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceIdInvoice",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductIdProduct",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Category",
                table: "Category",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250);

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
                name: "IX_User_UserTypeIdUser_Type",
                table: "User",
                column: "UserTypeIdUser_Type");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_InvoiceIdInvoice",
                table: "Sale",
                column: "InvoiceIdInvoice");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ProductIdProduct",
                table: "Sale",
                column: "ProductIdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Invoice_InvoiceIdInvoice",
                table: "Sale",
                column: "InvoiceIdInvoice",
                principalTable: "Invoice",
                principalColumn: "IdInvoice",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Product_ProductIdProduct",
                table: "Sale",
                column: "ProductIdProduct",
                principalTable: "Product",
                principalColumn: "IdProduct",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserType_UserTypeIdUser_Type",
                table: "User",
                column: "UserTypeIdUser_Type",
                principalTable: "UserType",
                principalColumn: "IdUser_Type",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
