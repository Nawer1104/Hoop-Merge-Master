using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Level : MonoBehaviour
{
    public List<GameObject> gameObjects;

    [SerializeField] private LineRenderer line;

    private TouchPoint fistCollected;

    List<TouchPoint> listCollected = new List<TouchPoint>();

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            listCollected.Clear();
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                //pl.localScale = Vector3.one * 0.6f;
                line.positionCount = 0;
                line.positionCount++;
                line.SetPosition(line.positionCount - 1, targetObject.transform.position);
            }
        }

        if (Input.GetMouseButton(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                var tp = targetObject.GetComponent<TouchPoint>();
                if (tp != null)
                {
                    if (fistCollected == null)
                    {
                        fistCollected = tp;
                        if (!listCollected.Contains(tp))
                            listCollected.Add(tp);
                        line.positionCount++;
                        line.SetPosition(line.positionCount - 1, tp.transform.position);
                    }
                    else
                    {
                        if (!listCollected.Contains(tp))
                            listCollected.Add(tp);
                        line.positionCount++;
                        line.SetPosition(line.positionCount - 1, tp.transform.position);
                    }
                }

                if (listCollected.Count == 2)
                {
                    line.positionCount = 0;

                    if (CheckList(listCollected))
                    {
                        foreach (TouchPoint point in listCollected)
                        {
                            point.SetCompleted();
                        }
                    }
                    else
                        return;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {

        }
    }

    private bool CheckList(List<TouchPoint> listCollected)
    {
        if (listCollected[0].GetComponent<SpriteRenderer>().sprite == listCollected[1].GetComponent<SpriteRenderer>().sprite)
        {
            return true;
        }

        return false;
    }
}
