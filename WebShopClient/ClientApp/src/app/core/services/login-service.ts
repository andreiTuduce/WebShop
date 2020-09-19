import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Customer } from '../models/customer-model';

const baseURL = 'api/SampleData';

@Injectable()

export class LoginService {

  constructor(private httpClient: HttpClient) { }

  registerCustomer(customer: Customer) {
    return this.httpClient.post(baseURL + '/CreateCustomer', customer)
  }

}
