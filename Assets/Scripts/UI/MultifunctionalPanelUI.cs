using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class MultifunctionalPanelUI : MonoBehaviour {

    [Header("Texts")]
    [SerializeField]
    TextMeshProUGUI messageText;
    [SerializeField]
    TextMeshProUGUI tittleText;

    [Header("Panels")]
    [SerializeField]
    GameObject modalPanel;
    [SerializeField]
    GameObject sandClockPanel;

    [Header("Buttons")]
    [SerializeField]
    Button yesButton;
    [SerializeField]
    Button noButton;
    [SerializeField]
    Button errorButton;

    Animator _anim;
    Animator anim
    {
        set { _anim = value; }
        get
        {
            if (_anim == null)
                _anim = GetComponentInChildren<Animator>();

            return _anim;
        }
    }


    AudioSource _audio;
    AudioSource audio
    {
        set { _audio = value; }
        get
        {
            if (_audio == null)
                _audio = GetComponent<AudioSource>();

            return _audio;
        }
    }

    private readonly string DEFAULT_TITTLE = "INFORMATION";

    public void ShowModalMode (string message, int time = 0)
    {
        DisableAll();
        StartCoroutine(ActivatePopup());
        messageText.text = message;

        //Close By Time, no buttons
        if (time != 0)
        {
            StartCoroutine(Close(time));        
        }
        else
        {
            //Close by button Ok
            yesButton.onClick.AddListener(HideModal);
            ActiveAndChangeTextButton(yesButton, "Ok");        
        }
    }

    public void ShowModalMode(string message, UnityAction callBackActionOk)
    {
        ShowModalMode(message);     
        yesButton.onClick.RemoveAllListeners();
        yesButton.onClick.AddListener(callBackActionOk);
        yesButton.onClick.AddListener(HideModal);
    }

    public void ShowYesNoMode(string message, UnityAction callBackActionYes, float delay)
    {        

        StartCoroutine(ShowYesNoModeCo(message,callBackActionYes, delay));
    }

    IEnumerator ShowYesNoModeCo (string message, UnityAction callBackActionYes, float delay)
    {
        yield return new WaitForSeconds(delay);
        ShowYesNoMode(message, callBackActionYes);
    }


    public void ShowYesNoMode(string message, UnityAction callBackActionYes, UnityAction callBackActionNo)
    {
        ShowYesNoMode(message);
        yesButton.onClick.AddListener(callBackActionNo);
        noButton.onClick.AddListener(callBackActionNo);
    }   

    public void ShowYesNoMode(string message, UnityAction callBackActionYes)
    {
        ShowYesNoMode(message);
        yesButton.onClick.AddListener(callBackActionYes);        
        noButton.onClick.AddListener(HideModal);

    }

    /// <summary>
    /// Base method to show Yes/No Modal
    /// </summary>
    /// <param name="message"></param>
    private void ShowYesNoMode(string message)
    {
        DisableAll();
        StartCoroutine(ActivatePopup());
        messageText.text = message;

        //Yes/no buttons
        ActiveAndChangeTextButton(yesButton, "Yes");
        ActiveAndChangeTextButton(noButton, "No");
    }

    void DisableAll ()
    {
        //Delete old corroutines
        StopAllCoroutines();

        //Remove listeners
        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();

        //Disble elements
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        modalPanel.gameObject.SetActive(false);
        sandClockPanel.gameObject.SetActive(false);

        //Default Text
        tittleText.text = DEFAULT_TITTLE;
    }

    //Show panel
    IEnumerator ActivatePopup()
    {
        yield return new WaitForSeconds(0.1f);
        audio.Play();
        anim.Play("Fade-in");
        modalPanel.gameObject.SetActive(true);
    }

    IEnumerator Close (int time)
    {
        //sandClockPanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        HideModal();
    }

    public void HideModal()
    {
        //Show panel
        anim.Play("Fade-out");
    }

    void ActiveAndChangeTextButton(Button btn, string txt)
    {
        btn.gameObject.SetActive(true);
        foreach (TextMeshProUGUI tmp in btn.GetComponentsInChildren<TextMeshProUGUI>())
            tmp.text = txt;
    }

}
