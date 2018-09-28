<?php
	require("functions/RegisterUser.php");

	if(isset($_POST['loginname'])){
		if(doesUserExist()){
			echo addUser();
		}
		return;
	}
?>
<!-- Registration form -->
<form class="form-sign-in" method="POST" action="">
	<h2 class="form-sign-in-header">Registration</h2>

	<?php if(isset($_SESSION['register-error'])) : ?>
		<div id="error-message"><?php echo $_SESSION['register-error'] ?></div>
	<?php endif; ?>
	<?php unset($_SESSION['register-error']); ?>
	
	<input type="text" name="firstname" class="form-control" placeholder="First name" required>
	<input type="text" name="lastname" class="form-control" placeholder="Last name" required>
	
	<input type="email" name="email" class="form-control" placeholder="Email" required>
	
	<input type="text" name="loginname" class="form-control" placeholder="Username" id="loginname" required>

	<input type="password" name="password" id="inputPassword" class="form-control" placeholder="Password" required>

	<input type="password" name="password2" id="verifyPassword" class="form-control" placeholder="Verify Password" required>

	<button class="btn btn-lg btn-primary btn-block" type="submit">Register</button>
	<a class="btn btn-lg btn-primary btn-block" href="index.php?action=login">Login</a>
</form>