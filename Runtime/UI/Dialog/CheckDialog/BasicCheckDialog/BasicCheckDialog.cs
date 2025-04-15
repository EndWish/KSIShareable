using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace KSIShareable.UI.Dialog
{
    public class BasicCheckDialog : CheckDialog
    {
        [Space(10)]
        [SerializeField] protected TextMeshProUGUI questionText;
        [SerializeField] protected TextMeshProUGUI checkBtnText;

        public BasicCheckDialog Init(string questionText, string checkBtnText, UnityAction actionOnCheck) {
            this.questionText.text = questionText;
            this.checkBtnText.text = checkBtnText;

            base.Init(actionOnCheck);

            return this;
        }


    }
}
