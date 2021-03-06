/*
* Author: Isaiah Mann
* Description: Util class for simple player settings
*/
using UnityEngine;
using System.Collections;

public static class SettingsUtil {
	
	// Keys used to acccess the settings from player prefs
	const string musicMuteSettingsKey = "musicMute";
	const string fxMuteSettingsKey = "fxMute";
	const string voMuteSettingsKey = "voMute";

	public static void ToggleMusicMuted (bool muted) {
		ToggleMute (
			musicMuteSettingsKey,
			muted
		);

		EventController.Event (
			AudioUtil.MuteActionFromBool(muted),
			AudioType.Music
		);

		checkForAllSoundOnOrOff();
	}

	public static void ToggleFXMuted (bool muted) {
		ToggleMute (
			fxMuteSettingsKey,
			muted
		);

		EventController.Event (
			AudioUtil.MuteActionFromBool(muted),
			AudioType.FX
		);

		checkForAllSoundOnOrOff();
	}

	public static void ToggleVOMuted (bool muted) {
		ToggleMute (
			voMuteSettingsKey,
			muted
		);

		EventController.Event (
			AudioUtil.MuteActionFromBool(muted),
			AudioType.VO
		);
	}


	public static bool MusicMuted {
		get {
			return IsMuted(musicMuteSettingsKey);
		}
	}

	public static bool FXMuted {
		get {
			return IsMuted(fxMuteSettingsKey);
		}
	}

	public static bool VOMuted {
		get {
			return IsMuted(voMuteSettingsKey);
		}
	}

	static void ToggleMute (string key, bool value) {
		PlayerPrefsUtil.SetBool(
			key,
			value
		);
	}

	static bool IsMuted (string key) {
		return PlayerPrefsUtil.GetBool(key);
	}

	static void checkForAllSoundOnOrOff () {
		if (MusicMuted == FXMuted) {
			EventController.Event(EventList.SOUND_TOGGLED_ON_OFF);
		}
	}
}