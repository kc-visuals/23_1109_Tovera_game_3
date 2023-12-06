using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class bookScript : MonoBehaviour
{
    [SerializeField]
    GameObject journalCanvas;

    [SerializeField]
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        journalCanvas.SetActive(false);
    }

    public void OpenJournal()
    {
        journalCanvas.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        player.GetComponentInChildren<CameraScript>().lookEnabled = false;
        player.GetComponent<PlayerInput>().enabled = false;
        //add journal to inventory
    }

    public void CloseJournal()
    {
        journalCanvas.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        player.GetComponentInChildren<CameraScript>().lookEnabled = true;
        player.GetComponent<PlayerInput>().enabled = true;
    }

    public void NextScene()
    {
        //play time travel cutscene

        //increment scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

        Debug.Log("timetravel");
    }
}
