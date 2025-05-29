using System.Collections.Generic;
using Gameplay.Extensions;
using VContainer;

namespace Gameplay.Services.SaveLoad
{
    public sealed class SaveLoadService : ISaveLoadService
    {
        private readonly IObjectResolver _objectResolver;
        
        private readonly List<ILoadable> _loadables = new List<ILoadable>(32);

        public SaveLoadService(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }
        
        public void RegisterManually<TData>(TData data) where TData : ILoadable
        {
            _loadables.Add(data);
        }

        public void RegisterAutomatically()
        {
            TypeExtensions
                .FindAllTypesImplementing<ILoadable>()
                .ForEach(type =>
                {
                    _loadables.Add(_objectResolver.Resolve(type) as ILoadable);
                });
        }

        public void LoadSave()
        {
            _loadables.ForEach(data => data.LoadSave());
        }
    }
}