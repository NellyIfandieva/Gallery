using Microsoft.EntityFrameworkCore.Migrations;

namespace Gallery.Data.Migrations
{
    public partial class AddedItemImagesDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemImage_Items_ItemId",
                table: "ItemImage");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProduct_Orders_OrderId",
                table: "OrderedProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderedProduct",
                table: "OrderedProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemImage",
                table: "ItemImage");

            migrationBuilder.RenameTable(
                name: "OrderedProduct",
                newName: "OrderedProducts");

            migrationBuilder.RenameTable(
                name: "ItemImage",
                newName: "ItemImages");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedProduct_OrderId",
                table: "OrderedProducts",
                newName: "IX_OrderedProducts_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemImage_ItemId",
                table: "ItemImages",
                newName: "IX_ItemImages_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderedProducts",
                table: "OrderedProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemImages",
                table: "ItemImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemImages_Items_ItemId",
                table: "ItemImages",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId",
                table: "OrderedProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemImages_Items_ItemId",
                table: "ItemImages");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId",
                table: "OrderedProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderedProducts",
                table: "OrderedProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemImages",
                table: "ItemImages");

            migrationBuilder.RenameTable(
                name: "OrderedProducts",
                newName: "OrderedProduct");

            migrationBuilder.RenameTable(
                name: "ItemImages",
                newName: "ItemImage");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedProducts_OrderId",
                table: "OrderedProduct",
                newName: "IX_OrderedProduct_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemImages_ItemId",
                table: "ItemImage",
                newName: "IX_ItemImage_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderedProduct",
                table: "OrderedProduct",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemImage",
                table: "ItemImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemImage_Items_ItemId",
                table: "ItemImage",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProduct_Orders_OrderId",
                table: "OrderedProduct",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
