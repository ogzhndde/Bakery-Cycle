using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
}
