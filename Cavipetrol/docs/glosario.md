# GLOSARIO ARQUITECTÓNICO (Defensa del Proyecto)

Tabla de conceptos avanzados para la defensa técnica del proyecto. *Formato ejecutivo, directo y sin carreta.*

| Término | Categoría | Qué es (Definición Técnica) | Por qué usarlo (Argumento de Defensa) |
| :--- | :--- | :--- | :--- |
| **Thin Controller** | Backend .NET | Controlador HTTP sin lógica de negocio ni de base de datos. Solo delega peticiones a la capa de Servicios. | Hace que las reglas de negocio sean 100% testeables, limpias y reutilizables en cualquier entorno. |
| **Dual Provider Pattern** | Arquitectura | Habilidad de inyectar dinámicamente la fuente de datos (`SqlServer` o `InMemory`) leyendo la configuración. | Da autonomía total. Si la BD falla o no está lista, la API levanta en memoria y nadie bloquea su trabajo. |
| **Zero Trust Security** | Seguridad | Arquitectura que asume que ninguna red es segura; exige token JWT validado en cada petición al API. | Previene ataques laterales y evita arrastrar el "sobrepeso" de soluciones monolíticas de identidad anticuadas. |
| **Standalone Components** | Frontend (Angular) | Arquitectura moderna de Angular 14+ que elimina los `NgModules`. Cada componente gestiona sus propias dependencias. | Reduce drásticamente el código basura (*boilerplate*), acelera la app y moderniza la base de código. |
| **Arquitectura Hexagonal** | Arquitectura | Separación que aísla el núcleo (reglas) del exterior (BD, UI) usando Puertos (interfaces) y Adaptadores. | Protege la inversión: permite cambiar de base de datos mañana sin reescribir la lógica de negocio. |
| **Junk Drawer** | Antipatrón (Evitado) | La mala práctica de crear carpetas llamadas `Shared` o `Utils` donde se tira código suelto sin cohesión. | En este proyecto se prohíbe para evitar el "código espagueti" y obligar a una agrupación limpia por módulos. |
| **Apple Minimalist** | UI / UX | Diseño estético limpio con fondos neutros (`#f5f5f7`) y superficies translúcidas (*Glassmorphism*). | Rompe la mediocridad del software interno entregando una experiencia visual premium e hiper-moderna. |
| **0% Scroll Global** | UI / UX | Patrón móvil donde la vista principal se restringe a `100vh`. Solo áreas específicas hacen scroll interno. | Da la sensación táctil de una App nativa instalada (tipo iOS), eliminando los rebotes torpes de la web tradicional. |
