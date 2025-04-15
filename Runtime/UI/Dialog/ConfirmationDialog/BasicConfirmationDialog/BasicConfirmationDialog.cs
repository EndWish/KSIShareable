using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace KSIShareable.UI.Dialog
{
    public class BasicConfirmationDialog : ConfirmationDialog
    {
        [Space(10)]
        [SerializeField] protected TextMeshProUGUI questionText;
        [SerializeField] protected TextMeshProUGUI yesBtnText;
        [SerializeField] protected TextMeshProUGUI noBtnText;

        public BasicConfirmationDialog Init(string questionText, string yesBtnText, string noBtnText, UnityAction actionOnYes, UnityAction actionOnNo) {
            this.questionText.text = questionText;
            this.yesBtnText.text = yesBtnText;
            this.noBtnText.text = noBtnText;

            base.Init(actionOnYes, actionOnNo);

            return this;
        }


    }
}
