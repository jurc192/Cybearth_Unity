using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent nav;               // Reference to the nav mesh agent.
    [SerializeField] GameObject patrolPoints;

    Transform[] pps;
    int numOfPps;
    int currentPP;

    float timeToWait = 6f;
    float timer = 0;

    float viewDistance = 60;
    int rayNum = 2; // debug
    int fov = 124;
    Ray seeRay;
    int envMask;
    int enemyMask;

    bool sawPlayer = false;
    Transform player;

    public bool SawPlayer { get { return sawPlayer; } }

    void Awake ()
    {
        nav = GetComponent <NavMeshAgent> ();
        pps = patrolPoints.GetComponentsInChildren<Transform>();
        numOfPps = pps.Length;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        envMask = LayerMask.GetMask("Environment");
        enemyMask = LayerMask.GetMask("Enemies");

        int currentPP = Random.Range(0, numOfPps);
        nav.SetDestination(pps[currentPP].position);
    }

    void FixedUpdate()
    {
        if (!sawPlayer)
            doISeePlayer();
    }

    void Update ()
    {
        ////////Debug
        for (int i = 0; i < rayNum; i++)
        {
            Debug.DrawRay(transform.position, Quaternion.AngleAxis(-fov/2f + fov/(rayNum-1) * i, Vector3.up) * transform.forward * viewDistance, Color.red, 0.1f);
        }
        Debug.DrawLine(transform.position, player.position);
        ////////

        if (sawPlayer)
        {
            if (Vector3.Distance(transform.position, player.position) < 10f)
            {
                transform.LookAt(player.position);
                nav.Stop();
            }
            else
            {
                nav.Resume();
                nav.SetDestination(player.position);
            }
            alertOthers();
        }
        //patrol
        else
        {
            if (Vector3.Distance(nav.destination, nav.transform.position) < 2)
            {
                timer += Time.deltaTime;

                if (timer <= 2)
                    transform.Rotate(0, Time.deltaTime * 45 / 2, 0);
                else
                    transform.Rotate(0, Time.deltaTime * -45 / 2, 0);

                if (timer >= timeToWait)
                {
                    currentPP = (currentPP + 1) % numOfPps;
                    nav.SetDestination(pps[currentPP].position);
                    timer = 0;
                }
            }
        }
    }

    void doISeePlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        // ce ni predalec
        if (distanceToPlayer <= viewDistance)
        {
            Vector3 vecToPlayer = player.position - transform.position;
            float angleToPlayer = Vector3.Angle(transform.forward, vecToPlayer);
            // ce je znotraj kota vidnega polja
            if (Mathf.Abs(angleToPlayer) <= fov / 2f)
            {
                seeRay.origin = transform.position;
                seeRay.direction = vecToPlayer;

                //ce ni vmes stena ipd.
                if (Physics.Raycast(seeRay, distanceToPlayer, envMask))
                    return;

                alert();

            }
        }
    }

    void alertOthers()
    {
        Collider[] others = Physics.OverlapSphere(transform.position, 5f, enemyMask);
        foreach(Collider c in others)
        {
            EnemyMovement em = c.gameObject.GetComponent<EnemyMovement>();
            if(em != null)
            {
                em.alert();
            }
        }
    }

    public void alert()
    {
        sawPlayer = true;
        nav.speed = 8;
        GameObject head = transform.Find("Head").gameObject;
        head.GetComponent<Renderer>().material.color = Color.green;
    }

    public void SetNavDestination(Vector3 dest)
    {
        nav.SetDestination(dest);
    }
}
