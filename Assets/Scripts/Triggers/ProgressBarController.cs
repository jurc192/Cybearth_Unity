using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour {
    [SerializeField] private RectTransform filler;
    [SerializeField] private Text text;
    [Range(1, 100)] public int speed;

    private float percentage;
    private float maxWidth;

    void OnEnable()
    {
        percentage = 0f;
        maxWidth = transform.GetComponent<RectTransform>().rect.width;
    }

    void Update()
    {
        float width = (float)System.Math.Floor(percentage/100 * maxWidth);
        filler.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, width);

        if (IsDone()) OnCompletion();
    }

    public void Increase()
    {
        percentage += Time.deltaTime * speed;
        if(percentage >= 100.0)
        {
            percentage = 100f;
            text.text = "Done";
        }
        else
        {
            text.text = percentage.ToString().Substring(0,4) + " %";
        }
    }

    public bool IsDone()
    {
        return percentage == 100f;
    }

    void OnCompletion() { }
}
