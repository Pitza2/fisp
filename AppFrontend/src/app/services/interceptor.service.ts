import { Injectable } from '@angular/core'
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http'
import { Observable } from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class InterceptorService implements HttpInterceptor {

  intercept (req: HttpRequest<any>,
    next: HttpHandler): Observable<HttpEvent<any>> {
    const Token = localStorage.getItem('jwt')
    if (Token) {
      const cloned = req.clone({
        headers: req.headers.set('Authorization', 'Bearer ' + Token)
      })
      return next.handle(cloned)
    }else{
      return next.handle(req)
    }

  }
}
