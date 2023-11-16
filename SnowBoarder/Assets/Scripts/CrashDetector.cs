using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayAmount;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashFx;
    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            FindObjectOfType<PlayerController>().DisableControls();
            hasCrashed = true;
            print($"Collided with {other.name}");
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashFx);
            Invoke("ReloadScene", delayAmount);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
