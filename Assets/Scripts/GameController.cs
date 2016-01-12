using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField] private GameObject fpc;
    [SerializeField] private GameObject findForkBombText;
    [SerializeField] private GameObject plantForkBombText;
    [SerializeField]
    private GameObject forkBomb;
    [SerializeField]
    private GameObject door;


    [SerializeField] private Text hackText;

    private int allHacks;
    private int alreadyHacked;

	// Use this for initialization
	void Start () {
        alreadyHacked = 0;
        //allHacks = TriggerBoxHandler.TriggerBoxCount;
        allHacks = 1;
    }
	
    public void FinishedHacking()
    {
        alreadyHacked++;
        hackText.text = "- Hack all terminals [" + alreadyHacked.ToString() + "/1]";

        if (alreadyHacked >= allHacks)
        {
            hackText.color = Color.green;
            findForkBombText.SetActive(true);
            forkBomb.SetActive(true);
        }
    }

    public void PickedUpForkBomb()
    {
        findForkBombText.GetComponent<Text>().color = Color.green;
        plantForkBombText.SetActive(true);
        door.SetActive(true);
    }
}
