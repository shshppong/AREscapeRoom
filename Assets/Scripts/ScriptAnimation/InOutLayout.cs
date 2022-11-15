using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OptionMenuControl
{
    public class InOutLayout : MonoBehaviour
    {
        public Transform editorStartPosition;
        public Transform editorEndPosition;

        Vector3 startPos;
        Vector3 endPos;

        public float lerpTime = 5f;
        float currentTime;

        public static bool isMove = false;

        void Start()
        {
            startPos = new Vector3(editorStartPosition.position.x, this.transform.position.y, this.transform.position.z);
            endPos = new Vector3(editorEndPosition.position.x, this.transform.position.y, this.transform.position.z);

            this.transform.position = startPos;
        }

        void Update()
        {
            if(OptionMenuControl.OptionMenuController.isMenuOpen)
            {
                ShowImage();
            }
            else
            {
                UnShowImage();
            }
        }

        void ShowImage()
        {
            currentTime += Time.deltaTime;

            float distance = Vector2.Distance(this.transform.position, endPos);
            if (distance <= 0.01f)
            {
                this.transform.position = endPos;
                currentTime = 0;
                isMove = false;
            }

            float t = currentTime / lerpTime;

            this.transform.position = Vector3.Lerp(transform.position, endPos, t);
        }

        void UnShowImage()
        {
            currentTime += Time.deltaTime;

            float distance = Vector2.Distance(this.transform.position, startPos);
            if (distance <= 0.01f)
            {
                this.transform.position = startPos;
                currentTime = 0;
                isMove = false;
            }

            float t = currentTime / lerpTime;

            this.transform.position = Vector3.Lerp(transform.position, startPos, t);
        }
    }

}
