using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


/// <summary>
/// ChanGyu, Yerin
/// </summary>
public class FPSPiece : MonoBehaviour
{
    [Header("Spec")]
    [SerializeField] float hp;

    [Header("Component")]
    [SerializeField] CharacterController controller;
    [SerializeField] Rigidbody rigid;
    [SerializeField] Weapon weapon;
    [SerializeField] Animator animator;
    [SerializeField] LayerMask groundCheck;
    [SerializeField] LayerMask hanCheck;
    [SerializeField] LayerMask dieCheck;
    [SerializeField] UICoolTime1 uiCoolTime1;
    [SerializeField] UICoolTime2 uiCoolTime2;

    [Header("Property")]
    [SerializeField] float moveSpeed;
    [SerializeField] float breakPower;

    [SerializeField] bool isGround;  // 플레이어의 땅 위 여부
    [SerializeField] bool isWalking; // 플레이어의 걷기 여부
    [SerializeField] bool isJumping; // 플레이어의 점프 여부

    bool canUseSkill = true;

    Coroutine coolTime;

    public float HP { get { return hp; } }
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public bool CanUseSkill { get { return canUseSkill; } set { canUseSkill = value; } }
    public Weapon Weapon { get { return weapon; } }

    List<Collider> groundList = new List<Collider>();

    private Vector3 moveDir;

    [SerializeField] UnityEvent OnDied;

    void Awake()
    {
        groundList = new List<Collider>();
    }

    public void Start()
    {
        if (hanCheck.Contain(gameObject.layer))
        {
            uiCoolTime1 = FindAnyObjectByType<UICoolTime1>();
            uiCoolTime2 = null;
        }
        else
        {
            uiCoolTime1 = null;
            uiCoolTime2 = FindObjectOfType<UICoolTime2>();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// ChanGyu
    /// 플레이어 이동 함수
    /// </summary>
    public void Move()
    {
        controller.Move(transform.right * moveDir.x * moveSpeed * Time.deltaTime);
        controller.Move(transform.forward * moveDir.z * moveSpeed * Time.deltaTime);

        if (moveDir.x == 0 && moveDir.z == 0)
        {
            isWalking = false;
        }

        if (isGround)
        {
            if (!isJumping)
            {
                if (isWalking)
                {
                    animator.Play("Walk");
                }
                else
                {
                    animator.Play("Idle A");
                }
            }
            else
            {
                animator.Play("Jump");
            }
        }
    }

    /// <summary>
    /// ChanGyu
    /// 마우스 클릭을 했을 시 발사하는 함수
    /// 차징무기를 위한 로직을 따로 구현한 상태
    /// 어썰트라이플을 위한 로직도 따로 구현
    /// </summary>
    /// <param name="value"></param>
    void OnFire(InputValue value)
    {
        MaAssultRiffle assultRiffle;
        weapon.TryGetComponent(out assultRiffle);

        ChargingWeapon charge;
        if (!weapon.TryGetComponent(out charge))
        {
            charge = null;
        }

        if (value.isPressed)
        {
            if (charge != null)
            {
                charge.Charging();
            }
            else if (assultRiffle != null)
            {
                assultRiffle.StartFiring();
            }
            else
            {
                weapon.Fire();
            }
        }
        else
        {
            if (charge != null)
            {
                charge.Fire();
            }
            else if (assultRiffle != null)
            {
                assultRiffle.StopFiring();
            }
        }
    }

    // 인풋액션에서 받아오는 정보
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        moveDir.x = input.x;
        moveDir.z = input.y;

        isWalking = true;
    }

    // 점프
    private void OnJump(InputValue value)
    {
        isJumping = true;
    }

    protected virtual void OnSkill(InputValue value)
    {
        if (hanCheck.Contain(gameObject.layer))
        {
            uiCoolTime1.CoolTimeCheck();
        }
        else
        {
            uiCoolTime2.CoolTimeCheck();
        }
    }

    /// <summary>
    /// 데미지를 받는 함수
    /// </summary>
    /// <param name="damage"></param>
    public virtual void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp > 0)     // 체력이 0초과면 리턴
            return;

        Die();
    }

    /// <summary>as
    /// 사망하는 함수
    /// </summary>
    protected virtual void Die()
    {
        Debug.Log("Die");
        OnDied?.Invoke();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (groundCheck.Contain(other.gameObject.layer))    // 플레이어가 땅 위에 있을 경우
        {
            groundList.Add(other);
            isGround = true;
            isJumping = false;
        }

        if (dieCheck.Contain(other.gameObject.layer))
        {
            Die();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (groundCheck.Contain(other.gameObject.layer))    // 플레이어가 땅 위에 없을 경우
        {
            groundList.Remove(other);
            if (groundList.Count == 0)
            {
                isGround = false;
            }
        }
    }

    public void makeIsJumpingFalse()
    {
        isJumping = false;
    }

    IEnumerator SkillCoolTime(float time)
    {
        yield return new WaitForSeconds(time);

        canUseSkill = true;
    }

    public void CoolTime(float time)
    {
        coolTime = StartCoroutine(SkillCoolTime(time));
    }
}