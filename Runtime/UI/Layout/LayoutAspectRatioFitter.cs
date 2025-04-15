using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KSIShareable.UI
{
    [RequireComponent(typeof(RectTransform), typeof(LayoutElement))]
    [ExecuteInEditMode]
    public class LayoutAspectRatioFitter : AspectRatioFitter
    {
        private new RectTransform transform;
        private LayoutElement layoutElement;

        protected override void OnEnable() {
            base.OnEnable();

            transform = GetComponent<RectTransform>();
            layoutElement = GetComponent<LayoutElement>();
        }

        protected override void Update() {
            base.Update();

            if (this.aspectMode == AspectMode.HeightControlsWidth) {
                layoutElement.minWidth = transform.rect.width;
            }
            else if (this.aspectMode == AspectMode.WidthControlsHeight) {
                layoutElement.minHeight = transform.rect.height;
            }
        }

    }
}
