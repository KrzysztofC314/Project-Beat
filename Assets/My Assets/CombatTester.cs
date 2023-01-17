using System.Collections.Generic;
using UnityEngine;

public class CombatTester : MonoBehaviour
{
    [SerializeField] private bool canAttack = true;
    
    [SerializeField] private Collider2D inLineCollider;
    
    [SerializeField] private LayerMask enemyLayer;
    
    PlayerInput input;
    Controls controls = new Controls();
    private ContactFilter2D contactFilter2D;
    public List<Collider2D> cols = new List<Collider2D>();
    public Animator animator;
    public Transform attackPoint;
    public float attackRange;
    public int attackDamage = 20;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        contactFilter2D.SetLayerMask(enemyLayer);
    }

    // Update is called once per frame
    void Update()
    {
        controls = input.GetInput();
        if (Time.time >= nextAttackTime)
        {
            if (controls.AttackState)
            {
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + 1f / attackRate;
                inLineCollider.OverlapCollider(contactFilter2D, cols);
                if (cols.Count > 0)
                {
                    foreach (var col in cols)
                    {
                        print(col.transform.name);
                        if (col.TryGetComponent(out SpriteRenderer sr))
                        {
                            sr.color = Color.red;
                        }
                        Attack();
                    }
                }
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }
    void Attack()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }


    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
