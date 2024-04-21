# Instalar paquete para migraciones por comandos

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

## Microsoft.EntityFrameworkCore.Design

- Agregar referencia a `Microsoft.EntityFrameworkCore.Design`

```
dotnet add package Microsoft.EntityFrameworkCore.Design
```

Comandos

- `add`: operacion de agregar
- `package`: paquete de `nuget.org`
- `Microsoft.EntityFrameworkCore.Design`: nombre de paquete

<p align="center">
<img src="./images/image-19.png"/>
</p>

<p align="center">
[Agregar Microsoft.EntityFrameworkCore.Design]
</p>

- Chequear que se agrego `Microsoft.EntityFrameworkCore.Design`. Hacer doble click en `Vidly.WebApi.csproj`
<p align="center">
<img src="./images/image-20.png"/>
</p>

<p align="center">
[Chequear Microsoft.EntityFrameworkCore.Design]
</p>

<!-- ## Microsoft.EntityFrameworkCore.Tools

- Agregar referencia a `Microsoft.EntityFrameworkCore.Tools`

```
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

Comandos

- `add`: operacion de agregar
- `package`: paquete de `nuget.org`
- `Microsoft.EntityFrameworkCore.Tools`: nombre de paquete

<p align="center">
<img src="./images/image-21.png"/>
</p>

<p align="center">
[Agregar Microsoft.EntityFrameworkCore.Tools]
</p>

- Chequear que se agrego `Microsoft.EntityFrameworkCore.Tools`. Hacer doble click en `Vidly.WebApi.csproj`
<p align="center">
<img src="./images/image-22.png"/>
</p>

<p align="center">
[Chequear Microsoft.EntityFrameworkCore.Tools]
</p> -->