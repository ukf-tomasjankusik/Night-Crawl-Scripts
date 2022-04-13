
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class ZombieNavMesh : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    public Animator animator;
    public int playerHealth;


    //Targets
    public GameObject[] MoveTargets;
    private int TargetNow = 0;
    private int TargetNowLast = 0;
    [HideInInspector]
    public bool TargetMovingTo = false;

    //Check for Ground/Obstacles
    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //Attack Player
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Audio;
    private int lastState = -2;
    private int actualState = -1;
    private bool stateChanged = true;
    public AudioSource ZombieFootsteps;

    public ChangeSceneButton changeSceneButton;

    private void Start()
    {
        ZombieFootsteps = GetComponent<AudioSource>();
        ZombieFootsteps.Play();
        StartLookForPlayer();
    }
    private void Awake()
    {     
        agent = GetComponent<NavMeshAgent>();
        MoveTargets = GameObject.FindGameObjectsWithTag("MoveTarget");
        animator = GetComponent<Animator>();
    }

    public void StartLookForPlayer()
    {
        player = GameObject.Find("FPSController").transform;
    }

    private void Update()
    {
        RaycastHit hit;
        Physics.SphereCast(transform.position, 3f, transform.forward, out hit, 6);
        
            //Check if Player in sightrange
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        //Check if Player in attackrange
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);


        if (!playerInSightRange && !playerInAttackRange) //state 1
        {
            actualState = 1;
            if (lastState != actualState) stateChanged = true;
            lastState = actualState;
            Patroling();
        }
        if (playerInSightRange && !playerInAttackRange)     //state 2
        {
            actualState = 2;
            if (lastState != actualState) stateChanged = true;
            lastState = actualState;
            ChasePlayer();
        }

        if (playerInAttackRange && playerInSightRange) //state 3
        {
            AttackPlayer();
        }

    }

    private void Patroling()
    {

        agent.SetDestination(MoveTargets[TargetNow].transform.position);
        agent.speed = 1f;
        animator.SetBool("isPatrolling", true);
        animator.SetBool("isChasing", false);
        animator.SetBool("isAttacking", false);

        if (TargetMovingTo == false)
        {
            
            TargetMovingTo = true;

            while (TargetNow == TargetNowLast)
            {
                TargetNow = Random.Range(0, MoveTargets.Length);
            }
            TargetNowLast = TargetNow;
            agent.SetDestination(MoveTargets[TargetNow].transform.position);
        }
    }

    private void WaitForNewTarget()
    {
        TargetMovingTo = false;
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("MoveTarget"))
        {
          TargetMovingTo = false;
            
        }
    }

    private void ChasePlayer()
    {
        if (stateChanged == true)
        {
            FindObjectOfType<ZombieAudioManager>().Play("ZombieChasing");
        }

        stateChanged = false;

        animator.SetBool("isChasing", true);
        animator.SetBool("isAttacking", false);
        agent.speed = 2.5f;
        agent.SetDestination(player.position);
        
    }
    private void AttackPlayer()
    {
        agent.SetDestination(player.position);


        if (!alreadyAttacked){
            animator.SetBool("isChasing", false);
            animator.SetBool("isAttacking", true);
            //Attack         
            playerHealth--;
            if (playerHealth == 0)
            {
                FindObjectOfType<ZombieAudioManager>().Play("Death");
                ZombieFootsteps.Stop();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                SceneManager.LoadScene("GameOver");
            }
            else
                FindObjectOfType<ZombieAudioManager>().Play("Hit");
            
            alreadyAttacked = true;
            Invoke("ResetAttack", timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void ZombieFootstepsTurnOn()
    {
        ZombieFootsteps.enabled = true;
    }

    private void Destroyy()
    {
        Destroy(gameObject);
    }
}
