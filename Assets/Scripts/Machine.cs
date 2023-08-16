using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine : MonoBehaviour
{

    public Image IMA_FillBar;

    public Transform spawnPoint;

    void Start()
    {

    }

    void Update()
    {

    }


    void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                if (other.GetComponent<PlayerController>().HamurCollected.Count >= 5)
                    return;

                IMA_FillBar.fillAmount += Time.deltaTime;
                if (IMA_FillBar.fillAmount == 1)
                {
                    IMA_FillBar.fillAmount = 0;
                    other.GetComponent<PlayerController>().CollectHamur(spawnPoint);
                }

                break;
        }
    }

    void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                IMA_FillBar.fillAmount = 0;

                break;
        }
    }
}
