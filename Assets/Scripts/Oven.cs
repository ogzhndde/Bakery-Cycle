using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Oven : MonoBehaviour
{
    public Image IMA_FillBar;

    public Transform bakePoint;
    public Transform ekmekPoint;

    public List<GameObject> OvenHamur;
    public List<GameObject> OvenEkmek;

    public float bakeCooldown = 2f;

    void Update()
    {
        if (OvenHamur.Count > 0 && bakeCooldown > 0)
        {
            bakeCooldown -= Time.deltaTime;
        }

        if (bakeCooldown <= 0)
        {
            BakeBread();
        }
    }

    public void BakeBread()
    {
        //HAMURUMU ALICAK
        GameObject lastHamur = OvenHamur[^1];

        OvenHamur.Remove(lastHamur);
        OvenEkmek.Add(lastHamur);

        lastHamur.GetComponent<Bread>().SetMaterial(BreadState.EkmekState);

        //PISIRICEK
        lastHamur.transform.DOMove(ekmekPoint.position + new Vector3(0, OvenEkmek.Count * 0.5f, 0), 0.4f).SetEase(Ease.OutExpo);
        bakeCooldown = 2f;
    }


    void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                if (other.GetComponent<PlayerController>().HamurCollected.Count == 0)
                    return;

                IMA_FillBar.fillAmount += Time.deltaTime;

                if (IMA_FillBar.fillAmount == 1)
                {
                    IMA_FillBar.fillAmount = 0;
                    other.GetComponent<PlayerController>().BakeBread(bakePoint, ref OvenHamur);
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
