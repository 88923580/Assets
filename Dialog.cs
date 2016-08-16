using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialog : MonoBehaviour 
{
	public TextAsset dialog;	
	public Text txt;
	char[] seperateChar = {'[',']','/'};
	string[] dialogs;
	float timeSpan = 0.05f;
	float timeGo;

	public Button b1;
	public Button b2;
	public Button b3;
	 
	bool Continue = true;
	int charNumber = 0;
	int stringNubmer = 0;

	void Start () 
	{
		dialogs = dialog.text.Split (seperateChar);
	}
	
	void Update ()
	{
		if (Continue) 
		{
			timeGo += Time.deltaTime;
			//这里是核心
			if (timeGo > timeSpan) 
			{
				if (charNumber < dialogs [stringNubmer].Length) 
				{
					txt.text += dialogs [stringNubmer] [charNumber] + "";
					charNumber++;
					timeGo = 0;
				}
				else 
				{
					stringNubmer++;
					if (dialogs [stringNubmer] == " ") 
					{
						stringNubmer++;
					}
					if (dialogs [stringNubmer] == "P") 
					{
						b1.gameObject.SetActive (true);
						Continue = false;
						stringNubmer++;
					}
					if (dialogs [stringNubmer] == "N") 
					{
						b2.gameObject.SetActive (true);
						Continue = false;
					}
					if (dialogs [stringNubmer] == "E") 
					{
						b3.gameObject.SetActive (true);
						Continue = false;
					}
					Continue = false;
				}
			}
		}
	
		if (Input.GetMouseButton (0)) 
		{
			timeSpan = 0.01f;
		}
		if (Input.GetMouseButtonUp (0)) 
		{
			timeSpan = 0.05f;
		}
	}

	public void pastButton()
	{
		txt.text = "";
		charNumber = 0;
		if (stringNubmer > 3) {
			stringNubmer -= 5;
		}
		Continue = true;
		b1.gameObject.SetActive (false );
		b2.gameObject.SetActive (false );
		b3.gameObject.SetActive (false );
	}

	public void nextButton()
	{
		txt.text = "";
		charNumber = 0;
		stringNubmer++;
		Continue = true;
		b1.gameObject.SetActive (false );
		b2.gameObject.SetActive (false );
	}

	public void overButton()
	{
		Application.Quit ();
	}
}
