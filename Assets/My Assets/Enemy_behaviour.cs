using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_behaviour : MonoBehaviour
{
     #region Public Variables
     public Transform rayCast;
     public LayerMask raycastMask;
     public float raycastLength;
     public float attackDistance;
     public float moveSpeed;
     public float timer;
     public int maxHealth = 20;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private Collider2D collider;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
    private int currentHealth;
    #endregion

    void Awake ()
    {
      intTimer = timer;
      anim = GetComponent<Animator>();
      currentHealth = maxHealth;

    }

    void Update()
    {
        if (inRange)
        {
           hit = Physics2D.Raycast (rayCast.position, Vector2.left, raycastLength, raycastMask);
           RaycastDebugger ();
        }

        //When Player is detected
        if (hit.collider != null)
        {
           EnemyLogic();
        }
        else if(hit.collider == null)
        {
            inRange = false;
        }
        
        if(inRange == false)
        {
            anim.SetBool ("canWalk", false);
            StopAttack();
        }


    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
          target = trig.gameObject;
          inRange = true;

        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if(distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if(attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            anim.SetBool("Attack", false);
        }
    }

    void Move()
    {
        anim.SetBool("canWalk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Skel_attack"))
        {
           Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
        
           
           transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
           }

    }
     void Attack()
     {
          timer = timer - intTimer; //Reset Timer when Player enter Attack Range
          attackMode = true; //To check if Enemy can still attack or not

          anim.SetBool("canWalk", false);
          anim.SetBool("Attack", true);

     }

    void StopAttack()
    {
         cooling = false;
         attackMode = false;
         anim.SetBool("Attack", false);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetBool("IsDead",true);
        collider.enabled = false;
        this.enabled = false;
    }

    void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
           Debug.DrawRay(rayCast.position, Vector2.left * raycastLength, Color.red);
        }
         else if (attackDistance > distance)
        {
          Debug.DrawRay(rayCast.position, Vector2.left * raycastLength, Color.green);
        }
        
        
        }
}
