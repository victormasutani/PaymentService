export default class PaymentService {
	constructor(
		$http
	) {
		'ngInject';

		this.$http = $http;
	}

	processPayment = (data) => {
		return this.$http.post('https://localhost:44341/api/Payments/processPayment', data || {})
		.then(function successCallback(response) {
				return response;
			}, function errorCallback(response) {
			console.log(response);
			return response;
		});
	};
}
