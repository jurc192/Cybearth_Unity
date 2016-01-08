using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        NavMeshAgent nav;               // Reference to the nav mesh agent.
        [SerializeField] GameObject patrolPoints;

        Transform[] pps;
        int numOfPps;
        int currentPP = 0;

        float timeToWait = 4f;
        float timer = 0;

        void Awake ()
        {
            nav = GetComponent <NavMeshAgent> ();
            pps = patrolPoints.GetComponentsInChildren<Transform>();
            numOfPps = pps.Length;

            nav.SetDestination(pps[currentPP].position);
        }


        void Update ()
        {
            if(Vector3.Distance(nav.destination,nav.transform.position) <  2)
            {
                timer += Time.deltaTime;

                if (timer >= timeToWait)
                {
                    currentPP = (currentPP + 1) % numOfPps;
                    nav.SetDestination(pps[currentPP].position);
                    timer = 0;
                }
            }
        }
    }
}