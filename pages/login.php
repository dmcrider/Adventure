<?php
    //echo "You'll be able to login soon enough!";
    //die();
	/**
	 * Once the user clicks the 'Login' button, verify they entered information
	 * and attempt to login using the appropriate class.
	 */
	if(isset($_POST['email']) and isset($_POST['password'])){
		// Check the database for a match
		if(User::Login()){
			$_SESSION['is-logged-in'] = TRUE;
			header('Location: index.php?action=home');
			die();

		}else{
			header('Location: index.php?action=login');
			die();
		}
		return;
	}
?>
<!-- Login Form -->
<form class="form-sign-in" method="POST" action="">
	<h2 class="form-sign-in-header">Login</h2>

	<?php
		if(isset($_SESSION['login-error'])){
			echo "<div id='error-message'>" . $_SESSION['login-error'] . "</div>";
			unset($_SESSION['login-error']);
		}
	?>

	<input type="text" name="loginname" class="form-control" autocomplete="off" placeholder="Username" required>
	
	<label for="inputPassword" class="sr-only">Password</label>
	<input type="password" name="password" id="inputPassword" class="form-control" autocomplete="off" placeholder="Password" required>

	<button class="btn btn-lg btn-primary btn-block" type="submit">Login</button>
	<a class="btn btn-lg btn-primary btn-block" href="index.php?action=register">Register</a>
</form>
<!-- End Login Form-->