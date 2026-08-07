export interface ApiResponse<T> {
  exito: boolean;
  mensaje: string;
  datos?: T;
  errores: string[];
  fechaUtc: string;
}
