var mapMain;
var widgetEditor;

// @formatter:off
require([
    "esri/map",

    "dojo/ready",
    "dojo/parser",
    "dojo/on",
    "dojo/_base/array",

    "dijit/layout/BorderContainer",
    "dijit/layout/ContentPane", "esri/layers/FeatureLayer", "esri/config",
    "esri/dijit/editing/Editor", "esri/tasks/GeometryService", "esri/dijit/editing/TemplatePicker"
],
    function (Map,
        ready, parser, on, array,
        BorderContainer, ContentPane, FeatureLayer, config, Editor, GeometryService, TemplatePicker) {
        // @formatter:on

        // Wait until DOM is ready *and* all outstanding require() calls have been resolved
        ready(function () {

            // Parse DOM nodes decorated with the data-dojo-type attribute
            parser.parse();

            /*
             * Step: Specify the proxy Url
             */
            config.defaults.io.proxyUrl = "http://localhost/proxy/proxy.ashx";

            // Create the map
            mapMain = new Map("divMap", {
                basemap: "topo",
                center: [-7.82, 33.52],
                zoom: 13
            });

            var flFirePoints, flFireLines, flFirePolygons;
            /*
             * Step: Construct the editable layers
             */
            /*flFirePoints = new FeatureLayer("http://sampleserver6.arcgisonline.com/arcgis/rest/services/Wildfire/FeatureServer/0", {
                outFields: ['*']
            });

            flFireLines = new FeatureLayer("http://sampleserver6.arcgisonline.com/arcgis/rest/services/Wildfire/FeatureServer/1", {
                outFields: ['*']
            });

            flFirePolygons = new FeatureLayer("http://sampleserver6.arcgisonline.com/arcgis/rest/services/Wildfire/FeatureServer/2", {
                outFields: ['*']
            });*/
            var F1 = new FeatureLayer("https://localhost:6443/arcgis/rest/services/Projet_ASP/NRs/FeatureServer/0", {
                outFields: ["Reference_", "Prenom","Societe"]
            });






            // Listen for the editable layers to finish loading
            mapMain.on("layers-add-result", initEditor);

            // add the editable layers to the map
            mapMain.addLayers([F1]);

            function initEditor(results) {
                // Map the event results into an array of layerInfo objects
                var layerInfosWildfire = array.map(results.layers, function (result) {
                    return {
                        featureLayer: result.layer
                    };
                });


                /*
                 * Step: Map the event results into an array of Layer objects
                 */
                /*var layersWildfire = array.map(results.layers, function (result) {
                    return result.layer;
                });*/









                /*
                 * Step: Add a custom TemplatePicker widget
                 */
                /*var tpCustom = new TemplatePicker({ featureLayers: layersWildfire, columns: 2 },
                    'divLeft');
                tpCustom.startup();*/





                /*
                 * Step: Prepare the Editor widget settings
                 */
                var editorSettings = {
                    map: mapMain,
                    geometryService: "http://sampleserver6.arcgisonline.com/arcgis/rest/services/Utilities/Geometry/GeometryServer",
                    layerInfos: layerInfosWildfire,
                    toolbarVisible: true,
                    createOptions: { polygonDrawTools: [Editor.CREATE_TOOL_FREEHAND_POLYGON] },
                    toolbarOptions: { reshapeVisible: true },
                    enableUndoRedo: true
                };



                /*
                 * Step: Build the Editor constructor's first parameter
                 */
                var editorParams = {
                    settings: editorSettings
                };





                /*
                 * Step: Construct the Editor widget
                 */
                var editorWidget = new Editor(editorParams, 'divLeft');
                editorWidget.startup();



            };
        });

    });
