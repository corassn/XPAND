import { HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

export abstract class BaseApiService {
  handleError(error: HttpErrorResponse): Observable<never> {
    console.error(error);
    return throwError(() => new Error(error.error ?? 'An unknown error occurred'));
  }
}
