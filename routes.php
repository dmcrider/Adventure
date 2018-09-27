<?php
    function call($action){
        require_once('_controllers/pages_controller.php');
		$controller = new PagesController();
        if($action == 'pages'){
            $controller->{'home'}();
        }else{
            $controller->{$action}();
        }
    }

    $controllers = array('pages' => ['home','login','logout','register','error', 'account']);

    if(in_array($action, $controllers['pages'])){
        call($action);
    }else{
        call('error');
    }
?>