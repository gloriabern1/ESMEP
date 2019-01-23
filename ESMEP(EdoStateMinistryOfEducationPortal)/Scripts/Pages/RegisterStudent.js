(function () {
    $(function () {
        getAllStudents();
        GetAllSubject();
    });

    function getAllStudents() {
        $.ajax({
            type: 'GET',
            url: `/api/StudentPersonalDatas/GetAllStudent`,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $('#student').empty();
                if (data.length != 0) {
                    var strTable = `<thead><tr><th>#.</th><th><input id="all" type="checkbox"></th><th>Full Name</th><th>Sex</th><th>Date Of Birth</th></tr></thead>`;
                    strTable += '<tbody>';
                    var i = 1;
                    $.each(data, function () {
                        var row = $(this)[0];
                        strTable += '<tr><td>' + i + '</td><td><input id="' + row["Id"] +'" type="checkbox" runat="server"></td><td>'  + row["FirstName"] + " " + row["LastName"] + '</td><td>' + row["Sex"] + '</td><td>' + row["DateOfBirth"] + '</td></tr>'
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

    function GetAllSubject() {
        $.ajax({
            type: 'GET',
            url: '/api/Subject/GetAllSubject',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                console.log(data);
                $('#subject').empty();
                if (data.length != 0) {
                    $.each(data, function (index, val) {
                        $('#subject').append('<option value="' + val.ID + '">' + val.Name + '</option>');
                    })
                } else {
                    $('#subject').append('<option value="">' + 'No Subject' + '</option>')
                }
            },
            failure: function () {
                console.log("Failed");
                var message = {
                    message: "Failed to load data... Try again later"
                };
                $('#Location').append('<option value="">' + message.message + '</option>')
            }
        })
    }


})()