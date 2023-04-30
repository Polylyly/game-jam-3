using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueTriggering : MonoBehaviour
{
	public GameObject dialogeBox;
	public GameObject myPlayer;
	public string name;
	public string[] dialogue;
	public Sprite avatarr;
	// Script HaggleManager;
	Vector3 playerTransform;
	int counter = 0;
	bool outOfRange = false;
	bool randomize = true;
	//bool refillFlag = false;
	public static DialogueTriggering instance;
	HaggleManager HaggleAinstance;
	bool _sellingFlag = false;
	bool soldOnce = false;
	void Awake(){
		instance = this;
		HaggleAinstance = GetComponent<HaggleManager>();
	}
	void Start()
	{
		dialogeBox.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		MetalDetectorBehavior battery = GameObject.FindWithTag("Player").transform.GetChild(0).gameObject.GetComponent<MetalDetectorBehavior>();
		float myDist = calculateDistance();
		if (myDist <= 3.0f){
			Debug.Log(name);
			outOfRange = false;
			if (name == "Bella" && Input.GetKeyUp(KeyCode.Space)){
				counter = (counter + 1) % dialogue.Length;
				if (counter % dialogue.Length > (counter + 1) % dialogue.Length)
				battery.Charge(100f);
			}
			if (name == "Bigoton")
			_sellingFlag = true;
			//GameObject.FindWithTag("Player").transform.GetChild(0).gameObject.GetComponent<MetalDetectorBehavior>().Charge(100f);
			dialogeBox.SetActive(true);
			setCharacter();
		}else{
			if(!outOfRange){
				counter = 0;
				randomize = true;
				dialogeBox.SetActive(false);
				_sellingFlag = false;
				outOfRange = true;
				soldOnce = false;
			}
		}
	}
	public bool sellingStatus(){
		return _sellingFlag;
	}
	float calculateDistance(){
		playerTransform = myPlayer.transform.position;
		float part1 = (playerTransform.x - this.transform.position.x);
		float part2 = (playerTransform.y - this.transform.position.y);
		float part3 = (playerTransform.z - this.transform.position.z);
		float part11 = part1 * part1;
		float part22 = part2 * part2;
		float part33 = part3 * part3;
		return Mathf.Sqrt(part11 + part22 + part33);
	}
	void setName(){
		GameObject.Find("DialogueBox/ActorName").GetComponent<UnityEngine.UI.Text>().text = name;
	}
	void setDialogue(){
		if (name == "Tito" && randomize == true){
			counter = Random.Range(0,dialogue.Length);
			randomize = false;
		}
		GameObject.Find("Dialogue/DialogueBox/Message").GetComponent<UnityEngine.UI.Text>().text = dialogue[counter];
	}
	void setImage(){
		GameObject.Find("DialogueBox/Avatar").GetComponent<Image>().sprite = avatarr;
	}
	void BigotonManage(){
		if(!soldOnce){
		soldOnce = true;
		Debug.Log("Start haggle sequence");
		HaggleAinstance.StartHaggleSequence();
	}
		if(HaggleAinstance.selling()){
		if (Input.GetKeyDown("y"))
		{
			Debug.Log("Start haggle minigame");
			HaggleAinstance.OnHaggleMinigameStart();
		}
		else if (Input.GetKeyDown("n"))
		{
			Debug.Log("Price accepted");
			HaggleAinstance.OnAcceptPrice();
		}
		if (HaggleAinstance.slider._pauseToggle == true)
			{
				HaggleAinstance.OnHaggleMinigameEnd();
				HaggleAinstance.slider._pauseToggle = false;
			}
	}
	}
	void setCharacter(){
		// Debug.Log(myDist);
		// Debug.Log(name);
		setName();
		if (name != "Bigoton")
		setDialogue();
		else
		BigotonManage();
		setImage();
	}
}
