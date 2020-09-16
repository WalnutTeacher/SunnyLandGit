using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator _Animator;
    Rigidbody2D _Rigidbody2D;

    BackGround _BackGround_1;
    BackGround _BackGround_2;

    RaycastHit2D _RaycastHit2D;
    Vector2 _Vector2;

    //송무현
    public bool is_clear = false;
    public bool is_cave_land = false;
    float dash_duration;
    Vector2 Began_Point;
    Vector2 Ended_Point;
    Vector2 Dash_Direction;
    //송무현
    public float moveSpeed = 5.0f;
    public float jumpPower = 15.0f;
    public float dashPower = 20.0f;

    bool home = false;

    bool isRun = false;
    bool isJump = false;
    bool isDash = false;

    // 강희
    bool isHurt = false;

    [SerializeField]
    bool isJumpAble = true;
    bool isDashAble = true;

    bool _Jump = false;
    public bool _Dash = false;

    float dashTime = 0.2f;

    void Start()
    {
        _Animator = GetComponent<Animator>();
        _Rigidbody2D = GetComponent<Rigidbody2D>();

        //
        _BackGround_1 = GameObject.Find("BackGround_1").GetComponent<BackGround>();
        _BackGround_2 = GameObject.Find("BackGround_2").GetComponent<BackGround>();
        //

        dash_duration = dashPower;
    }

    void Update()
    {
        if (home || isHurt)
        {
            return;
        }
        //시작 방식을 어떻게 할건지 고민해 봅시다

        //if (!isRun && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    isRun = true;
        //    _Animator.SetBool("Run", true);
        //    _BackGround_1.On();
        //    _BackGround_2.On();
        //}
        if (isRun)
        {
            _Animator.SetBool("Run", true);
               _BackGround_1.On();
               _BackGround_2.On();
        }
    }


    void FixedUpdate()
    {
        _RaycastHit2D = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.6875f), Vector2.down, Mathf.Infinity, LayerMask.GetMask("Ground", "Enemy"));

        // RUN
        if (isRun)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.fixedDeltaTime);
        }

        // JUMP
        if (_Jump)
        {
            _Rigidbody2D.velocity = Vector2.zero;
            _Rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

            _Jump = false;
        }

        // FALL
        if (!isHurt)
        {
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        _Vector2 = new Vector2(transform.position.x - 0.5625f, transform.position.y - 0.6875f);
                        break;
                    case 1:
                        _Vector2 = new Vector2(transform.position.x, transform.position.y - 0.6875f);
                        break;
                    case 2:
                        _Vector2 = new Vector2(transform.position.x + 0.5625f, transform.position.y - 0.6875f);
                        break;
                }

                _RaycastHit2D = Physics2D.Raycast(_Vector2, Vector2.down, Mathf.Infinity, LayerMask.GetMask("Ground", "Enemy"));

                if ((!_RaycastHit2D || _RaycastHit2D.distance > 0) && _Rigidbody2D.velocity.y < 0)
                {
                    _Animator.SetBool("Fall", true);

                    isJumpAble = false;
                }
                else if (_RaycastHit2D && _RaycastHit2D.distance <= 0 && _Rigidbody2D.velocity.y < 0)
                {
                    if (_RaycastHit2D.transform.CompareTag("Ground"))
                    {
                        _Animator.SetBool("Fall", false);

                        isJump = false;
                        isJumpAble = true;
                        _Dash = false;
                    }
                    else if (_RaycastHit2D.transform.CompareTag("Enemy"))
                    {
                        _Animator.SetBool("Fall", false);
                        _Animator.SetTrigger("_Jump");

                        isJump = true;
                        isJumpAble = false;
                        _Jump = true;

                        //
                        _RaycastHit2D.transform.GetComponent<Enemy>().Death();
                        //

                        AudioManager._AudioManager.SE_Ppyong(); // 효과음

                        return;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "House") // 도착
        {
            if (collision.CompareTag("NextStage"))
                is_cave_land = true;
            _Animator.SetBool("Crouch", true);
            _Animator.SetBool("Run", false);

            home = true;

            isRun = false;

            isJumpAble = false;

            //
            _BackGround_1.Off();
            _BackGround_2.Off();
            //

            AudioManager._AudioManager.BGM_Volume(0.7f);
            AudioManager._AudioManager.SE_Clear(); // 효과음

            is_clear = true;
            GameObject.Find("Canvas").GetComponent<UiManager>().Result();
        }

        if (collision.CompareTag("GameOver")) // 떨어진다
        {
            isHurt = true;

            //
            _BackGround_1.Off();
            _BackGround_2.Off();
            //

            Destroy(gameObject, 1.0f);

            AudioManager._AudioManager.BGM_Stop();
            AudioManager._AudioManager.SE_FallDown(); // 효과음

            GameObject.Find("Canvas").GetComponent<UiManager>().Result();
        }

        if (collision.CompareTag("Enemy") || collision.CompareTag("Obstacle"))//obstacle은 장애물
        {
            _Animator.SetTrigger("_Hurt");

            isHurt = true;

            isJumpAble = false;

            isRun = false;
            _Jump = true;

            gameObject.layer = 16;

            //
            _BackGround_1.Off();
            _BackGround_2.Off();
            //

            Destroy(gameObject, 1.0f);

            AudioManager._AudioManager.BGM_Stop();
            AudioManager._AudioManager.SE_FallDown(); // 효과음

            GameObject.Find("Canvas").GetComponent<UiManager>().Result();
        }
    }

    // 강희 : 피격부분
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy")) // 적에게 닿았다
        {
            _Animator.SetTrigger("_Hurt");

            isHurt = true;

            isJumpAble = false;

            isRun = false;
            _Jump = true;

            gameObject.layer = 16;

            //
            _BackGround_1.Off();
            _BackGround_2.Off();
            //

            Destroy(gameObject, 1.0f);

            AudioManager._AudioManager.BGM_Stop();
            AudioManager._AudioManager.SE_FallDown(); // 효과음

            GameObject.Find("Canvas").GetComponent<UiManager>().Result();
        }
    }
    //

    // 점프
    public void JumpButton()
    {
        if (!isRun)
        {
            isRun = true;
        }
        if (isJumpAble && !home)
        {
            _Animator.SetTrigger("_Jump"); // 점프 애니메이션
            isJump = true; // 점프상태
            isJumpAble = false; // 점프 불가능
            _Jump = true; // 점프 구현
            _Dash = true;

            AudioManager._AudioManager.SE_Jump();
        }
    }

    public void ButtonDown()
    {
        Began_Point = Input.GetTouch(0).position;

    }
    public void ButtonUp()
    {
        if (_Dash)
        {
            float inclination = 0;
            Ended_Point = Input.GetTouch(0).position;
            if (Began_Point.x - Ended_Point.x <= 0)
            {
                inclination = (Began_Point.y - Ended_Point.y) / (Began_Point.x - Ended_Point.x);

                if (inclination >= 5)
                    Dash_Direction = Vector2.up;
                if (inclination > 0.5 && inclination < 5)
                    Dash_Direction = Vector2.up + Vector2.right;
                if (inclination >= -0.5 && inclination <= 0.5)
                    Dash_Direction = Vector2.right;
                if (inclination < -0.5 && inclination > -5)
                    Dash_Direction = Vector2.down + Vector2.right;
                if (inclination <= -5)
                    Dash_Direction = Vector2.down;
                _Dash = false;
                isDash = true;
                StartCoroutine("DashCorutine");
            }
        }
    }
    IEnumerator DashCorutine()
    {
        while (true)
        {
            transform.Translate(Dash_Direction.x / 5, Dash_Direction.y / 5, 0);
            if (dash_duration <= 0)
            {
                isDash = false;
                dash_duration = dashPower;
                StopCoroutine("DashCorutine");
            }
            dash_duration -= 1;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
