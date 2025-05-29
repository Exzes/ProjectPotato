using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace ProjectPotato.Menu
{
    public class MenuNavegation : MonoBehaviour
    {
        void Awake()
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); 
    }
        
    }
}
