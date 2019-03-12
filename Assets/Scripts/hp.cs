using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp : MonoBehaviour {

    Image hpUI;
    scriptPlayer player;
	// Use this for initialization
	void Start () {
        hpUI = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<scriptPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
        hpUI.fillAmount = (float)player.health / 4;
		
	}
}
