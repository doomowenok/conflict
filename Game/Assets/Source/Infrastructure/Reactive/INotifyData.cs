using System;

namespace Infrastructure.Reactive
{
    public interface INotifyData<TData>
    {
        event Action<TData> OnValueChanged;
        TData Value { get; }
        void ChangeData(TData data);
    }
}