using Photon.Voice.PUN;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeakerHighlight : MonoBehaviour
{
    [SerializeField]
    private Image recorder;
    [SerializeField]
    private Image speaker;

    private Canvas canvas;

    private PhotonVoiceView photonVoiceView;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        if (canvas != null && canvas.worldCamera == null) 
        { 
            canvas.worldCamera = Camera.main; 
        }
        photonVoiceView = GetComponentInParent<PhotonVoiceView>();
    }

    private void Update()
    {
        recorder.enabled = photonVoiceView.IsRecording;
        speaker.enabled = photonVoiceView.IsSpeaking;
    }
}
