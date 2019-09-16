var viz;

function onToolbarStateChange(toolbarEvent) {
    // when event occurs, get state and update custom buttons
    var toolbarState = toolbarEvent.getToolbarState();
    updateToolbarState(toolbarState)
}

function updateToolbarState(toolbarState) {
    $('#undoButton').prop('disable', !toolbarState.isButtonEnabled(tableau.ToolbarButtonName.UNDO));
    $('#redoButton').prop('disable', !toolbarState.isButtonEnabled(tableau.ToolbarButtonName.REDO));
}


function redo() {
    viz.redoAsync().then(function (t) {
        console.log("redo");
    });
}

function undo() {
    viz.undoAsync().then(function (t) {
        console.log("undo");
    });
}

function TableroScoring() {
    var containerDiv = document.getElementById("vizContainer"),
    url = "http://asboppmp01:8000/#/site/GobiernoIT/views/ScoringProveedoresv01_02_Blanco/ScoringdeProveedores",

    options = {
        hideTabs: true,
        hideToolbar: true,
        onFirstInteractive: function () {
                 // Listen for toolbar events
            viz.addEventListener(tableau.TableauEventName.TOOLBAR_STATE_CHANGE, onToolbarStateChange);
        }
    };
       viz = new tableau.Viz(containerDiv, url, options);
}

function TableroDetalleScoring() {
    var containerDiv = document.getElementById("vizContainer"),
    url = "http://asboppmp01:8000/#/site/GobiernoIT/views/ScoringProveedoresv01_02_Blanco/DetalledeScoring",

    options = {
        hideTabs: true,
        hideToolbar: true,
        onFirstInteractive: function () {
            // Listen for toolbar events
            viz.addEventListener(tableau.TableauEventName.TOOLBAR_STATE_CHANGE, onToolbarStateChange);
        }
    };
    viz = new tableau.Viz(containerDiv, url, options);
}

function TableroMGDP() {
    var containerDiv = document.getElementById("vizContainer"),
    url = "http://asboppmp01:8000/#/site/GobiernoIT/views/MGDP/INDICEMGDP",

    options = {
        hideTabs: false,
        hideToolbar: true,
        onFirstInteractive: function () {
            // Listen for toolbar events
            viz.addEventListener(tableau.TableauEventName.TOOLBAR_STATE_CHANGE, onToolbarStateChange);
        }
    };
    viz = new tableau.Viz(containerDiv, url, options);
}

