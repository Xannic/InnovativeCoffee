<?php
	$con = mysql_connect("db.xannic.nl","md225607db329084","0iHYE3Ig");
	if (!$con)
	{
		die('Could not connect: ' . mysql_error());
	}
	mysql_select_db("md225607db329084", $con);
	session_start();
?>