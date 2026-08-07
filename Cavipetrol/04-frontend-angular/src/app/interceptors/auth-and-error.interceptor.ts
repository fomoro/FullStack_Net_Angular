import { HttpInterceptorFn, HttpErrorResponse } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';

export const authAndErrorInterceptor: HttpInterceptorFn = (req, next) => {
  const token = localStorage.getItem('token');
  
  let authReq = req;
  if (token) {
    authReq = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
  }

  return next(authReq).pipe(
    catchError((error: HttpErrorResponse) => {
      let mensajeError = 'Ocurrió un error inesperado al comunicarse con el servidor.';
      
      if (error.status === 0) {
        mensajeError = 'No se pudo establecer conexión con el Backend .NET. Verifique que la API esté ejecutándose en http://localhost:5000.';
      } else if (error.status === 404 && error.error?.mensaje) {
        mensajeError = error.error.mensaje;
      } else if (error.error?.mensaje) {
        mensajeError = error.error.mensaje;
      }

      return throwError(() => new Error(mensajeError));
    })
  );
};
