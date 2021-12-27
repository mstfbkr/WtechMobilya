"use strict";
var KTDatatablesDataSourceAjaxServer = function () {


    var initTable1 = function () {
        var table = $('#kt_customers_table');
        // begin first table
        table.DataTable({
            responsive: true,
            searchDelay: 500,
            processing: true,
            serverSide: true,
            ajax: {
                url: 'https://localhost:44375/api/product/getall',
                type: 'POST',
               
            },
            data: {
                // parameters for custom backend script demo
                columnsDef: [
                    'productId', 'productName',
                    'productDescription', 'productPrice', 'creatingDate', 'updatedDate', 'isActived', 'Actions'],
            },
            columns: [
                { data: 'productId' },
                { data: 'productName' },
                { data: 'productDescription' },
                { data: 'productPrice' },                
                { data: 'creatingDate' },
                { data: 'updatedDate' },
                { data: 'isActived' },
                { data: null, responsivePriority: -1 },
            ],
            columnDefs: [
                {
                    targets: -1,
                    title: 'Actions',
                    orderable: false,
                    render: function (data, type, full, meta) {
                        return '\
                            <div class="dropdown dropdown-inline">\
                                <a href="javascript:;" class="btn btn-sm btn-clean btn-icon" data-toggle="dropdown">\
                                    <i class="la la-cog"></i>\
                                </a>\
                                  <div class="dropdown-menu dropdown-menu-sm dropdown-menu-right">\
                                    <ul class="nav nav-hoverable flex-column">\
                                        <li class="nav-item"><a class="nav-link" href="#"><i class="nav-icon la la-edit"></i><span class="nav-text">Edit Details</span></a></li>\
                                        <li class="nav-item"><a class="nav-link" href="#"><i class="nav-icon la la-leaf"></i><span class="nav-text">Update Status</span></a></li>\
                                        <li class="nav-item"><a class="nav-link" href="#"><i class="nav-icon la la-print"></i><span class="nav-text">Print</span></a></li>\
                                    </ul>\
                                  </div>\
                            </div>\
                            <a href="javascript:;" class="btn btn-sm btn-clean btn-icon" title="Edit details">\
                                <i class="la la-edit"></i>\
                            </a>\
                            <a href="javascript:;" class="btn btn-sm btn-clean btn-icon" title="Delete">\
                                <i class="la la-trash"></i>\
                            </a>\
                        ';
                    },
                },
                {
                    width: '75px',
                    targets: -3,
                    render: function (data, type, full, meta) {
                        var status = {
                            1: { 'title': 'Pending', 'class': 'label-light-primary' },
                            2: { 'title': 'Delivered', 'class': ' label-light-danger' },
                            3: { 'title': 'Canceled', 'class': ' label-light-primary' },
                            4: { 'title': 'Success', 'class': ' label-light-success' },
                            5: { 'title': 'Info', 'class': ' label-light-info' },
                            6: { 'title': 'Danger', 'class': ' label-light-danger' },
                            7: { 'title': 'Warning', 'class': ' label-light-warning' },
                        };
                        if (typeof status[data] === 'undefined') {
                            return data;
                        }
                        return '<span class="label label-lg font-weight-bold' + status[data].class + ' label-inline">' + status[data].title + '</span>';
                    },
                },
                {
                    width: '75px',
                    targets: -2,
                    render: function (data, type, full, meta) {
                        var status = {
                            1: { 'title': 'Online', 'state': 'danger' },
                            2: { 'title': 'Retail', 'state': 'primary' },
                            3: { 'title': 'Direct', 'state': 'success' },
                        };
                        if (typeof status[data] === 'undefined') {
                            return data;
                        }
                        return '<span class="label label-' + status[data].state + ' label-dot mr-2"></span>' +
                            '<span class="font-weight-bold text-' + status[data].state + '">' + status[data].title + '</span>';
                    },
                },
            ],
        });
    };


    return {


        //main function to initiate the module
        init: function () {
            initTable1();
        },


    };


}();


jQuery(document).ready(function () {
    KTDatatablesDataSourceAjaxServer.init();
});
















//$(document).ready(function () {
//    $.ajax({
//        'url': 'https://localhost:44362/api/product/getall',
//        'type': 'GET',
//        'dataType': 'json',

//        'success': function (response) {
//            if (response.results) {
//                var html = '';
//                for (var i = 0; i < response.results.length; i++) {
//                    html += '<table><thead class="thead-default"> <tr> <th>Reitur</th> <th>Gildi</th> </tr> </thead>';
//                    html += '<tr><td>Tegund</td><td>' + response.results[i].type + '</td></tr>';
//                    html += '<tr><td>Undirgerð</td><td>' + response.results[i].subType + '</td></tr>';
//                    html += '<tr><td>Litur</td><td>' + response.results[i].color + '</td></tr>';
//                    html += '<tr><td>Verksmiðjunúmer</td><td>' + response.results[i].factoryNumber + '</td></tr>';
//                    html += '<tr><td>Skráður</td><td>' + response.results[i].registeredAt + '</td></tr>';
//                    html += '<tr><td>Mengun</td><td>' + response.results[i].pollution + '</td></tr>';
//                    html += '<tr><td>Þyngd</td><td>' + response.results[i].weight + '</td></tr>';
//                    html += '<tr><td>Skoðunarstaða</td><td>' + response.results[i].status + '</td></tr>';
//                    html += '<tr><td>Næsta skoðun</td><td>' + response.results[i].nextCheck + '</td></tr>';
//                    html += '</table><p>&nbsp</p>';
//                }
//                $('#results').html(html);

//            }
//        }


//    });
//});





//$(document).ready(function () {
//    $.ajax({
//        'url': 'https://localhost:44375/api/product/getall',
//        'type': 'GET',
//        'dataType': 'json',        
//        'success': function (response) {
//            console.log(response);
//            console.log(response.productName);
//            console.log(response["productPrice"])

//            var deneme = response.getJSONObject("productName")
//            var deneme = response.getJSONObject(0).getString("productName");

//            document.getElementById('pronam').textContent = response.productName;
//        }        
//    });
//});





//const api_url = 'https://localhost:44375/api/category/getall' //buraya get linki koyulacak
//async function getproduct() {
//    const response = await fetch(api_url);
//    const data = await response.json();
   

//    console.log(data);
//    console.log(data.productName);


//    $(data).each(function (index) {

//        console.log(data[index].productName);
//        document.getElementById('pronam').innerHTML = data[index].productName;
//    });
//    console.log(data.response.productName);
    



//    document.getElementById('pronam').textContent = productId;
//    document.getElementById('pronam').innerHTML = myData.productName;
//    document.getElementById('propri').textContent = productPrice;
//    document.getElementById('pro').textContent = data;
//}
//getproduct();