(function () {

    window.tableobjext = null;

    function getAllInspector() {
        $.ajax({
            type: 'GET',
            url: `api/Inspector/AllInspector`,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.length != 0) {
                    var i = 1;
                    if (tableobjext != null) {
                        tableobjext.clear();
                    }
                    $.each(response, function () {
                        var row = $(this)[0];
                        var cie = row["Name"];
                        if (cie === "No Inspector Assigned") {
                            var btn = `<a href="/CreateInspector.aspx" class="btn btn-primary pull-right" >Add Inspector</a >`;
                        } else {
                            var btn = `<a href="/ViewInspector.aspx" class="btn btn-default pull-right"">View</a >`;
                        };
                        UpdateRow(i, row["Name"], row["LocalGovtName"], btn)
                        i++;
                    });

                }
                 else {
                    $('#tblGeneral').append('<tr>' + 'No Local Government' + '</tr>')
                }
            },
            failure: function () {
                console.log("Failed");
                var message = {
                    message: "Failed to load data... Try again later"
                };
                $('#tblGeneral').append('<tr>' + message.message + '</tr>')
            }

        })
    }


    function UpdateRow(sn, name, LGA, Button) {
        tableobjext.row.add([
            sn,
            name,
            LGA,
            Button
        ]).draw();
    }

    function getDataTableObject() {
        tableobjext = $('#tblGeneral').DataTable({
            retrieve: true,
            paging: false
        });
    }

    $(document).ready(function () {
        getAllInspector();
    })

})();