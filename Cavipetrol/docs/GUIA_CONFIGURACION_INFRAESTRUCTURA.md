# Guía rápida de configuración de infraestructura (.NET / SQL Server / Angular)

## 1. Preparar la Base de Datos (SQL Server)

Ejecutar el script T-SQL en SQL Server 2019+ para crear la base de datos `DBClientes`, la tabla `dbo.Clientes` y el Stored Procedure `dbo.sp_ObtenerClientePorIdentificacion`:

```powershell
sqlcmd -S localhost -U sa -P "TuPasswordSuperSeguro2026" -i 01-database/script_dbclientes.sql
```

## 2. Configurar e Iniciar el Backend (.NET 8 Web API)

Restaurar dependencias y ejecutar la API REST Hexagonal (por defecto inicia con proveedor Fake `InMemory` sin requerir SQL Server local):

```powershell
cd 03-backend-dotnet
dotnet restore ApiClientes.sln
dotnet run --project ApiClientes.API/ApiClientes.API.csproj
```

Probar el endpoint de consulta por número de identificación (en otra ventana de terminal):

```powershell
curl -X GET "http://localhost:5000/api/clientes/12345678" -H "accept: application/json"
```

## 3. Configurar e Iniciar el Frontend (Angular 17 + Ionic)

Instalar dependencias y levantar el servidor de desarrollo en modo Standalone:

```powershell
cd 04-frontend-angular
npm install
npm start
```

Abrir la SPA responsiva en el navegador:
`http://localhost:4200`

## 4. Ejecución Cero-Instalación (Visualización Instantánea)

Para evaluar el prototipo móvil *Apple Minimalist* sin instalar `npm` ni configurar SQL Server:

```powershell
Invoke-Item 02-poc-look-and-feel/index.html
```

## 5. Validación General de la Solución

Comprobar la integración del Backend desde la línea de comandos:

```powershell
py -c "import urllib.request, json; r=urllib.request.urlopen('http://localhost:5000/api/clientes/12345678'); d=json.loads(r.read()); print('API .NET OK:', d['datos']['nombre'], d['datos']['categoria'])"
```
