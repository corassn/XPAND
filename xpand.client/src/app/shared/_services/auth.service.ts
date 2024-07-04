import { Injectable } from "@angular/core";
import { BaseApiService } from "./base-api.service";
import { AccountService as AccountApi } from "../../../../openapi";
import { BehaviorSubject, Observable, ReplaySubject, catchError, tap } from "rxjs";
import { Router } from "@angular/router";
import { User } from "../../auth/_interfaces/user.interface";
import { Login } from "../../auth/_interfaces/login.interface";

@Injectable({
    providedIn: 'root',
})
export class AuthService extends BaseApiService {
    private currentUserSource: BehaviorSubject<User | null>;
    public currentUser$: Observable<User | null>;

    constructor(private accountApi: AccountApi, private router: Router) {
        super();
        const user = localStorage.getItem('currentUser');
        this.currentUserSource = new BehaviorSubject<User | null>(user ? JSON.parse(user) : null);
        this.currentUser$ = this.currentUserSource.asObservable();
    }

    public get currentUserValue(): User | null {
        return this.currentUserSource.value;
    }

    login(login: Login): Observable<User> {
        return this.accountApi.apiAccountLoginPost(login).pipe(
            tap(response => {
                localStorage.setItem('currentUser', JSON.stringify(response));
                localStorage.setItem('token', response.token || '');
                this.currentUserSource.next(response);
                this.router.navigate(['planets']);
            }),
            catchError((error) => this.handleError(error))
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
}