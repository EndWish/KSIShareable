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
    /// 주어진 하위 폴더에서 TValue 컴포넌트를 가진 프리팹들을 검색하여 리스트에 추가합니다.
    /// </summary>
    /// <param name="subFolder">Assets 하위 폴더 경로</param>
    protected void LoadPrefabsFromSubFolder(string subFolder) {

        // 경로 설정
        string folderPath = $"Assets/_Prefab/{subFolder}";

        // 폴더 존재 여부 확인
        if (!AssetDatabase.IsValidFolder(folderPath)) {
            Debug.LogWarning($"폴더 '{folderPath}'가 존재하지 않습니다.");
            return;
        }

        // 기존 리스트 초기화
        list.Clear();

        // 해당 폴더에서 프리팹 검색
        string[] prefabGUIDs = AssetDatabase.FindAssets("t:Prefab", new[] { folderPath });

        foreach (string guid in prefabGUIDs) {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);

            if (prefab != null) {
                // 프리팹에 TValue 컴포넌트가 있는지 확인
                TValue component = prefab.GetComponent<TValue>();
                if (component != null) {
                    list.Add(component);
                }
            }
        }

        EditorUtility.SetDirty(this);

        Debug.Log($"{list.Count}개의 프리팹이 로드되었습니다.");
    }
#endif

    }
}