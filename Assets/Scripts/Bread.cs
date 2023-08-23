using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BreadState
{
    HamurState,
    EkmekState
}

public class Bread : MonoBehaviour
{
    public BreadState breadStateEnum;

    public Material MAT_Hamur, MAT_Ekmek;
    SkinnedMeshRenderer renderer;


    void Start()
    {
        renderer = GetComponent<SkinnedMeshRenderer>();
        SetMaterial(BreadState.HamurState);
    }


    public void SetMaterial(BreadState breadState)
    {
        breadStateEnum = breadState;

        if (breadStateEnum == BreadState.HamurState)
        {
            renderer.material = MAT_Hamur;
        }
        else if (breadStateEnum == BreadState.EkmekState)
        {
            renderer.material = MAT_Ekmek;
        }
    }

}
