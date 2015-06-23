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
	$sql = "SELECT * FROM CoffeeChoice ORDER BY id DESC LIMIT 1";
	$result = mysql_query($sql);
	while($row = mysql_fetch_array($result)) {
        echo json_encode($row);
    }
	mysql_close($con);
?>