<!DOCTYPE html>
<?php include("scripts/testphp.php"); ?>
<html lang="es">
  <head>
	<meta charset="utf-8" />
	<meta http-equiv="x-ua-compatible" content="ie=edge" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />
	<title>Wev Development Environtment</title>
	<link rel="stylesheet" href="styles/test1.css" />
  </head>
  <body style="background-color:lightyellow">
	<div style="margin-left:auto;margin-right:auto;font-size:18px;font-style:bold;text-align:center"><h1>KS Server</h1></div>
	<div style="height:120px"><div>
				<ul id="menu">
					<li><a href="index.php">Inicio</a></li>
					<li><a href="login.php">Login</a></li>
					<!--<li><a href="nosotros.php">Nosotros</a></li>
					<li><a href="contacto.php">Contacto</a></li>-->
				</ul>
			</div></div>
	<div class="testtable" >
		<table class="default" border="ridge" style="margin-left:auto;margin-right:auto;margin-top:auto;border-collapse:collapse;text-align:center">
			<tr style="background-color:lightgreen">
				<th>Version actual de PHP:</th>
				<th>P.IP</th>
				<th>Fecha</th>
			</tr>
			<tr>
				<td><?php msgPhpVersion();?></td>
				<td><?php msgIp();?></td>
				<td><?php msgDate();?></td>
			</tr>
			
		</table>
	</div>
  </body>
</html>