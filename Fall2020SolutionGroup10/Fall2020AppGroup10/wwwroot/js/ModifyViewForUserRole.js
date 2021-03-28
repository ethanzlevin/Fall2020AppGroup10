$(document).ready(

    function () {
        $('#numberOfHoursWorkedGroup').hide();

        $('#userRole').change(

            function () {

                var userRole = $('#userRole').val();

                if (userRole == "Employee") {
                    $('#numberOfVolunteerHoursGroup').show();
                }
                else {
                    $('#numberOfVolunteerHoursGroup').hide();
                }

            }

        );
    }
);