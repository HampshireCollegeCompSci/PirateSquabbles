﻿using UnityEngine;
using System.Collections;

public class SpecialActions_Speech : SpecialActions {

    public override void DoSpecialAction(string actionTag) {
		AudioController audio = GameObject.Find ("AudioController").GetComponent<AudioController> ();
        switch (actionTag) {
		case "FirstMateSpeech":
			audio.VoiceEffect("FirstMateSpeech");
            break;
		case "QuartermasterSpeech":
			audio.VoiceEffect("QuartermasterSpeech");
			break;
		case "SecondMateSpeech":
			audio.VoiceEffect("SecondMateSpeech");
			break;
		case "RiggerSpeech":
			audio.VoiceEffect ("RiggerSpeech");
			break;
		case "SwabbieSpeech":
			audio.VoiceEffect("SwabbieSpeech");
			break;
		case "OJSpeech":
			audio.VoiceEffect("OJSpeech");
			break;
		case "SadieAhoy":
			audio.VoiceEffect("SadieAhoy");
			break;
		case "SadieTalk":
			audio.VoiceEffect("SadieTalk");
			break;
		case "SadieConfused":
			EventController.Event ("SadieConfused");
			break;
        case "ChangeToMop":
            gameObject.GetComponent<Animator>().SetTrigger("Mop");
            break;
        }
    }

    private void destroyMe() {
        Destroy(gameObject);
    }
}