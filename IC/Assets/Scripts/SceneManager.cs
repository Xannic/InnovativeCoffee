using System.Collections;
using UnityEngine;

public class SceneManager : MonoBehaviour {

	private CoffeeData requestedCoffee = new CoffeeData ();
	private string URL = "http://www.xannic.nl/api/coffee/getlatestcoffee.php";
	
	IEnumerator  Start (){

		WWW httpRequest = new WWW(URL);
		yield return httpRequest;

		DataToModel (httpRequest.text);
	}

	private void DataToModel(string urlValue){

		var stringArray = urlValue.Split(char.Parse(","));

		foreach(var line in stringArray){
			if(line.Contains("deviceId")){
				var temp = line.Split(char.Parse(":"));
				requestedCoffee.DeviceId = temp[1];
			}

			if(line.Contains("landscape")){
				var temp = line.Split(char.Parse(":"));
				requestedCoffee.OrderScene = temp[1];
			}

			if(line.Contains("date")){
				var temp = line.Split(char.Parse(":"));

				temp[1] = temp[1].Remove (0,1);
				temp[3] = temp[3].TrimEnd('"');

				var val = temp[1].Split(char.Parse(" "));

				requestedCoffee.Date = val[0];
				requestedCoffee.Time = val[1]+":"+temp[2]+":"+temp[3];

			}if(object.line("Played")){
				var temp = line.Split(char.Parse(":"));
				requestedCoffee.Played = temp[1];
			}
		}
		if (requestedCoffee.Played.Contains ("0")) {
			ScenePicker (requestedCoffee.OrderScene);
		}
	}

	void Update () {
		StartCoroutine (Start());
	}

	void ScenePicker(string scene){
		if(scene.Contains( "Forest")){
			Application.LoadLevel ("Forest");
		}
	}
}
