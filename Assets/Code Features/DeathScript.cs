using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject Player;
    public string levelToReset = "Level 1";

    AudioManager audioManager;

    // Start is called before the first frame update
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.dead);
            Player.transform.position = startPoint.transform.position;
            ResetLevel();
        }
    
    }

    private void ResetLevel()
    {
        
        SceneManager.LoadScene(levelToReset); // Load the same scene to reset it
    }
}
