using Cysharp.Threading.Tasks;
using Gameplay.Services.SaveLoad;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;

namespace Gameplay.Boot
{
    public sealed class BootState : IState
    {
        private readonly IApplicationStateMachine _stateMachine;
        private readonly ISaveLoadService _saveLoadService;

        public BootState(IApplicationStateMachine stateMachine, ISaveLoadService saveLoadService)
        {
            _stateMachine = stateMachine;
            _saveLoadService = saveLoadService;
        }

        public UniTask Enter()
        {
            _saveLoadService.RegisterAutomatically();
            _saveLoadService.LoadSave();
            return UniTask.CompletedTask;
        }

        public UniTask Exit()
        {
            return UniTask.CompletedTask;
        }
    }
}