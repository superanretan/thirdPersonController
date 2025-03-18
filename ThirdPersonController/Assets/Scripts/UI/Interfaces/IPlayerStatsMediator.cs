using UnityEngine;

namespace UI.Interfaces
{
    public interface IPlayerStatsMediator
    {
        public void SetPlayerHpAmount(float actualHp);
        public void SetPlayerHpMaxAmount(float maxHp);
        public void SetPlayerNickname(string nickname);
     
    }
}
