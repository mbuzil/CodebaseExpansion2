using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] int dotsNumber;
    [SerializeField] GameObject dotsParent;
    [SerializeField] GameObject dotsPrefab;
    [SerializeField]float dotSpacing;
    [SerializeField] [Range(0.01f, 0.3f)] float dotMinScale;
    [SerializeField][Range(0.3f, 1f)]float dotMaxScale;



    Transform [] dotsList;
    Vector2 pos;

    float timeStamp;

    void Start()
    {
        Hide();
        //prepare dots

    PrepDots();

    }

    void PrepDots()
    {
        dotsList = new Transform[dotsNumber];
        dotsPrefab.transform.localScale = Vector3.one * dotMaxScale;

        float scale = dotMaxScale;
        float scaleFactor = scale / dotsNumber;
        for(int i = 0; i< dotsNumber; i++)
        {
            dotsList [i] = Instantiate (dotsPrefab, null).transform;
            dotsList [i].parent = dotsParent.transform;

            dotsList [i].localScale = Vector3.one * scale;
            if(scale > dotMinScale)
            scale -= scaleFactor;
        }
    }


public void UpdateDots(Vector3 seedPos, Vector2 forceApplied)
{
    timeStamp = dotSpacing;
    
    for(int i = 0; i< dotsNumber; i++)
    {
        pos.x = (seedPos.x + forceApplied.x * timeStamp);
        pos.y = (seedPos.y + forceApplied.y * timeStamp) - (Physics2D.gravity.magnitude*timeStamp*timeStamp)/2f;

        dotsList [i].position = pos;
        timeStamp += dotSpacing;
    }

}
    public void Show()
    {
        dotsParent.SetActive(true);
    }

    public void Hide()
    {
        dotsParent.SetActive(false);
    }
}
