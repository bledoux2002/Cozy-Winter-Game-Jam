using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mug : MonoBehaviour
{
    public Dictionary<string, bool> components = new Dictionary<string, bool>();

    [SerializeField]
    private GameObject _empty;
    //[SerializeField]
    //private GameObject _water;
    [SerializeField]
    private GameObject _milk;
    [SerializeField]
    private GameObject _cocoa;
    [SerializeField]
    private GameObject _mixed;
    [SerializeField]
    private GameObject _whippedCream;
    [SerializeField]
    private GameObject _marshmallow;

    string[] boolNames = { /*"_hasWater",*/ "_hasMilk", /*"_isHot", */"_hasCocoa", /*"_isMixed",*/ "_hasWhippedCream", "_hasMarshmallows" };

    private void Awake()
    {
        foreach (string boolName in boolNames)
        {
            components.Add(boolName, false);
        }
    }

    public void addIngredient(GameObject ingredient)
    {
        switch (ingredient.name)
        {
/*            case "Water Pot":
                if (_cocoa.activeSelf)
                {
                    _empty.SetActive(false);
                    _cocoa.SetActive(false);
                    _whippedCream.SetActive(false);
                    _mixed.SetActive(true);
                    components["_hasWater"] = true;
                    components["_isMixed"] = true;
                    components["_isHot"] = true;
                }
                else if (_empty.activeSelf)
                {
                    _empty.SetActive(false);
                    _water.SetActive(true);
                    components["_hasWater"] = true;
                    components["_isHot"] = true;
                }
                break;
*/            case "Milk Pot":
 /*               if (_cocoa.activeSelf)
                {
                    _empty.SetActive(false);
                    _cocoa.SetActive(false);
 //                   _whippedCream.SetActive(false);
                    _mixed.SetActive(true);
                    components["_hasMilk"] = true;
                    components["_isMixed"] = true;
//                    components["_isHot"] = true;
                }
                else if (_empty.activeSelf)
                {
                    _empty.SetActive(false);
                    _milk.SetActive(true);
                    components["_hasMilk"] = true;
//                    components["_isHot"] = true;
                }*/
                _empty.SetActive(false);
                components["_hasMilk"] = true;
                if (_cocoa.activeSelf)
                {
                    _cocoa.SetActive(false);
                    _mixed.SetActive(true);
//                    components["_isMixed"] = true;
                } else
                {
                    _milk.SetActive(true);
                }
                break;
            case "Cocoa":
                if (_empty.activeSelf)
                {
                    _cocoa.SetActive(true);
                    components["_hasCocoa"] = true;
                }
                else if (/*_water.activeSelf ||*/ _milk.activeSelf)
                {
//                    _water.SetActive(false);
                    _milk.SetActive(false);
                    _mixed.SetActive(true);
                    components["_hasCocoa"] = true;
//                    components["_isMixed"] = true;
                }
/*                else
                {
                    _cocoa.SetActive(true);
                    components["_isMixed"] = false;
                }*/
                break;
            case "Whipped Cream":
                _whippedCream.SetActive(true);
                components["_hasWhippedCream"] = true;
                break;
            case "Marshmallows":
                _marshmallow.SetActive(true);
                components["_hasMarshmallows"] = true;
                break;
 /*           case "Sink":
                if (_cocoa.activeSelf)
                {
                    _empty.SetActive(false);
                    _cocoa.SetActive(false);
                    _whippedCream.SetActive(false);
                    _mixed.SetActive(true);
                    components["_hasWater"] = true;
                    components["_isMixed"] = true;
                    components["_isHot"] = false;
                }
                else if (_empty.activeSelf)
                {
                    _empty.SetActive(false);
                    _water.SetActive(true);
                    components["_hasWater"] = true;
                    components["_isHot"] = false;
                }
                break;
            case "Milk":
                if (_cocoa.activeSelf)
                {
                    _empty.SetActive(false);
                    _cocoa.SetActive(false);
                    _whippedCream.SetActive(false);
                    _mixed.SetActive(true);
                    components["_hasMilk"] = true;
                    components["_isMixed"] = true;
                    components["_isHot"] = false;
                }
                else if (_empty.activeSelf)
                {
                    _empty.SetActive(false);
                    _milk.SetActive(true);
                    components["_hasMilk"] = true;
                    components["_isHot"] = false;
                }
                break;*/
            default:
                break;
        }
    }
    public void emptyCup()
    {
        foreach (string boolName in boolNames)
        {
            components[boolName] = false;
        }
        _empty.SetActive(true);
//        _water.SetActive(false);
        _milk.SetActive(false);
        _cocoa.SetActive(false);
        _mixed.SetActive(false);
        _whippedCream.SetActive(false);
        _marshmallow.SetActive(false);
    }
}
