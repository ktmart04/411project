<?php 

// This is just an example of reading server side data and sending it to the client.
// It reads a json formatted text file and outputs it.

$string = file_get_contents("sampleData.json");
echo $string;

// Instead you can query your database and parse into JSON etc etc

resource mssql_connect ([ string $martin.uofl-cis411.com [, string $kwekum1 [, string $Taffyd4l** [, bool $new_link = false ]]]] )

$q=$_GET["q"];
  $dbuser="kwekum1";
  $dbname="Martin";
  $dbpass="Taffyd4l**";
  $dbserver="martin.uofl-cis411.com";

  $sql_query = "SELECT Venue FROM ReceiptPages;
  $con = mysql_connect($dbserver,$dbuser,$dbpass);
  if (!$con){ die('Could not connect: ' . mysql_error()); }
  mysql_select_db($dbname, $con);
  $result = mysql_query($sql_query);
  echo "{ \"cols\": [ {\"id\":\"\",\"label\":\"Name-Label\",\"pattern\":\"\",\"type\":\"string\"}, {\"id\":\"\",\"label\":\"PointSum\",\"pattern\":\"\",\"type\":\"number\"} ], \"rows\": [ ";
  $total_rows = mysql_num_rows($result);
  $row_num = 0;
  while($row = mysql_fetch_array($result)){
    $row_num++;
    if ($row_num == $total_rows){
      echo "{\"c\":[{\"v\":\"" . $row['name'] . "-" . $row['label'] . "\",\"f\":null},{\"v\":" . $row['pointsum'] . ",\"f\":null}]}";
    } else {
      echo "{\"c\":[{\"v\":\"" . $row['name'] . "-" . $row['label'] . "\",\"f\":null},{\"v\":" . $row['pointsum'] . ",\"f\":null}]}, ";
    }
  }
  echo " ] }";
  mysql_close($con);
?>


?>