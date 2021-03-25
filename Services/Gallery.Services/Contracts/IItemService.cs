using Gallery.Enums;
using Gallery.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Services.Contracts
{
    public interface IItemService
    {
        // Create
        Task<int?> CreateAsync(ItemCreateSM model);
        // Read 
        // Update
        // Delete

        // DisplayAll
        Task<IEnumerable<ItemSM>> DisplayAllItemsAsync(CommercialType? type);

        Task<ItemDetailsSM> GetByIdAsync(int itemId);
    }
}
