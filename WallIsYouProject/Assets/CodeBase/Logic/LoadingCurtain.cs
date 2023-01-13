using System;
using System.Collections;
using System.ComponentModel;
using UnityEngine;

namespace CodeBase.Logic
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup Curtain;
        [SerializeField] private float _disappearingSpeed = 0.03f;
        private static bool isHide;
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
        private void Update()
        {
            if (isHide)
            {
                StartCoroutine(DoFadeIn());
                isHide = false;
            }
        }
        public void Hide()
        {
            isHide = true;
        }

        public void Show()
        {
            gameObject.SetActive(true);
            Curtain.alpha = 1;
        }


        private IEnumerator DoFadeIn()
        {
            while (Curtain.alpha > 0)
            {
                Curtain.alpha -= 0.03f;
                yield return new WaitForSeconds(_disappearingSpeed);
            }

            gameObject.SetActive(false);
        }
    }
}