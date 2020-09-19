"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var baseURL = 'api/SampleData';
var LoginService = /** @class */ (function () {
    function LoginService(httpClient) {
        this.httpClient = httpClient;
    }
    LoginService.prototype.registerCustomer = function (customer) {
        return this.httpClient.post(baseURL + 'CreateCustomer', customer);
    };
    return LoginService;
}());
exports.LoginService = LoginService;
//# sourceMappingURL=login-service.js.map