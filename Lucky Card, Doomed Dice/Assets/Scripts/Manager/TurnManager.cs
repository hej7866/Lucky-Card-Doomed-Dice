using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class TurnManager : SingleTon<TurnManager>
{
    public int maxTurns = 15; // 총 턴 제한
    public int currTurn = 1; // 현재 턴
    public float thinkingTime = 30f; // 카드 선택 시간
    public float battleTime = 15f; // 전투 진행 시간
    private bool isTurnActive = false; // 턴 진행 여부
    private float turnTimer;

    private void Start()
    {
        StartCoroutine(TurnRoutine());
    }

    private IEnumerator TurnRoutine()
    {
        while (currTurn <= maxTurns)
        {
            isTurnActive = true;
            Debug.Log($"턴 {currTurn} 시작!");

            // **① 준비 단계 (30초)**
            turnTimer = thinkingTime;
            yield return StartCoroutine(ThinkingPhase());

            // **② 전투 단계 (15초)**
            turnTimer = battleTime;
            yield return StartCoroutine(BattlePhase());

            // **③ 턴 종료 & 다음 턴 시작**
            currTurn++;
        }

        Debug.Log("게임 종료!");
    }

    // 💡 준비 단계: 카드 뽑기 & 주사위 굴리기 & 공격/수비 선택
    private IEnumerator ThinkingPhase()
    {
        Debug.Log("카드 선택 & 주사위 굴리기 단계");

        while (turnTimer > 0)
        {
            turnTimer -= Time.deltaTime;
            yield return null;
        }

        Debug.Log("생각하는 시간이 끝났습니다!");
    }

    // 💡 전투 단계: 카드 공개 & 결과 적용
    private IEnumerator BattlePhase()
    {
        Debug.Log("전투 단계");
        // 카드와 주사위 값 공개

        while (turnTimer > 0)
        {
            turnTimer -= Time.deltaTime;
            yield return null;
        }

        Debug.Log("전투가 끝났습니다!");
    }
}
