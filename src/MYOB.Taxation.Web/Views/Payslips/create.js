(function ($) {
    $(function () {

        var _$form = $('#PayslipCreationForm');

        //_$form.find('input:first').focus();

        _$form.validate();

        _$form.find('button[type=submit]')
            .click(function (e) {
                e.preventDefault();

                if (!_$form.valid()) {
                    return;
                }

                var input = _$form.serializeFormToObject();
                abp.services.app.employeeTax.create(input, Date.now)
                    .done(function () {
                        location.href = '/Payslips';
                    });
            });
    });
})(jQuery);