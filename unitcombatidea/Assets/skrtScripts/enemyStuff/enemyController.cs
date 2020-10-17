using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyController : MonoBehaviour
{
    public float transitionPatrol = 10f;
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    public bool patrolTrip1;
    public bool patrolTrip2 = true;
    public bool patrolTrip3 = true;
    public bool patrolTrip4 = true;
    public bool patrolTrip5 = true;
    public Transform patrol1;
    public Transform patrol2;
    public Transform patrol3;
    public Transform patrol4;
    public Transform patrol5;
    public Transform gun;
    public AIBulletScript aiBS;
    public float attackDistance;

    // Start is called before the first frame update
    void Start()
    {
        target = playerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance > lookRadius)
        {
            patrol();
            lookRadius = 20f;
        }
        if(distance <= lookRadius)
        {
            FoundPlayer();
        }

        if(distance <= agent.stoppingDistance)
        {
            FaceTarget();
            //attack the target
        }

    }

    void patrol()
    {
        if(!patrolTrip1)
        {
            float patrolDistance1 = Vector3.Distance(patrol1.position, transform.position);
            agent.SetDestination(patrol1.position);
            if(patrolDistance1 < transitionPatrol)
            {
                patrolTrip1 = true;
                patrolTrip2 = false;
            }
        }
         if(!patrolTrip2)
        {
            float patrolDistance2 = Vector3.Distance(patrol2.position, transform.position);
            agent.SetDestination(patrol2.position);
            if(patrolDistance2 < transitionPatrol)
            {
                patrolTrip2 = true;
                patrolTrip3 = false;
            }
        }
         if(!patrolTrip3)
        {
            float patrolDistance3 = Vector3.Distance(patrol3.position, transform.position);
            agent.SetDestination(patrol3.position);
            if(patrolDistance3 < transitionPatrol)
            {
                patrolTrip3 = true;
                patrolTrip4 = false;
            }
        }
         if(!patrolTrip4)
        {
            float patrolDistance4 = Vector3.Distance(patrol4.position, transform.position);
            agent.SetDestination(patrol4.position);
            if(patrolDistance4 < transitionPatrol)
            {
                patrolTrip4 = true;
                patrolTrip5 = false;
            }
        }
         if(!patrolTrip5)
        {
            float patrolDistance5 = Vector3.Distance(patrol5.position, transform.position);
            agent.SetDestination(patrol5.position);
            if(patrolDistance5 < transitionPatrol)
            {
                patrolTrip5 = true;
                patrolTrip1 = false;
            }
        }
    }
    void FoundPlayer()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        agent.SetDestination(target.position);
        lookRadius = 40f;
        if(distance < attackDistance)
        {
            agentAttack();
        }
    }
    void agentAttack()
    {
        Vector3 direction = (target.position - gun.position).normalized;
        Quaternion gunRotation = Quaternion.LookRotation(direction);
        gun.rotation = Quaternion.Slerp(gun.rotation,gunRotation,Time.deltaTime * 5f); 
        aiBS.firing = true;
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime * 5f); 

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
