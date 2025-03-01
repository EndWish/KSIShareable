# KSIShareable

## 목차
- [개요](#개요)
- [설치](#설치)
- [스펙](#스펙)
- [Components](#components)

---

## 개요
**KSIShareable**는 Unity 프로젝트에서 개발 효율성을 높이기 위해 다양한 유틸리티 컴포넌트를 제공합니다. 
이 패키지는 UI, 오디오 관리, 입력 처리 등 여러 분야에서 활용할 수 있는 기능들을 포함하고 있습니다.

## 설치

KSIShareable은 Git URL을 이용하여 Unity Package Manager(UPM)에서 설치할 수 있습니다.

### 설치 방법 (Unity Package Manager 사용)
1. Unity를 실행하고 `Window > Package Manager`로 이동합니다.
2. 좌측 상단의 `+` 버튼을 클릭하고 **"Add package from git URL..."**을 선택합니다.
3. 아래의 Git URL을 입력한 후 **"Add"** 버튼을 클릭합니다.
   ```
   https://github.com/EndWish/KSIShareable.git#develop
   ```
4. 설치가 완료되면 `KSIShareable` 패키지를 사용할 수 있습니다.

## 스펙

### Unity 지원 버전

- 2019.4.0 이상

### 네임스페이스

```csharp
using KSIShareable;
```

## Components

| Component | 설명 |
| --- | --- |
| [AudioManager](Runtime/Audio/AudioManager/README.md) | 오디오 클립의 재생 및 관리를 담당하는 싱글톤 오디오 매니저입니다. |
| [ButtonActions](Runtime/UI/Button/ButtonActions/README.md) | UI 버튼에서 직접 호출할 수 있는 다양한 기능을 제공하여 추가적인 스크립트 작성을 줄이는 유틸리티 클래스입니다. |
| [ConfirmationDialog](Runtime/UI/Dialog/ConfirmationDialog/README.md) | 사용자에게 확인 또는 취소를 요청하는 대화 상자를 구현한 컴포넌트입니다. |
| [PriorityKeyHandler](Runtime/Input/PriorityKeyHandler/README.md) | 키 입력에 우선순위를 부여하여 처리할 수 있도록 도와주는 컴포넌트입니다. |
| [ShowScriptableObject](Editor/ShowScriptableObject/README.md) | 인스펙터에서 ScriptableObject의 필드를 직접 편집할 수 있도록 도와주는 커스텀 프로퍼티 드로어입니다. |

---

**Note:** 상대 경로를 사용하여 링크를 설정하였으며, 이는 현재 `README.md` 파일의 위치에 따라 다르게 동작할 수 있습니다. 
만약 링크가 제대로 작동하지 않을 경우, 절대 경로를 사용하거나 링크 경로를 조정해주시기 바랍니다.

