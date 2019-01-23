(function () {
    window.DataTable = null;
        function initializeTable(name) {
            DataTable = name.DataTable({
                colReorder: {
                    realtime: false
                },
                dom: 'Bfrtip',
                buttons: [
                    //'copy', 'csv', 'excel', 'pdf', 'print'
                    {
                        extend: 'print',
                        key: {
                            key: 'p',
                            altKey: true
                        }
                    },
                    'copyHtml5',
                    'excelHtml5',
                    'csvHtml5',
                    'pdfHtml5',
                    //'print'
                ]
            });
        };

    //function initializeTable(name) {
    //    name.DataTable({
    //        dom: 'Bfrtip',
    //        buttons: [
    //            {
    //                extend: 'csv',
    //                exportOptions: {
    //                    title: "Download",
    //                    exportOptions: {
    //                        columns: /*`:not(${name.find('td:last-child, th:last-child')})`,*/
    //                        ":not(.not-export-column)"
    //                    }
    //                }

    //            }
    //        ]
    //    })
    //}








    window.onload = function () {
        //console.log($('#tblGeneral'))
        initializeTable($('#tblGeneral'));
    }
})();






//(function () {
//    function initializeTable(name) {
//    name.DataTable({
//        colReorder: {
//            realtime: false
//        },
//        dom: 'Bfrtip',
//        buttons: [
//            {
//                extend: ['print','copy', 'csv', 'excel', 'pdf'],
//                exportOptions: {
//                    columns: ':visible'
//                },
//                customize: function (win) {
//                    $()
//                    $(win.document.body).find('table').find('td:last-child, th:last-child').remove();
//                }
//            }
//            //'copy', 'csv', 'excel', 'pdf', 'print'
//            ,'colvis'
//        ],
//         columnDefs: [{
//            targets: -1,
//            visible: false
//        }]
//    });
//}

//})();