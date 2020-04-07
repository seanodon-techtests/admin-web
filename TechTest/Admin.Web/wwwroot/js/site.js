// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

addPerson = function () {
	var resetForm = function() {
		var form = document.getElementById("add-person-form");
		var inputs = form.getElementsByClassName("form-control");
		for (var i = 0; i < inputs.length; i++) {
			inputs[i].value = "";
		}
	};

	return {
		onSuccess: function () {
			feedback.showFeedback("Person successfully added!");
			resetForm();
		},
		onFailure: function () {
			feedback.showFeedback("An error occurred");
		}
	};
}();

feedback = function () {
	var timeout;

	var getFooter = function() {
		return document.getElementById("feedback-footer");
	}

	var hideFooter = function() {
		getFooter().classList.remove("show");
	};

	var scheduleHideFooter = function () {
		clearTimeout(timeout);
		timeout = setTimeout(hideFooter, 2000);
	};

	return {
		showFeedback: function(message) {
			var feedbackFooter = getFooter();
			feedbackFooter.getElementsByClassName("message")[0].innerText = message;
			feedbackFooter.classList.add("show");
			scheduleHideFooter();
		}
	}
}();