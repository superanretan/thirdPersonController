using System;
using UI.Interfaces;
using UI.Views;
using UnityEngine;

namespace UI.Mediators
{
    public class PlayerStatsMediator : MonoBehaviour, IPlayerStatsMediator
    {
        private PlayerStatsView _playerStatsView;
        private float _playerHpMaxAmount;
        private float _playerManaMaxAmount;
        
        private void Start()
        {
            TryGetComponent(out _playerStatsView);
        }

        public void SetPlayerHpAmount(float actualHp)
        {
            _playerStatsView.SetPlayerHp(actualHp/_playerHpMaxAmount);
        }

        public void SetPlayerHpMaxAmount(float maxHp)
        {
            _playerHpMaxAmount = maxHp;
        }
        
        public void SetPlayerNickname(string nickname)
        {
            _playerStatsView.SetPlayerNickname(nickname);
        }
    }
}
