﻿using UnityEngine;
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

    bool active = false;

	void Start () {
        elevator = transform.parent;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        text = infoText.GetComponent<Text>();
	}

	void Update()
    {
        if (active && Input.GetKeyDown(KeyCode.E))
        {
            direction = (direction + 1) % 4;
        }

        if (direction == 1 && elevator.transform.position.y >= 18.411)
        {
            Vector3 tmp = elevator.transform.position;
            tmp.y = 18.411f;
            elevator.transform.position = tmp;

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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoText.SetActive(true);
            text.text = "PRESS < E >\nTO TOGGLE";
            active = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoText.SetActive(false);
            active = false;
        }
    }

    public void CallElevator()
    {
        direction = 1;
    }
}
