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
            "datatype": "json", 
            cache: false//cachelemeyi önlemek için yazdık 
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
                "render": function (data, row) {
                    return "<a href='#' class='btn btn-danger' onclick=DeleteProduct('"+ data.productId + "'); >Delete</a>";
                    //return "<a href='#' class='btn btn-danger' onclick=DeleteProduct('" + row.productId + "'); >Delete</a>";
                   //return '<a href="#" onclick="DeleteProduct(' + data.productId + ')" class="buttons edit-button"></a> '
                   //return "<a class='btn btn-default btn-sm' onclick=PopupForm('@Url.Action("DeleteProduct")/" + data + "')><i class='fa fa-pencil'></i> Edit</a><a onclick=Delete(" + data + ")><i class='fa fa-trash'></i> Delete</a>"

                }
                
            },
            
        ]
    });
});
var deletedata;
function DeleteProduct(deletedata) {
    console.log(JSON.stringify(deletedata));
    console.log(J(deletedata));
   
}



var today = new Date();
var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
var dateTime = date + ' ' + time;
console.log(dateTime);


var today = new Date();
var dd = String(today.getDate()).padStart(2, '0');
var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
var yyyy = today.getFullYear();

today = mm + '/' + dd + '/' + yyyy;
console.log(today);







//$('#customerDatatable tbody').on('click', '.editRow', function () {
//    event.preventDefault();
//    var id = $(this).attr("id").match(/\d+/)[0];
//    var data = $('#customerDatatable').DataTable().row(this).data();
//    console.log(data[0]); //should show the Name data
//    console.log(data[1]); //should show the Age data
//});