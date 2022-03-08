using UnityEngine;

using UnityEditor;

namespace GameWish.Game
{
	public class AnchorAutoFit : MonoBehaviour
	{
        [MenuItem("UGUI/Anchors to Corners &c")]
        static void AnchorsToCorners()
        {
            RectTransform rect = Selection.activeTransform as RectTransform;
            RectTransform pt = Selection.activeTransform.parent as RectTransform;


            if (rect == null || pt == null) return;

            Vector2 newAnchorsMin = new Vector2(rect.anchorMin.x + rect.offsetMin.x / pt.rect.width,
                rect.anchorMin.y + rect.offsetMin.y / pt.rect.height);
            Vector2 newAnchorsMax = new Vector2(rect.anchorMax.x + rect.offsetMax.x / pt.rect.width,
                rect.anchorMax.y + rect.offsetMax.y / pt.rect.height);

            rect.anchorMin = newAnchorsMin;
            rect.anchorMax = newAnchorsMax;
            rect.offsetMin = rect.offsetMax = new Vector2(0, 0);
        }

        [MenuItem("UGUI/Corners to Anchors &b")]
        static void CornersToAnchors()
        {
            RectTransform rect = Selection.activeTransform as RectTransform;

            if (rect == null) return;

            rect.offsetMin = rect.offsetMax = new Vector2(0, 0);
        }
        [MenuItem("UGUI/Anchors to Middle &v")]
        static void AnchorsToMiddle()
        {
            RectTransform rect = Selection.activeTransform as RectTransform;
            RectTransform pt = Selection.activeTransform.parent as RectTransform;


            if (rect == null || pt == null)
                return;

            Vector2 newAnchorsMin = new Vector2(
                rect.anchorMin.x + (rect.offsetMin.x + rect.rect.width / 2) / pt.rect.width,
                rect.anchorMin.y + (rect.offsetMin.y + rect.rect.height / 2) / pt.rect.height);

            rect.anchorMin = newAnchorsMin;
            rect.anchorMax = newAnchorsMin;
            rect.anchoredPosition = Vector2.zero;
            //rect.offsetMin = new Vector2(-rect.rect.width / 2, -rect.rect.height / 2);
            //rect.offsetMax = new Vector2(rect.rect.width / 2, rect.rect.height / 2);
        }

    }

}