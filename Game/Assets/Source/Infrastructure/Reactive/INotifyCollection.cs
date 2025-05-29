using System;
using System.Collections.Generic;

namespace Infrastructure.Reactive
{
    public interface INotifyCollection<out TCollection, TItem> where TCollection : ICollection<TItem>
    {
        event Action<TCollection> OnCollectionChanged;
        IEnumerable<TItem> Get();
        void Add(TItem item);
        void Remove(TItem item);
        void Clear();
    }
}