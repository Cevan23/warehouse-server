﻿using warehouse_BE.Application.Areas.CreateArea;
using warehouse_BE.Application.Inventories.Commands.DeleteInventoryProduct;
using warehouse_BE.Application.Inventories.Queries.GetInventoriesByStorage;
using warehouse_BE.Application.Inventories.Queries.GetListProductOfInventory;
using warehouse_BE.Application.Response;

namespace warehouse_BE.Web.Endpoints
{
    public class Inventories : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                .RequireAuthorization()
                .MapPost(GetInventoryProductList)
                .MapDelete(DeleteInventoryProduct,"{id}")
                .MapPost(GetInventoriesByStorage,"storageId")
                ;
        }
        public Task<InventoryProductsListVM> GetInventoryProductList(ISender sender, GetListProductOfInventory query)
        {
            return sender.Send(query);
        }
        public Task<ResponseDto> DeleteInventoryProduct(ISender sender,int id)
        {
            return sender.Send(new DeleteInventoryProductCommand { Id = id });
        }
        public Task<InventoryListVM> GetInventoriesByStorage(ISender sender, GetInventoriesByStorageQuery query)
        {
            return sender.Send(query);
        }
    }
}
