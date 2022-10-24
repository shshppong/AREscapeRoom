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

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("MainCamera"))
        {
            text.gameObject.SetActive(true);
        }
        else
        {
            text.gameObject.SetActive(false);
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
