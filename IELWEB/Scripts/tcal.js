function LlenaEdad(sender, e) {
    dateVar1 = new Date();

    var fecha = e.get_selectedDate();
    var mesPic = fecha.getMonth() + 1;
    var anoPic = fecha.getFullYear();
    var anoActual = dateVar1.getFullYear();
    var mesActual = dateVar1.getMonth();
    var txtAnos = document.getElementById("txtAnos");
    var txtMeses = document.getElementById("txtMeses");
    var Anos = anoActual - anoPic;
    var Meses = mesActual - mesPic;
    if (Meses > 0) {
        txtAnos.value = Anos;
        txtMeses.value = Meses;


    }
    else {
        if (Meses < 0) {
            txtAnos.value = Anos - 1;
            txtMeses.value = ((12 - Meses) + mesActual);

        }
        else {
            txtAnos.value = Anos;
            txtMeses.value = "0";

        }
    }

}

(function (global, undefined) {
    var demo = {};

    function OnClientFilesUploaded(sender, args) {
        $find(demo.ajaxManagerID).ajaxRequest();
    }

    function serverID(name, id) {
        demo[name] = id;
    }

    global.serverID = serverID;

    global.OnClientFilesUploaded = OnClientFilesUploaded;
})(window);