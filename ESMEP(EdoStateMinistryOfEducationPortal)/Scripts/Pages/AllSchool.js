(function() {

    $(function () {
        getAllSchools();
    })

    function getAllSchools() {
        $.ajax({
            type: 'GET',
            url: `/api/School/GetAllSchool`,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $('#school').empty();
                if (data.length != 0) {
                    var strTable = '<thead><tr><th>#.</th><th>School Name</th><th>Phone</th><th>Email</th><th>Starting Date</th><th>Principal</th><th>No of Student</th></tr></thead>';
                    strTable += '<tbody>';
                    var i = 1;
                    $.each(data, function () {
                        var row = $(this)[0];
                        strTable += '<tr><td>' + i + '</td><td>' + row["Name"] + '</td><td>' + row["MobileNo"] + '</td><td>' + row["Email"] + '</td><td>' + row["DateOfIncorporation"] + '</td><td>' + row["NameOfPrincipal"] + '</td><td>'+ row[""] +'</td></tr>'
                        i++;
                    });
                    strTable += '</tbody>';
                    $('#school').html(strTable)
                } else {
                    $('#school')
                }
            },
            failure: function () {
                console.log("Failed");
                var message = {
                    message: "Failed to load data... Try again later"
                };
                $('#school').append('<tr>' + message.message + '</tr>')
            }
        })
    }



})()

