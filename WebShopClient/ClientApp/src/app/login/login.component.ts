import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { LoginService } from '../core/services/login-service';
import { Customer } from '../core/models/customer-model';
import { FormField, DataType } from '../core/models/core-models';

@Component({
    selector: 'app-home',
    templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {

    formGroup: FormGroup;
    dataType = DataType;

    fields = [
        <FormField>{
            name: 'firstName',
            maxLength: 100,
            dataType: 1,
            required: true
        },
        <FormField>{
            name: 'lastName',
            maxLength: 100,
            dataType: 1,
            required: true
        },
        <FormField>{
            name: 'username',
            maxLength: 20,
            dataType: 1,
            required: true
        },
        <FormField>{
            name: 'password',
            minLength: 3,
            dataType: 3,
            required: true
        }
    ];

    constructor(private loginService: LoginService) { }

    ngOnInit(): void {
        this.initForm();
    }

    update(): void {

        if (this.formGroup.valid) {

            let customer = <Customer>{};
            this.fields.forEach(field => {
                customer[field.name] = this.formGroup.get(field.name).value;
            });

            console.log(customer);
            this.loginService.registerCustomer(customer).subscribe(() => { console.log('added new customer') });
        }

    }

    private initForm() {
        this.formGroup = new FormGroup({});

        this.fields.forEach(field => {
            this.formGroup.addControl(field.name, new FormControl({ value: field.value ? field.value : null, validators: this.addControl(field) }));
        });

    }

    private addControl(field: FormField) {
        let validators = [];

        if (field.minValue)
            validators.push(Validators.min(field.minValue));
        if (field.maxValue)
            validators.push(Validators.min(field.maxValue));
        if (field.minLength)
            validators.push(Validators.minLength(field.minLength));
        if (field.maxLength)
            validators.push(Validators.maxLength(field.maxLength));
        if (field.required)
            validators.push(Validators.required);

        return validators;
    }
}