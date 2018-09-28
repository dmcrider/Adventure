<?php
    class PagesController{
        public function home(){
            require_once('_pages/home.php');
        }

        public function error(){
            require_once('_pages/error.php');
        }

        public function login(){
            require_once('_pages/login.php');
        }

        public function logout(){
            require_once('_pages/logout.php');
        }

        public function register(){
            require_once('_pages/register.php');
        }

        public function account(){
            require_once('_pages/account.php');
        }
    }
?>