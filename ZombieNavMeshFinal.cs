
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class ZombieNavMeshFinal : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    public Animator animator;
    public int playerHealth;


    //Targets
    public GameObject[] MoveTargets2;
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

    public ChangeSceneButton changeSceneButton;

    private void Start()
    {
        animator = GetComponent<Animator>();
        MoveTargets2 = GameObject.FindGameObjectsWithTag("MoveTargetFinal");
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(MoveTargets2[TargetNow].transform.position);
        agent.speed = 1f;
    }

    private void Update()
    {
        
    }

    private void WaitForNewTarget()
    {
      
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("MoveTargetFinal"))
        {
            TargetMovingTo = false;
            animator.SetBool("FinalRadio", true);
        }
    }

    
}
