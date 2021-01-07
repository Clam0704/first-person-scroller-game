using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playButtonControl : MonoBehaviour {

    public Button yourButton;

    // Use this for initialization
    void Start () {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(buttonClick);
    }
	
	// Update is called once per frame
	void buttonClick() {
        SceneManager.LoadScene(1);
	}
}
