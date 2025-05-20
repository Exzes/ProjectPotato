using System.Collections;
using System.Collections.Generic;
using ProjectPotato;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ProjectPotato.UI
{
    public class SplashScreen : MonoBehaviour
    {
        private Image _logo;
        private bool _loaded;
        private bool _endLogo;

        void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _logo = GetComponent<Image>();
            _loaded = false;
            _endLogo = false;
            _logo.color = new Color(_logo.color.r, _logo.color.g, _logo.color.b, 0f);
        }
        void Start()
        {
            _loaded = true;
        }

        void Update()
        {
            if (_loaded && _endLogo)
            {
                LoadScenes.Instance.LoadSceneWhithLoader(2);
                //SceneManager.LoadSceneAsync("MenuScreen");
                //Debug.Log("SI");
            }
        }

        public void AnimationFinished()
        {
            _endLogo = true;
        }
    }
}
