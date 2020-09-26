using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trace : MonoBehaviour
{
    [SerializeField] GameSystem gameSystem;
    [SerializeField] Trace traceSystem;
    [SerializeField] private int targetCount; // 타겟수;
    [HideInInspector]
    [SerializeField] private Transform[] target = null;
   // [Header("회전 속도")]
  //  [SerializeField] private float rotationSpeed = 2.0f; 
    [Header("n초 뒤 스피드 복귀 시간")]
    [SerializeField] private float changeTime; // 꺾고나서 n초뒤에 스피드 복귀 할건지 
    [Header("꺾을때 스피드 and 회전속도")]
    [SerializeField] private float slowSpeed; // 구간 꺾을때 스피드 
    [SerializeField] private float slowRotateSpeed; // 구간 꺾는 스피드 
    //
    [Header("사운드")]
    [SerializeField] private SoundSystem soundSystem;

    [SerializeField] private int index;
    [SerializeField] private float[] railSpeedArray = new float[34];
    private float baseSpeed;
    private float baseRotateSpeed;


    [SerializeField] private bool isStart = false;
    // 
    private void Awake()
    {
        index = 0;
        baseSpeed = railSpeedArray[index];
     //   baseRotateSpeed = rotationSpeed;
        TargetFind();
    }

    private void Update()
    {
        if (isStart == false)
            return;

        TargetTrace();
    }

    private void TargetTrace()
    {
        if (index >= target.Length)
        {
            EndRailGame();
            gameSystem.EndGame();
           // traceSystem.SetActive(false);
            index = 0;
            return;
        }

        float distance = Vector3.Distance(target[index].position, transform.position);

        Vector3 dir = (target[index].position - transform.position).normalized;
        
        transform.position += dir * Time.deltaTime * baseSpeed;
   

        LookAtTarget();

        if (distance < 0.3f)
        {
            StartCoroutine(SlowRotate());
            index++;
        }
    }

    private void LookAtTarget() // 회전 보간
    {
        Vector3 dirToTarget = this.target[index].position - this.transform.position;
        Vector3 look = Vector3.Slerp(this.transform.forward, dirToTarget.normalized, Time.deltaTime * baseRotateSpeed);
        this.transform.rotation = Quaternion.LookRotation(look, Vector3.up);
    }

    private void ArraySet() // 배열 크기 체크 
    { 
        for (int i = 0; i < target.Length; i++)
        {
            if (target[i] == null)
            {
                if (i - 1 < 0) // 예외처리 
                {
                    Debug.LogError("포인트를 등록하세요! ");
                    break;
                }

                target = new Transform[i - 1];
                break;
            }
        }
    }
    
    private void TargetFind()
    {
        target = new Transform[targetCount];
        for (int i = 0; i < targetCount; i++)
        {
            Debug.Log(i);
            target[i] = GameObject.Find("Point" + (i + 1)).GetComponent<Transform>();
        }
        
    }

    IEnumerator SlowRotate()
    {
        baseSpeed = slowSpeed;
        baseRotateSpeed = slowRotateSpeed;
        yield return new WaitForSeconds(changeTime);
        baseSpeed = railSpeedArray[index];
        //  baseRotateSpeed = rotationSpeed;
    }

    public void StartRailGame()
    {
        isStart = true;
        soundSystem.SoundMinePlay();
    }

    public void EndRailGame()
    {
        isStart = false;
        index = 0;
        baseSpeed = railSpeedArray[index];
        soundSystem.SounMainPlay();
    }
}
