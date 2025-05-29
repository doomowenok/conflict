using Infrastructure.MVVM;
using Infrastructure.Reactive;
using VContainer;

namespace Gameplay.Core
{
    public sealed class SettingsScreenViewModel : BaseViewModel
    {
        [Inject] private readonly Settings _settings;
        
        public INotifyProperty<float> SoundVolume { get; private set; } = new AlwaysNotifyProperty<float>(1.0f);
        public INotifyProperty<float> MusicVolume { get; private set; } = new AlwaysNotifyProperty<float>(1.0f);
        
        public override void Subscribe()
        {
            _settings.SoundVolume.OnValueChanged += UpdateSoundVolume;
            _settings.MusicVolume.OnValueChanged += UpdateMusicVolume;
            UpdateSoundVolume(_settings.SoundVolume.Value);
            UpdateMusicVolume(_settings.MusicVolume.Value);
        }

        public override void Unsubscribe()
        {
            _settings.SoundVolume.OnValueChanged -= UpdateSoundVolume;
            _settings.MusicVolume.OnValueChanged -= UpdateMusicVolume;
        }

        private void UpdateSoundVolume(float value)
        {
            SoundVolume.Value = value;
        }

        private void UpdateMusicVolume(float value)
        {
            MusicVolume.Value = value;
        }
    }
}