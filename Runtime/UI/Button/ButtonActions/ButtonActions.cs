using UnityEngine;
using UnityEngine.SceneManagement;

namespace KSIShareable.UI.Button
{
    public class ButtonActions : MonoBehaviour
    {
        public void LoadScene(string sceneName) {
            SceneManager.LoadScene(sceneName);
        }

        public void Deactivate(GameObject gameObject) {
            gameObject.SetActive(false);
        }
        public void Activate(GameObject gameObject) {
            gameObject.SetActive(true);
        }
        public void ToggleActive(GameObject gameObject) {
            gameObject.SetActive(!gameObject.activeSelf);
        }
        public void Create(GameObject prefab) {
            Instantiate(prefab);
        }
        public void Destroy(GameObject gameObject) {
            Object.Destroy(gameObject);
        }

        public void Enable(MonoBehaviour monoBehaviour) {
            monoBehaviour.enabled = true;
        }
        public void Disable(MonoBehaviour monoBehaviour) {
            monoBehaviour.enabled = false;
        }
        public void ToggleEnabled(MonoBehaviour monoBehaviour) {
            monoBehaviour.enabled = !monoBehaviour.enabled;
        }
        public void Destroy(MonoBehaviour monoBehaviour) {
            Object.Destroy(monoBehaviour);
        }

    }
}
