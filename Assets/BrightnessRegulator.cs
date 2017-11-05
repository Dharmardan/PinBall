using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour {
	//マテリアルを入れる
	Material mymaterial;
	//Emissionの最小値
	private float minemission=0.3f;
	//Emiddionの強度
	private float magemission=2.0f;
	//角度
	private int degree=0;
	//発光速度
	private int speed=10;
	//ターゲットのデフォルトの色
	Color defaultcolor=Color.white;
	// Use this for initialization
	void Start () {
		//タグによって光らせる色を変える
		if (tag == "SmallStarTag") {
			this.defaultcolor = Color.white;
		} else if (tag == "LargeStarTag") {
			this.defaultcolor = Color.yellow;
		} else if (tag == "SmallCloudTag" || tag == "LargeCloudTag") {
			this.defaultcolor = Color.blue;
		}
		//オブジェクトにアタッチしているMaterialを取得
		this.mymaterial=GetComponent<Renderer>().material;
		//オブジェクトの最初の色を設定
		mymaterial.SetColor("_EmissionColor",this.defaultcolor*minemission);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.degree >= 0) {
			//光らせる強度を計算する
			Color emissioncolor = this.defaultcolor * (this.minemission + Mathf.Sin (this.degree * Mathf.Deg2Rad) * this.magemission);
			//emissionに色を設定する
			mymaterial.SetColor ("_EmissionColor", emissioncolor);
			//現在の角度を小さくする
			this.degree -= this.speed;
		}
	}
		//衝突時に呼ばれる関数
		void OnCollisionEnter(Collision other){
			//角度を180度に設定
			this.degree=180;
		}
}
