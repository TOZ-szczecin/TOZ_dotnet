﻿// Write your Javascript code.
$(document).ready( function() {
    	$(document).on('change', '.btn-file :file', function() {
		var input = $(this),
			label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
		input.trigger('fileselect', [label]);
		});

		$('.btn-file :file').on('fileselect', function(event, label) {
		    
		    var input = $(this).parents('.input-group').find(':text'),
		        log = label;
		    
		    if( input.length ) {
		        input.val(log);
		    } else {
		        if( log ) alert(log);
		    }
	    
		});
		function readURL(input) {
		    if (input.files && input.files[0]) {
		        var reader = new FileReader();
		        
		        reader.onload = function (e) {
		            $('#img-upload').attr('src', e.target.result);
		        }
		        
		        reader.readAsDataURL(input.files[0]);
		    }
		}

		$("#imgInp").change(function(){
		    readURL(this);
        }); 

        jQuery.validator.setDefaults({
            highlight: function (element, errorClass, validClass) {
                if (element.type === 'radio') {
                    this.findByName(element.name).addClass(errorClass).removeClass(validClass);
                } else {
                    $(element).addClass(errorClass).removeClass(validClass);
                    $(element).closest('.form-group').removeClass('has-success').addClass('has-error');
                    $(element).closest('.form-control-feedback').removeClass('glyphicon-ok').addClass('glyphicon-remove');
                    $(element).nextAll('.glyphicon').removeClass('hidden');
                    $(element).nextAll('.glyphicon').removeClass('glyphicon-ok').addClass('glyphicon-remove');
                    $(element).nextAll('.glyphicon').removeClass('has-success').addClass('has-error');
                }
            },
            unhighlight: function (element, errorClass, validClass) {
                if (element.type === 'radio') {
                    this.findByName(element.name).removeClass(errorClass).addClass(validClass);
                } else {
                    $(element).removeClass(errorClass).addClass(validClass);
                    $(element).closest('.form-group').removeClass('has-error').addClass('has-success');
                    $(element).nextAll('.glyphicon').removeClass('hidden');
                    $(element).nextAll('.glyphicon').removeClass('glyphicon-remove').addClass('glyphicon-ok');
                    $(element).nextAll('.glyphicon').removeClass('has-error').addClass('has-success');
                }
            }
        });

        $(function () {

            $("span.field-validation-valid, span.field-validation-error").addClass('help-block');
            $("div.form-group").has("span.field-validation-error").addClass('has-error');
            $("div.validation-summary-errors").has("li:visible").addClass("alert");

        });
	});