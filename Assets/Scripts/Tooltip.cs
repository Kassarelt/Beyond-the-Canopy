using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tooltip : MonoBehaviour {

    public Animator tooltipAnim;
    public GameObject tooltipImage;

    public Text tooltipText;

    public bool tooltipOpen;

    private void Start()
    {
        tooltipOpen = false;
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            OpenLevelTooltip();
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            if (Input.GetKeyDown(KeyCode.H)){
                OpenLevelTooltip();
            }
        }
    }

    public void OpenTooltip()
    {
        StopAllCoroutines();
        tooltipImage.SetActive(true);
        tooltipAnim.SetTrigger("start");
        StartCoroutine(TooltipCoroutine());
    }

    IEnumerator TooltipCoroutine()
    {
        yield return new WaitForSeconds(6f);
        tooltipAnim.SetTrigger("start");
        yield return new WaitForSeconds(0.5f);
        tooltipImage.SetActive(false);
        tooltipOpen = false;
    }

    public void OpenOptionsTooltip() {
        tooltipText.text = "I'm sorry Challenger 42, the parameters of your ship are unaccesable but we are working on that.";
        if (!tooltipOpen) {
            tooltipOpen = true;
            OpenTooltip();
        }
    }

    public void OpenContinueTooltip()
    {
        tooltipText.text = "Uhm it's seems there is a problem with the time continuum, history keeps on erasing itself.\nGive me a second I'll have a look on that.";
        if (!tooltipOpen)
        {
            tooltipOpen = true;
            OpenTooltip();
        }
    }

    //Tooltip for the level
    public void OpenLevelTooltip()
    {
        tooltipText.text = "Don't forget if you press F on your suit-controller near some heavy objets you will me able to drag them.";
        if (!tooltipOpen)
        {
            tooltipOpen = true;
            StopAllCoroutines();
            tooltipImage.SetActive(true);
            tooltipAnim.SetTrigger("start");
            StartCoroutine(TooltipLevelCoroutine());
        }
    }

    IEnumerator TooltipLevelCoroutine()
    {
        yield return new WaitForSeconds(3f);
        tooltipText.text = "If anything goes wrong press R and your last actions will be reset.";
        yield return new WaitForSeconds(3f);
        tooltipText.text = "If you need my help again just press H.\nGood luck Challenger 42, over.";
        yield return new WaitForSeconds(3f);
        tooltipAnim.SetTrigger("start");
        yield return new WaitForSeconds(0.5f);
        tooltipImage.SetActive(false);
        tooltipOpen = false;
    }
}
