using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KSIShareable.UI
{
    public class ResolutionSetting : MonoBehaviour
    {
        public TMP_Dropdown Dropdown;
        [SerializeField] private bool Descending;
        private List<Resolution> resolutions = new List<Resolution>();
        private int index;

        private void OnEnable() {
            InitUI();
        }

        private void InitUI() {
            resolutions.AddRange(Screen.resolutions);
            if (Descending)
                resolutions.Reverse();

            Dropdown.options.Clear();
            foreach (Resolution resolution in resolutions) {
                TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
                option.text = resolution.width + " x " + resolution.height + " " + ((int)resolution.refreshRateRatio.value) + "hz";
                Dropdown.options.Add(option);

                if (Screen.width == resolution.width && Screen.height == resolution.height) {
                    index = Dropdown.options.Count - 1;
                    Dropdown.value = index;
                }

            }
            Dropdown.RefreshShownValue();
        }

        public void DropdownOptionChange(int index) {
            this.index = index;
        }

        public void Apply() {
            Resolution resolution = resolutions[index];
            if (Screen.width == resolution.width && Screen.height == resolution.height) {
                return;
            }
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode, resolution.refreshRateRatio);
        }

        private void Reset() {
            TryGetComponent<TMP_Dropdown>(out Dropdown);
        }

    }
}
