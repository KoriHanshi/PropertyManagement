'use strict';


//Validation
(function ($) {
	$.fn.validate = function () {

		function validateForm(form) {
			var valid = true;

			$('input, select, textarea', form).
				filter(function (i, e) {
					return $(e).hasClass('form-control');
				}).each(function () {
					valid = validateField(this) && valid;
					console.log(valid);
				});

			return valid;
		};

		function validateField(element) {
			var valid;

			var $element = $(element);
			var $parent = $($element.parent());
			var required = $element.data('required');

			function display(valid, message) {
				$('.validation-message, .form-control-feedback', $parent).remove();
				return (valid) ? displaySuccess(message) : displayError(message);
			};
			
			function displaySuccess(message) {
				$parent.removeClass('has-error').addClass('has-success').addClass('has-feedback');
				$parent.append('<span class="glyphicon glyphicon-ok form-control-feedback"></span>');
				$('.help-block', $parent).remove();
				return true;
			};
			
			function displayError(message) {
				$parent.removeClass('has-success').addClass('has-error').addClass('has-feedback');
				$parent.append('<span class="glyphicon glyphicon-remove form-control-feedback"></span>');
				($('.help-block', $parent).length > 0) ? null : $parent.append('<span class="help-block">' + message + '</span>');
				return false;
			};

			function label($element) {
				return $('label', $element.closest('.form-group')).html();
			}

			function validateText($element) {
				var valid = ($element.val() !== undefined && $element.val() !== null && $element.val().trim() !== '');
				return display(valid, label($element) + ' is required');
			}

			function validateSelect($element) {
				var valid = ($element.val() !== undefined && $element.val() !== null && $('option:selected', $element).text().trim() !== '');
				return display(valid, label($element) + ' is required');
			};

			switch ($element.prop('tagName')) {
				case 'INPUT':
					switch ($element.prop('type')) {
						case 'text':
							valid = required ? validateText($element) : true;
							break;
						case 'email':
							valid = required ? validateText($element) : true; //temp
							break;
						case 'date':
							valid = required ? validateText($element) : true; //temp
							break;
						case 'time':
							valid = required ? validateText($element) : true; //temp
							break;
						case 'tel':
							valid = required ? validateText($element) : true; //temp
							break;
						case 'password':
							valid = required ? validateText($element) : true; //temp
							break;
						case 'number':
							valid = required ? validateText($element) : true; //temp
							break;
						case 'currency':
							valid = required ? validateText($element) : true; //temp
							break;
					}
					break;
				case 'TEXTAREA':
					valid = required ? validateText($element) : true;
					break;
				case 'SELECT':
					valid = required ? validateSelect($element) : true;
					break;
			};

			return valid; 
		};

		return ($(this).prop('tagName') === 'FORM') ? validateForm(this) : validateField(this);
	};
	$.registerValidation = function () {

		//register validation on form submission
		$('form').each(function () {
			$(this).on('submit', function (e) {
				($(this).validate()) ? null : e.preventDefault();
			});
		});

		//register validation on field blur
		$('input, select, textarea').
			filter(function (i, e) {
				return $(e).hasClass('form-control');
			}).each(function () {
				$(this).on('blur', function () {
					$(this).validate();
				});
			});

	};
}(jQuery));

// Navigation
(function ($) {
	$.fn.navigate = function () {
		
		var data = $(this).data();

		function value(v) {
			return ($.isNumeric(v)) ? v : '"' + v + '"';
		};

		function action(a) {
			return (a && a !== '' && a !== 'Index') ? '/' + a : '';
		}

		function parameters(data) {

			var queryStringVariables = [];

			$(Object.keys(data).filter(function (p) { return p.indexOf('param') === 0; })).each(function () {

				queryStringVariables.push(this.replace('param', '') + '=' + value(data[this]));

			});

			return (queryStringVariables.length > 0) ? '?' + queryStringVariables.join('&') : '';

		};

		(data['controller'] && data['controller'] !== '') ?
			window.location.href = '/' + data['controller'] + action(data['action']) + parameters(data) :
			console.error('Navigation Failed! - Invalid URL');
	};
	$.registerNavigation = function () {
		$('.table-row').each(function () {
			$(this).click(function () {
				$(this).navigate();
			});
		});
	};
}(jQuery));


// Ready Page
$(document).ready(function () {
	$.registerValidation();
	$.registerNavigation();
});




























