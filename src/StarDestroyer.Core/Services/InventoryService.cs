using System;
using System.Collections.Generic;
using StarDestroyer.Core.Entities;
using StarDestroyer.Core.Repository;

namespace StarDestroyer.Core.Services
{
    public interface IInventoryService
    {
        IList<AssaultItem> GetAllAssaultItems();
        AssaultItem GetAssaultItemById(int id);
        AssaultItem SaveAssaultItem(AssaultItem item);
    }

    public class InventoryService : IInventoryService
    {
        private IRepository<AssaultItem> _repository;

        public InventoryService() : this(null) { }

        public InventoryService(IRepository<AssaultItem> repository)
        {
            _repository = repository ?? new Repository<AssaultItem>();
        }

        public IList<AssaultItem> GetAllAssaultItems()
        {
            return _repository.GetAll();
        }

        public AssaultItem GetAssaultItemById(int id)
        {
            return _repository.GetById(id);
        }

        public AssaultItem SaveAssaultItem(AssaultItem item)
        {
            int id;
            if(item.Id > 0)
            {
                _repository.Update(item);
                id = item.Id;
            }
            else
            {
                id = _repository.Save(item);
            }

            return _repository.GetById(id);
        }
    }
}