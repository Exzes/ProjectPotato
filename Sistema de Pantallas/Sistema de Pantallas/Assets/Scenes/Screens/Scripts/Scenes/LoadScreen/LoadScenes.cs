using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ProjectPotato
{
    public class LoadScenes : MonoBehaviour
    {
        public static LoadScenes Instance;
        [SerializeField] private Image _barra;

        private float scaleRange = 0.9f;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            if (gameObject != null)
            {
                gameObject.SetActive(false);
            }
        }
        public void LoadSceneWhithLoader(int sceneIndex)
        {
            gameObject.SetActive(true);
            StartCoroutine(Cargar(sceneIndex));
        }
        private IEnumerator Cargar(int sceneIndex)
        {
            yield return new WaitForSeconds(0.1f);
            if (gameObject != null)
            {
                gameObject.SetActive(true);
            }

            AsyncOperation _load = SceneManager.LoadSceneAsync(sceneIndex);
            _load.allowSceneActivation = false;

            while (!_load.isDone)
            {
                _barra.fillAmount = Mathf.Clamp01(_load.progress / scaleRange);
                if (_load.progress >= scaleRange)
                {
                    _load.allowSceneActivation = true;
                }
                yield return null;
            }
            if (gameObject != null)
            {
                gameObject.SetActive(false);
            }

        }
        public static void ChangeSceneWhitLoader(int sceneIndex) //Pasar de nivel
        {
            if (Instance != null)
            {
                Instance.LoadSceneWhithLoader(sceneIndex);
            }
            else
            {
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }
}
