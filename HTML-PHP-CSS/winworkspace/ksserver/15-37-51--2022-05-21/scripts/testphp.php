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
?>