

function EntregaButton1() {
    document.getElementById("divEEC").style.display = 'none';
    document.getElementById("entregaemcasa").style.display = 'none';
    document.getElementById("entregaemloja").style.display = 'none';
    document.getElementById("entregaemcasaform").style.display = 'block';
}

function EntregaButton2() {
    document.getElementById("divEEC").style.display = 'none';
    document.getElementById("entregaemcasa").style.display = 'none';
    document.getElementById("entregaemloja").style.display = 'none';
    document.getElementById("entregaemlojaform").style.display = 'block';
}

function ChangeEntrega(sel) {

    var value = sel.value;
    document.getElementById("formChanger").value = value;
}

function ChangeEntrega2(sel) {

    var value = sel.value;
    document.getElementById("formChanger2").value = value;
}

function ChangeEntrega3(sel) {

    var value = sel.value;
    document.getElementById("formChanger3").value = value;
}

function trans1() {

    document.getElementById("textIBAN").style.display = 'block';
    document.getElementById("devolucaodinheiroIBAN").style.display = 'block';
    document.getElementById("textlojas").style.display = 'none';
    document.getElementById("devolucaodinheiroMorada").style.display = 'none';
    document.getElementById("devolucaodinheiroMorada").value = " ";
    document.getElementById("devolucaodinheiroCP").style.display = 'none';
    document.getElementById("devolucaodinheiroCP").value = " ";
    document.getElementById("devolucaodinheiroMPI").value = "IBAN";
    document.getElementById("devolucaodinheiroMPCR").value = " ";
}

function loja1() {

    document.getElementById("textIBAN").style.display = 'none';
    document.getElementById("devolucaodinheiroIBAN").style.display = 'none';
    document.getElementById("devolucaodinheiroIBAN").value = " ";
    document.getElementById("textlojas").style.display = 'block';
    document.getElementById("devolucaodinheiroMorada").style.display = 'block';
    document.getElementById("devolucaodinheiroCP").style.display = 'block';
    document.getElementById("devolucaodinheiroMPCR").value = "Contra Reembolso";
    document.getElementById("devolucaodinheiroMPI").value = " ";
}
