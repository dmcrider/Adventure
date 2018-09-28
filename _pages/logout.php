<?php
	session_start();
	// Save any messages before logging out - ie password update success messages
	if(isset($_SESSION['update_message'])){
		$message = $_SESSION['update_message'];
		$header = "Location: index.php?action=login&message=$message";
	}else{
		$header = "Location: index.php?action=login";
	}
	session_destroy();
	header($header);
?>