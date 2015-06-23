<?php 
	include("koffie_config.php");
?>
	
<?php

//$sql = "SELECT ID FROM Cities WHERE Name LIKE '%" . $cityName . "%' LIMIT 1";
	
//$result= mysql_query($sql)
	
//$json['item'][]="ok";
//$encodedJson = json_encode($json); 
//echo $encodedJson;
	//www.xannic.nl/api/coffee/insertcoffee.php?coffee=esspresso&landscape=forest&time_seconds=30
	$sql = "INSERT INTO CoffeeChoice(coffee,landscape,seconds,deviceId) Values ('". $_POST["coffee"] ."','". $_POST["landscape"] ."','". $_POST["time_seconds"] ."','". $_POST["deviceId"] ."')";
	mysql_query($sql);
	
	mysql_close($con);
?>