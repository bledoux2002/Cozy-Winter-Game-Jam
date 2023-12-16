using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mug : MonoBehaviour
{
    //Must have, mutually exclusive
    public bool _hasWater = false;
    public bool _hasMilk = false;

    //Must have
    public bool _isHot = false;
    public bool _hasCocoa = false;
    public bool _isMixed = false;
    
    //Optional
    public bool _hasWhippedCream = false;
    public bool _hasMarshmallows = false;

    [SerializeField]
    private GameObject _empty;
    [SerializeField]
    private GameObject _water;
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

    public void addIngredient(GameObject ingredient)
    {
        switch (ingredient.name)
        {
            case "Water Pot":
                if (_cocoa.activeSelf)
                {
                    _empty.SetActive(false);
                    _cocoa.SetActive(false);
                    _whippedCream.SetActive(false);
                    _mixed.SetActive(true);
                    _hasWater = true;
                    _isMixed = true;
                    _isHot = true;
                }
                else if (_empty.activeSelf)
                {
                    _empty.SetActive(false);
                    _water.SetActive(true);
                    _hasWater = true;
                    _isHot = true;
                }
                break;
            case "Milk Pot":
                if (_cocoa.activeSelf)
                {
                    _empty.SetActive(false);
                    _cocoa.SetActive(false);
                    _whippedCream.SetActive(false);
                    _mixed.SetActive(true);
                    _hasMilk = true;
                    _isMixed = true;
                    _isHot = true;
                }
                else if (_empty.activeSelf)
                {
                    _empty.SetActive(false);
                    _milk.SetActive(true);
                    _hasMilk = true;
                    _isHot = true;
                }
                break;
            case "Cocoa":
                if (_empty.activeSelf)
                {
                    _cocoa.SetActive(true);
                    _hasCocoa = true;
                }
                else if (_water.activeSelf || _milk.activeSelf)
                {
                    _water.SetActive(false);
                    _milk.SetActive(false);
                    _mixed.SetActive(true);
                    _hasCocoa = true;
                    _isMixed = true;
                }
                else
                {
                    _cocoa.SetActive(true);
                    _isMixed = false;
                }
                break;
            case "Whipped Cream":
                _whippedCream.SetActive(true);
                _hasWhippedCream = true;
                break;
            case "Marshmallows":
                _marshmallow.SetActive(true);
                _hasMarshmallows = true;
                break;
            case "Sink":
                if (_cocoa.activeSelf)
                {
                    _empty.SetActive(false);
                    _cocoa.SetActive(false);
                    _whippedCream.SetActive(false);
                    _mixed.SetActive(true);
                    _hasWater = true;
                    _isMixed = true;
                    _isHot = false;
                }
                else if (_empty.activeSelf)
                {
                    _empty.SetActive(false);
                    _water.SetActive(true);
                    _hasWater = true;
                    _isHot = false;
                }
                break;
            case "Milk":
                if (_cocoa.activeSelf)
                {
                    _empty.SetActive(false);
                    _cocoa.SetActive(false);
                    _whippedCream.SetActive(false);
                    _mixed.SetActive(true);
                    _hasMilk = true;
                    _isMixed = true;
                    _isHot = false;
                }
                else if (_empty.activeSelf)
                {
                    _empty.SetActive(false);
                    _milk.SetActive(true);
                    _hasMilk = true;
                    _isHot = false;
                }
                break;
            default:
                break;
        }
    }
}
