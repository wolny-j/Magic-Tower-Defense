<?php
$servername = "localhost";
$username = "id17170564_cicadagames1";
$password = "3y||LU&ahtKb|<0<";
$dbname = "id17170564_magictdtesting";


//variables submited
//Player
$name = $_POST["name"];
$level= $_POST["level"];
$wave= $_POST["wave"];
$money= $_POST["money"];
$deaths= $_POST["deaths"];
$playTime= $_POST["playTime"];
$sessionToken= $_POST["sessionToken"];
$sessionDate= $_POST["sessionDate"];

//HpPotion
$hpPotionCounter= $_POST["hpPotionCounter"];
$hpPotionPower= $_POST["hpPotionPower"];
//ManaPotion
$manaPotionCounter= $_POST["manaPotionCounter"];
$manaPotionPower= $_POST["manaPotionPower"];
//inventory;
$manaPotion= $_POST["manaPotion"];
$hpPotion= $_POST["hpPotion"];
$keys= $_POST["keys"];
$books= $_POST["books"];
//Spell1
$s1Counter= $_POST["s1Counter"];
$s1Upgrades= $_POST["s1Upgrades"];
//Spell2
$s2Counter= $_POST["s2Counter"];
$s2Upgrades= $_POST["s2Upgrades"];
//Spell3
$s3Counter= $_POST["s3Counter"];
$s3Upgrades= $_POST["s3Upgrades"];
//Spell4
$s4Counter= $_POST["s4Counter"];
$s4Upgrades= $_POST["s4Upgrades"];
//Upgrades
$health= $_POST["health"];
$mana = $_POST["mana"];
$manaRegen= $_POST["manaRegen"];
$attack= $_POST["attack"];
$defence = $_POST["defence"];

$conn = new mysqli($servername, $username, $password, $dbname);
if($conn->connect_error)
{
    die("Connection failed: " . $conn->connect_error);
}
$sql = "INSERT INTO Player (Name, Level, Wave, Money, Deaths, PlayTime, SessionToken, SessionDate) VALUES ('$name', '$level', '$wave', '$money', '$deaths', '$playTime', '$sessionToken', '$sessionDate')";
if($conn->query($sql) == TRUE)
{
    echo "New record created";
}
else
{
    echo "Error: " . $sql . "<br>" . $conn->error;
}

$sql = "INSERT INTO HpPotion (Counter, PotionPower ) VALUES ('$hpPotionCounter', '$hpPotionPower')";
if($conn->query($sql) == TRUE)
{
    echo "New record created";
}
else
{
    echo "Error: " . $sql . "<br>" . $conn->error;
}
$sql = "INSERT INTO ManaPotion (Counter, PotionPower ) VALUES ('$manaPotionCounter', '$manaPotionPower')";
if($conn->query($sql) == TRUE)
{
    echo "New record created";
}
else
{
    echo "Error: " . $sql . "<br>" . $conn->error;
}
$sql = "INSERT INTO Inventory (ManaPotion, HpPotion, Keys_, Books) VALUES ('$manaPotion', '$hpPotion', '$keys', '$books')";
if($conn->query($sql) == TRUE)
{
    echo "New record created";
}
else
{
    echo "Error: " . $sql . "<br>" . $conn->error;
}
$sql = "INSERT INTO Spell1 (Counter, Upgrades) VALUES ('$s1Counter', '$s1Upgrades')";
if($conn->query($sql) == TRUE)
{
    echo "New record created";
}
else
{
    echo "Error: " . $sql . "<br>" . $conn->error;
}
$sql = "INSERT INTO Spell2 (Counter, Upgrades) VALUES ('$s2Counter', '$s2Upgrades')";
if($conn->query($sql) == TRUE)
{
    echo "New record created";
}
else
{
    echo "Error: " . $sql . "<br>" . $conn->error;
}
$sql = "INSERT INTO Spell3 (Counter, Upgrades) VALUES ('$s3Counter', '$s3Upgrades')";
if($conn->query($sql) == TRUE)
{
    echo "New record created";
}
else
{
    echo "Error: " . $sql . "<br>" . $conn->error;
}
$sql = "INSERT INTO Spell4 (Counter, Upgrades) VALUES ('$s4Counter', '$s4Upgrades')";
if($conn->query($sql) == TRUE)
{
    echo "New record created";
}
else
{
    echo "Error: " . $sql . "<br>" . $conn->error;
}
$sql = "INSERT INTO Upgrades (Health, Mana, ManaRegen, Attack, Defence) VALUES ('$health', '$mana', '$manaRegen', '$attack', '$defence')";
if($conn->query($sql) == TRUE)
{
    echo "New record created";
}
else
{
    echo "Error: " . $sql . "<br>" . $conn->error;
}

?>