#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace KSIShareable.Audio
{
#if UNITY_EDITOR
    [CustomEditor(typeof(AudioLibrary))]
    public class AudioLibraryEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI() {
            DrawDefaultInspector();

            AudioLibrary library = (AudioLibrary)target;

            if (GUILayout.Button("Sort by Key")) {
                library.SortByKey();
            }
        }
    }
#endif
}