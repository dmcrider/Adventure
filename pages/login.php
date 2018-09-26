<?php
    echo "You'll be able to login soon enough!";
    die();
	/**
	 * Once the user clicks the 'Login' button, verify they entered information
	 * and attempt to login using the appropriate class.
	 */
	if(isset($_POST['email']) and isset($_POST['password'])){
		// Check the database for a match
		return;
	}

	// Add the message from password update
	if(isset($_GET['message'])){
		$_SESSION['update_message'] = $_GET['message'];
	}
?>
<?php
	/**
	 * Display the update message if the user successfully
	 * updated their password
	 */
	if(isset($_SESSION["update_message"])){
		echo "<p id='success-message'>" . $_SESSION["update_message"] . "</p>";
		unset($_SESSION['update_message']);
	}
?>
<!-- Login Form -->
<form class="form-sign-in" method="POST" action="">
	<h2 class="form-sign-in-header">Login</h2>

	<?php if(isset($_SESSION['login_error'])) : ?>
		<div id="error-message"><?php echo $_SESSION['login_error'] ?></div>
	<?php endif; ?>
	<?php unset($_SESSION['login_error']); ?>

	<input type="text" name="loginname" class="form-control" placeholder="Username" required>
	
	<label for="inputPassword" class="sr-only">Password</label>
	<input type="password" name="password" id="inputPassword" class="form-control" placeholder="Password" required>

	<button class="btn btn-lg btn-primary btn-block" type="submit">Login</button>
	<a class="btn btn-lg btn-primary btn-block" href="index.php?action=register">Register</a>
</form>
<!-- End Login Form-->