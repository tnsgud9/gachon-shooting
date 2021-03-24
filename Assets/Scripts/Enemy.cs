using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    private GameObject player;
    Vector3 dir;

    public GameObject explosionFactory;
    void Start()
    {
        
        // 0부터 9 까지 10개의 값 중에 하나를 랜덤으로 가져온다.
        int randValue = UnityEngine.Random.Range(0, 10);
        // 만약 3보다 작으면
        if (randValue < 3)
        {
            //플레이어를 찾아 Target으로 하고 싶다,.
            GameObject target = GameObject.Find("Player");
            //방향을 구하고 싶다. target-me
            dir = target.transform.position - transform.position;
            
            //방향의 크기를 1로 하고 싶다,.
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        //1. 방향을 구한다.
        // Vector3 dir = Vector3.down;
        //2. 이동하고 싶다.
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        //2. 폭발 효과 공장에서 폭발 효과를 하나 만들어야한다.
        //GameObject explosion = Instantiate(explosionFactory);
        //explosion.transform.position = transform.position;
        // 너 죽고
        Destroy(other.gameObject);
        //나 죽자.
        Destroy(gameObject);
    }

    private void OnCollisionStay(Collision other)
    {
        //충돌 중
    }

    private void OnCollisionExit(Collision other)
    {
        //충돌 끝
    }
}
