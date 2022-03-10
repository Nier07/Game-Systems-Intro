using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : GradientHealth
{
    //redo this with IENumerators and coroutines later!!!!!!!!!!!!!!
    public enum AIStates
    {
        Patrol,
        Seek,
        Attack,
        Die
    }

    #region Variables
    public AIStates state;
    public Transform player;
    public Transform waypointParent;
    public Transform[] waypoints;
    public int curWaypoint, difficulty;
    public NavMeshAgent agent;
    public float walkSpeed, runSpeed, attackRange, attackSpeed, sightRange, baseDamage, critAmount;
    public bool isDead;
    public float distanceToPoint, changeCloseWaypoint;
    public float StopFromPlayer;
    public float turnSpeed;
    public Animator anim;
    #endregion

    public override void Start()
    {
        //runs inherted start function then this i think???
        base.Start();
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        //get navMeshAgent from self
        agent = GetComponent<NavMeshAgent>();
        //set speed of agent
        agent.speed = walkSpeed;
        //get animator component
        anim = GetComponent<Animator>();
        //set target waypoint
        curWaypoint = 1;
        //set ai state
        Patrol();
    }

    public override void Update()
    {
        base.Update();
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);
        anim.SetBool("Attack", false);

        Patrol();
        Seek();
        Attack();
        Die();
        FaceTarget();
    }
    #region FaceTarget
    void FaceTarget()
    {
        //makes the ai face player
        Vector3 turnTowardsNavSteeringTarget = agent.steeringTarget;
        Vector3 direction = (turnTowardsNavSteeringTarget - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //smooth rotation/turning
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
    #endregion
    #region Patrol
    void Patrol()
    {
        //returns out of patrol if within sight range or waypoints less than or = to 0 
        if (waypoints.Length <= 0 || Vector3.Distance(player.position, transform.position) <= sightRange || isDead)
        {
            return;
        }

        //makes ai go into waypoint since its an invisible gameobject its fine
        agent.stoppingDistance = 0;
        //changes ai speed
        agent.speed = walkSpeed;
        //changes state to patrol
        state = AIStates.Patrol;
        //sets animation to walk
        anim.SetBool("Walk", true);
        //changes ai destination to current waypoint goal
        agent.destination = waypoints[curWaypoint].position;
        //Calculates the distance to the goal based on current position and waypoint position
        distanceToPoint = Vector3.Distance(transform.position, waypoints[curWaypoint].position);

        // changes waypoint index if distance to point is less than threshold
        if (distanceToPoint <= changeCloseWaypoint)
        {
            if (curWaypoint < waypoints.Length - 1)
            {
                curWaypoint++;
            }
            else
            {
                curWaypoint = 1;
            }
        }
    }
    #endregion
    #region Seek
    void Seek()
    {
        //returns out of seek if the distance to player is out of sight range ot attack range or is dead
        if (Vector3.Distance(player.position, transform.position) > sightRange || Vector3.Distance(player.position, transform.position) < attackRange || isDead)
        {
            return;
        }
        //sets enum to seek
        state = AIStates.Seek;
        //applies run animation
        anim.SetBool("Run", true);
        //makes ai not go into player
        agent.stoppingDistance = StopFromPlayer;
        //changes agent speed
        agent.speed = runSpeed;
        //makes the waypoint player
        agent.destination = player.position;
    }
    #endregion
    #region Attack
    void Attack()
    {
        //retuens out of attack if player out of attack range or either ai or player is dead
        if (Vector3.Distance(player.position, transform.position) > attackRange || isDead /*|| PlayerHandler.isDead */)
        {
            return;
        }

        //makes ai not go into player
        agent.stoppingDistance = StopFromPlayer;
        //changes ai speed
        agent.speed = 0;
        //sets ai state to attack
        state = AIStates.Attack;
        //changes animation to attack animation
        anim.SetBool("Attack", true);
    }
    #endregion
    #region Die
    void Die()
    {
        //returns if current health is greater than 0 and if already dead
        if (attributes[0].curValue > 0 || isDead)
        {
            return;
        }
        //changes ai state to die
        state = AIStates.Die;
        //starts the death animation
        anim.SetTrigger("Die");
        //sets isdead to true to stop function from running multiple times
        isDead = true;
        //changes the wolds target to itself
        agent.destination = transform.position;
        //stops wolf from moving
        agent.speed = 0;
        //disables the NavMeshAgent
        agent.enabled = false;
    }
    #endregion
}