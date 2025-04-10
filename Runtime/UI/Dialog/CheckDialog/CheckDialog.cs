using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace KSIShareable.UI.Dialog
{

    public abstract class CheckDialog : Dialog
    {

        public UnityEvent OnClickCheck;

        protected CheckDialog Init(UnityAction actionOnCheck) {
            OnClickCheck.RemoveAllListeners();
            if (actionOnCheck != null)
                this.OnClickCheck.AddListener(actionOnCheck);

            LayoutRebuilder.ForceRebuildLayoutImmediate(dialogRectTransform);

            return this;
        }

        public void ActOnClickCheck() {
            OnClickCheck?.Invoke();
            ExecuteCloseAction();
        }
    }
}