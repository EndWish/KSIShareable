using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

namespace KSIShareable.UI.Dialog
{
    public class LocalizeConfirmationDialog : ConfirmationDialog
    {
        [Space(10)]
        [SerializeField] protected LocalizeStringEvent questionText;
        [SerializeField] protected LocalizeStringEvent yesBtnText;
        [SerializeField] protected LocalizeStringEvent noBtnText;

        public LocalizeConfirmationDialog Init(LocalizedString questionText, LocalizedString yesBtnText, LocalizedString noBtnText, UnityAction actionOnYes, UnityAction actionOnNo) {
            this.questionText.StringReference = questionText;
            this.yesBtnText.StringReference = yesBtnText;
            this.noBtnText.StringReference = noBtnText;

            base.Init(actionOnYes, actionOnNo);

            return this;
        }


    }
}
