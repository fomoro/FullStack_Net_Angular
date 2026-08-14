# Roles y gobernanza de agentes de proyecto (Cavipetrol)

**Proyecto:** Sistema de Gestión y Consulta de Clientes (Cavipetrol)
**Autor:** Sr. Wolfan (Arquitecto de Soluciones Senior - Corbeta)
**Enfoque:** Multi-Role Collaboration (Data-First, Clean Architecture, Apple UI)

---

## 1. Propósito y alcance

Este archivo define la gobernanza local del proyecto Cavipetrol: agentes especializados, responsabilidades, skills aplicables y criterios de salida por carpeta.

Sus reglas aplican al proyecto y a las carpetas bajo su alcance. Las reglas globales del asistente continúan vigentes salvo cuando este archivo establezca una instrucción local más específica.

---

## 2. Precedencia y gobernanza local

La gobernanza local complementa las reglas globales y prevalece únicamente cuando define una instrucción más específica para este proyecto o una de sus carpetas.

Al trabajar sobre una carpeta:

1. Identificar el agente responsable según este archivo.
2. Aplicar sus responsabilidades y criterios de salida.
3. Consultar en `.agents/skills/` únicamente las skills relevantes para la tarea.
4. Mantener las reglas globales que no entren en conflicto con la gobernanza local.

Ante solapamiento entre agentes, priorizar el más específico al contexto de la tarea.

---

## 3. Agentes especializados del proyecto

* **Agente 1: Arquitecto Data-First (`01-database/`)**

  * Responsabilidad: Diseñar modelos DBML, scripts DDL (SQL Server 2019) y Stored Procedures parametrizados como contrato único de verdad.

* **Agente 2: Diseñador UI/UX & Creador POC (`02-poc-look-and-feel/`)**

  * Responsabilidad: Maquetar prototipos funcionales cero-instalación en HTML/CSS/JS con estética Apple Minimalist y navegación táctil 0% scroll móvil.

* **Agente 3: Arquitecto Backend .NET (`03-backend-dotnet/`)**

  * Responsabilidad: API REST .NET 8 en 5 capas, controladores delgados (*Thin Controllers*) sin lógica de negocio, estrategia Dual Provider (`SqlServer`/`InMemory`) y Zero Trust Security.

* **Agente 4: Desarrollador SPA Angular & Ionic (`04-frontend-angular/`)**

  * Responsabilidad: Construir la aplicación SPA Angular 17 Standalone con componentes Ionic UI, servicios reactivos HTTP y gestión de estado visual.

* **Agente 5: UX Writer (transversal)**

  * Responsabilidad: Definir micro-copys, errores, tooltips, estados, etiquetas y textos explicativos para POC y Angular.

* **Agente 6: Escritor Técnico & Copywriter Ejecutivo (`docs/` & `README.md`)**

  * Responsabilidad: Producir Roadmap, ADRs, matriz de trade-offs, diagramas C4 en Mermaid y guías operativas.

---

## 4. Skills y especialización

`.agents/skills/` contiene las habilidades especializadas disponibles para el proyecto.

Los agentes utilizan únicamente las skills relevantes para la tarea y la carpeta activa. Las skills complementan esta gobernanza y no reemplazan las responsabilidades ni los criterios de salida definidos en este archivo.

No se inventan skills, reglas o comportamientos que no estén definidos en la gobernanza global, este archivo o las skills disponibles.

---

## 5. Criterios de salida por carpeta

* **`01-database/`** → Script T-SQL ejecutable en SQL Server 2019 con SP probado.
* **`02-poc-look-and-feel/`** → POC funcional HTML/CSS/JS, navegable y validable sin instalación.
* **`03-backend-dotnet/`** → API REST .NET 8 en 5 capas compilando con Swagger.
* **`04-frontend-angular/`** → SPA Standalone Angular 17 con 0% scroll móvil.
* **`docs/`** → Roadmap con ADRs, C4 y guías operativas en Markdown.

Los entregables transversales deben cumplir adicionalmente las responsabilidades del agente especializado que participe en su construcción.

---

## 6. Meta-reglas para evolución de agentes y skills

* **Abstracción sobre implementación:** Al definir o ajustar una skill, priorizar reglas, principios de comportamiento y patrones arquitectónicos sobre componentes estáticos específicos.

* **Especialización progresiva:** Incorporar una regla en una skill cuando sea específica, reutilizable y suficientemente estable; evitar trasladar detalles circunstanciales del proyecto.

* **Propósito:** Mantener contexto estructural suficiente sin limitar innecesariamente la capacidad de adaptar soluciones cuando cambien requisitos o tecnologías.
