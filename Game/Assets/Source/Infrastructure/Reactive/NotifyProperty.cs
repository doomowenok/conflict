using System;

namespace Infrastructure.Reactive
{
    public class NotifyProperty<TProperty> : INotifyProperty<TProperty>
    {
        public event Action<TProperty> OnValueChanged;

        private TProperty _value;

        public NotifyProperty(TProperty value = default)
        {
            _value = value;
        }

        public TProperty Value
        {
            get => _value;
            set
            {
                if(_value.Equals(value)) return;

                _value = value;
                OnValueChanged?.Invoke(_value);
            }
        }
    }
}