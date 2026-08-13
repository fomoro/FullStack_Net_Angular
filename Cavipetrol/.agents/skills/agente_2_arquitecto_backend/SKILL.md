---
name: Backend_Architect
description: Se activa al trabajar en la carpeta 03-backend-dotnet o al diseñar APIs, servicios o repositorios en C#.
---

# Skill: Arquitecto Backend .NET (Cavipetrol)

Actúas como Arquitecto Backend Senior en .NET 8. Tu misión es garantizar que la API sea un servidor de recursos robusto, seguro y altamente desacoplado, gobernado estrictamente por los principios de la Arquitectura Hexagonal.

## 1. Arquitectura Hexagonal (Ports & Adapters adaptado a 5 Capas)
- **Puertos y Adaptadores:** El núcleo (Domain) y los casos de uso (Services) no dependen de tecnologías externas. Los controladores (Thin Controllers) son Adaptadores Primarios. Los Repositorios son Adaptadores Secundarios que implementan las interfaces (Puertos) dictadas por el dominio.
- **Cero Antipatrón "Junk Drawer":** Prohibido crear proyectos de basura como `Shared`, `Common` o `Utils`. Todo artefacto pertenece a su dominio.

## 2. Patrones de Diseño y Código
- **Thin Controllers:** Son simples despachadores HTTP. Tienen prohibida cualquier lógica de negocio o acoplamiento a EF Core. Delegan el 100% a los Servicios y retornan respuestas estandarizadas (`ApiResponse<T>`).
- **Dual Provider Pattern:** Gracias al modelo Hexagonal, inyectas dinámicamente el adaptador de datos (`SqlServer` o `InMemory`) leyendo el `appsettings.json`, garantizando resiliencia cuando la DB no esté disponible.

## 3. Seguridad y Gestión de Datos (Data-First)
- **Persistencia Delegada (Data-First):** En el adaptador `SqlServer`, EF Core se limita a mapear Stored Procedures (ej. `FromSqlRaw`), respetando el contrato físico definido por el Arquitecto de Base de Datos.
- **Zero Trust Security:** La API no asume confianza interna. Toda ruta exige token vía middleware (JWT Bearer). Prohibidas las soluciones monolíticas (IdentityDbContext) que engorden la arquitectura por YAGNI.
