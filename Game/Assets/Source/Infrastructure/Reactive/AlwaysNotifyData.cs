using System;

namespace Infrastructure.Reactive
{
    public sealed class AlwaysNotifyData<TData> : INotifyData<TData>
    {
        public event Action<TData> OnValueChanged;
        
        public TData Value { get; private set; }

        public AlwaysNotifyData(TData data = default)
        {
            Value = data;
        }
        
        public void ChangeData(TData data)
        {
            Value = data;
            OnValueChanged?.Invoke(Value);
        }
    }
}