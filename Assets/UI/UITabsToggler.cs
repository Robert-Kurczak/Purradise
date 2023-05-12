using UnityEngine;
using UnityEngine.UI;

public class UITabsToggler : MonoBehaviour{
	public Image buttonImage;
	public Sprite backgroundActiveSprite;
	public Sprite backgroundInactiveSprite;

	public GameObject activeIcon;
	public GameObject inactiveIcon;
	public GameObject tab;

	void Start(){
		activeIcon.SetActive(false);
		inactiveIcon.SetActive(true);
		tab.SetActive(false);
	}

	public void toggleTab(){
		//Toggle on
		if(!tab.activeSelf){
			buttonImage.sprite = backgroundActiveSprite;

			inactiveIcon.SetActive(false);
			activeIcon.SetActive(true);

			tab.SetActive(true);
		}
		//Toggle off
		else{
			buttonImage.sprite = backgroundInactiveSprite;

			inactiveIcon.SetActive(true);
			activeIcon.SetActive(false);

			tab.SetActive(false);
		}
	}
}
