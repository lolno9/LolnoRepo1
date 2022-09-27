<!DOCTYPE html>	
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
		<div >
			<ul id="menu">
				<li><a href="index.php">Inicio</a></li>
				<li><a href="login.php">Login</a></li>
				<!--<li><a href="nosotros.php">Nosotros</a></li>
				<li><a href="contacto.php">Contacto</a></li>-->
			</ul>
		</div>	
	<div style="margin-top:110px;margin-left:auto;margin-right:auto;text-align:center">
		<form class="loginform" action="/action_page.php">
			<label for="uname"><b>Username</b></label>
			<input type="text" placeholder="Enter Username" name="uname" required>

			<label for="psw"><b>Password</b></label>
			<input type="password" placeholder="Enter Password" name="psw" required>

			<button type="submit">Login</button>
		</form>
    </div>
</html>
