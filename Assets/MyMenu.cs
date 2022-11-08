using System.Collections;
using UnityEngine;

public class MyMenu : MonoBehaviour
{
    Animator anim;

    bool open;

    void Start()
    {
        anim = GetComponent<Animator>();
        open = false;
    }

    public void ShowAndUnShowUI()
    {
        if(open == false)
        {
            StartCoroutine(opening());
        }
        else
        {
            StartCoroutine(closing());
        }
    }

    IEnumerator opening()
    {
        print("Menu is Opening");
        anim.Play("ShowButton");
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing()
    {
        print("Menu is Closing");
        anim.Play("UnShowButton");
        open = false;
        yield return new WaitForSeconds(.5f);
    }
}
