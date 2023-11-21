<?php
	$base_url = "http://localhost:5143/netcon/api/v1/converter";
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Conversor Anos-Luz e Km</title>
</head>
<body>
    <div style="margin-top: 10%">
        <h1>Conversor Anos-Luz e Km</h1>
    </div>

    <div class="forms">
        <section style="left: 5%;">
            <h2>Anos-Luz para Km</h2>
            <form method="post">
                <label for="anos-luz">Anos-Luz:</label>
                <input type="number" name="anos-luz" id="anos-luz" required>
                <input type="submit" name="converter-anos-luz" value="Converter">
            </form>
        </section>
    
        <section style="right: 5%;">
            <h2>Km para Anos-Luz</h2>
            <form method="post">
                <label for="km">Km:</label>
                <input type="number" name="km" id="km" required>
                <input type="submit" name="converter-km" value="Converter">
            </form>
        </section>
    </div>
</body>
</html>