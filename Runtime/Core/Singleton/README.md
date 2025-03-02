# Singleton

## 목차
- [개요](#개요)
- [특징](#특징)
- [설정](#설정)
- [사용 방법](#사용-방법)
  - [MonoSingleton](#monosingleton)
  - [ScriptableSingleton](#scriptablesingleton)
  - [ScriptableLibrary](#scriptablelibrary)
  - [Singleton](#singleton)
- [샘플 코드](#샘플-코드)

---

## 개요
`Singleton` 시스템은 Unity에서 객체의 단일 인스턴스를 유지하여 **전역적으로 접근할 수 있도록 하는 패턴**입니다.
KSIShareable에서는 다양한 환경에서 활용할 수 있도록 여러 형태의 싱글톤을 제공합니다.

## 특징
- **MonoSingleton**: Unity `MonoBehaviour` 기반 싱글톤
- **ScriptableSingleton**: Unity `ScriptableObject` 기반 싱글톤
- **ScriptableLibrary**: `ScriptableSingleton`을 확장하여 데이터 저장 및 프리팹 관리 기능 제공
- **Singleton**: 일반 `C# 클래스` 기반 싱글톤

## 설정

각 싱글톤 클래스를 프로젝트에 추가하고, 해당 클래스를 상속받아 구현하면 됩니다.

---

## 사용 방법

### **MonoSingleton**
`MonoBehaviour` 기반 싱글톤으로, Unity 씬 내에서 게임 오브젝트로 존재하는 경우 사용됩니다.
```csharp
public class GameManager : MonoSingleton<GameManager> {
    protected override void Awake() {
        base.Awake();
        Debug.Log("GameManager Initialized");
    }
}
```
- `dontDestroyOnLoad` 옵션을 활성화하면 씬 변경 시에도 오브젝트가 유지됩니다.

### **ScriptableSingleton**
`ScriptableObject`를 활용한 싱글톤으로, **데이터 저장 및 관리**에 유용합니다.
```csharp
[CreateAssetMenu(fileName = "GameSettings", menuName = "Game/Game Settings")]
public class GameSettings : ScriptableSingleton<GameSettings> {
    public int maxPlayers;
}
```
- `ScriptableObject` 기반이므로 씬과 독립적으로 유지됩니다.

### **ScriptableLibrary**
`ScriptableSingleton`을 확장하여 **프리팹 및 오브젝트 관리 기능**을 추가한 형태입니다.
```csharp
public class EnemyLibrary : ScriptableLibrary<string, Enemy> {
    protected override string GetKeyOf(Enemy value) {
        return value.enemyName;
    }
}
```
- `GetPrefab(key)`, `Create(key)` 메서드를 통해 특정 키 값에 해당하는 프리팹을 가져오거나 인스턴스화할 수 있습니다.

### **Singleton**
일반 C# 클래스 기반 싱글톤으로, Unity 프레임워크와 무관하게 사용할 수 있습니다.
```csharp
public class DataManager : Singleton<DataManager> {
    public int playerScore;
}
```
- Unity 환경이 아닌 **순수 C# 환경에서도 사용 가능**합니다.

---

## 샘플 코드
```csharp
public class GameController : MonoBehaviour {
    void Start() {
        GameManager.Instance.SomeMethod();
        int score = DataManager.Instance.playerScore;
    }
}
```

이와 같이 `Instance`를 통해 어디서든 싱글톤 객체에 접근할 수 있습니다.

