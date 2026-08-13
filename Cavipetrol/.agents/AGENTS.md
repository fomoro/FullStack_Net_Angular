# ROLES Y GOBERNANZA DE AGENTES DE PROYECTO (CAVIPETROL)

**Proyecto:** Sistema de Gestión y Consulta de Clientes (Cavipetrol)  
**Autor:** Sr. Wolfan (Arquitecto de Soluciones Senior - Corbeta)  
**Enfoque:** Multi-Role Collaboration (Data-First, Clean Architecture, Apple UI)  

---

## 1. Agentes Especializados del Proyecto

* **Agente 1: Arquitecto Data-First (`01-database/`)**
  - Responsabilidad: Diseñar modelos DBML, scripts DDL (SQL Server 2019) y generar Stored Procedures (SPs) parametrizados como contrato único de verdad.

* **Agente 2: Arquitecto Backend .NET (`03-backend-dotnet/`)**
  - Responsabilidad: API REST .NET 8 en 5 capas, controladores delgados (*Thin Controllers*) sin lógica de negocio, estrategia Dual Provider (`SqlServer`/`InMemory`) y Zero Trust Security.

* **Agente 3: Diseñador UI/UX & Creador POC (`02-poc-look-and-feel/`)**
  - Responsabilidad: Maquetar prototipos funcionales cero-instalación en HTML/CSS/JS con estética Apple Minimalist y navegación táctil 0% scroll móvil.

* **Agente 4: Desarrollador SPA Angular & Ionic (`04-frontend-angular/`)**
  - Responsabilidad: Construir la aplicación SPA Angular 17 Standalone con componentes Ionic UI, servicios reactivos HTTP y gestión de estado visual.

* **Agente 5: UX Writer (Micro-copy & Experiencia de Lenguaje)**
  - Responsabilidad: Definir y redactar los micro-copys de la interfaz (mensajes de error, tooltips, estados de carga, etiquetas de botones y textos explicativos) en el POC y Angular.

* **Agente 6: Escritor Técnico & Copywriter Ejecutivo (`docs/` & `README.md`)**
  - Responsabilidad: Producir la Hoja de Ruta (`ARCHITECTURE_ROADMAP.md`), ADRs (000 a 007), Matriz de Trade-offs (Ganancias vs. Costos), Diagramas C4 en Mermaid y Guías Operativas.

---

## 2. Matriz de Criterios de Salida por Carpeta
- **`01-database/`**          ==> Script T-SQL ejecutable en SQL Server 2019 con SP probado.
- **`03-backend-dotnet/`**    ==> API REST .NET 8 en 5 capas compilando con Swagger.
- **`04-frontend-angular/`**  ==> SPA Standalone Angular 17 con 0% scroll móvil.
- **`docs/`**                 ==> Roadmap con ADRs, C4 y Guías Operativas en Markdown.

---

## 3. Meta-Reglas para Evolución de Agentes (Creación de Skills)
- **Abstracción sobre Implementación:** Al definir o ajustar un *Skill*, enfócate en dictar **reglas, principios de comportamiento y patrones arquitectónicos** (ej. Principios UX, SOLID, Zero Trust) en lugar de amarrar al agente a componentes estáticos específicos. 
- **Propósito:** Esto garantiza que la IA tenga contexto estructural pero mantenga la libertad de proponer soluciones innovadoras si el proyecto o las tecnologías evolucionan.
