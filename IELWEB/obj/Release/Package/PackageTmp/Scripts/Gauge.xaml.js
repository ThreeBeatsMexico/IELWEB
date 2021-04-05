if (!window.Gauge)
	Gauge = {};

Gauge.Page = function() 
{
}

Gauge.Page.prototype =
{
    handleLoad: function(control, userContext, rootElement) {
        this.control = control;
  
         if (SKIN!="NO"){
             loadjsfile("temas/" + SKIN + ".js");
         } 
  
        inicializa();
        redimencionaGauge(DIMENSION);
        var interval = setInterval(FUNCION, INTERVALO);
    }  
}
