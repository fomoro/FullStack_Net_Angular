# Guía rápida de uso de la API REST (.NET 8)

## 1. Acceso a Swagger UI (Documentación Interactiva)

Abrir en el navegador con la API en ejecución:
`http://localhost:5000/swagger`

## 2. Consultar Cliente por Número de Identificación

### Vía cURL (CMD / Bash)

```powershell
curl -X GET "http://localhost:5000/api/clientes/12345678" -H "accept: application/json"
```

### Vía PowerShell

```powershell
Invoke-RestMethod -Uri "http://localhost:5000/api/clientes/12345678" -Method Get
```

### Vía Python

```powershell
py -c "import requests; r=requests.get('http://localhost:5000/api/clientes/12345678'); print(r.json())"
```

## 3. Formato Estándar de Respuesta (`ApiResponse<T>`)

### Respuesta Exitosa (HTTP 200 OK)

```json
{
  "exito": true,
  "mensaje": "Cliente consultado exitosamente",
  "datos": {
    "idCliente": 1,
    "identificacion": "12345678",
    "nombre": "Carlos",
    "apellido": "Mendoza",
    "email": "carlos.mendoza@cavipetrol.com",
    "fechaCreacion": "2026-01-15T10:00:00Z",
    "genero": "M",
    "fechaNacimiento": "1985-04-12",
    "estado": "Activo",
    "categoria": "VIP"
  },
  "errores": [],
  "fechaUtc": "2026-08-07T21:00:00Z"
}
```

### Documento No Encontrado (HTTP 404 Not Found)

```json
{
  "exito": false,
  "mensaje": "No se encontró ningún cliente registrado con la identificación '99999999'",
  "datos": null,
  "errores": [],
  "fechaUtc": "2026-08-07T21:00:00Z"
}
```

## 4. Consumo con Token JWT (Seguridad Zero Trust)

Para enviar peticiones autenticadas agregando el encabezado `Authorization`:

```powershell
curl -X GET "http://localhost:5000/api/clientes/12345678" -H "Authorization: Bearer TuTokenJWTAqui"
```
