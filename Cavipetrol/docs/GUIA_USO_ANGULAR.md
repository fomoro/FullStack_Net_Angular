# Guía rápida de uso de la aplicación Angular (Standalone + Ionic)

## 1. Requisitos Previos

Tener instalado Node.js (v18+) y npm:

```powershell
node -v
npm -v
```

## 2. Instalar Dependencias y Levantar la Aplicación

Abrir la terminal en la carpeta del frontend:

```powershell
cd 04-frontend-angular
npm install
npm start
```

Abrir la SPA responsiva en el navegador:
`http://localhost:4200`

## 3. Uso de las Pestañas de la Aplicación

### Pestaña Búsqueda 360°
1. Ingrese el número de cédula en la barra de búsqueda (Ej: `12345678`, `10987654` o `11223344`).
2. Presione la tecla **Enter** o el botón **Buscar**.
3. Visualice la **Ficha 360° del Cliente** (Categoría VIP/Frecuente/Estándar, Estado Activo, Datos de contacto y Registro BD).
4. Para evaluar la tarjeta de error (404 Not Found), ingrese un documento no registrado (Ej: `99999999`).

### Pestaña Analítica
- Visualice las métricas demográficas globales (Total de registros, 100% cuentas activas y gráfico de distribución por género Masculino/Femenino).

### Pestaña Directorio
- Explore la lista general de clientes y haga clic en el botón de ojo (**Ver Ficha**) para saltar automáticamente al buscador y cargar el cliente seleccionado.

## 4. Cambiar la URL de la API REST Backend

Para apuntar a otro entorno (Servidor Dev / Staging / Prod), modifique la propiedad `apiUrl` en `src/environments/environment.ts`:

```typescript
export const environment = {
  production: false,
  apiUrl: 'http://localhost:5000/api'
};
```

## 5. Compilar para Producción

Generar el paquete estático optimizado para despliegue en IIS, Nginx o CDN:

```powershell
ng build --configuration production
```

Los artefactos listos para producción quedarán alojados en `dist/frontend-angular-cavipetrol/`.
