using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool crashTriggered = false;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground" && !crashTriggered) {
            // Debug.Log("Bonk!");
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            crashTriggered = true;
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", delay);
        }
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     if(other.gameObject.tag == "Ground") {
    //         // Debug.Log("Bonk!");
    //         FindObjectOfType<PlayerController>().DisableControls();
    //         crashEffect.Play();
    //         GetComponent<AudioSource>().PlayOneShot(crashSFX);
    //         Invoke("ReloadScene", delay);
    //     }
    // }

    void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
