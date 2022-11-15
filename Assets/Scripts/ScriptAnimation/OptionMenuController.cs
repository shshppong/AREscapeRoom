using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OptionMenuControl
{
    public class OptionMenuController : MonoBehaviour
    {
        public static bool isMenuOpen = false;

        public void PressButton()
        {
            if (OptionMenuControl.InOutLayout.isMove) return;

            if (! isMenuOpen)
            {
                OptionMenuControl.InOutLayout.isMove = true;
                isMenuOpen = true;
            }
            else
            {
                OptionMenuControl.InOutLayout.isMove = true;
                isMenuOpen = false;
            }
        }
    }
}
