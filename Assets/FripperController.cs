using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
	// HingeJointコンポーメントを入れる
	private HingeJoint myHingeJoint;
	//初期の傾き
	private float defaultAngle=20;
	//弾いた時の傾き
	private float flickAngle=-20;
	Touch touch;

	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint=GetComponent<HingeJoint>();
		//フリッパーの傾きを設定
		setangle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//左矢印キーを押した時右フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			setangle (this.flickAngle);
		}
		//右矢印キーを押した時右フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			setangle (this.flickAngle);
		}
		//矢印が離された時フリッパーを元に戻す
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			setangle (this.defaultAngle);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			setangle (this.defaultAngle);
		}
		//スマホのタッチに対応
		if (Input.touchCount > 0) {
			//タッチされている指の数だけ処理
			for (int i = 0; i < Input.touchCount; i++) {
				this.touch = Input.touches [i];
				//タッチした時
				if (this.touch.phase == TouchPhase.Began) {
					//画面の左をタッチした時左フリッパーを動かす
					if (this.touch.position.x < 250 && tag == "LeftFripperTag") {
						setangle (this.flickAngle);
					}
					//画面の右をタッチした時右フリッパーを動かす
					if (this.touch.position.x > 250 && tag == "RightFripperTag") {
						setangle (this.flickAngle);
					}
					//指を離した時
				} else if (this.touch.phase == TouchPhase.Ended) {
					setangle (this.defaultAngle);
				}
			}
		}
	}
	public void setangle(float angle){
		JointSpring jointspr = this.myHingeJoint.spring;
		jointspr.targetPosition = angle;
		this.myHingeJoint.spring = jointspr;
	}
}
