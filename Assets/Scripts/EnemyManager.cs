using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 최소시간
    private float minTime = 1;
    // 최대 시간
    private float maxTime = 5;
    // 현재 시간
    float currentTime;
    // 일정시간
    public float createTime = 1;
    // 적 공장
    public GameObject enemyFactory;
    // Start is called before the first frame update
    void Start()
    {
        //태어날 떄 적의 생성 시간을 확인하고
        createTime = UnityEngine.Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        //1. 시간이 흐르다가
        currentTime += Time.deltaTime;
        
        //2. 현재 만약 시간이 일정시간이 되면.
        if (currentTime > createTime)
        {
            //3. 적 공장에서 적을 생성해
            GameObject enemy = Instantiate(enemyFactory);
            // 내 위치에 갖다 놓고 싶다.
            enemy.transform.position = transform.position;
            // 현재 시간을 0 으로 초기화
            currentTime = 0;
            createTime = UnityEngine.Random.Range(minTime, maxTime);
        }
    }
}
