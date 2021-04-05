/*****No cambies estos valores! ******************/

var C_POSICION_CERO = 146.081;
var C_INCREMENTO_DIFERENCIA = 24.4503;
var POSICIONANTERIOR = 0;
var C_PORCENTAJE_INICIAL = 0;
//Seleccion del SKIN
var MODELOXAML = "GaugeHector.xaml";
var SKIN = "NO"; //"NO" para no seleccionar Skin - NOTA: LA Versiones GaugetV2x no necesitan Skins, es decir, se ven más cool sin Skin (por ahora)
var FUNCION = "";
var INTERVALO = 2000;
//Es cuadrado (en pixeles), tomando en cuenta que el valor original es 218(en el XAML) , jugamos con las transformaciones
var DIMENSION = 50;
var DIMENSIONORIGINAL = 68;
var DIVGAUGE = "DivGauge";
//Corresponde al ID del Gauget
var IDGAUGE = "MiGauge";
var plugin;

//Deja en cero el Gaudget , se llama desde Gauge.xaml.js
function inicializa() {
    plugin = document.getElementById(IDGAUGE);
    plugin.content.findName("texto").Text = C_PORCENTAJE_INICIAL + '%';
    var rotateTransform = plugin.content.findName("angulo");
    rotateTransform.Angle = C_POSICION_CERO;
}

//Solo para Ejemplo
function aleatorio() {
    numPosibilidades = 100 - 0
    aleat = Math.random() * numPosibilidades
    aleat = Math.round(aleat)
    return parseInt(0) + aleat
}
function generaAnimacion(valor) {
    plugin.content.findName("texto").Text = valor + "%";
    var animacion = plugin.content.findName("animacion");
    var inicio = plugin.content.findName("inicio");
    if (POSICIONANTERIOR == 0) {
        inicio.Value = C_POSICION_CERO;
    } else {
        inicio.Value = POSICIONANTERIOR;
    }
    var fin = plugin.content.findName("fin");
    var cal = calculoAngulo(valor);
    fin.Value = cal;
    POSICIONANTERIOR = cal;
    animacion.Begin()
}

function calculoAngulo(valor) {
    return C_POSICION_CERO + (C_INCREMENTO_DIFERENCIA * (valor / 10));
}

function redimencionaGauge(DIMENSION) {
    var zoom = plugin.content.findName("zoom");
    zoom.ScaleX = (((100 * DIMENSION) / DIMENSIONORIGINAL) / 100); ;
    zoom.ScaleY = zoom.ScaleX;
}

function dibujarGauge2(p) {
    FUNCION = "generaAnimacion(" + p + ")";
    dibujarGauge();
}

function dibujarGauge() {
    var scene = new Gauge.Page();
    Silverlight.createObjectEx({
        source: MODELOXAML,
        parentElement: document.getElementById(DIVGAUGE),
        id: IDGAUGE,
        properties: {
            width: "100%",
            height: "100%",
            version: "1.0"
        },
        events: {
            onLoad: Silverlight.createDelegate(scene, scene.handleLoad),
            onError: function(sender, args) {
                var errorDiv = document.getElementById("errorLocation");
                if (errorDiv != null) {
                    var errorText = args.errorType + "- " + args.errorMessage;

                    if (args.ErrorType == "ParserError") {
                        errorText += "<br>File: " + args.xamlFile;
                        errorText += ", line " + args.lineNumber;
                        errorText += " character " + args.charPosition;
                    }
                    else if (args.ErrorType == "RuntimeError") {
                        errorText += "<br>line " + args.lineNumber;
                        errorText += " character " + args.charPosition;
                    }
                    errorDiv.innerHTML = errorText;

                }
            }
        }
    });

}

if (!window.Silverlight)
    Silverlight = {};

Silverlight.createDelegate = function(instance, method) {
    return function() {
        return method.apply(instance, arguments);
    }
}

function loadjsfile(filename) {
    var fileref = document.createElement('script')
    fileref.setAttribute("type", "text/javascript")
    fileref.setAttribute("src", filename)
    if (typeof fileref != "undefined")
        document.getElementsByTagName("head")[0].appendChild(fileref)
}


