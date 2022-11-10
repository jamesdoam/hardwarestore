var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#productTable').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "price", "width": "15%" },
            { "data": "sku", "width": "15%" },
            { "data": "imageUrl", "width": "15%" },
        ]
    });
}