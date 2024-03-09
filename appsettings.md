Es un archivo JSON que contiene configuraciones de la aplicacion. En este archivo se pueden guardar configuraciones como connection strings, configuraciones de la aplicacion mismo, logging, y cualquier otra cosa que uno quiera cambiar sin la necesidad de recompilar la aplicacion.

Las configuraciones en este archivo pueden ser leidas en tiempo de ejecucion y sobrescritas por las configuraciones especificas del ambiente en el cual se corre. En un ambiente de desarrollo se usan los valores de `appsettings.Development.json` y en un ambiente de produccion se usarian los valores de `appsettings.Production.json`.

`Appsettings.json` define las variables que se deben configurar y los valores se deben poner en extensiones segun el ambiente de este archivo.

Es importante no guardar informacion sensible en estos archivos, como contraseñas o secret keys. Para esta informacion se debera usar una forma segura de alojamiento como variables de ambiente.

Asi como los `appsettings.{environment}.json` sobrescriben los valores posibles encontrados en `appsettings.json`, hay otros fuentes de configuracion que pueden sobrescribir los valores en `appsettings.{environment}.json`. El orden de carga de estas fuentes de configuracion es el siguiente:

- appsettings.json
- appsettings.{environment}.json
- User secrets
- Environment variables

Esto quiere decir que si todas las fuentes configuran las mismas variables, el unico valor que se tendra sera el de `environment variables`.

Este orden y las fuentes de configuracion pueden ser modificadas en caso que se requiera.

En este archivo podemos encontrar lo siguiente:
```C#
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
- **Logging**: Define el nivel de logueo para diferentes componentes de la aplicacion

- **AllowedHosts**: Especifica los hosts que la aplicacion va a estar escuchando


## Buenas practicas

- **Evitar credenciales hard-coded**: No se deberia guardar informacion sensible directamente en el codigo ni en estos archivos si no son ignorados.

- **Usar configuraciones especificas de ambiente**: Se debe hacer uso de `appsettings.{environment}.json` para sobrescribir y especificar valores acorde al ambiente.

- **Control de version**: Si `appsettings.json` es incluido en el control de version del codigo, respetar la primera practica.
