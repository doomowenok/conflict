using System;

namespace Infrastructure.Reactive
{
    public class AlwaysNotifyProperty<TProperty> : INotifyProperty<TProperty>
    {
        public event Action<TProperty> OnValueChanged;

        private TProperty _value;

        public AlwaysNotifyProperty(TProperty value = default)
        {
            _value = value;
        }

        public TProperty Value
        {
            get => _value;
            set
            {
                _value = value;
                OnValueChanged?.Invoke(_value);
            }
        }
    }
}