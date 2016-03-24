﻿/*
 * Author: Isaiah Mann
 * Description: Stores a list of credits
 */
using UnityEngine;
using System.Collections;

public class CreditGroup {

	public string Title;
	public Credit[] Credits;

	public CreditGroup (string title, params string[] credits) {
		this.Title = title;
		this.Credits = generateCredits(credits);
	}

	Credit[] generateCredits (params string[] creditNames) {
		Credit[] credits = new Credit[creditNames.Length];

		for (int i = 0; i < credits.Length; i++) {
			credits[i] = new Credit(creditNames[i]);
		}

		return credits;
	}
		
}
