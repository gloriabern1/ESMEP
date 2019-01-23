(function () {

    $(function () {
        getAllSchools();
    });


    function getAllSchools() {
        $.ajax({
            type: 'GET',
            url: `/api/StudentPersonalDatas/GetAllStudent`,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $('#student').empty();
                if (data.length != 0) {
                    var strTable = '<thead><tr><th>#.</th><th>Full Name</th><th>Address</th><th>Date Of Birth</th><th>Sex</th><th>School</th><th>Action</th></tr></thead>';
                    strTable += '<tbody>';
                    var i = 1;
                    console.log(data);
                    $.each(data, function () {
                        var row = $(this)[0];
                        strTable += '<tr><td>' + i + '</td><td>' + row["FirstName"] + " " + row["LastName"] + '</td><td>' + row["Address"] + '</td><td>' + row["DateOfBirth"] + '</td><td>' + row["Sex"] + '</td><td>' + row["School.Name"] + '</td><td><a class="btn btn-warning" href="RegisterStudent?id='+ row["StudentId"]+ '&idx= '+ row["SchoolId"] +'">Register</a></td></tr>'
                        i++;
                    });
                    strTable += '</tbody>';
                    $('#student').html(strTable)
                } else {
                    $('#student')
                }
            },
            failure: function () {
                console.log("Failed");
                var message = {
                    message: "Failed to load data... Try again later"
                };
                $('#student').append('<tr>' + message.message + '</tr>')
            }
        })
    }



})()

