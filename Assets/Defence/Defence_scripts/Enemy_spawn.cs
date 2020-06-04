using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawn : MonoBehaviour
{  
    public GameObject enemy;

    //쿨타임
   public int count =0;
   public float time;
    public float cooltime;

    //생성될 enemy숫자
    public int enemycount;
    //체력도 1이상이면 승리한다.
    //남은 적 (모든 적을 해치우면 승리라는 조건을 넣기위해 만든 변수[0이 되면 승리한다.])
    private int enemy_count;
    private void Start()
    {
        enemy_count = enemycount;//코드가 시작되면 생성될 enemy의 숫자와 같게 하기 위해 만듬
    }
    void Update()
    {
        time -= Time.deltaTime;
        
            if (time <= 0)
            {
                if (count < enemycount)
                {
                    Instantiate(enemy, transform.position, Quaternion.identity);
                    count += 1;
                }
                time = cooltime;
            }     
      //  if (enemy_count == 0) { GameOver(true);}
             }
    //남아있는 적
    public void remaining_enemy()
    {
        enemy_count--;
    }

}
