$(document).ready(function() {

    $('#createButtonId').click(function(e) {
        e.preventDefault();
        var ex = {};
        var Name = $("#ExerciseName").val();
        var Time = $("#DateTime").val();
        var Duration = $("#Duration").val();
        var error = $(".error");
       
        ex.ExerciseName = Name;
        ex.DateTime = Time;
        ex.Duration = Duration;
       
        if (Name == "")
        {
            error.html("Name Cannot be empty");
            return false;

        }
        else if (Time == 0)
        {
            error.html("Choose date cannot be empty");
            return false;
        }
        else if (Duration == 0)
        {
            error.html("Duration cannot be empty");
            return false;
        }
        else
        {
            $.ajax({
                url: 'Insert',
                type: 'POST',
                dataType: 'json',
                data: ex,
                success: function (data)
                {
                    if (data.Success === false)
                    {
                        alert(data.Message);
                       // alert("Server validation !!! Please enter valid data");

                    }
                   
                    else
                    {
                        console.log(data);
                        console.log('success');
                        $("#grid").data("kendoGrid").dataSource.data(data);
                        $("#newRecordId").hide();
                        $("#newRecordId").modal('hide');
                        console.log('finish hide');

                    }

                },
                error: function (e)
                {
                    
                    //called when there is an error
                    console.log(e.message);
                    alert(xhr.Message);
                }

            });

            // window.location.reload();
        }
    } ) ;
});

