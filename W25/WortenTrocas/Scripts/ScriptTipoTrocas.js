function paypal1() {
    document.getElementById("textPayPal").style.display = 'block';
    document.getElementById("devolucaodinheiropaypal").style.display = 'block';
    document.getElementById("devolucaodinheiropaypal").value = "example@example.com";
    document.getElementById("br1").style.display = "block";
    document.getElementById("textIBAN").style.display = 'none';
    document.getElementById("devolucaodinheiroIBAN").style.display = 'none';
    document.getElementById("devolucaodinheiroIBAN").value = " ";
    document.getElementById("textlojas").style.display = 'none';
    document.getElementById("devolucaodinheiroloja").style.display = 'none';
    document.getElementById("devolucaodinheiroloja").value = " ";
}

function trans1() {
    document.getElementById("textPayPal").style.display = 'none';
    document.getElementById("devolucaodinheiropaypal").style.display = 'none';
    document.getElementById("devolucaodinheiropaypal").value = " ";
    document.getElementById("br1").style.display = "none";
    document.getElementById("br3").style.display = "none";
    document.getElementById("textIBAN").style.display = 'block';
    document.getElementById("devolucaodinheiroIBAN").style.display = 'block';
    document.getElementById("devolucaodinheiroIBAN").value = "0055223322";
    document.getElementById("br2").style.display = "block";
    document.getElementById("textlojas").style.display = 'none';
    document.getElementById("devolucaodinheiroloja").style.display = 'none';
    document.getElementById("devolucaodinheiroloja").value = " ";
}

function loja1() {
    document.getElementById("textPayPal").style.display = 'none';
    document.getElementById("devolucaodinheiropaypal").style.display = 'none';
    document.getElementById("devolucaodinheiropaypal").value = " ";
    document.getElementById("br1").style.display = "none";
    document.getElementById("textIBAN").style.display = 'none';
    document.getElementById("devolucaodinheiroIBAN").style.display = 'none';
    document.getElementById("devolucaodinheiroIBAN").value = " ";
    document.getElementById("br2").style.display = "none";
    document.getElementById("textlojas").style.display = 'block';
    document.getElementById("devolucaodinheiroloja").style.display = 'block';
    document.getElementById("devolucaodinheiroloja").value = "Oeiras";
    document.getElementById("br3").style.display = "block";
}
