
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{   //체력
    public int health;
    public int maxhealth = 6;

    //물리
    Rigidbody2D rb;

    //점프
    public float jumpPower;
    public bool isground;
    private float vertical;
    //이동
    private float horizon;
    public float movespeed;

    //대쉬
   bool isDash;
   public bool canDash= true;
    IEnumerator dashCourutine;
    public int dashSpeed;
    private float nomalGravity;

    //애니메이션
    Animator animator;
    string playerAnimationState;

    string idle = "player_idle";
    string walk = "player_walk";
    string dash = "player_dash";
    string jump = "player_jump";
    string fall = "player_fall";
    //피격 음성
    public AudioClip hit;
    private AudioSource source = null;

    public bool ondmg = false;
    void Start()
    {
       
        animator = GetComponent<Animator>();
        health = maxhealth;
        rb = GetComponent<Rigidbody2D>();
        nomalGravity = rb.gravityScale;
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (health > maxhealth)
        {
            health = maxhealth;
        }
        if (health <= 0)
        {
            Die();
        }
        //이동하거나 점프하면 각각의 변수에 값이 들어감
        //getaxisraw는 -1또는 1이 즉시 들어가고 getaxis는 -1또는1까지 조금씩 증가또는 감소함 
        horizon = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && horizon!=0 && canDash == true) {
            if (dashCourutine != null)
            {
                StopCoroutine(dashCourutine);
            }
            dashCourutine = Dash(0.2f,0.5f);
            StartCoroutine(dashCourutine);
        }
    }

    void FixedUpdate()
    {
        if (isDash == false)
        {
            //점프
            if (vertical != 0 && rb.velocity.y == 0)
            {
                rb.AddForce(new Vector2(0, vertical * jumpPower), ForceMode2D.Impulse);

            }
            if (rb.velocity.y > 0&&!isground)
            {
                changeAnimation(jump);
            }
            else if (rb.velocity.y <0 && !isground)
            {
                changeAnimation(fall);
            }
            //이동
            rb.velocity = new Vector2(horizon * movespeed, rb.velocity.y);
            if (horizon != 0 && isground == true)
            {
                changeAnimation(walk);
            }
            else if (horizon == 0 && isground == true)
            {
                changeAnimation(idle);
            }
        }
        //대쉬
        if (isDash) {
            rb.AddForce(new Vector2(horizon*dashSpeed,0), ForceMode2D.Impulse);
        }
    }
    IEnumerator Dash(float duration, float dashCooltime){
        gameObject.layer = 9;//레이어 12로 변경
        isDash = true;
        canDash = false;
        rb.velocity = Vector2.zero;
        changeAnimation(dash);
        yield return new WaitForSeconds(duration);
        Invoke("offDMG", duration);//2초 있다가 off데미지로 이동
        isDash = false;
        yield return new WaitForSeconds(dashCooltime);
        canDash = true;
    }

        void Die()
    {
        //다시시작
        Application.LoadLevel(Application.loadedLevel);

    }

    //충돌관련
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ENEMY") {
            Damage(1);
            onDMG();
        }
    }

    //데미지
    public void Damage(int dmg)
    {
        health -= dmg;
    }
    //넉백과 무적
    void onDMG()
    {
        ondmg = true;
        source.PlayOneShot(hit, 2f);
        gameObject.layer = 9;//레이어 9로 변경
        rb.AddForce(new Vector2(0,4f), ForceMode2D.Impulse);//forcemode2D.impulse==충돌하면 지정된 힘을 가함
       // gameObject.GetComponent<Animation>().Play("player_hit");
        Invoke("offDMG", 2.0f);//2초 있다가 off데미지로 이동
    }

    void offDMG() {
        gameObject.layer = 8;//레이어 원래대로
    }
    //애니메이션 변경함수
    void changeAnimation(string state) {
        if (state == playerAnimationState)
        {
            return;
        }
        animator.Play(state);
        playerAnimationState = state;
    }

}
