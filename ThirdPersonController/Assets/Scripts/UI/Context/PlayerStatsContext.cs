using Signals;
using UI.Interfaces;
using UnityEngine;
using Zenject;

namespace UI.Context
{
    public class PlayerStatsContext : MonoBehaviour
    {
        private IPlayerStatsMediator _playerStatsMediator;
        private SignalBus _signalBus;
        
        [Inject]
        public void Construct(IPlayerStatsMediator playerStatsMediator, SignalBus signalBus)
        {
            _playerStatsMediator = playerStatsMediator;
            _signalBus = signalBus;
            SubscribeSignals();
        }

        private void SubscribeSignals()
        {
            _signalBus.Subscribe<PlayerHpChangeSignal>(OnHpChanged);
        }


        private void OnHpChanged(PlayerHpChangeSignal signal)
        {
            _playerStatsMediator.SetPlayerHpAmount(signal.PlayerHpChange);
        }
    }
    
}
