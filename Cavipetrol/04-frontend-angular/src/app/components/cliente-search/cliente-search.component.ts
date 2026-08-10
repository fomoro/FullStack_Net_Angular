import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {
  IonContent,
  IonHeader,
  IonIcon,
  IonSpinner,
  IonToolbar
} from '@ionic/angular/standalone';
import { addIcons } from 'ionicons';
import {
  alertCircleOutline,
  barChartOutline,
  bookOutline,
  checkmarkCircleOutline,
  eyeOutline,
  femaleOutline,
  flashOutline,
  informationCircleOutline,
  layersOutline,
  maleOutline,
  peopleOutline,
  personAddOutline,
  personCircleOutline,
  personRemoveOutline,
  phonePortraitOutline,
  pieChartOutline,
  refreshOutline,
  searchOutline,
  trendingUpOutline,
  warningOutline
} from 'ionicons/icons';
import { ClienteDto } from '../../models/cliente.model';
import { ClienteService } from '../../services/cliente.service';

type TabClientes = 'busqueda' | 'analitica' | 'directorio';

interface ResumenAnalitico {
  total: number;
  activos: number;
  inactivos: number;
  enValidacion: number;
  hombres: number;
  mujeres: number;
  porcentajeActivos: number;
  porcentajeHombres: number;
  porcentajeMujeres: number;
}

interface AlturasEstado {
  activos: number;
  inactivos: number;
  enValidacion: number;
}

const ANALITICA_VACIA: ResumenAnalitico = {
  total: 0,
  activos: 0,
  inactivos: 0,
  enValidacion: 0,
  hombres: 0,
  mujeres: 0,
  porcentajeActivos: 0,
  porcentajeHombres: 0,
  porcentajeMujeres: 0
};

@Component({
  selector: 'app-cliente-search',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    IonContent,
    IonHeader,
    IonIcon,
    IonSpinner,
    IonToolbar
  ],
  templateUrl: './cliente-search.component.html',
  styleUrls: ['./cliente-search.component.css']
})
export class ClienteSearchComponent implements OnInit {
  private readonly clienteService = inject(ClienteService);

  tabActiva: TabClientes = 'busqueda';
  identificacion = '';
  identificacionConsultada = '';
  cliente: ClienteDto | null = null;
  clientes: ClienteDto[] = [];
  readonly registrosPorPagina = 10;
  paginaActual = 1;
  analitica: ResumenAnalitico = { ...ANALITICA_VACIA };
  alturasEstado: AlturasEstado = { activos: 0, inactivos: 0, enValidacion: 0 };
  donutBackground = 'conic-gradient(#0071e3 0 50%, #af52de 50% 100%)';
  cargando = false;
  cargandoDirectorio = true;
  errorMensaje = '';
  errorDirectorio = '';

  constructor() {
    addIcons({
      alertCircleOutline,
      barChartOutline,
      bookOutline,
      checkmarkCircleOutline,
      eyeOutline,
      femaleOutline,
      flashOutline,
      informationCircleOutline,
      layersOutline,
      maleOutline,
      peopleOutline,
      personAddOutline,
      personCircleOutline,
      personRemoveOutline,
      phonePortraitOutline,
      pieChartOutline,
      refreshOutline,
      searchOutline,
      trendingUpOutline,
      warningOutline
    });
  }

  ngOnInit(): void {
    this.cargarDirectorio();
  }

  get totalPaginas(): number {
    return Math.ceil(this.clientes.length / this.registrosPorPagina);
  }

  get paginasDisponibles(): number[] {
    return Array.from({ length: this.totalPaginas }, (_, indice) => indice + 1);
  }

  get clientesPaginados(): ClienteDto[] {
    const inicio = (this.paginaActual - 1) * this.registrosPorPagina;
    return this.clientes.slice(inicio, inicio + this.registrosPorPagina);
  }

  get primerRegistroVisible(): number {
    return this.clientes.length === 0 ? 0 : (this.paginaActual - 1) * this.registrosPorPagina + 1;
  }

  get ultimoRegistroVisible(): number {
    return Math.min(this.paginaActual * this.registrosPorPagina, this.clientes.length);
  }

  cambiarTab(tab: TabClientes): void {
    this.tabActiva = tab;
  }

  cambiarPagina(pagina: number): void {
    if (pagina < 1 || pagina > this.totalPaginas || pagina === this.paginaActual) {
      return;
    }

    this.paginaActual = pagina;
  }

  buscarDemo(identificacion: string): void {
    this.identificacion = identificacion;
    this.tabActiva = 'busqueda';
    this.buscarCliente();
  }

  buscarCliente(): void {
    const identificacion = this.identificacion.trim();

    if (!identificacion) {
      this.errorMensaje = 'Por favor ingrese un número de identificación válido.';
      this.identificacionConsultada = '';
      this.cliente = null;
      return;
    }

    this.prepararBusqueda(identificacion);

    this.clienteService.obtenerPorIdentificacion(identificacion).subscribe({
      next: (response) => this.procesarRespuestaBusqueda(response.exito, response.datos, response.mensaje),
      error: (error: Error) => {
        this.cargando = false;
        this.errorMensaje = error.message;
      }
    });
  }

  seleccionarDelDirectorio(identificacion: string): void {
    this.buscarDemo(identificacion);
  }

  limpiar(): void {
    this.identificacion = '';
    this.identificacionConsultada = '';
    this.cliente = null;
    this.errorMensaje = '';
  }

  private cargarDirectorio(): void {
    this.clienteService.obtenerTodos().subscribe({
      next: (response) => {
        this.cargandoDirectorio = false;
        this.clientes = response.datos ?? [];
        this.paginaActual = 1;
        this.actualizarAnalitica(this.clientes);
      },
      error: (error: Error) => {
        this.cargandoDirectorio = false;
        this.errorDirectorio = error.message;
        this.actualizarAnalitica([]);
      }
    });
  }

  private prepararBusqueda(identificacion: string): void {
    this.identificacion = identificacion;
    this.identificacionConsultada = identificacion;
    this.cargando = true;
    this.errorMensaje = '';
    this.cliente = null;
  }

  private procesarRespuestaBusqueda(exito: boolean, datos: ClienteDto | undefined, mensaje: string): void {
    this.cargando = false;

    if (exito && datos) {
      this.cliente = datos;
      return;
    }

    this.errorMensaje = mensaje || 'No se encontraron datos del cliente.';
  }

  private actualizarAnalitica(clientes: ClienteDto[]): void {
    const total = clientes.length;
    const activos = clientes.filter(cliente => cliente.estado.toLowerCase() === 'activo').length;
    const inactivos = clientes.filter(cliente => cliente.estado.toLowerCase() === 'inactivo').length;
    const enValidacion = clientes.filter(cliente => cliente.estado.toLowerCase() === 'validación').length;
    const hombres = clientes.filter(cliente => cliente.genero === 'M').length;
    const mujeres = clientes.filter(cliente => cliente.genero === 'F').length;

    this.analitica = {
      total,
      activos,
      inactivos,
      enValidacion,
      hombres,
      mujeres,
      porcentajeActivos: this.calcularPorcentaje(activos, total),
      porcentajeHombres: this.calcularPorcentaje(hombres, total),
      porcentajeMujeres: this.calcularPorcentaje(mujeres, total)
    };

    this.actualizarGraficas();
  }

  private actualizarGraficas(): void {
    const maximoEstado = Math.max(
      this.analitica.activos,
      this.analitica.inactivos,
      this.analitica.enValidacion,
      1
    );

    this.alturasEstado = {
      activos: this.calcularAltura(this.analitica.activos, maximoEstado),
      inactivos: this.calcularAltura(this.analitica.inactivos, maximoEstado),
      enValidacion: this.calcularAltura(this.analitica.enValidacion, maximoEstado)
    };

    const hombres = this.analitica.porcentajeHombres;
    this.donutBackground = `conic-gradient(#0071e3 0 ${hombres}%, #af52de ${hombres}% 100%)`;
  }

  private calcularPorcentaje(cantidad: number, total: number): number {
    return total === 0 ? 0 : cantidad * 100 / total;
  }

  private calcularAltura(cantidad: number, maximo: number): number {
    return cantidad === 0 ? 0 : Math.max(8, cantidad * 96 / maximo);
  }
}
