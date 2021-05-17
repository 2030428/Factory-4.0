<?php
	//database variables
	$dsn = "odbc:FestoMES";
	$user = "";
	$password = "";
	$options = array(PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION);
	
	//command options
	$command = null; 
	if(isset($_GET['Command'])){
		$command = $_GET['Command'];
	}
	switch($command) {
		case "ordersOptions":
			$sql_request = "
				SELECT tblParts.PNo, tblParts.Description, tblParts.Picture
				FROM tblParts
				WHERE tblParts.Type=3 AND tblParts.WPNo<>0
				ORDER By tblParts.PNo";
			Break;
		case "currentOrders": 
			$sql_request = "
				SELECT tblOrder.ONo, tblCustomer.Company, tblOrder.PlanedStart AS PlannedStart, tblOrder.PlanedEnd AS PlannedEnd, tblStates.Description AS State
				FROM (tblOrder INNER JOIN tblCustomer ON tblOrder.CNo = tblCustomer.CNo)
				INNER JOIN tblStates ON tblOrder.State = tblStates.State
				WHERE tblOrder.Enabled = 1
				ORDER BY tblOrder.PlanedStart";
			Break;
		case "finishedOrders": 
			if(!isset($_GET['numOrders'])) {
				$numOrders = 10;
			} 
			else {
				$numOrders = $_GET['numOrders'];
			}
			$sql_request = "
				SELECT TOP " . $numOrders . " tblFinOrder.ONo AS FinONo, tblCustomer.Company, tblFinOrder.[Start], tblFinOrder.[End], tblStates.Description AS State
				FROM (tblFinOrder INNER JOIN tblCustomer ON tblFinOrder.CNo = tblCustomer.CNo)
				INNER JOIN tblStates ON tblFinOrder.State = tblStates.State
				ORDER BY tblFinOrder.Start DESC";
			Break;
		case "cart": 
			if(!isset($_GET['carrierID'])) {
				$sql_request = "
					SELECT * 
					FROM tblcarrier";
			} 
			else {
				$sql_request = "
					SELECT * 
					FROM tblcarrier
					WHERE CarrierID = " . $_GET['carrierID'] ;
			}
			Break;
		default:
			echo "choose one of these options as gets : </br>
				ordersOptions, </br>
				currentOrders, </br>
				finishedOrders with optional numOrders, </br>
				cart with optional carrierID </br>
			";
	}
	if(isset($sql_request)) sqlGetValues($sql_request);		
	
	function sqlGetValues($sql) {
    // Executes SQL query, e.g. to delete buffer position
    // Create new PHP Data Object:
		try {
			$db = new PDO($GLOBALS["dsn"],$GLOBALS["user"],$GLOBALS["password"],$GLOBALS["options"]);
			// Execute SQL-query:
			$result = $db->query($sql);
			//$q = $db->prepare($sql);
			//$q->execute();
			//echo '$result[0]: ' . $result[0];
			$emparray = array();
			foreach ($result as $row) {      
				//$emparray[] =  utf8_encode($row);
				$emparray[] =  $row;
			}
			echo json_encode($emparray);
		}
		catch(PDOException $e) {
			echo utf8_encode($e->getMessage());
		}   
		$db = null;
	}
	
?>