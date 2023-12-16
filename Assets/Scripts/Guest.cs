using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Guest : MonoBehaviour
{
    [SerializeField]
    private GameObject _orderImg;
    [SerializeField]
    private GameObject _angryImg;
    [SerializeField]
    private GameObject _happyImg;
    [SerializeField]
    private GameObject _marshmallowImg;
    [SerializeField]
    private GameObject _whippedCreamImg;

    [HideInInspector]
    public float _timer;

    bool _hasOrder = false;
    bool _orderComplete = false;
    Dictionary<string, bool> _order;
    string[] boolNames = { /*"_hasWater",*/ "_hasMilk", /*"_isHot", */"_hasCocoa", /*"_isMixed",*/ "_hasWhippedCream", "_hasMarshmallows" };

    // Start is called before the first frame update
    void Start()
    {
        _timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasOrder)
        {
            _order = generateOrder();
            _hasOrder = true;
            _orderComplete = false;
/*            foreach (string name in boolNames)
            {
                Debug.Log(name + ", " + _order[name]);
            }*/
        }
        if (_orderComplete)
        {
            _timer += Time.deltaTime;
            if (_timer > 2f)
            {
                _angryImg.SetActive(false);
                _happyImg.SetActive(false);
                _hasOrder = false;
                _orderComplete = false;
                _timer = 0f;
            }
        }
    }

    Dictionary<string, bool> generateOrder()
    {
        Dictionary<string, bool> genOrder = new Dictionary<string, bool>();
        Random rand = new Random();
        _orderImg.SetActive(true);
        genOrder.Add("_hasMilk", true);
        genOrder.Add("_hasCocoa", true);
        genOrder.Add("_hasWhippedCream", (rand.NextDouble() >= 0.5));
        if (genOrder["_hasWhippedCream"])
        {
            _whippedCreamImg.SetActive(true);
        }
        else
        {
            _whippedCreamImg.SetActive(false);
        }
        genOrder.Add("_hasMarshmallows", (rand.NextDouble() >= 0.5));
        if (genOrder["_hasMarshmallows"])
        {
            _marshmallowImg.SetActive(true);
        }
        else
        {
            _marshmallowImg.SetActive(false);
        }
        return genOrder;
    }

    public void checkOrder(Dictionary<string, bool> prepOrder)
    {
        _orderImg.SetActive(false);
        foreach (string boolName in boolNames)
        {
            if (prepOrder[boolName] != _order[boolName])
            {
                Debug.Log("Order was wrong");
                _angryImg.SetActive(true);
                _orderImg.SetActive(false);
                _orderComplete = true;
                return;
            }
        }
        Debug.Log("Order was correct");
        _happyImg.SetActive(true);
        _orderImg.SetActive(false);
        _orderComplete = true;
    }    

}
