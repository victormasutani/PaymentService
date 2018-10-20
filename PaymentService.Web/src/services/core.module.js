import routerHelperService from './router-helper/router-helper.service';
import paymentService from './payment/payment.service';

const coreModule = angular.module('app.core', [
	'ui.router'
]);

// inject services, config, filters and re-usable code
// which can be shared via all modules
coreModule.config(routerHelperService);

coreModule.service('paymentService', paymentService);

export default coreModule;
