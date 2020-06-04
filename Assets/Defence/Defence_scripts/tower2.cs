using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower2 : Unit
{//참조
    Rigidbody rb;

    //공격
    public float rangeradius;//공격범위
    public GameObject meleeattck;
    public Transform attackpos;
    private float elapsedtime;//쿨타임
    float velocity;
    public float enemyradius;//에너미 감지범위
    public Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isground == true)
        {//애니메이션 삽입
            animator.SetBool("IsRun", true);
            Collider[] enemycollider = Physics.OverlapSphere(transform.position, enemyradius);
            if (enemycollider.Length != 0)
            {
                float min = int.MaxValue;//min에 가장 큰 값을 넣어둔다.
                int index = -1;//index에 -1을 넣어둔다.

                for (int i = 0; i < enemycollider.Length; i++)//enemycollider배열의 길이만큼 반복한다.
                {
                    if (enemycollider[i].tag == "ENEMY")//HERO태그면
                    {
                        float dis = Vector3.Distance(enemycollider[i].transform.position, transform.position);//상대방과 나의 위치를 비교한다.

                        if (dis < min)//만약 dis의 값이 min의 값보다 작으면 
                        {
                            index = i;//index에 i의 값을 넣고
                            min = dis;//min에 dis를 넣어 결국 for문이 끝나면 최소값이 구해지게 된다.
                        }
                    }
                }
                if (index < 0)
                {
                    animator.SetBool("IsAttack", false);
                    animator.SetBool("IsRun", false);
                }

                if (index > 0)
                {
                    Vector3 target = enemycollider[index].transform.position; //첫번째로 들어온 콜라이더의 위치를 저장         
                    float distance = Vector3.Distance(target, transform.position);
                    turnmove(target);
                    if (distance > rangeradius)
                    {//애니메이션 삽입
                        velocity = speed * Time.deltaTime;
                        rb.MovePosition(Vector3.MoveTowards(transform.position, target, velocity));
                    }
                    else if (distance <= rangeradius)
                    {   // enemy가 있으면 멈추고 attack메소드를 실행시켜서 공격을 한다.
                        //애니메이션 삽입
                        animator.SetBool("IsAttack", true);
                       
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
    public void Shoot()
    {

    }
    void turnmove(Vector3 target)
    {
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
            Instantiate(meleeattck, attackpos.position, attackpos.rotation);// as == 캐스트성공하면 결과를 리턴하고 실패하면 null 을 리턴
        }
        elapsedtime += Time.deltaTime;

    }

    private void Hit(int Damage)
    {//애니메이션 삽입
        hp -= Damage;
        animator.SetTrigger("IsHit");
        if (hp <= 0)
        {
            animator.SetBool("IsDeath", true);
            Destroy(gameObject, 3f);
            Debug.Log("Enemy Die");
            speed = 0;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "ENEMYATTACK")
        {
            Hit(col.GetComponent<MeleeAttack_Enemy>().damage);
        }
    }
}
