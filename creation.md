# Creacion de servicio y repositorio

En esta parte vamos a crear un servicio junto con su repositorio para consumir los tipos de peliculas disponibles a desplegar en el componente `movie-type-dropdown`.

Para ello debemos crear las carpetas restantes de la organizacion ya vista, `services`, `services/models` y `repositories`.

Creacion de la carpeta `services` y `services/models`

```CMD
cd src
mkdir services
cd services
mkdir models
```

Creacion de la carpeta `repositories`

```CMD
cd src
mkdir repositories
```

## Creacion del repositorio

La carpeta de `repositories` sera la capa mas baja de nuestra aplicacion de Angular. Esta podria consumir la data desde una API Web como podria consumir la data en memoria. Lo importante es que los servicios no deben enterarse de donde proviene la data para limitar el impacto de cambio.

Para crear un repositorio procedemos a situarnos en el directorio:

```CMD
cd src
cd repositories
```

Y ejecutamos el siguiente comando de Angular CLI:

```CMD
ng generate service
```

