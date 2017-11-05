using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRegulator : MonoBehaviour {
	
	//得点を表示するテキスト
	private GameObject scoretext;
	//得点
	private int score=0;


	// Use this for initialization
	void Start () {
		//ScoreTextオブジェクトを取得
		this.scoretext=GameObject.Find("ScoreText");

	}
	
	// Update is called once per frame
	void Update () {
			
	}
	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other){
		//衝突時にタグによって追加する得点を変える
		if (other.gameObject.CompareTag("SmallStarTag")) {
			this.score+=10;
		} else if (other.gameObject.CompareTag("LargeStarTag")) {
			this.score+=50;
		} else if (other.gameObject.CompareTag("SmallCloudTag")) {
			this.score+=25;
		} else if (other.gameObject.CompareTag("LargeCloudTag")){
			this.score+=70;
		}
		//得点を表示
		this.scoretext.GetComponent<Text> ().text = "Score:" + this.score;
	}
}
