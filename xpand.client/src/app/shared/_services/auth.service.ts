import { Injectable } from "@angular/core";
import { BaseApiService } from "./base-api.service";
import { AccountService as AccountApi, UserDto } from "../../../../openapi";
import { Observable, catchError } from "rxjs";
import { LoginDto } from '../../../../openapi/model/login-dto';

@Injectable({
    providedIn: 'root',
})
export class AuthService extends BaseApiService {
    constructor(private accountApi: AccountApi) {
        super();
    }

    login(login: LoginDto): Observable<UserDto> {
        return this.accountApi.apiAccountLoginPost(login).pipe(catchError((error) => this.handleError(error)));
    }
}