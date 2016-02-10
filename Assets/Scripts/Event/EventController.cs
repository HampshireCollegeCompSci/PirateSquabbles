﻿/*
 * Author(s): Isaiah Mann 
 * Description: A single event class that others can subscribe to and call events from
 * Currently relies on event names as strings
 * Event method can be overloaded to implement different event types
 * Dependencies: EventList
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class EventController {

	public delegate void NamedEventAction (string nameOfEvent);
	public static event NamedEventAction OnNamedEvent;

	public delegate void AudioEventAction (AudioActionType actionType, AudioType audioType);
	public static event AudioEventAction OnAudioEvent;

	static Dictionary<PSEventType, string> eventMapping;

	static EventController () {
		Init();
	}
	
	public static void Event (string eventName) {
		if (OnNamedEvent != null) {
			OnNamedEvent(eventName);
		}
	}

	public static void Event (AudioActionType actionType, AudioType audioType) {
		if (OnAudioEvent != null) {
			OnAudioEvent(actionType, audioType);
		}
	}

	public static void Event (PSEventType eventType) {
		if (eventMapping.ContainsKey(eventType)) {
			Event(
				eventMapping[eventType]
			);
		} else {
			Debug.LogWarning("Event System does not contain event " + eventType);       
        }
	}

	static void Init() {
		InitMappingDictionary();
	}

	static void InitMappingDictionary () {
		eventMapping = new Dictionary<PSEventType, string>();

		for (int i = 0; i < EventList.length; i++) {
			eventMapping.Add (
				(PSEventType) i,
				EventList.events[i]
			);
		}
	}
}