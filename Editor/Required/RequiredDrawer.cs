using UnityEditor;
#if UNITY_EDITOR
using UnityEngine;
#endif

namespace KSIShareable.Editor
{
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(RequiredAttribute))]
    public class RequiredDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            // 참조 타입인지 확인
            if (property.propertyType != SerializedPropertyType.ObjectReference) {
                EditorGUI.PropertyField(position, property, label);
                return;
            }

            // 현재 값이 null 또는 Missing인지 확인
            bool isMissing = property.objectReferenceValue == null || property.objectReferenceInstanceIDValue == 0;

            // 기본 배경색 저장
            Color defaultColor = GUI.backgroundColor;

            // 값이 없으면 배경색을 붉게 변경
            if (isMissing) {
                GUI.backgroundColor = new Color(1f, 0.5f, 0.5f); // 연한 붉은색
            }

            // 입력 필드 그리기
            EditorGUI.PropertyField(position, property, label, true);

            // 배경색 원래대로 복구
            GUI.backgroundColor = defaultColor;
        }
    }
#endif
}
