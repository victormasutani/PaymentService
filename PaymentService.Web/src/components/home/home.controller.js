export default class HomeController {
	constructor(paymentService) {
		'ngInject';

		this.paymentService = paymentService;
	}

	processPayment = () => {
		this.paymentService.processPayment(this.payment).then((response) => {
			if(response.status == 200)
				alert("Success!");
			else if(response.status == 400)
				alert(response.data.join("\n"));
			else
				alert(response.data);
		});
	};
}
