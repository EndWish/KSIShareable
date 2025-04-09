using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace KSIShareable.UI.Dialog
{
    public abstract class ConfirmationDialog : Dialog
    {

        public UnityEvent OnClickYes;
        public UnityEvent OnClickNo;

        protected ConfirmationDialog Init(UnityAction actionOnYes, UnityAction actionOnNo) {
            OnClickYes.RemoveAllListeners();
            if (actionOnYes != null)
                this.OnClickYes.AddListener(actionOnYes);
            OnClickNo.RemoveAllListeners();
            if (actionOnNo != null)
                this.OnClickNo.AddListener(actionOnNo);

            LayoutRebuilder.ForceRebuildLayoutImmediate(dialogRectTransform);

            return this;
        }

        public void ActOnClickYes() {
            OnClickYes?.Invoke();
            ExecuteCloseAction();
        }
        public void ActOnClickNo() {
            OnClickNo?.Invoke();
            ExecuteCloseAction();
        }
    }
}