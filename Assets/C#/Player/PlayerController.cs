using System;
using System.Collections.Generic;
using UnityEngine;
using MyNamespace;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Rigidbody2D Playrb;
    [NonSerialized] public Animator anime;
    private StateMachine stateMachine;
    private SpriteRenderer spriteRenderer;
    //フィールドとローカル変数を区別するために_(アンダースコア)を付けるのだ:D
    [SerializeField] GameObject _bullet;
    [SerializeField] float _bulletDelay;
    [SerializeField] float _Bulletspeed = 3.0f;
    [SerializeField] float _JumpPower;
    [SerializeField] float _sprintSpeed;
    [SerializeField] float _baseMoveSpeed;
    [SerializeField] float _stepSpeed;

    public bool IsDead { get; private set; }
    private bool _jumpRequested;
    private bool _IsGround;
    private bool _stepRequest;
    private bool isSprint;
    private bool _isShooting;
    private int lastDir;


    private float _bulletTime;
    private GameObject bulletIns;
    private SpriteRenderer armSR;
    private Vector2 mousePos;
    // キャッシュされた入力（Update でのみ読み取り）
    private int _horizontalInput;

    // 状態インスタンスを再利用して割当を減らす
    private IState _idleState;
    private IState _walkState;
    private IState _jumpState;
    private IState _shootState;
    private IState _dieState;


    void Awake()
    {
        armSR = transform.Find("Arm").GetComponent<SpriteRenderer>();
        stateMachine = new StateMachine();
        anime = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (Playrb == null)
            Playrb = GetComponent<Rigidbody2D>();
        
        // 状態インスタンスを一度だけ生成して再利用
        _idleState = new IdleState(this);
        _walkState = new WalkState(this);
        _jumpState = new JumpState(this);
        _shootState = new ShootState(this);
        _dieState = new DieState(this);
        // 初期状態を設定
        stateMachine.ChangeState(_idleState);
    }

    void Update()
    {
        // 入力を一度だけ読み取り、FixedUpdate ではキャッシュを使う
        if (Input.GetKey(KeyCode.D))
        {
            _horizontalInput = 1;
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _horizontalInput = -1;
            spriteRenderer.flipX = true;
        }
        else _horizontalInput = 0;

        if (_horizontalInput > 0) lastDir = 1;
        
        else if (_horizontalInput < 0) lastDir = -1;

        IState desiredState;
        if (GameManager.Instance.helthController._currentHealth <= 0)
        {
            if(GameManager.Instance.helthController ==null) Debug.LogError("HealthController is not assigned in GameManager!");
            IsDead = true;
            if (IsDead)
            {
                desiredState = _dieState;
                stateMachine.ChangeState(desiredState);
            }
        }
        // 状態の決定（インスタンスを再利用、不要な再遷移を防ぐ）
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _isShooting = true;
            _bulletTime += Time.deltaTime;
        }
        else
        {
            _bulletTime = 0f;
            _isShooting = false;
        }

        if (_IsGround && Input.GetKeyDown(KeyCode.Space))
        {
            _jumpRequested = true;
            desiredState = _jumpState;
        }
        
        else if (_horizontalInput != 0f)
        {
            desiredState = _walkState;
        }
        else if (_isShooting)
        {
            desiredState = _shootState;
        }
        else
        {
            desiredState = _idleState;
            
        }

        stateMachine.ChangeState(desiredState);

        if (Input.GetKeyDown(KeyCode.LeftShift))
            _stepRequest = true;

        if (Input.GetKeyDown(KeyCode.LeftControl))
            isSprint = !isSprint;

        if (_horizontalInput == 0f)
            isSprint = false;

        // 状態のロジック更新（各状態の Update を呼ぶ）
        stateMachine.Update();

        Vector3 mouse = Input.mousePosition;
        mouse.z = Mathf.Abs(Camera.main.transform.position.z);
        mousePos = Camera.main.ScreenToWorldPoint(mouse);
    }

    void FixedUpdate()
    {

        // スピードはフィールドを上書きせずローカルで計算
        float currentSpeed = _baseMoveSpeed * (isSprint ? _sprintSpeed : 1f);

        // まず X 目標速度を決定（Y は保持）
        float targetX = _horizontalInput * currentSpeed;

        // ステップ（ダッシュ）処理は優先して X を上書きするが Y は保持する
        if (_stepRequest && lastDir != 0)
        {
            targetX = _stepSpeed * lastDir;
            _stepRequest = false;
        }

        // 物理速度は一度だけ設定（Y 成分は保持）
        Playrb.velocity = new Vector2(targetX, Playrb.velocity.y);

        // ジャンプは AddForce（FixedUpdate で行う）
        if (_jumpRequested)
        {
            Playrb.AddForce(Vector2.up * _JumpPower, ForceMode2D.Impulse);
            _jumpRequested = false;
        }

        Vector2 dir = (mousePos - (Vector2)transform.position).normalized;
        armSR.transform.rotation = Quaternion.FromToRotation(Vector2.right, dir);//右向きを基準にdirという方向に回転する

        if (_bulletTime > _bulletDelay)
        {
            Vector2 spawnPos = (Vector2)armSR.transform.position + dir * 2.0f;
            bulletIns = Instantiate(_bullet, spawnPos, Quaternion.identity);
            bulletIns.GetComponent<Rigidbody2D>().velocity = dir * _Bulletspeed;
            _bulletTime -= _bulletTime;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        switch (collision.gameObject.tag)
        {
            case "Ground":
                _IsGround = true;
                break;
            case "damg":
                GameManager.Instance.helthController.TakeDamage(GameManager.Instance.helthController._damageAmount);
                _IsGround = true;
                Debug.Log("damage taken");
                break;
        }
        
            
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _IsGround = false;
        }
        else _IsGround = true;

    }
}