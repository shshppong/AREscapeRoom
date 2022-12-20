using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    Text text;

    public KeySystem.KeyInventory _keyInventory = null;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = _keyInventory.hasKeys.ToString();
    }
}
