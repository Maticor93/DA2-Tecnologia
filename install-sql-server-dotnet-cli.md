# Instalar paquete de sql por comandos

- Abrir terminal en el directorio de la solucion. Para saber si estamos bien situados ejecutar `ls` y se deberia de ver el archivo `.sln`

```
ls
```

Comandos:

- `ls`: lista elementos en un directorio
<p align="center">
<img src="./images/image-13.png"/>
</p>

<p align="center">
[Terminal en directorio]
</p>

- Entrar al directorio del proyecto de web api.

```
cd Vidly.WebApi
```

Comandos:

- `cd`: entrar a un directorio

<p align="center">
<img src="./images/image-14.png"/>
</p>

<p align="center">
[Entrar a directorio]
</p>

- Agregar referencia a `Microsoft.EntityFrameworkCore.SqlServer`

```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

Comandos

- `add`: operacion de agregar
- `package`: paquete de `nuget.org`
- `Microsoft.EntityFrameworkCore.SqlServer`: nombre de paquete

<p align="center">
<img src="./images/image-17.png"/>
</p>

<p align="center">
[Agregar Microsoft.EntityFrameworkCore.SqlServer]
</p>

- Chequear que se agrego `Microsoft.EntityFrameworkCore.SqlServer`. Hacer doble click en `Vidly.WebApi.csproj`
<p align="center">
<img src="./images/image-18.png"/>
</p>

<p align="center">
[Chequear Microsoft.EntityFrameworkCore.SqlServer]
</p>