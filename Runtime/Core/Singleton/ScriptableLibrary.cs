using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace KSIShareable.Core
{
    public abstract class ScriptableLibrary<TKey, TValue> : ScriptableSingleton<ScriptableLibrary<TKey, TValue>> where TValue : MonoBehaviour
    {
        [SerializeField] protected List<TValue> list = new List<TValue>();
        protected Dictionary<TKey, TValue> library = new Dictionary<TKey, TValue>();

        protected override void OnEnable() {
            base.OnEnable();

            for (int i = 0; i < list.Count; i++) {
                if (library.ContainsKey( GetKeyOf(list[i]) )) {
                    Debug.LogError( GetKeyOf(list[i]).ToString() + " key alreay exists." );
                }
                library.Add(GetKeyOf(list[i]), list[i]);
            }
        }

        protected abstract TKey GetKeyOf(TValue value);

        public TValue Create(TKey key) {
            return Instantiate(library[key]);
        }
        public TValue Create(TKey key, Vector3 position, Quaternion rotation) {
            return Instantiate(library[key], position, rotation);
        }
        public TValue Create(TKey key, Vector3 position, Quaternion rotation, Transform parent) {
            return Instantiate(library[key], position, rotation, parent);
        }
        public TValue Create(TKey key, Transform parent) {
            return Instantiate(library[key], parent);
        }

        public TValue GetPrefab(TKey key) {
            return library[key];
        }

#if UNITY_EDITOR
    /// <summary>
    /// �־��� ���� �������� TValue ������Ʈ�� ���� �����յ��� �˻��Ͽ� ����Ʈ�� �߰��մϴ�.
    /// </summary>
    /// <param name="subFolder">Assets ���� ���� ���</param>
    protected void LoadPrefabsFromSubFolder(string subFolder) {

        // ��� ����
        string folderPath = $"Assets/_Prefab/{subFolder}";

        // ���� ���� ���� Ȯ��
        if (!AssetDatabase.IsValidFolder(folderPath)) {
            Debug.LogWarning($"���� '{folderPath}'�� �������� �ʽ��ϴ�.");
            return;
        }

        // ���� ����Ʈ �ʱ�ȭ
        list.Clear();

        // �ش� �������� ������ �˻�
        string[] prefabGUIDs = AssetDatabase.FindAssets("t:Prefab", new[] { folderPath });

        foreach (string guid in prefabGUIDs) {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);

            if (prefab != null) {
                // �����տ� TValue ������Ʈ�� �ִ��� Ȯ��
                TValue component = prefab.GetComponent<TValue>();
                if (component != null) {
                    list.Add(component);
                }
            }
        }

        EditorUtility.SetDirty(this);

        Debug.Log($"{list.Count}���� �������� �ε�Ǿ����ϴ�.");
    }
#endif

    }
}