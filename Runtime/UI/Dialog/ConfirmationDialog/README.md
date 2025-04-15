[<- 상위 페이지로 가기](../../../../README.md)  
[<- CheckDialog](../CheckDialog/README.md)  

# ConfirmationDialog

## 목차
- [개요](#개요)
- [특징](#특징)
- [사용 방법](#사용-방법)
- [API](#api)
  - [BasicConfirmationDialog](#basicconfirmationdialog)
  - [LocalizeConfirmationDialog](#localizeconfirmationdialog)
  - [공통 API](#공통-api)
- [샘플 코드](#샘플-코드)

---

## 개요
`ConfirmationDialog`는 사용자가 확인, 취소 등의 액션을 수행하도록 유도하는 대화 상자입니다. 
이 컴포넌트는 간단한 메시지를 표시하고 버튼을 통해 사용자 입력을 받을 수 있도록 합니다.

## 특징
- 메시지와 버튼의 `Text`를 쉽게 설정 가능
- 확인 및 취소 버튼 클릭 시 발생할 이벤트 설정 가능
- 대화 상자 종료 시 `Destroy` / `Disable` / `Nothing` 설정 가능
- `Localize` 버전 지원

## 사용 방법
### 예시
![alt text](READMEImage~/ExampleOfUse.gif)  

### 컴포넌트  
![alt text](READMEImage~/Component.png)  
#### Close Action - 대화 상자의 종료 시 액션(`Destroy` / `Disable` / `Nothing`) 설정 가능  
#### OnClickYes - 확인 버튼 클릭 시 호출하는 이벤트  
#### OnClickNo - 취소 버튼 클릭 시 호출하는 이벤트  

### 스크립트
아래 예제는 `BasicConfirmationDialog`를 생성하고 초기화하는 방법을 보여줍니다.

```csharp
public void CreateDialog() {
    string questionText = "Starting a new game will delete your previous data.\n\nAre you sure you want to start a new game?";
    string yesBtnText = "New Game";
    string noBtnText = "Cancel";

    var dialog = Instantiate(dialogPrefab);
    dialog.Init(questionText, yesBtnText, noBtnText, AgreeNewGame, null);
}

public void AgreeNewGame() {
    Debug.Log("Deleted previous data. Create a new game.");
}
```



## API

### `BasicConfirmationDialog`
```csharp
public ConfirmationDialog Init(
    string questionText, 
    string yesBtnText, 
    string noBtnText, 
    UnityAction actionOnYes, 
    UnityAction actionOnNo
)
```
- 기본 `ConfirmationDialog` 초기화
- `questionText`: 질문 텍스트
- `yesBtnText`: 확인 버튼 텍스트
- `noBtnText`: 취소 버튼 텍스트
- `actionOnYes`: 확인 버튼 클릭 시 실행할 콜백
- `actionOnNo`: 취소 버튼 클릭 시 실행할 콜백

### `LocalizeConfirmationDialog`
```csharp
public ConfirmationDialog Init(
    LocalizedString questionText, 
    LocalizedString yesBtnText, 
    LocalizedString noBtnText, 
    UnityAction actionOnYes, 
    UnityAction actionOnNo
)
```
- `LocalizedString`을 활용한 `ConfirmationDialog` 초기화
- 다국어 지원을 위해 `LocalizedString` 사용

### `공통 API`
```csharp
void ActOnClickYes()
```
- 확인 버튼 클릭 시 실행되는 함수

```csharp
void ActOnClickNo()
```
- 취소 버튼 클릭 시 실행되는 함수

```csharp
void SetWidth(float width)
```
- 대화 상자의 너비 설정

```csharp
void SetSortOrder(int order)
```
- 대화 상자의 Canvas의 `Sorting Order` 설정

## 샘플 코드
```csharp
using KSIShareable.UI.Dialog;
using UnityEngine;

namespace KSIShareable.Samples
{
    internal class SampleNewGameManagaer : MonoBehaviour
    {
        [SerializeField] BasicConfirmationDialog dialogPrefab;

        public void CreateDialog() {
            string questionText = "Starting a new game will delete your previous data.\n\nAre you sure you want to start a new game?";
            string yesBtnText = "New Game";
            string noBtnText = "Cancel";

            var dialog = Instantiate(dialogPrefab);
            dialog.Init(questionText, yesBtnText, noBtnText, AgreeNewGame, null);
            dialog.SetWidth(700f);
            dialog.SetSortOder(10);

            //Another Style:
            //var dialog = Instantiate(dialogPrefab)
            //    .Init(questionText, yesBtnText, noBtnText, AgreeNewGame, null)
            //    .SetWidth(700f)
            //    .SetSortOder(10);
        }

        public void AgreeNewGame() {
            Debug.Log("Deleted previous data. Create a new game.");
        }
    }
}
```

