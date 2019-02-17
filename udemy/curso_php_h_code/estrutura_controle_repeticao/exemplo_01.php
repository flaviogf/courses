<form method="post">
  <input type="number" name="idade">
  <button type="submit">OK</button>
</form>

<?php
if(!empty($_POST)) {
  $idade = (int)$_POST["idade"];

  if($idade < 6)  {
    echo "criança";
  } elseif($idade < 18) {
    echo "jovem";
  } elseif($idade < 65) {
    echo "adulto";
  } else {
    echo "idoso";
  }
}
