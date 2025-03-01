using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace KSIShareable.UI.Dialog
{
    public enum CloseAction
    {
        Nothing,
        Disable,
        Destroy,
    }

    public abstract class ConfirmationDialog : MonoBehaviour
    {
        protected Canvas canvas;
        [SerializeField] protected RectTransform dialogRectTransform;

        [Space(10)]
        public CloseAction CloseAction = CloseAction.Destroy;
        public UnityEvent OnClickYes;
        public UnityEvent OnClickNo;
        

        protected void Awake() {
            canvas = GetComponent<Canvas>();
        }

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
        public ConfirmationDialog SetWidth(float width) {
            dialogRectTransform.sizeDelta = new Vector2(width, dialogRectTransform.sizeDelta.y);
            LayoutRebuilder.ForceRebuildLayoutImmediate(dialogRectTransform);
            return this;
        }
        public ConfirmationDialog SetSortOder(int order) {
            canvas.sortingOrder = order;
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
        protected void ExecuteCloseAction() {
            switch (CloseAction) {
                case CloseAction.Nothing:
                    break;
                case CloseAction.Disable:
                    gameObject.SetActive(false);
                    break;
                case CloseAction.Destroy:
                    Destroy(this.gameObject);
                    break;
            }
        }


    }
}