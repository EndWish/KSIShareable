using UnityEngine;

namespace KSIShareable.Core
{
    public class MonoSingleton<T> : MonoBehaviour where T : Component
    {
        [SerializeField] protected bool dontDestroyOnLoad;

        private static T instance = null;
        public static T Instance {
            get {
                if (instance == null) {
                    instance = (T)FindObjectOfType(typeof(T));
                }
                return instance;
            }
        }

        protected virtual void Awake() {
            if (instance == null || instance == this) {
                instance = this as T;
                if (dontDestroyOnLoad) {
                    DontDestroyOnLoad(gameObject);
                }
            }
            else {
                Destroy(this.gameObject);
            }
        }

    }
}