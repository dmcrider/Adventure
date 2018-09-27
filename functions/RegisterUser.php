<?php
	// Check if form is submitted
	function addUser(){
		if(isset($_POST['loginname']) and isset($_POST['password'])){
			// Get all the fields
			$firstname = stripslashes($_POST['firstname']);
			$lastname = stripslashes($_POST['lastname']);
			$password = $_POST['password'];
			$password2 = $_POST['password2'];
            $email = $_POST['email'];
            $loginname = stripslashes($_POST['loginname']);
			
			if($password === $password2 && filter_var($email, FILTER_VALIDATE_EMAIL)){
				
				// Hash the password for security
				$hash = password_hash($password, PASSWORD_DEFAULT);
				
				try{
					// Initiate a connection to the database
					$db = DB::getInstance();
					$command = "INSERT INTO users(FirstName, LastName, Email, LoginName, UPassword) VALUES (:firstname, :lastname, :email, :loginname, :upass)";
                    $query = $db->prepare($command);
                    $results = $query->execute(array(
                        ':firstname' => $firstname,
                        ':lastname' => $lastname,
                        ':email' => $email,
                        ':loginname' => $loginname,
                        ':upass' => $hash
                    ));
                    $_SESSION['is-logged-in'] = TRUE;
					header('Location: index.php?action=home');
					die();
				} catch (PDOException $e){
					$_SESSION['register-error'] = "PDO Error: " . $e;
				}
			}else{
				$_SESSION['register-error'] = "Something went wrong. Please try again later.";
			}
		}else{
			$_SESSION['register-error'] = "Something went wrong. Please try again later.";
		}
	}

	function doesUserExist(){
		try{
			$db = DB::getInstance();
			$command = "SELECT * FROM agent WHERE LoginName = ?";
			$stmt = $db->prepare($command);
			$result = $stmt->execute([$_POST['loginname']]);
			if($result){
				$users = $stmt->fetchAll();
			}else{
				return false;
			}
		}catch(PDOException $e){
			$_SESSION['register-error'] = "PDO Error: " . $e;
		}

		if(!isset($users[0])){
			// No user with that LoginName exists
			addUser();
		}else{
			// LoginName already exists - cannot add user
			$_SESSION['register-error'] = "An account for that Username already exists.";
			header("Location: index.php?action=register");
		}
	}
?>