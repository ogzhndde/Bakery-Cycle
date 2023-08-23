using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Shelf : MonoBehaviour
{
    public Image IMA_FillBar;

    public List<GameObject> ShelfEkmek;

    public List<GameObject> ShelfPoints;


    public void SendBreadToShelf(GameObject item)
    {
        item.transform.SetParent(GetAvailableShelfPoint().transform);
        item.transform.DOLocalMove(Vector3.zero, 0.4f).SetEase(Ease.OutExpo);
    }

    public GameObject GetAvailableShelfPoint()
    {
        GameObject availablePoint = null;

        for (int i = 0; i < ShelfPoints.Count; i++)
        {
            if (ShelfPoints[i].transform.childCount == 0)
            {
                availablePoint = ShelfPoints[i];
                break;
            }
        }
        return availablePoint;
    }


    void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                if (other.GetComponent<PlayerController>().EkmekCollected.Count == 0) return;
                if (GetAvailableShelfPoint() == null) return;

                IMA_FillBar.fillAmount += Time.deltaTime;

                if (IMA_FillBar.fillAmount == 1)
                {
                    IMA_FillBar.fillAmount = 0;
                    other.GetComponent<PlayerController>().SellBread(this, ref ShelfEkmek, ref ShelfPoints);
                }
                break;
        }
    }

    void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                IMA_FillBar.fillAmount += 0;
                break;
        }
    }
}
