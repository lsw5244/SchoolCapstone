using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_enemy2 : Enemy
{/*
    목표를 달려간다.
    달려가다 감지되면 추격한다.
    가까워졌으면 멈춰서 공격한다.
    적을 해치우면 다시 목표를 달려간다.
     */
    private static GM gm;
    private int waypointnumber;
    private const float changeDist = 0.1f;
    public float enemyradius;//감지범위
    Rigidbody rb;
    float velocity;
    public float rangeradius;//공격범위
    public GameObject meleeattack;
    public GameObject attackpos;
    private float elapsedtime;//쿨타임
    public Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        if (gm == null)
        {
            gm = FindObjectOfType<GM>();
        }
      
    }
    private void Update()
    {
        if (isground == true)
        {//애니메이션 삽입
            Collider[] enemycollider = Physics.OverlapSphere(transform.position, enemyradius);
            if (enemycollider.Length != 0)
            {
                float min = int.MaxValue;//min에 가장 큰 값을 넣어둔다.
                int index = -1;//index에 -1을 넣어둔다.

                for (int i = 0; i < enemycollider.Length; i++)//enemycollider배열의 길이만큼 반복한다.
                {
                    if (enemycollider[i].tag == "HERO")//HERO태그면
                    {
                        float dis = Vector3.Distance(enemycollider[i].transform.position, transform.position);//상대방과 나의 위치를 비교한다.

                        if (dis < min)//만약 dis의 값이 min의 값보다 작으면 
                        {
                            index = i;//index에 i의 값을 넣고
                            min = dis;//min에 dis를 넣어 결국 for문이 끝나면 최소값이 구해지게 된다.
                        }
                    }
                }
                if (index == -1)
                {
                    float dist = Vector3.Distance(transform.position, gm.waypoint[waypointnumber]);
                    if (dist <= changeDist)
                    {
                        waypointnumber++;
                    }
                    else
                    {
                        movetowards(gm.waypoint[waypointnumber]);
                        turnmove(gm.waypoint[waypointnumber]);

                    }
                    return;
                }
                    if (index > 0)
                    {
                        Vector3 target = enemycollider[index].transform.position; //첫번째로 들어온 콜라이더의 위치를 저장         
                        float distance = Vector3.Distance(target, transform.position);
                        turnmove(target);
                        if (distance > rangeradius)
                    {
                        velocity = speed * Time.deltaTime;             
                        rb.MovePosition(Vector3.MoveTowards(transform.position, target, velocity));
                        // 5월 24일 추가 Attack 애니메이션 멈춤
                        animator.SetBool("IsAttack", false);
                  
                    }
                        else if (distance <= rangeradius)
                        {   // enemy가 있으면 멈추고 attack메소드를 실행시켜서 공격을 한다.
                            // 5월 24일 추가 Attack 애니메이션 실행
                        animator.SetBool("IsAttack",true);
                     
                        velocity = 0;
                            attack();
                        }
                       
                    }            
            }
            
        }
    }
    public void Hit()
    {

    }
    public void FootR()
    {

    }
    public void FootL()
    {

    }
    void turnmove(Vector3 target) {
        Vector3 direction = (target - transform.position).normalized;//콜라이더의 방향을 계산
        float turn = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float rot = Mathf.LerpAngle(transform.eulerAngles.y, turn, Time.deltaTime * 180f);
        transform.eulerAngles = new Vector3(0, rot, 0);
        // Player와 객체 간의 거리 계산
    
    }
    void attack()
    {
        if (elapsedtime >= attackspeed)//유닛의 attackspeed의 값을 elapsedtime이 넘으면 아래의 코드를 실행하고 값을 초기화한다.
        {
            //애니메이션 삽입
            elapsedtime = 0;
            Instantiate(meleeattack, attackpos.transform.position, Quaternion.identity);// as == 캐스트성공하면 결과를 리턴하고 실패하면 null 을 리턴
        }
        elapsedtime += Time.deltaTime;

    }
    private void movetowards(Vector3 destination)//목적지 이동
    {//애니메이션 삽입
        turnmove(gm.waypoint[waypointnumber]);
        float step = speed * Time.deltaTime;
        rb.MovePosition(Vector3.MoveTowards(transform.position, destination, step));
    }
    private void Hit(int Damage)
    {//애니메이션 삽입
        hp -= Damage;
        animator.SetTrigger("IsHit1");
        //animator.SetBool("IsHit", false);
        Debug.Log("Enemy Hit true");
        if (hp <= 0)
        {//에너미를 죽이면 1원 획득 후 오브젝드 제거
         //   GameObject.FindGameObjectWithTag("MONEY").GetComponent<Money>().Changemoney(1);
         // ES.remaining_enemy();//enemy_spwan클래스의 remaining_enemy메소드를 실행시켜 남은 적의 숫자를 1줄인다.
         // 5월 24일 추가 3초후에 죽으면서 사라집니다ㅏ. 

            animator.SetBool("IsDie", true);
            Destroy(gameObject, 3f);
            Debug.Log("Enemy Die");
            //이게 없으면 죽어도 계속 전진합니다.
            speed = 0;
            //animator.SetTrigger(dietrigger);
        }
        else
        {
           //
            //Debug.Log("Enemy Hit false");
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "BULLET")
        {
            Hit(col.GetComponent<bullet>().damage);
            
        }
        else if (col.tag == "MELEEATTACK")
        {
            Hit(col.GetComponent<MeleeAttack>().damage);
        }
        if (col.tag == "ENDPOINT")
        {//여기에 체력을 깎는 코드도 추가
         //ES.remaining_enemy();
            Destroy(gameObject);
        }
    }
 
}
