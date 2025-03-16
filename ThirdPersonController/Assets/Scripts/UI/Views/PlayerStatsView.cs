using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class PlayerStatsView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerNicknameText;
        [SerializeField] private Image playerHpFillImage;
        
        public void SetPlayerNickname(string playerNickname)
        {
            playerNicknameText.text = playerNickname;
        }

        public void SetPlayerHp(float playerHp)
        {
            playerHpFillImage.fillAmount = playerHp;
        }
    }
}
