using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TriggerBoxHandler : MonoBehaviour {

    private static int triggerBoxCount = 0;
    public static int TriggerBoxCount
    {
        get
        {
            return triggerBoxCount;
        }
    }

    private bool isTriggerOn = false;

    [SerializeField] private ProgressBarController progressBar;
    [SerializeField] private GameObject progressBarGO;
    [SerializeField] private GameObject infoText;
	[SerializeField] private ControlTerminalScript cts;

    private Text text;

    void Start()
    {
        triggerBoxCount++;
        text = infoText.GetComponent<Text>();
    }

    void Update()
    {
        if (isTriggerOn)
        {
            if (Input.GetKey(KeyCode.E))
            {
                infoText.SetActive(false);
                progressBarGO.SetActive(true);
                progressBar.Increase();

                if (progressBar.IsDone())
                {
                    Done();
                }
            }
            else
            {
                infoText.SetActive(true);
                progressBarGO.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            infoText.SetActive(true);
            text.text = "HOLD < E >\nTO HACK";
            
            isTriggerOn = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            infoText.SetActive(false);
            progressBarGO.SetActive(false);
            isTriggerOn = false;
        }
    }

    private void Done()
    {
        GameController gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        infoText.SetActive(false);
        progressBarGO.SetActive(false);

		cts.HackJumbo();
		
        gameController.FinishedTask();

        this.enabled = false;
    }
}
