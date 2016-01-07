using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField]
    private GameObject text;
    private int numOfTasks;
    private int finishedTasks;

	// Use this for initialization
	void Start () {
        finishedTasks = 0;
        numOfTasks = TriggerBoxHandler.TriggerBoxCount;
	}
	
    public void FinishedTask()
    {
        finishedTasks++;
        
        if(finishedTasks >= numOfTasks)
        {
            text.GetComponent<Text>().text = "Game Over";
            text.SetActive(true);
        }
    }
}
