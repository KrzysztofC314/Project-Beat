using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Agent : MonoBehaviour
{
    private AgentAnimations agentAnimations;
    private AgentMover agentMover;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Collider2D inLineCollider;
    [SerializeField] private Vector2 movementInput;
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

    private void PerformAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
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


}
