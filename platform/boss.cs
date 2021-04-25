using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class boss : MonoBehaviour
{
    //오브젝트 참조
    public GameObject shootObject;
    public GameObject target;
    //보스 능력치
    public float bossSpeed;
    public Vector2 bossDirection;
    public int bossHP;

    //보스패턴
    public string bossState;
    private string[] bossPattern ={"stop","walk","dash","shootAttack","jumpAttack"};
    public float count=0;

    //컴포넌트 참조
    private Rigidbody2D rb;
    private Transform tr;
    private SpriteRenderer sp;

    private void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
 
        int r = Random.Range(0,5);
        if (count > 2)
        {
            changeState(bossPattern[r]);
            count = 0;
        }
        else {
            count += 1*Time.deltaTime;
        }

        //죽음
        if (bossHP<=0) {
            changeState("die");
        }
    }
    //감지
    void detect() {
        //플레이어 방향 감지
            if (target.transform.position.x > transform.position.x)
            {
                bossDirection.x = 1;
                tr.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                bossDirection.x = -1;
                tr.eulerAngles = new Vector3(0, 180, 0);
            }
    }

    public void changeState(string newState) {
        detect();
        if (bossState == newState)
        {
            return;
        }
        //기존 보스패턴 정지
        StopCoroutine(bossState);
            //보스패턴을 표시하는 변수에 새로운 패턴을 삽입
        bossState = newState;
        //새로운 패턴으로 시작
        StartCoroutine(bossState);
    }
    //정지
    IEnumerator stop()
    {
        rb.velocity= Vector2.zero;
        yield return null;
    }
    //전진
    IEnumerator walk()
    {
        while (true) {
            rb.velocity = bossSpeed * bossDirection;
            yield return new WaitForSeconds(0.05f);
        }
    }
    //돌진
    IEnumerator dash()
    {
        //색이 변하며 돌진할 준비를 한 뒤 0.5초 뒤에 대쉬하고 원래 색으로 돌아옴
        sp.color = new Color(1,0.5f,1);
        yield return new WaitForSeconds(1f);
        rb.AddForce(new Vector2(bossSpeed*10 * bossDirection.x, rb.velocity.y), ForceMode2D.Impulse);
        sp.color = new Color(1,1, 1);
    }
    //플레이어 지정 원거리공격
    IEnumerator shootAttack() {
        sp.color = new Color(1, 1, 0.5f);
        //+임팩트
        yield return new WaitForSeconds(1f);
        GameObject  bossShootObject = Instantiate(shootObject, transform.position, transform.rotation);
        bossShootObject.GetComponent<Rigidbody2D>().velocity = transform.right * 10;
      
        sp.color = new Color(1, 1, 1);
    }
    //점프어택
    IEnumerator jumpAttack() {
        //준비
        sp.color = new Color(0.5f, 1, 1);
        yield return new WaitForSeconds(1f);
        //점프
        sp.color = new Color(1, 1, 1);
        rb.AddForce(Vector2.up*10, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.6f);
        //플레이어쪽을 향해 전진
        rb.AddForce(new Vector2(bossSpeed * 12 * bossDirection.x, rb.velocity.y), ForceMode2D.Impulse);
    }

    //무작위전체공격
    IEnumerator globalAttack() {
        //+애니메이션
        //+사운드
        yield return new WaitForSeconds(2f);
        //+떨어지는 투사체 구현
    }

    //죽음
    IEnumerator die() {
        //+애니메이션
        //+사운드
        //+사라짐
        //+보상 또는 다음 지역으로 넘어갈 수 있는 포탈생성
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
