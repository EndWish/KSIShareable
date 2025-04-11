using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KSIShareable.UI
{
    public class FullScreenSetting : MonoBehaviour
    {
        [Serializable]
        public struct OptionData {
            public FullScreenMode mode;
            public string text;
        }

        public TMP_Dropdown Dropdown;
        [SerializeField] private List<OptionData> optionDatas = new List<OptionData>();
        private int index;

        private void OnEnable() {
            InitUI();
        }

        public void InitUI() {
            index = -1;

            Dropdown.options.Clear();
            for (int i = 0; i < optionDatas.Count; ++i) {
                OptionData optionData = optionDatas[i];
                Dropdown.options.Add(new TMP_Dropdown.OptionData(optionData.text));

                if (optionData.mode == Screen.fullScreenMode) {
                    index = i;
                    Dropdown.value = i;
                }
            }

#if DEBUG
            if(index == -1) {
                Debug.LogError("The currently applied FullScreenMode is not in the list.\nAdd the currently applied FullScreenMode to the list.");
            }
#endif
        }

        public void DropdownOptionChange(int index) {
            this.index = index;
        }

        public void Apply() {
            OptionData optionData = optionDatas[index];
            if (Screen.fullScreenMode != optionData.mode) {
                Screen.fullScreenMode = optionData.mode;
            }
        }

        private void Reset() {
            TryGetComponent<TMP_Dropdown>(out Dropdown);
        }

    }

}
