using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementInput;
    public UnityEvent OnAttack;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float chaseDistanceThreshold = 3;

    [SerializeField]
    private float attackDelay = 1;
    private float passedTime = 1;

    private void Update()
    {
        if (player == null)
            return;

        float distance = Vector2.Distance(player.position, transform.position);
        if(distance < chaseDistanceThreshold)
        {
            Vector2 direction = player.position - transform.position;
            OnMovementInput?.Invoke(direction.normalized);

        }
        if(passedTime < attackDelay)
        {
            passedTime += Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnMovementInput?.Invoke(Vector2.zero);
        if (passedTime >= attackDelay)
        {
            passedTime = 0;
            OnAttack?.Invoke();
        }
    }
}
