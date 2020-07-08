export class ResponseModel<T> {
    IsSuccess: boolean;
    Data?: T;
    Message: string;
}
