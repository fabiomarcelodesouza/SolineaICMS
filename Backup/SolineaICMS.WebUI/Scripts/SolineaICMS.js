function isNum(caractere) {
    var strValidos = "0123456789-,."

    if (strValidos.indexOf(caractere) == -1) {
        return false;
    }
    return true;
}

function validaTecla(campo, event) {
    var BACKSPACE = 8;
    var key;
    var tecla;

    CheckTAB = true;

    if (navigator.appName.indexOf("Netscape") != -1) {
        tecla = event.which;
    }
    else {
        tecla = event.keyCode;
    }

    key = String.fromCharCode(tecla);

    if (tecla == 13) {
        return false;
    }

    if (tecla == 44) {
        return false;
    }

    if (tecla == 46) {
        return false;
    }

    if (tecla == BACKSPACE) {
        return true;
    }

    return (isNum(key));
}

function FormataValor(campo, tammax, teclapres) {
    var tecla = teclapres.keyCode;

    vr = campo.value;
    vr = vr.replace("/", "");
    vr = vr.replace("/", "");
    vr = vr.replace(",", "");
    vr = vr.replace(".", "");
    vr = vr.replace(".", "");
    vr = vr.replace(".", "");
    vr = vr.replace(".", "");

    tam = vr.length;

    if (tammax == tam) {
        return false;
    }

    if (tam < tammax && tecla != 8) { tam = vr.length + 1; }
    if (tecla == 8) { tam = tam - 1; }
    if (tecla == 8 || tecla >= 48 && tecla <= 57 || tecla >= 96 && tecla <= 105) {

        if (tam <= 2) {
            campo.value = vr;
        }

        if ((tam > 2) && (tam <= 5)) {
            campo.value = vr.substr(0, tam - 2) + ',' + vr.substr(tam - 2, tam);
        }

        if ((tam >= 6) && (tam <= 8)) {
            campo.value = vr.substr(0, tam - 5) + '.' + vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2, tam);
        }

        if ((tam >= 9) && (tam <= 11)) {
            campo.value = vr.substr(0, tam - 8) + '.' + vr.substr(tam - 8, 3) + '.' + vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2, tam);
        }

        if ((tam >= 12) && (tam <= 14)) {
            campo.value = vr.substr(0, tam - 11) + '.' + vr.substr(tam - 11, 3) + '.' + vr.substr(tam - 8, 3) + '.' + vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2, tam);
        }

        if ((tam >= 15) && (tam <= 17)) {
            campo.value = vr.substr(0, tam - 14) + '.' + vr.substr(tam - 14, 3) + '.' + vr.substr(tam - 11, 3) + '.' + vr.substr(tam - 8, 3) + '.' + vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2, tam);
        }

        if ((tam >= 18) && (tam <= 20)) {
            campo.value = vr.substr(0, tam - 17) + '.' + vr.substr(tam - 17, 3) + '.' + vr.substr(tam - 14, 3) + '.' + vr.substr(tam - 11, 3) + '.' + vr.substr(tam - 8, 3) + '.' + vr.substr(tam - 5, tam) + ',' + vr.substr(tam - 2, tam);
        }
    }
}

function fctCancelar(acao) {
    if (acao == "cancelar") {
        return confirm("Tem certeza que deseja cancelar?");
    }
}

function fctChamaModalConfirmacao(title, message) {
    // a workaround for a flaw in the demo system (http://dev.jqueryui.com/ticket/4375), ignore!
    $("#dialog:ui-dialog").dialog("destroy");

    $("#dialog-confirm").dialog({
        resizable: false,
        height: 250,
        width: 450,
        modal: true,
        title: title,
        buttons: {
            "Confirmar": function () {
                $(this).dialog("close");
                fctCliqueBotaoRespostaConfirmacao();
            },
            "Cancelar": function () {
                $(this).dialog("close");
            }
        }
    });

    $("#imageModalMessage").attr("src", "/SolineaICMS_App/Images/Icons/question48px.png");
    $("#imageModalMessage").attr("alt", "Questão");

    $("#modalMessage").html(message);
    $("#imageModalMessage").css("display", "");

    return false;
}

function fctChamaModalInformacao(title, message, type) {
    // a workaround for a flaw in the demo system (http://dev.jqueryui.com/ticket/4375), ignore!
    $("#dialog:ui-dialog").dialog("destroy");

    $("#dialog-confirm").dialog({
        resizable: false,
        height: 250,
        width: 450,
        modal: true,
        title: title,
        buttons: {
            "Ok": function () {
                $(this).dialog("close");
            }
        }
    });

    $("#modalMessage").html(message);

    if (type == "Error") {
        $("#imageModalMessage").attr("src", "/SolineaICMS_App/Images/Icons/error48px.png");
        $("#imageModalMessage").attr("alt", "Erro");
    }
    else if (type == "Information") {
        $("#imageModalMessage").attr("src", "/SolineaICMS_App/Images/Icons/information48px.png");
        $("#imageModalMessage").attr("alt", "Informação");
    }
    else if (type == "Question") {
        $("#imageModalMessage").attr("src", "/SolineaICMS_App/Images/Icons/question48px.png");
        $("#imageModalMessage").attr("alt", "Confirmação");
    }
    else if (type == "Success") {
        $("#imageModalMessage").attr("src", "/SolineaICMS_App/Images/Icons/success48px.png");
        $("#imageModalMessage").attr("alt", "Sucesso");
    }
    else if (type == "Warning") {
        $("#imageModalMessage").attr("src", "/SolineaICMS_App/Images/Icons/warning48px.png");
        $("#imageModalMessage").attr("alt", "Cuidado");
    }

    $("#imageModalMessage").css("display", "");

    return false;
}

function fctConverteData(value) {
    var data = value;
    var dia = data.substr(0, 2);
    var mes = data.substr(3, 2);
    var ano = data.substr(6, 4);

    return new Date(ano, mes, dia);
}