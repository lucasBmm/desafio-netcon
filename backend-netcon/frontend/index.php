<?php
	$base_url = "https://rest/netcon/api/v1/converter";

    $arrContextOptions=array(
        "ssl"=>array(
            "verify_peer"=>false,
            "verify_peer_name"=>false,
        ));
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Conversor Anos-Luz e Km</title>
    <style>
         body {
            width: 90vw;
            height: 97vh;
            font-family: Arial, sans-serif;
            text-align: center;
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .forms {
            width: 100%;
        }

        .forms section {
            position: absolute;
            margin: 20px;
            width: 40%;
            text-align: center;
            height: 150px;
            border: 2px solid lightblue;
            display: inline-block;
        }

        input {
            width: 80px;
        }
    </style>
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
            <?php
                if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST["converter-anos-luz"])) {
                    $anosLuzValue = $_POST["anos-luz"];
                    
                    if ($anosLuzValue >= 1) {
                        // Faz a requisição para localhost com path /netcon/api/v1/converter?anos-luz=1
                        $url = "$base_url?anos-luz=" . urlencode($anosLuzValue);
                        $response = file_get_contents($url, false, stream_context_create($arrContextOptions));
                        $data = json_decode($response, true);
        
                        if ($data) {
                            echo "<p>$anosLuzValue anos-luz é aproximadamente {$data['value']}.</p>";
                        } else {
                            echo "<p style='color: red;'>Erro na requisição.</p>";
                        }
                    } else {
                        echo "<p style='color: red;'>Erro: Insira um valor maior ou igual a 1.</p>";
                    }
                }
            ?>
        </section>
    
        <section style="right: 5%;">
            <h2>Km para Anos-Luz</h2>
            <form method="post">
                <label for="km">Km:</label>
                <input type="number" name="km" id="km" required>
                <input type="submit" name="converter-km" value="Converter">
            </form>
            <?php
                if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST["converter-km"])) {
                    $kmValue = $_POST["km"];

                    if ($kmValue >= 1) {
                        // Faz a requisição para localhost com path /netcon/api/v1/converter?km=1
                        $url = "$base_url?km=" . urlencode($kmValue);
                        $response = file_get_contents($url, false, stream_context_create($arrContextOptions));
                        $data = json_decode($response, true);

                        echo '<p style="height: 20px;">';
                        if ($data) {
                            echo "Resultado: <span id='result'>{$data['value']}</span>";
                        } else {
                            echo "<span style='color: red;'>Erro na requisição.</span>";
                        }
                        echo '</p>';
                    } else {
                        echo "<p style='color: red;'>Erro: Insira um valor maior ou igual a 1.</p>";
                    }
                }
            ?>
        </section>
    </div>
</body>
</html>
