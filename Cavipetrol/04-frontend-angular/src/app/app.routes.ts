import { Routes } from '@angular/router';
import { ClienteSearchComponent } from './components/cliente-search/cliente-search.component';

export const routes: Routes = [
  {
    path: '',
    component: ClienteSearchComponent,
    title: 'Consulta de Clientes - Cavipetrol'
  },
  {
    path: '**',
    redirectTo: ''
  }
];
