﻿var config = {
    grid: {
        name: 'grid',
        url: '/DocumentoTipos/GetAllRecords',
        method: 'GET',
        show: {
            //header: true,  // indicates if header is visible
            toolbar: true,  // indicates if toolbar is visible
            footer: true,  // indicates if footer is visible
            lineNumbers: true,  // indicates if line numbers column is visible
            toolbarAdd: true,
            toolbarDelete: true,
            toolbarSave: true,
            toolbarEdit: true
        },
        multiSort: true,
        //toolbar: {
        //    items: [
        //        { type: 'button', id: 'w2ui-add', text: 'Añadir nuevo/a', icon: 'w2ui-icon-plus', tooltip: 'Añadir nuevo registro' },
        //        { type: 'button', id: 'w2ui-edit', text: 'Editar', icon: 'w2ui-icon-pencil', tooltip: 'Editar registro(s) seleccionado(s)' },
        //        { type: 'button', id: 'w2ui-delete', text: 'Eliminar', icon: 'w2ui-icon-cross', tooltip: 'Eliminar registro(s) seleccionado(s)' },
        //        { type: 'break' },
        //        { type: 'button', id: 'w2ui-details', text: 'Detalles', icon: 'w2ui-icon-info', tooltip: 'Detalles del registro(s) seleccionado(s)', disabled: true }
        //    ],
        //    onClick: function (target, data) {
        //        if (target == 'w2ui-details') {
        //            data.onComplete = function () {
        //                var selections = w2ui.grid.getSelection();
        //                var record = w2ui.grid.get(selections[0]);

        //                w2ui['detail'].clear();
        //                w2ui['detail'].add([
        //                    { recid: 0, name: 'Descripción:', value: record.description }
        //                ]);

        //                detail();
        //            }
        //        }
        //    }
        //},
        searches: [
            { field: 'descripcion', text: 'Descripción', type: 'text' }
        ],
        sortData: [{ field: 'descripcion', direction: 'DESC' }],
        columns: [
            { field: 'id', text: 'Id', sortable: true, resizable: true },
            { field: 'descripcion', text: 'Descripción', sortable: true, resizable: true }
        ],

        onClick: function (target, data) {
            if (target == 'w2ui-details') {
                data.onComplete = function () {
                    var selections = w2ui.grid.getSelection();
                    var record = w2ui.grid.get(selections[0]);

                    w2ui['detail'].clear();
                    w2ui['detail'].add([
                        { recid: 0, name: 'Descripción:', value: record.description }
                    ]);

                    detail();
                }
            }
        },
        onSelect: function (event) {
            var grid = this;
            event.onComplete = function () {
                //check if a record is selected.
                if (grid.get(grid.getSelection()[0]) !== null) {
                    w2ui['grid'].toolbar.enable('w2ui-details');
                }
            }
        },
        onUnselect: function (event) {
            event.onComplete = function () {
                w2ui['grid'].toolbar.disable('w2ui-details');
            }
        },
        onAdd: function (event) {
            event.onComplete = function () {
                openPopup(0, false);
            }
        },
        onEdit: function (event) {
            console.log(event);
            event.onComplete = function () {
                var record = this.get(event.recid);
                var editMode = true;

                if (record != null) {
                    openPopup(record.id, editMode);
                }
            }
        },
        onDelete: function (target, data) {
            data.preventDefault();

            $().w2popup({
                width: 400,
                height: 180,
                showMax: false,
                title: 'Eliminar registro(s)',
                body: '<div class="w2ui-grid-delete-msg w2ui-centered">¿Desea eliminar el(los) registro(s)?</div>',
                buttons: '<button class="w2ui-btn" onclick="w2popup.close();">Cancelar</button>' +
                    '<button class="w2ui-btn" onclick="deleteRecord(); w2popup.close();">Eliminar</button>'
            });
        }
    }
};

var detailGrid = {
    grid: {
        header: 'Detalles',
        show: { header: true, columnHeaders: false },
        name: 'detail',
        columns: [
            { field: 'name', caption: 'Nombre', size: '150px', style: 'background-color: #efefef; border-bottom: 1px solid white; padding-right: 5px;', attr: "align=right" },
            { field: 'value', caption: 'Valor', size: '100%' }
        ]
    }
};

function refreshGrid(auto) {
    w2ui.grid.autoLoad = auto;
    w2ui.grid.skip(0);
}

// init
$(function () {
    $('#documentoTipoGrid').w2grid(config.grid);
    $().w2grid(detailGrid.grid);
});

function deleteRecord() {

    var grid = w2ui['grid'];

    var selection = grid.getSelection();

    if (selection.length) {
        var selectedId = grid.get(selection[0]);
        console.log(selectedId.id);

        if (selectedId.id > 0) {
            $.ajax({
                type: 'POST',
                url: '/DocumentoTipos/Delete/' + selectedId.id,
                async: true
            }).done(function (e) {
                w2ui.grid.remove(selectedId.id);
                w2ui['grid'].reload();
            });
        }
    }
}