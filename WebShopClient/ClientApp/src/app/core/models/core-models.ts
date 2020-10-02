export interface FormField {
    name: string;
    dataType: DataType;
    value?: any;
    minValue?: any;
    maxValue?: any;
    minLength?: number;
    maxLength?: number;
    required?: boolean
}

export enum DataType {
    none = 0,
    text = 1,
    number = 2,
    password = 3
}