#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace KSIShareable.Core
{
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    public abstract class ScriptableSingleton<T> : ScriptableObject where T : ScriptableObject
    {
        protected static T instance = null;
        public static T Instance {
            get { return instance; }
        }

        protected virtual void OnEnable() {
            if (instance == null) {
                instance = this as T;
            }
            else if (instance != this) {
                Debug.LogWarning($"An instance of {typeof(T).Name} already exists. This will be ignored.");
            }
        }
    }

}