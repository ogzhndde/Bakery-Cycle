using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEkmek : MonoBehaviour
{
    public Oven oven;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                other.GetComponent<PlayerController>().CollectEkmek(ref oven.OvenEkmek);
                break;
        }
    }
}
