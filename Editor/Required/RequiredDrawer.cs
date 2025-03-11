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
            // ���� Ÿ������ Ȯ��
            if (property.propertyType != SerializedPropertyType.ObjectReference) {
                EditorGUI.PropertyField(position, property, label);
                return;
            }

            // ���� ���� null �Ǵ� Missing���� Ȯ��
            bool isMissing = property.objectReferenceValue == null || property.objectReferenceInstanceIDValue == 0;

            // �⺻ ���� ����
            Color defaultColor = GUI.backgroundColor;

            // ���� ������ ������ �Ӱ� ����
            if (isMissing) {
                GUI.backgroundColor = new Color(1f, 0.5f, 0.5f); // ���� ������
            }

            // �Է� �ʵ� �׸���
            EditorGUI.PropertyField(position, property, label, true);

            // ���� ������� ����
            GUI.backgroundColor = defaultColor;
        }
    }
#endif
}
