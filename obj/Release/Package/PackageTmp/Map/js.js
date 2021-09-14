var mapMain;
// @formatter:off
require([
    "esri/map",
    "esri/geometry/Extent",
    "esri/layers/ArcGISDynamicMapServiceLayer",
    "esri/layers/FeatureLayer",
    "esri/dijit/BasemapGallery",
    "esri/dijit/Legend",
    "dojo/ready",
    "dojo/parser",
    "dojo/on",
    "dijit/layout/BorderContainer",
    "dijit/layout/ContentPane",
    "esri/dijit/Search"],
    function (Map, Extent, ArcGISDynamicMapServiceLayer, FeatureLayer, BasemapGallery, Legend,
        ready, parser, on,
        BorderContainer, ContentPane, Search) {
        // @formatter:on
        // Wait until DOM is ready *and* all outstanding require() calls have been resolved
        ready(function () {
            // Parse DOM nodes decorated with the data-dojo-type attribute
            parser.parse();

            // Create the map
            mapMain = new Map("cpCenter", {
                basemap: "topo",
                center: [-7.82, 33.52],
                zoom: 13,
                showAttribution:false
            });
            //creation de la couche du PA
            var PA = new ArcGISDynamicMapServiceLayer(
                "https://localhost:6443/arcgis/rest/services/Projet_ASP/PA_Casablanca/MapServer", {
                "opacity": 0.75
            });
            //creation de la couche des NRs
            var NR = new FeatureLayer("https://localhost:6443/arcgis/rest/services/Projet_ASP/NRs/FeatureServer/0");
            //ajout de la couche a la carte:
            mapMain.addLayers([PA,NR]);
            //ajout de la legende
            mapMain.on("layers-add-result", function () {
                var dijitLegend = new Legend({
                    map: mapMain,
                    arrangement: Legend.ALIGN_RIGHT
                }, "divLegend");
                dijitLegend.startup();
            });
            //ajout de la basemapGallery
            var basemapGallery = new BasemapGallery({
                showArcGISBasemaps: true,
                map: mapMain
            }, "basemapGallery");
            basemapGallery.startup();
            //ajout de la search
            
            var s = new Search({
                map: mapMain
            }, "search");


        });
    });