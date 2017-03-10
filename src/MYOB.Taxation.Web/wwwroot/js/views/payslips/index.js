(function ($) {
    $(function () {

        var _$form = $('#PayslipCreationForm');

        var _$employeeCombobox = $('#EmployeeCombobox');

        //_$taskStateCombobox.change(function () {
        //    location.href = '/Tasks?state=' + _$taskStateCombobox.val();
        //});

        //_$form.find('input:first').focus();

        _$form.validate();

        _$form.find('button[type=submit]')
            .click(function (e) {
                e.preventDefault();

                if (!_$form.valid()) {
                    return;
                }

                var input = {
                    id: _$employeeCombobox.val()
                };
                //var input = _$form.serializeFormToObject();
                //var num = Number(_$employeeCombobox.val());
                //abp.services.app.employeeTax.getPaySlipForWeb(input);
                abp.services.app.employeeTax.getPaySlipForWeb(input)
                   .done(function (data) {
                       $.post('/Payslips/Display',
                        data, function (result) {//add callback for success - result is the returned view
                            $("#payslipDiv").html(result);//place the view inside of the div
                        });
                   });                

            });
    });
})(jQuery);