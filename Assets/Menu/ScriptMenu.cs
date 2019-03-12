using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour {

    public GameObject transition;
    public Animator animTransition;
    string sceneName;

    void Start()
    {
        transition = GameObject.FindGameObjectWithTag("Fade");
        animTransition = transition.GetComponent<Animator>();
    }
    
    //IEnumerator Fade()
    //{
    //    //animTransition.SetTrigger("fadeOut");
    //   animTransition.Play("toDark");
    //   yield return new WaitForSeconds(1f);
        
    //}

    //Buttons
    public void bAbout() {

        // transição escurece
        // transição clareia
        sceneName = "Credits";
        StartCoroutine(LoadScene());

        //Fade();
        // tela de creditos

    }

    public void bPlay()     {

        // transição escurece
        // transição clareia
        //Fade();
        // cutscene inicial
        sceneName = "play";
        StartCoroutine(LoadScene());
       
    }

    public IEnumerator LoadScene()
    {
        animTransition.SetTrigger("fadeOut");
        yield return new WaitForSeconds(1f);
        animTransition.SetTrigger("fadeIn");
       
        SceneManager.LoadScene(sceneName);
        
    }

        public void bQuit()
    {
        // transição escurece
        animTransition.SetTrigger("fadeOut");
        

        Application.Quit();
    }

}
