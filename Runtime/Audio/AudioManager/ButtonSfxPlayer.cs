using UnityEngine;
using UnityEngine.UI;

namespace KSIShareable.Audio
{
    public class ButtonSfxPlayer : MonoBehaviour
    {
        [SerializeField] private string sfxKey = "ButtonClick";

        private void Awake() {
            Button button = GetComponent<Button>();
            if (button != null) {
                button.onClick.AddListener(() => PlaySfx());
            }
        }

        private void PlaySfx() {
            AudioManager.Instance.PlaySfx(sfxKey);
        }
    }
}