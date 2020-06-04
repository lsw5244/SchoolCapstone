using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : Enemy
{
    public Vector3 waypoint = new Vector3(9, 0, -9);
    public Enemy_spawn ES;
    //공격
    public float rangeradius;//공격범위
    public GameObject meleeattck;
    public GameObject attackpos;
    private float elapsedtime;//쿨타임
    float velocity;
    public float enemyradius;//에너미 감지범위
    void Start()
    {
        ES = FindObjectOfType<Enemy_spawn>();
    }
    void FixedUpdate()
    {
        if (isground == true)
        {
            Collider[] enemycollider = Physics.OverlapSphere(transform.position, enemyradius);
            if (enemycollider.Length != 0)
            {
                float min = int.MaxValue;//오버플로우 검사를 위한 변수
                int index = -1;
                //몇번째 콜라이더인지 알기 위한 변수
                for (int i = 0; i < enemycollider.Length; i++)
                {
                    if (enemycollider[i].tag == "HERO")
                    {//들어온 콜라이더와 타워의 거리값을 distance변수에 넣는다.
                        float dis = Vector3.Distance(enemycollider[i].transform.position, transform.position);
                        //오버플로우가 아니면~
                        if (dis < min)
                        {//범위 안에 들어온 콜라이더의 갯수를 index에 넣는다.
                            index = i;
                            min = dis;
                        }
                    }
                }
                if (index == -1)//만약 범위안에 콜라이더가 없으면 목적지로 이동한다.
                {
                    transform.LookAt(waypoint);
                    transform.position = Vector3.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
                    return;
                }
                if (index > 0) {
                    Transform tar = enemycollider[index].transform; //첫번째로 들어온 콜라이더의 위치를 저장           
                    transform.LookAt(tar);//콜라이더 방향을 바라봄
                    Vector3 direction = (tar.position - transform.position * 1.0f).normalized;//콜라이더의 방향을 계산
                    velocity = speed * Time.deltaTime;
                    // Player와 객체 간의 거리 계산
                    float distance = Vector3.Distance(tar.position, transform.position);
                    // enemy가 있으면 다가간다.
                    if (distance > rangeradius)
                    {
                        this.transform.position = new Vector3(transform.position.x + (direction.x * velocity), transform.position.y, transform.position.z + (direction.z * velocity));
                    }
                    else if (distance <= rangeradius)
                    {   // enemy가 있으면 멈추고 attack메소드를 실행시켜서 공격을 한다.
                        velocity = 0.0f;
                        attack();
                    }
                }
            }
        }   
    }
    private void attack()
    {
        Collider[] hitcollider = Physics.OverlapSphere(transform.position, rangeradius);
        if (hitcollider.Length != 0)
        {
            float min = int.MaxValue;//오버플로우 검사를 위한 변수
            int index = -1;
            //몇번째 콜라이더인지 알기 위한 변수
            for (int i = 0; i < hitcollider.Length; i++)
            {
                if (hitcollider[i].tag == "HERO")
                {//들어온 콜라이더와 타워의 거리값을 distance변수에 넣는다.
                    float distance = Vector3.Distance(hitcollider[i].transform.position, transform.position);
                    //오버플로우가 아니면~
                    if (distance < min)
                    {//범위 안에 들어온 콜라이더의 갯수를 index에 넣는다.
                        index = i;
                        min = distance;
                    }
                }
            }
            if (index == -1)
            {
                return;
            }
            Transform target = hitcollider[index].transform; //첫번째로 들어온 콜라이더의 위치를 저장
            transform.LookAt(target);//콜라이더 방향을 바라봄
            Vector3 direction = (target.position - transform.position).normalized;//콜라이더의 방향을 계산

            if (elapsedtime >= attackspeed)//유닛의 attackspeed의 값을 elapsedtime이 넘으면 아래의 코드를 실행하고 값을 초기화한다.
            {
                elapsedtime = 0;
                GameObject projectile = GameObject.Instantiate(meleeattck, attackpos.transform.position, Quaternion.identity) as GameObject;// as == 캐스트성공하면 결과를 리턴하고 실패하면 null 을 리턴
                projectile.GetComponent<MeleeAttack_Enemy>().direction = direction;
            }
            elapsedtime += Time.deltaTime;
        }
    }
    private void Hit(int Damage) {
        hp -= Damage;
        if (hp <= 0)
        {//에너미를 죽이면 1원 획득 후 오브젝드 제거
         //   GameObject.FindGameObjectWithTag("MONEY").GetComponent<Money>().Changemoney(1);
            ES.remaining_enemy();//enemy_spwan클래스의 remaining_enemy메소드를 실행시켜 남은 적의 숫자를 1줄인다.
            Destroy(gameObject);
            //animator.SetTrigger(dietrigger);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "BULLET")
        {
            Hit(col.GetComponent<bullet>().damage);
        }
        else if (col.tag == "MELEEATTACK") {
            Hit(col.GetComponent<MeleeAttack>().damage);
        }
        if (col.tag =="ENDPOINT")
        {//여기에 체력을 깎는 코드도 추가
            ES.remaining_enemy();
            Destroy(gameObject);
        }
    }
}
