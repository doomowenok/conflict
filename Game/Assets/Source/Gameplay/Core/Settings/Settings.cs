using Gameplay.Services.SaveLoad;
using Infrastructure.Reactive;
using UnityEngine;

namespace Gameplay.Core
{
    public sealed class Settings : ILoadable
    {
        private readonly ISavingService _savingService;
        
        public INotifyProperty<float> SoundVolume { get; private set; } = new AlwaysNotifyProperty<float>(1.0f);
        public INotifyProperty<float> MusicVolume { get; private set; } = new AlwaysNotifyProperty<float>(1.0f);

        public Settings(ISavingService savingService)
        {
            _savingService = savingService;
        }
        
        public void LoadSave()
        {
            if (_savingService.TryLoadSimple<float>(SettingsConstants.SoundSaveKey, out float soundVolume))
            {
                SoundVolume.Value = soundVolume;
            }

            if (_savingService.TryLoadSimple<float>(SettingsConstants.MusicSaveKey, out float musicVolume))
            {
                MusicVolume.Value = musicVolume;
            }
        }
    }
}