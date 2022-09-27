<?php 
	function msgIp() {
		$output = shell_exec("scripts/puip.sh"); 
		echo $output; 
	}
	function msgDate() {
		$output = shell_exec("scripts/testtime.sh");
		echo $output;
	}
	function msgPhpVersion() {
		echo phpversion();
	}
	function msgRemoteIp() {
		$ip = $_SERVER['REMOTE_ADDR'];
		echo $ip;
	}
	function msgUname(){
		if(isset($_POST['uname'])){
			echo $_POST['uname'];
			
			} else {
				echo 'Introduce un nombre de usuario';
			}
	}
	
?>
