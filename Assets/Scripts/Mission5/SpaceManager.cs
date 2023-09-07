using UnityEngine;

public class SpaceManager : MonoBehaviour
{
    // 두 스크립트 간의 상호작용을 위한 이벤트 정의
    public delegate void OnScriptCompleted();
    public static event OnScriptCompleted ScriptCompleted;

    // 게임 시작 시 호출
    private void Start()
    {
        // 첫 번째 스크립트 실행
        // 여기서는 예시로 InvokeScript1 함수를 호출합니다.
        InvokeScript1();
    }

    // 첫 번째 스크립트 실행
    private void InvokeScript1()
    {
        // 첫 번째 스크립트의 내용을 여기에 추가합니다.
        // 스크립트가 완료되면 이벤트를 발생시킵니다.
        Debug.Log("첫 번째 스크립트가 끝났습니다.");
        OnScript1Completed();
    }

    // 두 번째 스크립트 실행
    private void InvokeScript2()
    {
        // 두 번째 스크립트의 내용을 여기에 추가합니다.
        Debug.Log("두 번째 스크립트가 끝났습니다.");
    }

    // 첫 번째 스크립트 완료 이벤트 핸들러
    private void OnScript1Completed()
    {
        // 첫 번째 스크립트가 완료되면 두 번째 스크립트를 실행합니다.
        InvokeScript2();

        // 두 번째 스크립트 실행 후 이벤트를 발생시킵니다.
        if (ScriptCompleted != null)
        {
            ScriptCompleted();
        }
    }
}
