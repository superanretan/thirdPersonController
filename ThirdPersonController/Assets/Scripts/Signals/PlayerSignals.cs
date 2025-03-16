using UnityEngine;

namespace Signals
{
    public class PlayerHpChangeSignal
    {
        public float PlayerHpChange { get; }
        
        
        public PlayerHpChangeSignal(float hpChange)
        {
            PlayerHpChange = hpChange;
        }
    }
}
