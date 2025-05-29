using System;
using System.Collections.Generic;

namespace Infrastructure.Reactive
{
    public class NotifyCollection<TCollection, TItem> : INotifyCollection<TCollection, TItem> where TCollection : ICollection<TItem>
    {
        public event Action<TCollection> OnCollectionChanged;

        private TCollection _collection;
        
        public NotifyCollection(TCollection collection = default)
        {
            _collection = collection;
        }

        public IEnumerable<TItem> Get() => _collection;

        public void Add(TItem item)
        {
            _collection.Add(item);
            OnCollectionChanged?.Invoke(_collection);
        }

        public void Remove(TItem item)
        {
            _collection.Remove(item);
            OnCollectionChanged?.Invoke(_collection);
        }

        public void Clear()
        {
            _collection.Clear();
            OnCollectionChanged?.Invoke(_collection);
        }
    }
}