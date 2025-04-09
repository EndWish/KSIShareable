using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace KSIShareable.UI.Dialog
{

    public abstract class CheckDialog : Dialog
    {

        public UnityEvent OnClickCheck;

        protected CheckDialog Init(UnityAction actionOnYes) {
            OnClickCheck.RemoveAllListeners();
            if (actionOnYes != null)
                this.OnClickCheck.AddListener(actionOnYes);

            LayoutRebuilder.ForceRebuildLayoutImmediate(dialogRectTransform);

            return this;
        }

        public void ActOnClickYes() {
            OnClickCheck?.Invoke();
            ExecuteCloseAction();
        }
    }
}