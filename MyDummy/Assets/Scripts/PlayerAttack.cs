using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;


public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private Animator animator;

    [SerializeField] private PlayerController playerController;

    private bool isAttacking;

    [SerializeField] private Transform attackPoint;

    [SerializeField] private int attackDamage = 10;

    [SerializeField] private float attackRange = 1.0f;

    [SerializeField] private float attackDuration = 0.8f;
    [SerializeField] private float attackMoment = 0.3f;
    [SerializeField] private string attackAnimationname = "Atack";


    void Start()
    {

    }

    void Update()
    {
        Mouse mouse = Mouse.current;

        if (mouse == null || isAttacking) return;
        if (playerController.IsNormalState() == false) return;

        if (mouse.leftButton.wasPressedThisFrame)
        {
            StartCoroutine("");
        }
    }

    private IEnumerable AttackAnimation()
    {
        isAttacking = true;

        playerController.ChangeState(PlayerState.Attack);
        animator.CrossFade("Attack01", 0.1f);

        yield return new WaitForSeconds(0.8f);

        animator.CrossFade("Blend Tree", 0.1f);
        playerController.ChangeState(PlayerState.Normal);
        isAttacking = false;
    }

    private void HitEnemy()
    {
        Collider[] targets = Physics.OverlapSphere(attackPoint.position, attackRange);

        foreach (Collider target in targets)
        {
            EnemyHealth enemy = target.GetComponent<EnemyHealth>();

            if (enemy == null) continue;

            enemy.TakeDamage(attackDamage);
            //break                              //break면 1명만 데미지 들어감

        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }


}
