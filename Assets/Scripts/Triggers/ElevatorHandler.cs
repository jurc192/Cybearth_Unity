using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ElevatorHandler : MonoBehaviour {
    [SerializeField] GameObject infoText;
    Text text;

    Transform elevator;
    Transform player;

    bool playerOnElevator = false;
    public bool PlayerOnElevator { get { return playerOnElevator; } set { playerOnElevator = value; } }

    float speed = 10f;
    // direction: 0 = stop, 1 = up, 2 = stop, 3 = down;
    int direction = 0;
    bool isOnTop = false;
    float timeToWait = 5f;
    float timer = 0f;


	void Start () {
        elevator = transform.parent;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        text = infoText.GetComponent<Text>();
	}

	void Update()
    {
        if (direction == 1 && elevator.transform.position.y >= 70)
        {
            direction = 2;
            isOnTop = true;
            timer = 0f;
        }
        else if (direction == 3 && elevator.transform.position.y <= 0.05)
        {
            direction = 0;
        }

        if (isOnTop)
        {
            timer += Time.deltaTime;
            if(timer >= timeToWait)
            {
                direction = 3;
                isOnTop = false;
            }
        }
    }

	void FixedUpdate () {
        if (direction == 1)
        {
            elevator.transform.Translate(Vector3.up * speed * Time.deltaTime);
            if (PlayerOnElevator)
                player.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (direction == 3)
        {
            elevator.transform.Translate(-1 * Vector3.up * speed * Time.deltaTime);
            if(PlayerOnElevator)
                player.Translate(-1 * Vector3.up * speed * Time.deltaTime);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                direction = (direction + 1) % 4; 
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoText.SetActive(true);
            text.text = "PRESS < E >\nTO TOGGLE";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoText.SetActive(false);
        }
    }

    public void CallElevator()
    {
        direction = 1;
    }
}
