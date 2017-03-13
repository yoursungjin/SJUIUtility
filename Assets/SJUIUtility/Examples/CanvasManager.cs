using UnityEngine;
using UnityEngine.UI;

using System.Collections;

using YourSungjin.UI;

public class CanvasManager : MonoBehaviour
{
	[SerializeField] private CanvasGroup groupA, groupB, groupC;

	void Awake ()
	{
		//bind buttons
		Button[] groupAButtons = groupA.GetComponentsInChildren<Button> (true);
		foreach (Button button in groupAButtons) {  
			Button temp = button;
			button.onClick.AddListener (() => OnClickGroupAButton (temp));
		}

		Button[] groupBButtons = groupB.GetComponentsInChildren<Button> (true);
		foreach (Button button in groupBButtons) {  
			Button temp = button;
			button.onClick.AddListener (() => OnClickGroupBButton (temp));
		}

		Button[] groupCButtons = groupC.GetComponentsInChildren<Button> (true);
		foreach (Button button in groupCButtons) {  
			Button temp = button;
			button.onClick.AddListener (() => OnClickGroupCButton (temp));
		}
	}

	void Start ()
	{ 
		InitUI ();
	}


	private void InitUI ()
	{
		groupA.gameObject.SetActive (true);
		groupB.gameObject.SetActive (false);
		groupC.gameObject.SetActive (false);
	}


	void OnDestroy ()
	{
		//unbind buttons
		Button[] groupAButtons = groupA.GetComponentsInChildren<Button> (true);
		foreach (Button button in groupAButtons) {  
			Button temp = button;
			button.onClick.RemoveListener (() => OnClickGroupAButton (temp));
		}

		Button[] groupBButtons = groupB.GetComponentsInChildren<Button> (true);
		foreach (Button button in groupBButtons) {  
			Button temp = button;
			button.onClick.RemoveListener (() => OnClickGroupBButton (temp));
		}

		Button[] groupCButtons = groupC.GetComponentsInChildren<Button> (true);
		foreach (Button button in groupCButtons) {  
			Button temp = button;
			button.onClick.RemoveListener (() => OnClickGroupCButton (temp));
		}
	}


	#region EventHandler

	private void OnClickGroupAButton (Button sender)
	{  
		switch (sender.transform.name) {  
		case "AtoBButton":  
			SJUIUtility.ShowUI (this, groupA, false, 0, .5f, delegate() {
				SJUIUtility.ShowUI (this, groupB, true, 0, .5f);
			});
			break;

		case "AtoBtoCButton":  
			SJUIUtility.ShowUI (this, groupA, false, 0, .5f, delegate() {
				SJUIUtility.ShowUI (this, groupB, true, 0, .5f, delegate() {
					SJUIUtility.ShowUI (this, groupC, true, 0, .5f); 
				});
			});
			break;

		default:  
			break;  
		}  
	}

	private void OnClickGroupBButton (Button sender)
	{  
		switch (sender.transform.name) {  
		case "DoneButton":  
			InitUI();
			break;
		default:  
			break;  
		}  
	}

	private void OnClickGroupCButton (Button sender)
	{  
		switch (sender.transform.name) {  
		case "DoneButton":  
			InitUI();
			break;
		default:  
			break;  
		} 
	}
		
	#endregion
}
