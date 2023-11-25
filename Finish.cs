using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    
    private AudioSource finishSourceSound;

    // Start is called before the first frame update
    void Start()
    {
        finishSourceSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            finishSourceSound.Play();
            CompleteLevel();
        }
        
    }

    private void CompleteLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }



}
