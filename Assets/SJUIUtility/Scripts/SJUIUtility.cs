using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace YourSungjin.UI
{

	public static class SJUIUtility
	{

		public delegate void ShowUIDelegate ();

		static public void ShowUI (MonoBehaviour monoBehaviour, CanvasGroup cg, bool show, float delayTime, float durationTime, ShowUIDelegate showUIComplete = null)
		{
			monoBehaviour.StartCoroutine (UITransition (cg, show, delayTime, durationTime, showUIComplete));
		}

		static private IEnumerator UITransition (CanvasGroup cg, bool show, float delayTime, float durationTime, ShowUIDelegate showUIComplete)
		{

			yield return new WaitForSeconds (delayTime);

			float elapsedTime = 0;
			float start, end;
			cg.gameObject.SetActive (true);

			if (show) {
				start = 0f;
				end = 1f;
			} else {
				start = 1f;
				end = 0f;
			}

			while (elapsedTime < durationTime) {
				cg.alpha = Mathf.Lerp (start, end, elapsedTime / durationTime);
				elapsedTime += Time.deltaTime;
				yield return null;
			}

			//cg.alpha = end;
			cg.alpha = 1f; //whether the UI gets activated or not, cg.alpha should always be 1f for later use.
			cg.gameObject.SetActive (show);

			if (showUIComplete != null)
				showUIComplete ();
		}

	}
}