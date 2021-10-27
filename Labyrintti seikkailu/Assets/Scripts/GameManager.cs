using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI doorsLocked;
    public TextMeshProUGUI doorsOpened;
    public GameObject winner;
    public GameObject redWallOpen;
    public GameObject yellowWallOpen;
    public GameObject blueWallOpen;
    public GameObject pinkWallOpen;
    public GameObject fireworkBlue;
    public GameObject fireworkGreen;
    public GameObject fireworkYellow;
    private string[] locked = { "Red", "Yellow", "Blue", "Pink"}; 
    private string[] opened = { "Red ", "Yellow ", "Blue", "Pink" };
    

    // Start is called before the first frame update
    void Start()
    {
        redWallOpen.SetActive(false);
        yellowWallOpen.SetActive(false);
        blueWallOpen.SetActive(false);
        pinkWallOpen.SetActive(false);

        doorsLocked.text = "Doors locked: " + locked[0] + " " + locked[1] + " " + locked[2] + " " + locked[3];
        doorsOpened.text = "Doors opened: All doors are locked.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        redWallOpen.SetActive(false);
        yellowWallOpen.SetActive(false);
        blueWallOpen.SetActive(false);
        pinkWallOpen.SetActive(false);
    }

    public void RedWallOpen()
    {
        redWallOpen.SetActive(true);
        StartCoroutine(WaitForSec());

        doorsLocked.text = "Doors locked: " + locked[1] + " " + locked[2] + " " + locked[3];
        doorsOpened.text = "Doors opened: " + opened[0];
    }

    public void YellowWallOpen()
    {
        yellowWallOpen.SetActive(true);
        StartCoroutine(WaitForSec());

        doorsLocked.text = "Doors locked: " + locked[2] + " " + locked[3];
        doorsOpened.text = "Doors opened: " + opened[0] + " " + opened[1];
    }

    public void BlueWallOpen()
    {
        blueWallOpen.SetActive(true);
        StartCoroutine(WaitForSec());

        doorsLocked.text = "Doors locked: " + locked[3];
        doorsOpened.text = "Doors opened: " + opened[0] + " " + opened[1] + " " + opened[2];
    }

    public void PinkWallOpen()
    {
        pinkWallOpen.SetActive(true);
        StartCoroutine(WaitForSec());

        doorsLocked.text = "Doors locked: All doors are open.";
        doorsOpened.text = "Doors opened: " + opened[0] + " " + opened[1] + " " + opened[2] + " " + opened[3];
    }

    public void PlayFireworks()
    {
        fireworkBlue.SetActive(true);
        fireworkGreen.SetActive(true);
        fireworkYellow.SetActive(true);
        winner.SetActive(true);
    }
}
