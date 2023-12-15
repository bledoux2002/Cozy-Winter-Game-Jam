using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mug : MonoBehaviour
{
    //Must have, mutually exclusive
    public bool _hasMilk;
    public bool _hasWater;

    //Must have
    public bool _hasCocoa;
    
    //Optional
    public bool _hasWhippedCream;
    public bool _hasMarshmallows;

    public void addIngredient(GameObject ingredient)
    {

    }
}
