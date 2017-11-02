// Validation

'use strict';

//var validate = {};

//// overall
//validate.form = function () {

//	var valid = true;

//	for (var i = 0; i < arguments.length; i++) {
//		valid = arguments[i] && valid;
//	}

//	return valid;
//};

//// utility
//validate.util = {};

//validate.util.inputHasValue = function ($field) {

//	var val = ($field.length > 0) ? $field.val() : null;

//	return (val != undefined && val != null & val.trim() != '');
//};





//validate.text = function ($field, message) {
//	var valid = this.util.inputHasValue($field);
//	return this.util.errorDisplay(valid, message);
//};

//Validation
(function ($) {
	$.fn.validate = function () {

		function validateForm(scope) {
			var valid = true;

			$('input, select, textarea', scope).each(function () {
				valid = validateField(this) && valid;
			});

			return valid;
		};

		function validateField(element) {

			var $element = $(element);
			var $parent = $($element.parent());

			function display(valid, message) {
				$('.validation-message, .form-control-feedback', $parent).remove();
				return (valid) ? displaySuccess(message) : displayError(message);
			};
			
			function displaySuccess(message) {
				$parent.removeClass('has-error').addClass('has-success');
				$parent.append('<span class="glyphicon glyphicon-ok form-control-feedback"></span>');
				return true;
			};

			function displayError(message) {
				$parent.removeClass('has-success').addClass('has-error');
				$parent.append('<span class="glyphicon glyphicon-remove form-control-feedback"></span>');
				$parent.append('<span class="validation-message">' + message + '</span>');
				return false;
			};

			function validateSelect($element) {
				var valid = ($element.val() != undefined && $element.val() != null && $('option:selected', $element).text().trim() != '');
				return display(valid, label($element) + ' is required');
			};

			switch (element.tag) {
				case 'input', 'textarea':
					switch ($element.prop('type')) {
						case 'text':
							validateText($element) // need to only run if class exists (always do this, use select for reference...)
							break;
						case 'email':
							break;
						case 'date':
							break;
						case 'phone':
							break;
						case 'password':
							break;
						case 'number':
							break;
						case 'currency':
							break;
					}
					break;
				case 'select':
					($element.hasClass('form-control-required')) ? validateSelect($element) : null;
					break;
			};

		};

		
		return (this.tag == 'form' || this.tag == 'div') ? validateForm(this) : validateField(this);
	};
}(jQuery));




























