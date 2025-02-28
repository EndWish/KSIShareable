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

        public ConfirmationDialog Init(LocalizedString questionText, LocalizedString yesBtnText, LocalizedString noBtnText, UnityAction actionOnYes, UnityAction actionOnNo) {
            if(questionText != null) {
                this.questionText.StringReference.SetReference(questionText.TableReference, questionText.TableEntryReference);
                this.questionText.StringReference.Clear();
                this.questionText.StringReference.AddRange(questionText);
            }

            if(yesBtnText != null) {
                this.yesBtnText.StringReference.SetReference(yesBtnText.TableReference, yesBtnText.TableEntryReference);
                this.yesBtnText.StringReference.Clear();
                this.yesBtnText.StringReference.AddRange(yesBtnText);
            }

            if(noBtnText != null) {
                this.noBtnText.StringReference.SetReference(noBtnText.TableReference, noBtnText.TableEntryReference);
                this.noBtnText.StringReference.Clear();
                this.noBtnText.StringReference.AddRange(noBtnText);
            }

            base.Init(actionOnYes, actionOnNo);

            return this;
        }


    }
}
