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
            if (questionText != null) {
                this.questionText.StringReference.SetReference(questionText.TableReference, questionText.TableEntryReference);
                this.questionText.StringReference.Clear();
                this.questionText.StringReference.AddRange(questionText);
            }

            if (checkBtnText != null) {
                this.checkBtnText.StringReference.SetReference(checkBtnText.TableReference, checkBtnText.TableEntryReference);
                this.checkBtnText.StringReference.Clear();
                this.checkBtnText.StringReference.AddRange(checkBtnText);
            }

            base.Init(actionOnCheck);

            return this;
        }


    }
}
