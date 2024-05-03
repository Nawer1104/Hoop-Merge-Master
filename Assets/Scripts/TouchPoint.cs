using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPoint : MonoBehaviour
{
    public GameObject vfxCompleted;

    private bool isComplted;

    private void Start()
    {
        isComplted = false;
    }

    public void SetCompleted()
    {
        if (isComplted) return;

        isComplted = true;

        GameObject vfx = Instantiate(vfxCompleted, transform.position, Quaternion.identity) as GameObject;
        Destroy(vfx, 1f);
        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);
        GameManager.Instance.CheckLevelUp();
        gameObject.SetActive(false);
    }
}
