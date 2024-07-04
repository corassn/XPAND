import { Injectable } from "@angular/core";
import { BaseApiService } from "./base-api.service";
import { AccountService as AccountApi, UserDto } from "../../../../openapi";
import { Observable, ReplaySubject, catchError, tap } from "rxjs";
import { Router } from "@angular/router";
import { User } from "../../auth/_interfaces/user.interface";
import { Login } from "../../auth/_interfaces/login.interface";

@Injectable({
    providedIn: 'root',
})
export class AuthService extends BaseApiService {
    private currentUserSource = new ReplaySubject<User | null>(1);
    public currentUser$: Observable<User | null> = this.currentUserSource.asObservable();

    constructor(private accountApi: AccountApi, private router: Router) {
        super();
    }

    login(login: Login): Observable<UserDto> {
        return this.accountApi.apiAccountLoginPost(login).pipe(
            catchError((error) => this.handleError(error)),
            tap(response => {
                localStorage.setItem('currentUser', JSON.stringify(response));
                localStorage.setItem('token', response.token || '');
                this.currentUserSource.next(response);
                this.router.navigate(['planets']);
            })
        );
    }

    logout(): void {
        localStorage.removeItem('currentUser');
        localStorage.removeItem('token');
        this.currentUserSource.next(null);
        this.router.navigate(['login']);
    }

    getCurrentUser(): any {
        const user = localStorage.getItem('currentUser');
        return user ? JSON.parse(user) : null;
    }

    getToken(): string | null {
        return localStorage.getItem('token');
    }

    isLoggedIn(): boolean {
        return !!this.getToken();
    }
}