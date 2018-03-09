using UnityEngine;
using System.Collections;

public class CoffeeData{

	private string _landscape;
	private string _deviceId;
	private string _date;
	private string _time;
	private string _played;

	public string OrderScene{
		get{return _landscape;}
		set{_landscape = value;}
	}

	public string DeviceId{
		get{return _deviceId;}
		set{_deviceId = value;}
	}

	public string Date{
		get{return _date;}
		set{_date = value;}
	}

	public string Time{
		get{return _time;}
		set{_time = value;}
	}

	public string Played{
		get{return _played;}
		set{_played = value;}
	}


}
