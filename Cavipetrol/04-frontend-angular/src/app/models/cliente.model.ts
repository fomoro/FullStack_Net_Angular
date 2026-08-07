export interface ClienteDto {
  idCliente: number;
  identificacion: string;
  nombre: string;
  apellido: string;
  email: string;
  fechaCreacion: string;
  fechaActualizacion?: string;
  genero?: string;
  fechaNacimiento?: string;
  estado: string;
  categoria: string;
}
