using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif


[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{  
    public GameObject playerNameInput;
    private TMP_InputField playerNameText;
    
    private void Start(){
        playerNameText = playerNameInput.GetComponent<TMP_InputField>();
    }

    public void StartNew(){
        SceneManager.LoadScene(1);
    }

    public void Exit() {
        //COMPILACION CONDICIONAL
        #if UNITY_EDITOR
            //UNITY DIRECTIVE
            GameManager.Instance.EraseScore();
            EditorApplication.ExitPlaymode();
        #else 
            //COMPILATION DIRECTIVE 
            Application.Quit();
        #endif
    }

    public void UpdatePlayerName(){
        if(GameManager.Instance != null){
            Debug.Log("New name: "+playerNameText.text);
            GameManager.Instance.SetPlayerName(playerNameText.text);
        }
    }
}