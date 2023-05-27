using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bee : MonoBehaviour
{

    public enum State { Idle, Trace, Return, Attack, Patrol }

    [SerializeField] private TMP_Text text;     
    [SerializeField] private float detectRange; 
    [SerializeField] private float attackRange;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform[] patrolPoints;

    private State curState;                           
                                                      
    private Transform player;                         
    private Vector3 returnPosition;                   
    private int patroIndex = 0;                       
    private void Start()
    {
        curState = State.Idle;                          
        player = GameObject.FindGameObjectWithTag("Player").transform;
        returnPosition = transform.position;           
    }
    private void Update()
    {
        switch (curState)                             
        {
            case State.Idle:
                text.text = "Idle";
                IdleUpdate();
                break;
            case State.Trace:
                text.text = "Trace";
                TraceUpdate();
                break;
            case State.Return:
                text.text = "Return";
                ReturnUpdate();
                break;
            case State.Attack:
                text.text = "Attack";
                AttackUpdate();
                break;
            case State.Patrol:
                PatrolUpdate();
                break;
        }
    }
    float idleTime = 0;
    private void IdleUpdate()  
    {
   

   
        if (idleTime > 2) 
        {
            idleTime = 0; 
            patroIndex = (patroIndex + 1) % patrolPoints.Length; 
            curState = State.Patrol; 
        }
        idleTime += Time.deltaTime;

        if (Vector2.Distance(player.position, transform.position) < detectRange) 
        {
            curState = State.Trace;
        }
    }
    private void TraceUpdate()
    {
        Vector2 dir = (player.position - transform.position).normalized;  
        transform.Translate(dir * moveSpeed * Time.deltaTime);

        if (Vector2.Distance(player.position, transform.position) > detectRange)
        {
            curState = State.Return;
        }

        else if (Vector2.Distance(player.position, transform.position) < attackRange)
        {
            curState = State.Attack;
        }
    }
    private void ReturnUpdate() 
    {

        Vector2 dir = (returnPosition - transform.position).normalized;
        transform.Translate(dir * moveSpeed * Time.deltaTime);


        if (Vector2.Distance(transform.position, returnPosition) < 0.02f) 
                                                                          
        {
            curState = State.Idle;
        }
        else if (Vector2.Distance(player.position, transform.position) < detectRange)
        {
            curState = State.Trace; 
        }
    }
    float lastAttackTime = 0;
    private void AttackUpdate()
    {
        
        if (lastAttackTime > 3) 
        {
            Debug.Log("АјАн");
            lastAttackTime = 0; 
        }
        lastAttackTime += Time.deltaTime;  
                                           

        if (Vector2.Distance(player.position, transform.position) > attackRange) 
        {
            curState = State.Trace; 
        }
    }
    private void PatrolUpdate() 
    {

        Vector2 dir = (patrolPoints[patroIndex].position - transform.position).normalized;
        transform.Translate(dir * moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, patrolPoints[patroIndex].position) < 0.02f)  

        {
            curState = State.Idle; 

        }
        else if (Vector2.Distance(player.position, transform.position) < detectRange) 
        {
            curState = State.Trace; 
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;                            
        Gizmos.DrawWireSphere(transform.position, detectRange); 
        Gizmos.color = Color.red;                               
        Gizmos.DrawWireSphere(transform.position, attackRange); 
    }
}
