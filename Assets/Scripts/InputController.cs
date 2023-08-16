using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector] public GameObject Player;
    [HideInInspector] public PlayerController playerController;

    public float defaultSpeed;


    void Start()
    {
        Player = FindObjectOfType<PlayerController>().gameObject;
        playerController = Player.GetComponent<PlayerController>();
    }

    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        playerController.SetSpeed(defaultSpeed);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerController.SetSpeed(0f);

    }
}
