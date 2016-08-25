using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// Activate head tracking using the gyroscope
public class Gyro2 : MonoBehaviour {
	public GameObject player; // First Person Controller parent node
	public GameObject head; // First Person Controller camera

	public Quaternion atti;
	public Text att;
	public Text oriX;
	public Text oriY;
	public Text oriZ;

	public Text gyroX;
	public Text gyroY;
	public Text gyroZ;

	public Text curX;
	public Text curY;
	public Text curZ;

	public Text playerUI;

	public Text enableText;
	// The initials orientation
	private float initialOrientationX;
	private float initialOrientationY;
	private float initialOrientationZ;
	
	// Use this for initialization
	void Start () {
		//check support Gyro
		if(SystemInfo.supportsGyroscope){
			Debug.Log("have gyro");
			enableText.text = "Y";
		}else{
			Debug.Log("dont have gyro");
			enableText.text = "N";
		}
		// Activate the gyroscope
		Input.gyro.enabled = true;

		

		// Save the firsts values
		initialOrientationX = Input.gyro.rotationRateUnbiased.x;
		initialOrientationY = Input.gyro.rotationRateUnbiased.y;
		initialOrientationZ = -Input.gyro.rotationRateUnbiased.z;

		//ui
		oriX.text = "oriX: " + initialOrientationX.ToString();
		oriY.text = "oriY: " + initialOrientationY.ToString();
		oriZ.text = "oriZ: " + initialOrientationZ.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		// Rotate the player and head using the gyroscope rotation rate
		player.transform.Rotate (initialOrientationX -Input.gyro.rotationRateUnbiased.x, 
		                         initialOrientationY -Input.gyro.rotationRateUnbiased.y, 
		                         initialOrientationZ + Input.gyro.rotationRateUnbiased.z);
//		head.transform.Rotate (initialOrientationX -Input.gyro.rotationRateUnbiased.x, 
//		                       0, 
//		                       initialOrientationZ + Input.gyro.rotationRateUnbiased.z);
		//ui
		gyroX.text = "gyroX: " + Input.gyro.rotationRateUnbiased.x.ToString();
		gyroY.text = "gyroY: " + Input.gyro.rotationRateUnbiased.y.ToString();
		gyroZ.text = "gyroZ: " + Input.gyro.rotationRateUnbiased.z.ToString();

		curX.text = "curX: " + (initialOrientationX -Input.gyro.rotationRateUnbiased.x).ToString();
		curY.text = "curY: " + (initialOrientationY -Input.gyro.rotationRateUnbiased.y).ToString();
		curZ.text = "curZ: " + (initialOrientationZ + Input.gyro.rotationRateUnbiased.z).ToString();

		atti = Input.gyro.attitude;
		att.text = "Att: " + atti.eulerAngles.ToString();
		playerUI.text = "Player: " + player.transform.rotation.eulerAngles.ToString();

	}







}
