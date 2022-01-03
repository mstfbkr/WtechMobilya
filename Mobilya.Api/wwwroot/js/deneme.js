$(document).ready(function () {
    $("#customerDatatable").DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        },
        "ajax": {
            "url": "https://localhost:44375/api/product/GetAlldt",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "columns": [
            { "data": "productId", "name": "Product Id", "autoWidth": true },
            { "data": "productName", "name": "Product Name", "autoWidth": true },
           
            { "data": "productPrice", "name": "Product Price", "autoWidth": true },           
            { "data": "creatingDate", "name": "Creating Date", "autoWidth": true },
            { "data": "updatedDate", "name": "Updated Date", "autoWidth": true },
            { "data": "isActived", "name": "IsActived", "autoWidth": true },
            {
                "render": function (data, row) { return "<a href='https://localhost:44375/api/product/Delete' class='btn btn-danger' onclick=Delete('" + row.productId + "'); >Delete</a>"; }
            },
        ]
    });
});
function myFunction() {
    var popup = document.getElementById("myPopup");
    popup.classList.toggle("show");
}