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

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        contactFilter2D.SetLayerMask(enemyLayer);
    }

    // Update is called once per frame
    void Update()
    {
        controls = input.GetInput();
        if (controls.AttackState)
        {
            animator.SetTrigger("Attack");
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
        }
    }
    void Attack()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
        }


    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
