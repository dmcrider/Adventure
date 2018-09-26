<?php
    class PagesController{
        public function home(){
            require_once('pages/home.php');
        }

        public function error(){
            require_once('pages/error.php');
        }

        public function login(){
            require_once('pages/login.php');
        }

        public function logout(){
            require_once('pages/logout.php');
        }

        public function register(){
            require_once('pages/register.php');
        }
    }
?>