using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinasPendidikan.Shared.DTOs;

namespace DinasPendidikan.Shared.Interfaces
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventoryItemDto>> GetAllItemsAsync();
        Task<InventoryItemDto> GetItemByIdAsync(int id);
        Task<InventoryItemDto> AddItemAsync(InventoryItemCreateDto itemDto);
        Task UpdateItemAsync(int id, InventoryItemUpdateDto itemDto);
        Task DeleteItemAsync(int id);
        Task<InventoryTransactionDto> RecordTransactionAsync(InventoryTransactionCreateDto transactionDto);
    }
}
