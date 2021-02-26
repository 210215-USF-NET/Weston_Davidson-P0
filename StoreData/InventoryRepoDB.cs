using System.Collections.Generic;
using Model = StoreModel;
using Entity = StoreData.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModel;

namespace StoreData
{
    public class InventoryRepoDB : IInventoryRepoDB
    {

        private Entity.P0Context _context;
        private IMapper _mapper;

        public InventoryRepoDB(Entity.P0Context context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        public Inventory AddInventory(Inventory newInventory)
        {
            _context.Inventories.Add(_mapper.ParseInventory(newInventory));
            _context.SaveChanges();
            return newInventory;
        }

        public List<Inventory> GetInventory()
        {
            return _context.Inventories.Select(x => _mapper.ParseInventory(x)).ToList();
        }
    }
}