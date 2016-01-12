

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

