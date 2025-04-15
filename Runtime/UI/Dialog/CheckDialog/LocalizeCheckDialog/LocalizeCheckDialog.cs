using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

namespace KSIShareable.UI.Dialog
{
    public class LocalizeCheckDialog : CheckDialog
    {
        [Space(10)]
        [SerializeField] protected LocalizeStringEvent questionText;
        [SerializeField] protected LocalizeStringEvent checkBtnText;

        public LocalizeCheckDialog Init(LocalizedString questionText, LocalizedString checkBtnText, UnityAction actionOnCheck) {
            this.questionText.StringReference = questionText;
            this.checkBtnText.StringReference = checkBtnText;

            base.Init(actionOnCheck);

            return this;
        }


    }
}
