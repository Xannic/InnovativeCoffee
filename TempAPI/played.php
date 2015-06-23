<?php 
	include("koffie_config.php");
?>
	
<?php
	$sql = "UPDATE `CoffeeChoice` SET  `Played` =  '1' WHERE  `CoffeeChoice`.`id` =(SELECT MAX(id) FROM (SELECT * FROM `CoffeeChoice`)AS something)";

	mysql_query($sql);
	mysql_close($con);
?>