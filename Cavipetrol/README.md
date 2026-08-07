# Sistema Gestor de Clientes (Cavipetrol)

**Arquitectura de Solución:** Executive Tech, Data-First & Hexagonal Clean Architecture  
**Autor:** Sr. Wolfan (Arquitecto de Soluciones Senior - Corbeta)  
**Asesor:** Asistente Senior de Arquitectura  

---

## 1. Estructura del Repositorio

| Carpeta / Componente | Descripción y Responsabilidad |
| :--- | :--- |
| **`01-database/`** | Modelo de datos Data-First (DBML, Script T-SQL, Stored Procedure `sp_ObtenerClientePorIdentificacion`). |
| **`02-poc-look-and-feel/`** | Prototipo visual *Apple Minimalist* (POC Cero-Instalación en HTML/JS/CSS). |
| **`03-backend-dotnet/`** | API REST Hexagonal en .NET 8 (`ApiClientes.sln`) con estrategia Dual Provider (`SqlServer` e `InMemory`). |
| **`04-frontend-angular/`** | Aplicación SPA en Angular 17 Standalone e Ionic UI (`ClienteSearchComponent`). |
| **`docs/`** | Centro de Documentación oficial, Hoja de Ruta, ADRs y Guías Rápidas de Operación. |

---

## 2. Centro de Documentación y Guías Rápidas (`docs/`)

- **[ARCHITECTURE_ROADMAP.md](file:///c:/Dev/TriposProyectosC%23/docs/ARCHITECTURE_ROADMAP.md):** Hoja de Ruta, Diagramas C4 Nivel 3 y Registro de Decisiones de Arquitectura (ADRs 000 a 007).
- **[GUIA_CONFIGURACION_INFRAESTRUCTURA.md](file:///c:/Dev/TriposProyectosC%23/docs/GUIA_CONFIGURACION_INFRAESTRUCTURA.md):** Pasos de arranque de BD, Backend y Frontend.
- **[GUIA_USO_API.md](file:///c:/Dev/TriposProyectosC%23/docs/GUIA_USO_API.md):** Guía de consumo REST con cURL, Swagger, PowerShell, Python y formato `ApiResponse<T>`.
- **[GUIA_USO_ANGULAR.md](file:///c:/Dev/TriposProyectosC%23/docs/GUIA_USO_ANGULAR.md):** Guía de instalación, ejecución y compilación de la SPA Angular Standalone.
- **[GUIA_FUNCIONAL_USUARIO.md](file:///c:/Dev/TriposProyectosC%23/docs/GUIA_FUNCIONAL_USUARIO.md):** Manual operativo para usuarios de negocio y analistas de atención al cliente.
- **[guia_librerias_python_pc_v2.md](file:///c:/Dev/TriposProyectosC%23/docs/guia_librerias_python_pc_v2.md):** Referencia rápida para scripts y automatizaciones Python.

---

## 3. Inicio Rápido Cero-Instalación

Para evaluar inmediatamente la interfaz móvil en cualquier navegador sin compilar ni instalar dependencias localmente:

```powershell
Invoke-Item 02-poc-look-and-feel/index.html
```
