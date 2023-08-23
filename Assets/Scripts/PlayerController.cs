using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerController : MonoBehaviour
{
    GameManager manager;

    public PathCreation.Examples.PathFollower pathFollower;

    public List<GameObject> HamurCollected;
    public List<GameObject> EkmekCollected;

    public Transform StackPoint;


    void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }


    void Update()
    {

    }

    public void SetSpeed(float speedValue)
    {
        pathFollower.speed = speedValue;
    }

    public void CollectHamur(Transform spawnPoint)
    {
        GameObject spawnedHamur = Instantiate(manager.PRE_HamurPrefab, spawnPoint.position, Quaternion.identity, StackPoint);

        HamurCollected.Add(spawnedHamur);

        spawnedHamur.transform.DOLocalMove(new Vector3(0, 0.6f * HamurCollected.Count, 0), 0.4f).SetEase(Ease.OutExpo);
    }

    public void BakeBread(Transform bakePoint, ref List<GameObject> ovenHamur)
    {
        GameObject lastHamur = HamurCollected[^1];
        HamurCollected.Remove(lastHamur);
        ovenHamur.Add(lastHamur);

        lastHamur.transform.SetParent(null);
        lastHamur.transform.DOMove(bakePoint.position, 0.4f).SetEase(Ease.OutExpo);
    }

    public void CollectEkmek(ref List<GameObject> OvenEkmek)
    {
        int ovenEkmekCount = OvenEkmek.Count;

        for (int i = 0; i < ovenEkmekCount; i++)
        {
            GameObject item = OvenEkmek[^1];

            item.transform.SetParent(StackPoint);
            OvenEkmek.Remove(item);
            EkmekCollected.Add(item);

            item.transform.DOLocalMove(new Vector3(0, 0.6f * EkmekCollected.Count, 0), 0.4f).SetEase(Ease.OutExpo);
        }
    }

    public void SellBread(Shelf shelf, ref List<GameObject> ShelfEkmek, ref List<GameObject> ShelfPoints)
    {
        int ekmekCount = EkmekCollected.Count;

        for (int i = 0; i < ekmekCount; i++)
        {
            if (shelf.GetAvailableShelfPoint() == null) return;

            GameObject lastEkmek = EkmekCollected[^1];

            EkmekCollected.Remove(lastEkmek);
            ShelfEkmek.Add(lastEkmek);

            shelf.SendBreadToShelf(lastEkmek);
        }
    }
}
