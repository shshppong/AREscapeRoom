using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontEscapeRoom : MonoBehaviour
{
    public Text text;

    void Start()
    {
        text.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("MainCamera"))
        {
            text.gameObject.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("MainCamera"))
        {
            text.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("MainCamera"))
        {
            text.gameObject.SetActive(false);
        }
    }
}
