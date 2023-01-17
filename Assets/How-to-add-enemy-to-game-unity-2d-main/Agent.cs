using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Agent : MonoBehaviour
{
    private AgentAnimations agentAnimations;
    private AgentMover agentMover;
    [SerializeField] private Collider2D inLineCollider;
    private ContactFilter2D contactFilter2D;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Vector2 movementInput;
    [SerializeField] private Animator animator;
    public List<Collider2D> cols = new List<Collider2D>();
    public Transform attackPoint;
    public float attackRange;
    public int attackDamage = 20;

    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }

    private void Update()
    {
        //movementInput = movement.action.ReadValue<Vector2>().normalized;

        agentMover.MovementInput = movementInput;
        AnimateCharacter();
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        inLineCollider.OverlapCollider(contactFilter2D, cols);
        if (cols.Count > 0)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            }
        }


    }

    private void Awake()
    {
        agentAnimations = GetComponentInChildren<AgentAnimations>();
        agentMover = GetComponent<AgentMover>();
    }

    private void AnimateCharacter()
    {
        agentAnimations.PlayAnimation(movementInput);
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}