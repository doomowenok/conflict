using System;

namespace Infrastructure.Reactive
{
    public interface INotifyProperty<TProperty>
    {
        event Action<TProperty> OnValueChanged;
        TProperty Value { get; set; }   
    }
}