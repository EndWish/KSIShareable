using UnityEngine;
using UnityEngine.UI;

namespace KSIShareable.UI.Dialog
{
    public enum CloseAction
    {
        Nothing,
        Disable,
        Destroy,
    }

    public abstract class Dialog : MonoBehaviour
    {
        protected Canvas canvas;
        [SerializeField] protected RectTransform dialogRectTransform;

        [Space(10)]
        public CloseAction CloseAction = CloseAction.Destroy;

        protected virtual void Awake() {
            canvas = GetComponent<Canvas>();
        }

        public Dialog SetWidth(float width) {
            dialogRectTransform.sizeDelta = new Vector2(width, dialogRectTransform.sizeDelta.y);
            LayoutRebuilder.ForceRebuildLayoutImmediate(dialogRectTransform);
            return this;
        }
        public Dialog SetSortOder(int order) {
            canvas.sortingOrder = order;
            return this;
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