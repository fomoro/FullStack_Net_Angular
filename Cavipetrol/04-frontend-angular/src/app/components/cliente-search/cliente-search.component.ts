import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import {
  IonHeader,
  IonToolbar,
  IonTitle,
  IonContent,
  IonSearchbar,
  IonCard,
  IonCardHeader,
  IonCardSubtitle,
  IonCardTitle,
  IonCardContent,
  IonBadge,
  IonSpinner,
  IonButton,
  IonIcon,
  IonItem,
  IonLabel,
  IonList,
  IonNote,
  IonTabBar,
  IonTabButton
} from '@ionic/angular/standalone';
import { addIcons } from 'ionicons';
import {
  searchOutline,
  personOutline,
  mailOutline,
  calendarOutline,
  idCardOutline,
  alertCircleOutline,
  checkmarkCircleOutline,
  pieChartOutline,
  bookOutline,
  eyeOutline,
  arrowBackOutline,
  statsChartOutline
} from 'ionicons/icons';
import { ClienteService } from '../../services/cliente.service';
import { ClienteDto } from '../../models/cliente.model';

@Component({
  selector: 'app-cliente-search',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    IonHeader,
    IonToolbar,
    IonTitle,
    IonContent,
    IonSearchbar,
    IonCard,
    IonCardHeader,
    IonCardSubtitle,
    IonCardTitle,
    IonCardContent,
    IonBadge,
    IonSpinner,
    IonButton,
    IonIcon,
    IonItem,
    IonLabel,
    IonList,
    IonNote,
    IonTabBar,
    IonTabButton
  ],
  templateUrl: './cliente-search.component.html',
  styleUrls: ['./cliente-search.component.css']
})
export class ClienteSearchComponent {
  private clienteService = inject(ClienteService);

  tabActiva: 'busqueda' | 'analitica' | 'directorio' = 'busqueda';

  identificacion: string = '';
  cliente: ClienteDto | null = null;
  cargando: boolean = false;
  errorMensaje: string = '';
  busquedaRealizada: boolean = false;

  // Datos para vista de Directorio General
  directorioSeed = [
    { identificacion: '12345678', nombre: 'Carlos Mendoza', email: 'carlos.mendoza@cavipetrol.com', estado: 'Activo', categoria: 'VIP' },
    { identificacion: '10987654', nombre: 'María Fernanda Gómez', email: 'maria.gomez@cavipetrol.com', estado: 'Activo', categoria: 'Frecuente' },
    { identificacion: '11223344', nombre: 'Juan Pablo Martínez', email: 'juan.martinez@cavipetrol.com', estado: 'Activo', categoria: 'Estándar' }
  ];

  constructor() {
    addIcons({
      searchOutline,
      personOutline,
      mailOutline,
      calendarOutline,
      idCardOutline,
      alertCircleOutline,
      checkmarkCircleOutline,
      pieChartOutline,
      bookOutline,
      eyeOutline,
      arrowBackOutline,
      statsChartOutline
    });
  }

  cambiarTab(tab: 'busqueda' | 'analitica' | 'directorio'): void {
    this.tabActiva = tab;
  }

  buscarCliente(): void {
    if (!this.identificacion || this.identificacion.trim() === '') {
      this.errorMensaje = 'Por favor ingrese un número de identificación válido.';
      this.cliente = null;
      return;
    }

    this.cargando = true;
    this.errorMensaje = '';
    this.cliente = null;
    this.busquedaRealizada = true;

    this.clienteService.obtenerPorIdentificacion(this.identificacion.trim()).subscribe({
      next: (response) => {
        this.cargando = false;
        if (response.exito && response.datos) {
          this.cliente = response.datos;
        } else {
          this.errorMensaje = response.mensaje || 'No se encontraron datos del cliente.';
        }
      },
      error: (err: Error) => {
        this.cargando = false;
        this.errorMensaje = err.message;
      }
    });
  }

  seleccionarDelDirectorio(id: string): void {
    this.identificacion = id;
    this.tabActiva = 'busqueda';
    this.buscarCliente();
  }

  limpiar(): void {
    this.identificacion = '';
    this.cliente = null;
    this.errorMensaje = '';
    this.busquedaRealizada = false;
  }
}
